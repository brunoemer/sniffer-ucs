using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MJsniffer;



namespace SnifferRedes2
{
    public partial class UserControlDiagrama : UserControl
    {
        private IPHeader IPData;
        private TCPHeader TCPData;
        private UDPHeader UDPData;

        public UserControlDiagrama()
        {
            InitializeComponent();
            

        }

        public void ClearConnectionData()
        {
            labelIPEsquerda.Text = "";
            labellabelIPDireita.Text = "";
            panel1.Controls.Clear();
        }

        public void AdicionaFrameTCP(IPHeader iph)
        {
            IPData = iph;

            switch (iph.ProtocolType)
            {
                case Protocol.TCP:
                    
                    TCPData = new TCPHeader(IPData.Data, IPData.MessageLength);
                    if (labelIPEsquerda.Text == "")
                    {
                        labelIPEsquerda.Text = IPData.SourceAddress + ":" + TCPData.SourcePort;
                        labellabelIPDireita.Text = IPData.DestinationAddress + ":" + TCPData.DestinationPort;
                    }

                    //FrameTCP.Flags = "SYN";
                    UserControlFrame u = new UserControlFrame(TCPData,iph.ListIndex);
                    u.Location = new Point(0, panel1.Controls.Count * u.Height);
                    ToolTip t = new ToolTip();
                    t.SetToolTip(u, "Ola, este é o dado Recebido...");
                    panel1.Controls.Add(u);

                    if (labelIPEsquerda.Text == IPData.SourceAddress + ":" + TCPData.SourcePort)
                    {
                        u.SetDirection(0);
                    }
                    else
                    {
                        u.SetDirection(1);
                    }
                    break;
                case Protocol.UDP:

                    break;
                case Protocol.Unknown:
                    break;
                default:
                    break;
            }


        }


        


    }
}
