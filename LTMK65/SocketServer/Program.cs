using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace SocketServer
{
    class Program
    {
        
        static void Main(string[] args)
        {
            List<Message> dstn = new List<Message>();
            // Khoi tao socket de lang nghe
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ep = new IPEndPoint(IPAddress.Any, 12100);
            listener.Bind(ep);

            // Bat dau lang nghe
            listener.Listen(100);
            Console.WriteLine("Bat dau lang nghe ...");
            // Lap lai viec tiep nhan ket noi tu client va xu ly yeu cau cua client
            while(true)
            {
                // Khoi tao mot socket de tiep nhan ket noi tu client
                Socket handler = listener.Accept();
                if(handler != null)
                {
                    // Cau truc tin nhan: NguoiGui<|tach|>NguoiNhan<|tach|>NoiDung<|EOM|>
                    Message msg = new Message();
                    Console.WriteLine("Tiep nhan ket noi Client");
                    // Khai bao bo dem de tiep nhan du lieu
                    String message = "";

                    // Nhan du lieu cho den khi nao ket thuc tin nhan tu client
                    while (true)
                    {
                        byte[] buffer = new byte[1024];
                        int count = handler.Receive(buffer);
                        message += Encoding.UTF8.GetString(buffer, 0, count);
                        if (message.IndexOf("<|EOM|>") > -1)
                        {
                            message = message.Replace("<|EOM|>", "");
                            message = message.Replace("<|TACH|>", "`");
                            if (message.Split('`').Length == 3)
                            {
                                msg.NguoiGui = message.Split('`')[0];
                                msg.NguoiNhan = message.Split('`')[1];
                                msg.NoiDung = message.Split('`')[2];
                                msg.TrangThai = "Đã gửi";
                                dstn.Add(msg);

                                Console.WriteLine(DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy") + ": " + msg.NguoiGui + "-->" + msg.NguoiNhan + ":: " + msg.NoiDung);
                                // Da ket thuc tin nhan, server se phan hoi lai cho client
                                String respose = "Da nhan " + message.Length + " bytes<|EOM|>";
                                byte[] responeByte = Encoding.UTF8.GetBytes(respose);
                                handler.Send(responeByte);
                                break;
                            }
                            else if(message.Split('`').Length == 2)
                            {
                                // Day la client hoi server
                                String nguoiNhan = message.Split('`')[0];
                                List<Message> dsChuaNhan = dstn.Where(x => x.NguoiNhan.Equals(nguoiNhan) && x.TrangThai.Equals("Đã gửi")).ToList();
                                if(dsChuaNhan != null && dsChuaNhan.Count > 0)
                                {
                                    Message newMsg = dsChuaNhan[0];
                                    String respose = newMsg.NguoiGui + "<|TACH|>" + newMsg.NoiDung + "<|EOM|>";
                                    byte[] responeByte = Encoding.UTF8.GetBytes(respose);
                                    handler.Send(responeByte);

                                    for(int i = 0; i < dstn.Count; i++)
                                    {
                                        if (dstn[i].ID.Equals(newMsg.ID))
                                        {
                                            dstn[i].TrangThai = "Đã nhận";
                                            break;
                                        }
                                    }    
                                    break;
                                }
                                else
                                {
                                    String respose = "<|TACH|><|EOM|>";
                                    byte[] responeByte = Encoding.UTF8.GetBytes(respose);
                                    handler.Send(responeByte);
                                    break;
                                }    
                            }    
                            
                        }
                    }
                }    
                   
            }    
        }
    }
}
