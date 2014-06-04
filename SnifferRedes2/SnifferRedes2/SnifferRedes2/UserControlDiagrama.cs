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
        public UserControlDiagrama()
        {
            InitializeComponent();
        }

        public void AdicionaFrameTCP(TCPHeader FrameTCP)
        {
            
            //FrameTCP.Flags = "SYN";
            UserControlFrame u = new UserControlFrame(FrameTCP);
            u.Location = new Point(0, panel1.Controls.Count * u.Height);
            ToolTip t = new ToolTip();
            t.SetToolTip(u, "Ola, este é o dado Recebido...");
            panel1.Controls.Add(u);
        }
    }
}
