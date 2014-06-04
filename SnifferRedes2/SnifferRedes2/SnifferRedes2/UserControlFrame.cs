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
    public partial class UserControlFrame : UserControl
    {
        public UserControlFrame(TCPHeader FrameTCP)
        {
            InitializeComponent();
            label1.Text = FrameTCP.Flags;
        }
    }
}
