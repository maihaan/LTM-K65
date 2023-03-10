using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace UDPServer
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient udp = new UdpClient(12100);
            while(true)
            {
                String message = "";
                IPEndPoint ep = new IPEndPoint(IPAddress.Any, 12100);
                byte[] buffer = udp.Receive(ref ep);
                while(buffer != null && buffer.Length > 0)
                {
                    message += Encoding.UTF8.GetString(buffer, 0, buffer.Length);
                    if (message.IndexOf("<|EOM|>") > 0)
                        break;
                    buffer = udp.Receive(ref ep);
                }
                if (!String.IsNullOrEmpty(message))
                {
                    Console.WriteLine(DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy")
                        + ": " + message);
                }
            }    
        }
    }
}
