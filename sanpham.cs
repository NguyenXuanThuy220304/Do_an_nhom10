using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_an_P10
{
    public class sanpham
    {
        public int MaSP { get; set; }                    // ✅ Thêm dòng này
        public string Tensanpham { get; set; }
        public string Kichthuoc { get; set; }
        public string Mausac { get; set;}
        public decimal Dongia { get; set; }
        public int Soluong { get; set; }
        public Image Hinhanh { get; set; }
        public int SoLuongTon { get; set; }

        public sanpham() { }

        public sanpham(int maSP, string tensanpham,  decimal dongia, int soluong, Image hinhanh, string kichthuoc, string mausac)
        {
            this.MaSP = maSP;   
            this.Tensanpham = tensanpham;
            this.Dongia = dongia;
            this.Soluong = soluong;
            this.Hinhanh = hinhanh;
            Kichthuoc = kichthuoc;
            Mausac = mausac;
           
        }
    }
}
