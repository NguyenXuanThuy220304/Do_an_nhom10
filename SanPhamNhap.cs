using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_an_P10
{
    public class SanPhamNhap
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public int SoLuongNhap { get; set; }
        public decimal DonGiaNhap { get; set; }

        public decimal ThanhTien => SoLuongNhap * DonGiaNhap;
    }

}
