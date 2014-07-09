using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MJsniffer;
 
namespace SnifferRedes2
{
    public partial class FormUDPDetail : Form
    {
        public FormUDPDetail()
        {
            InitializeComponent();
        }

        public void SetData(IPHeader ip, UDPHeader udp)
        {
            label1FlagsIP.Text = ip.Flags;
            label1OffsetFragmIP.Text = ip.FragmentationOffset;
            labelCSIP.Text = ip.Checksum;
            labelCSUDP.Text = udp.Checksum;
            labelEndDestIP.Text = ip.DestinationAddress.ToString();
            labelEndOrgIP.Text = ip.SourceAddress.ToString();
            labelIDIP.Text = ip.Identification;
            labelIHLIP.Text = "???";
            labelPortaDestinoUDP.Text = udp.DestinationPort;
            labelPortaOrigmUDP.Text = udp.SourcePort;
            labelProtocolIP.Text = ip.ProtocolType.ToString();
            labelTamanhoTotalIP.Text = ip.TotalLength;
            labelTamanhoUDP.Text = udp.Length;
            labelTipoServicoIP.Text = "?";
            labelTTLIP.Text = ip.TTL;
            labelVersaoIP.Text = ip.Version;

        }
    }
}
