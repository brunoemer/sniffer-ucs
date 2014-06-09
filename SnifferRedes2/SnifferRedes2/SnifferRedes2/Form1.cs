﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MJsniffer;
using System.Net.Sockets;
using System.Net;

namespace SnifferRedes2
{
    public partial class Form1 : Form
    {
        private Socket mainSocket;                          //The socket which captures all incoming packets
        private byte[] byteData = new byte[4096];
        private bool bContinueCapturing = false;            //A flag to check if packets are to be captured or not

        private delegate void AddFrame(IPHeader f);
        List<IPHeader> ListaPacotesRecebidos = new List<IPHeader>();


        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void OnReceive(IAsyncResult ar)
        {
            try
            {
                int nReceived = mainSocket.EndReceive(ar);

                //Analyze the bytes received...

                ParseData(byteData, nReceived);

                if (bContinueCapturing)
                {
                    byteData = new byte[4096];

                    //Another call to BeginReceive so that we continue to receive the incoming
                    //packets
                    mainSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None,
                        new AsyncCallback(OnReceive), null);
                }
            }
            catch (ObjectDisposedException)
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MJsniffer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ParseData(byte[] byteData, int nReceived)
        {
            //Since all protocol packets are encapsulated in the IP datagram
            //so we start by parsing the IP header and see what protocol data
            //is being carried by it
            IPHeader ipHeader = new IPHeader(byteData, nReceived);
            ipHeader.ListIndex = ListaPacotesRecebidos.Count;
            ListaPacotesRecebidos.Add(ipHeader);

            AddFrame addFrame = new AddFrame(OnAddFrame);
            //Thread safe adding of the nodes
            panel1.Invoke(addFrame, new object[] { ipHeader });
        }



        int PacotesRecebidos = 0;
        private void OnAddFrame(IPHeader frame)
        {            
            PacotesRecebidos++;
            toolStripLabel1.Text = PacotesRecebidos + " pacotes";
        }

        private void ShowFrames()
        {
            panel1.Visible = false;
            panel1.Controls.Clear();
            for (int i = FirstFrame; (i < ListaPacotesRecebidos.Count && i < FirstFrame + 10); i++)
            {
                UserControlReceivedFrame u = new UserControlReceivedFrame(this);
                u.Location = new Point(0, panel1.Controls.Count * u.Height);
                u.SetIPData(ListaPacotesRecebidos[i]);
                panel1.Controls.Add(u);   
            }
            panel1.Visible = true;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            string strIP = null;

            IPHostEntry HosyEntry = Dns.GetHostEntry((Dns.GetHostName()));
            if (HosyEntry.AddressList.Length > 0)
            {
                foreach (IPAddress ip in HosyEntry.AddressList)
                {
                    strIP = ip.ToString();
                    toolStripComboBox1.Items.Add(strIP);
                }
            }  
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (toolStripComboBox1.Text == "")
            {
                MessageBox.Show("Selecione uma interface para capturar os pacotes.", "Redes II",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (!bContinueCapturing)
                {
                    //Start capturing the packets...
                    toolStripButton3.Visible = false;
                    toolStripButton1.Image = imageListBtnConnect.Images[1];

                    bContinueCapturing = true;

                    //For sniffing the socket to capture the packets has to be a raw socket, with the
                    //address family being of type internetwork, and protocol being IP
                    mainSocket = new Socket(AddressFamily.InterNetwork,
                        SocketType.Raw, ProtocolType.IP);

                    //Bind the socket to the selected IP address
                    mainSocket.Bind(new IPEndPoint(IPAddress.Parse(toolStripComboBox1.Text), 0));

                    //Set the socket  options
                    mainSocket.SetSocketOption(SocketOptionLevel.IP,            //Applies only to IP packets
                                               SocketOptionName.HeaderIncluded, //Set the include the header
                                               true);                           //option to true

                    byte[] byTrue = new byte[4] { 1, 0, 0, 0 };
                    byte[] byOut = new byte[4] { 1, 0, 0, 0 }; //Capture outgoing packets

                    //Socket.IOControl is analogous to the WSAIoctl method of Winsock 2
                    mainSocket.IOControl(IOControlCode.ReceiveAll,              //Equivalent to SIO_RCVALL constant
                        //of Winsock 2
                                         byTrue,
                                         byOut);

                    //Start receiving the packets asynchronously
                    mainSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None,
                        new AsyncCallback(OnReceive), null);
                }
                else
                {
                    if (PacotesRecebidos > 0)
                    {
                        toolStripButton3.Visible = true;
                    }
                    toolStripButton1.Image = imageListBtnConnect.Images[0];
                    bContinueCapturing = false;
                    //To stop capturing the packets close the socket
                    mainSocket.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MJsniffer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ListaPacotesRecebidos.Clear();
            panel1.Controls.Clear();
            toolStripLabel1.Text = "0 pacotes";
            panel1.Visible = false;
            PacotesRecebidos = 0;
            toolStripButton3.Visible = false;
            userControlDiagrama1.Visible = false;
            userControlDiagrama1.ClearConnectionData();
        }

        private void treeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode node = e.Node;
            MessageBox.Show(node.ToString());
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            FirstFrame = 0;
            ShowFrames();
        }
        int FirstFrame = 0;

        public void FindConnectionPacks(IPHeader InitialPack)
        {
            if (InitialPack.ProtocolType == Protocol.TCP)
            {                 
                userControlDiagrama1.ClearConnectionData();
                TCPHeader th1 = new TCPHeader(InitialPack.Data, InitialPack.MessageLength);
                string SourceSockIni = InitialPack.SourceAddress.ToString() + ":" + th1.SourcePort;
                string DestinSockIni = InitialPack.DestinationAddress.ToString() + ":" + th1.DestinationPort;

                for (int i = 0; i < ListaPacotesRecebidos.Count; i++)
                {
                    if (ListaPacotesRecebidos[i].ProtocolType == Protocol.TCP)
                    {
                        TCPHeader th2 = new TCPHeader(ListaPacotesRecebidos[i].Data, ListaPacotesRecebidos[i].MessageLength);
                        string SourceSock = ListaPacotesRecebidos[i].SourceAddress.ToString() + ":" + th2.SourcePort;
                        string DestinSock = ListaPacotesRecebidos[i].DestinationAddress.ToString() + ":" + th2.DestinationPort;

                        if ((SourceSock == SourceSockIni && DestinSock == DestinSockIni) ||
                            SourceSock == DestinSockIni && DestinSock == SourceSockIni)
                        {
                            userControlDiagrama1.AdicionaFrameTCP(ListaPacotesRecebidos[i]);                        
                        }
                    }
                }
                userControlDiagrama1.Visible = true;
            }
            else if (InitialPack.ProtocolType == Protocol.UDP)
            {
                MessageBox.Show("O protocolo UDP não é orientado a conexão!");
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (FirstFrame < ListaPacotesRecebidos.Count)
            {
                FirstFrame += 10;
            }
            ShowFrames();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (FirstFrame > 10)
            {
                FirstFrame -= 10;
            }
            else
            {
                FirstFrame = 0;
            }
            ShowFrames();
        }


    }
}
