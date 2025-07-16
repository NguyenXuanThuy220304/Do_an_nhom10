using Do_an_P10;

public class GioHangData
{
    private static GioHangData instance;
    public static GioHangData Instance
    {
        get
        {
            if (instance == null)
                instance = new GioHangData();
            return instance;
        }
    }

    public List<Giohang> DanhSachSanPham { get; private set; }

    private GioHangData()
    {
        DanhSachSanPham = new List<Giohang>();
    }

    public void ThemSanPham(Giohang item)
    {
        var spTonTai = DanhSachSanPham.FirstOrDefault(x => x.MaSP == item.MaSP);
        if (spTonTai != null)
        {
            spTonTai.SoLuong += item.SoLuong;
        }
        else
        {
            DanhSachSanPham.Add(item);
        }
    }

    public void XoaTatCa()
    {
        DanhSachSanPham.Clear();
    }

    public decimal TongTien()
    {
        return DanhSachSanPham.Sum(x => x.ThanhTien);
    }
}
