using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServer
{
    public class Message
    {
        public String ID { get; }
        public String NguoiGui { get; set; }
        public String NguoiNhan { get; set; }
        public String NoiDung { get; set; }
        public DateTime ThoiGian { get; set; }
        public String TrangThai { get; set; }
        public Message()
        {
            ID = DateTime.Now.Ticks.ToString();
        }
    }
}
