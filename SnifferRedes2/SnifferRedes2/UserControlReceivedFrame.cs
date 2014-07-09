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
    public partial class UserControlReceivedFrame : UserControl
    {
        private IPHeader IPData;
        private TCPHeader TCPData;
        private UDPHeader UDPData;
        private string SourceAdd = "";
        private string DestAdd = "";
        private string SourcePort = "";
        private string DestPort = "";

  private Form1 _f;
        public UserControlReceivedFrame(Form1 f)
        {
            InitializeComponent();

            _f = f;
        }

        public void SetIPData(IPHeader iph)
        {
            IPData = iph;
            SourceAdd = IPData.SourceAddress.ToString();
            DestAdd = IPData.DestinationAddress.ToString();
            labelIndex.Text = iph.ListIndex.ToString();

            switch (iph.ProtocolType)
            {
                case Protocol.TCP:
                    labelProtocol.Text = "TCP";
                    TCPData = new TCPHeader(IPData.Data, IPData.MessageLength);
                    SourcePort = TCPData.SourcePort;
                    DestPort = TCPData.DestinationPort;
                    //If the port is equal to 53 then the underlying protocol is DNS
                    //Note: DNS can use either TCP or UDP thats why the check is done twice
                    if (TCPData.DestinationPort == "53" || TCPData.SourcePort == "53")
                    {
                        //TreeNode dnsNode = MakeDNSTreeNode(tcpHeader.Data, (int)tcpHeader.MessageLength);                       
                    }
                    break;
                case Protocol.UDP:
                    labelProtocol.Text = "UDP";
                    UDPData = new UDPHeader(IPData.Data, (int)IPData.MessageLength);
                    SourcePort = UDPData.SourcePort;
                    DestPort = UDPData.DestinationPort;
                    //If the port is equal to 53 then the underlying protocol is DNS
                    //Note: DNS can use either TCP or UDP thats why the check is done twice
                    if (UDPData.DestinationPort == "53" || UDPData.SourcePort == "53")
                    {

                        //TreeNode dnsNode = MakeDNSTreeNode(udpHeader.Data, Convert.ToInt32(udpHeader.Length) - 8);
                    }
                    break;
                case Protocol.Unknown:
                    break;
                default:
                    break;
            }
            labelSource.Text = SourceAdd + ":" + SourcePort;
            labelDestination.Text = DestAdd + ":" + DestPort;

        }



        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "Ver Frame")
            {
                if (IPData.ProtocolType == Protocol.UDP)
                {
                    FormUDPDetail f = new FormUDPDetail();
                    f.SetData(IPData, UDPData);
                    f.Show();
                }
                else if (IPData.ProtocolType == Protocol.TCP)
                {
                    FormTCPDetail f = new FormTCPDetail();
                    f.SetData(IPData, TCPData);
                    f.Show();
                }
            }
            else
            {
                _f.FindConnectionPacks(IPData);
            }

        }
    }
}
