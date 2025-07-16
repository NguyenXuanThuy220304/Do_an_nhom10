using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_an_P10
{
    public class khachhang
    {
        public int MaKH { get; set; }
        public string Hoten { get; set; }
        public string SDT { get; set; }
        public string Diachi { get; set; }
        public string Email { get; set; }
        public string Tentaikhoan { get; set; }

        public khachhang() { }

        public khachhang(int makh, string hoten, string sdt, string diachi, string email, string tentaikhoan)
        {
            MaKH = makh;
            Hoten = hoten;
            SDT = sdt;
            Diachi = diachi;
            Email = email;
            Tentaikhoan = tentaikhoan;
        }
    }

}
