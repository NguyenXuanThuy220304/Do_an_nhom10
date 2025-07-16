using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_an_P10
{
    public class donhang
    {
        public int MaDH { get; set; }           // Sẽ nhận sau khi thêm
        public DateTime NgayLap { get; set; }
        public int MaKH { get; set; }
        public decimal TongTien { get; set; }

        public donhang(DateTime ngayLap, int maKH, decimal tongTien)
        {
            NgayLap = ngayLap;
            MaKH = maKH;
            TongTien = tongTien;
        }
    }

}
