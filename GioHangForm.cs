using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Do_an_P10
{
    public partial class GioHangForm : Form
    {
        private string tentk;
        public GioHangForm(string tentk)
        {
            InitializeComponent();
            this.tentk = tentk;
            LoadGioHang();
        }
        private void HienThiThongTinKhachHang()
        {
            DataRow row = Modify.LayThongTinKhachHang(tentk);
            if (row != null)
            {
                txtHoTen.Text = row["Hoten"].ToString();
                txtSDT.Text = row["SDT"].ToString();
                txtDiaChi.Text = row["Diachi"].ToString();
                txtEmail.Text = row["Email"].ToString();
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void LoadGioHang()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = GioHangData.Instance.DanhSachSanPham;

            HienThiThongTinKhachHang();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EcoStraws eco = new EcoStraws(tentk);
            eco.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }



        private void GioHangForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            var danhSachSanPham = GioHangData.Instance.DanhSachSanPham;
            if (danhSachSanPham.Count == 0)
            {
                MessageBox.Show("Giỏ hàng đang trống!");
                return;
            }

            int maKH = Modify.LayMaKhachHang(tentk); // Lấy mã khách từ tài khoản đăng nhập
            DateTime ngayLap = DateTime.Now;
            decimal tongTien = GioHangData.Instance.TongTien();

            // Thêm đơn hàng mới và lấy mã đơn hàng vừa tạo
            int maDonHang = Modify.ThemDonHangVaLayMa(ngayLap, maKH, tongTien);

            // Thêm chi tiết đơn hàng
            foreach (var sp in danhSachSanPham)
            {
                Modify.ThemChiTietDonHang(maDonHang, sp.MaSP,sp.TenSanPham, sp.SoLuong, sp.DonGia);
            }

            MessageBox.Show("Đặt hàng thành công!");

            // Xóa giỏ hàng sau khi đặt
            GioHangData.Instance.XoaTatCa();

            // Mở form hóa đơn và truyền mã đơn hàng và mã khách
            HoaDon hoaDonForm = new HoaDon(maDonHang, maKH, tentk);
            hoaDonForm.Show();
            this.Hide();
        }
    }
}
