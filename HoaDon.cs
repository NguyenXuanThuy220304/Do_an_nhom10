using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Do_an_P10
{
    public partial class HoaDon : Form
    {
        private int maKH;
        private int maDH;
        private string tentk;
        public HoaDon(int maDH, int maKH, string tentk)
        {
            InitializeComponent();
            this.maKH = maKH;
            this.maDH = maDH;
            this.tentk = tentk;
            LoadHoaDon();
        }
        private void LoadHoaDon()
        {
            var dtDonHang = Modify.LayDonHang(maDH);
            var dtChiTiet = Modify.LayChiTietDonHang(maDH);
            var dtKhachHang = Modify.LayThongTinKhachHang(maKH);

            if (dtDonHang.Rows.Count > 0)
            {
                var rowDH = dtDonHang.Rows[0];
                mak.Text = rowDH["MaKH"].ToString();
                mad.Text = rowDH["MaDH"].ToString();
                date.Text = Convert.ToDateTime(rowDH["NgayLap"]).ToString("dd/MM/yyyy");
                thanht.Text = string.Format("{0:N0} đ", rowDH["TongTien"]);
                trangt.Text = rowDH["TrangThai"].ToString();
            }

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void xuat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string scanned = lbnhapma.Text.Trim();
            if (scanned == currentCode)
            {
                Modify.CapNhatTrangThaiDonHang(maDH, "Đã thanh toán");

                MessageBox.Show("Hóa đơn đã được xuất và cập nhật trạng thái thành 'Đã thanh toán'.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Lấy danh sách sản phẩm trong đơn hàng
                var dtChiTiet = Modify.LayChiTietDonHang(maDH);
                foreach (DataRow row in dtChiTiet.Rows)
                {
                    int maSP = Convert.ToInt32(row["MaSP"]);
                    int soLuongMua = Convert.ToInt32(row["SoLuong"]);

                    // Trừ số lượng trong kho
                    Modify.TruSoLuongSanPham(maSP, soLuongMua);
                    Modify.GhiLichSuKho(maSP, -soLuongMua, "Xuất bán", $"Đơn hàng: {maDH}");
                }
                // Làm mới giao diện
                LoadHoaDon();
                EcoStraws eco = new EcoStraws(tentk);
                eco.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Mã bạn nhập không đúng vui lòng nhập lại!");
            }
        }
        private string GenerateRandomCode()
        {
            Random rnd = new Random();
            int number = rnd.Next(100000, 999999); // 6 chữ số
            return number.ToString(); // ví dụ: 548293
        }
        string currentCode = ""; // biến lưu mã hiện tại (có thể đặt global)

      

        private void HoaDon_Load(object sender, EventArgs e)
        {
            try
            {
                currentCode = GenerateRandomCode(); // tạo mã mới mỗi lần

                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(currentCode, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(20, Color.Black, Color.White, true);

                Qrcode.Image = qrCodeImage;
             //   lblQRText.Text = "Mã sinh: " + currentCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo mã QR: " + ex.Message);
            }
        }
    }
}

