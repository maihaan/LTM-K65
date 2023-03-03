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

namespace SocketClient
{
    public partial class Form1 : Form
    {
        Timer tm = new Timer();
        public Form1()
        {
            InitializeComponent();
            tm.Interval = 3000;
            tm.Tick += Tm_Tick;
            
        }

        private void Tm_Tick(object sender, EventArgs e)
        {
            if (ccbNguoiGui.SelectedItem != null && ccbNguoiNhan.SelectedItem != null)
            {
                String nguoiNhan = ccbNguoiGui.SelectedItem.ToString();

                // Tao socket de gui tin nhan
                Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12100);


                // Gui tin nhan
                byte[] messageByte = Encoding.UTF8.GetBytes(nguoiNhan + "<|TACH|>?<|EOM|>");
                client.Connect(ep);
                if (!client.Connected)
                {
                    return;
                }
                client.Send(messageByte);

                // Nhan du lieu phan hoi tu server
                String message = "";

                // Nhan du lieu cho den khi nao ket thuc tin nhan tu server
                byte[] buffer = new byte[1024];
                int count = 0;
                while ((count = client.Receive(buffer)) > 0)
                {
                    message += Encoding.UTF8.GetString(buffer, 0, count);
                    if (message.IndexOf("<|EOM|>") > -1)
                    {
                        message = message.Replace("<|EOM|>", "").Replace("<|TACH|>", "`");
                        String nguoiGui = message.Split('`')[0];
                        String noiDung = message.Split('`')[1];
                        if(!String.IsNullOrEmpty(noiDung))
                            tbLog.Text += DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy") + nguoiGui + ": " + noiDung + "\r\n";
                        break;
                    }
                }
            }
        }

        private void btSend_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(tbMessage.Text))
            {
                tbMessage.Focus();
                return;
            }    

            // Tao socket de gui tin nhan
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12100);


            // Gui tin nhan
            String msg = ccbNguoiGui.Text + "<|TACH|>" + ccbNguoiNhan.Text + "<|TACH|>" + tbMessage.Text + "<|EOM|>";
            byte[] messageByte = Encoding.UTF8.GetBytes(msg);
            client.Connect(ep);
            if(!client.Connected)
            {
                MessageBox.Show("Không kết nối được máy chủ!");
                return;
            }    
            client.Send(messageByte);

            // Nhan du lieu phan hoi tu server
            String message = "";

            // Nhan du lieu cho den khi nao ket thuc tin nhan tu server
            byte[] buffer = new byte[1024];
            int count = 0;
            while ((count = client.Receive(buffer)) > 0)
            {
                message += Encoding.UTF8.GetString(buffer, 0, count);
                if (message.IndexOf("<|EOM|>") > -1)
                {
                    tbLog.Text += DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy") + "Client: " + tbMessage.Text + "\r\n";
                    tbLog.Text += DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy") + "Server: " + message + "\r\n";
                    tbMessage.Text = "";
                    tbMessage.Focus();
                    break;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tm.Start();
        }
    }
}
