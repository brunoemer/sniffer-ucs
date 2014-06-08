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
        public UserControlFrame(TCPHeader FrameTCP, int index)
        {
            InitializeComponent();
            label1.Text = FrameTCP.Flags;
            labelIndex.Text = index.ToString();
            string data = Encoding.UTF8.GetString(FrameTCP.Data);
            data = data.Replace('\0', ' ');
            data = data.Trim();
            if (data.Length > 0)
            {
                toolTip1.SetToolTip(pictureBox2, data);
                pictureBox2.Visible = true;
            }
            else
            {
                pictureBox2.Visible = false;
            }
        }

        public void SetDirection(int dir)
        {
            
            if (dir < 2)
            {
                pictureBox1.Image = imageList1.Images[dir];
            }
        }
    }
}
