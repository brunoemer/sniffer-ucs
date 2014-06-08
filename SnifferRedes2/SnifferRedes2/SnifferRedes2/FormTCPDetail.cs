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
    public partial class FormTCPDetail : Form
    {
        public FormTCPDetail()
        {
            InitializeComponent();

        }

        public void SetData(IPHeader ip, TCPHeader tcp)
        {
            label1FlagsIP.Text = ip.Flags;
            label1OffsetFragmIP.Text = ip.FragmentationOffset;
            labelCSIP.Text = ip.Checksum;
            labelCSTCP.Text = tcp.Checksum;
            labelEndDestIP.Text = ip.DestinationAddress.ToString();
            labelEndOrgIP.Text = ip.SourceAddress.ToString();
            labelIDIP.Text = ip.Identification;
            labelIHLIP.Text = "???";
            labelFlagsTCP.Text = tcp.Flags;
            labelJanelaTCP.Text = tcp.WindowSize;
            labelNroConfirmTCP.Text = tcp.AcknowledgementNumber;
            labelNroSeqTCP.Text = tcp.SequenceNumber;
            labelOffsetTCP.Text = "??";
            labelPonteiroTCP.Text = tcp.UrgentPointer;
            labelPortaDestinoTCP.Text = tcp.DestinationPort;
            labelPortaOrigmTCP.Text = tcp.SourcePort;
            labelProtocolIP.Text = ip.ProtocolType.ToString();
            labelTamanhoTotalIP.Text = ip.TotalLength;
            labelResTCP.Text = "-";
            labelTipoServicoIP.Text = "?";

            labelTTLIP.Text = ip.TTL;
            labelVersaoIP.Text = ip.Version;

        }

    }
}
