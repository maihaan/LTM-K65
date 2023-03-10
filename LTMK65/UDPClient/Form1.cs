using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace UDPClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btSend_Click(object sender, EventArgs e)
        {
            if(tbMessage.Text.Length  == 0)
            {
                return;
            }
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12100);
            UdpClient udp = new UdpClient();
            byte[] msg = Encoding.UTF8.GetBytes(tbMessage.Text + "<|EOM|>");           
            udp.Send(msg, msg.Length, ep);
            
            tbLog.Text += DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy") + ": "
                + tbMessage.Text + "\r\n";
            tbMessage.Text = "";
            tbMessage.Focus();
            udp.Close();
        }

        private void tbMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btSend_Click(sender, e);
        }
    }
}
