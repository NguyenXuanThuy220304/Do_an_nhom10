using ClosedXML.Excel;
using Do_an_P10;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Do_an_P10
{
    public partial class QL_EcoStraws : Form
    {
        public QL_EcoStraws()
        {
            InitializeComponent();

        }
        Modify modify = new Modify();

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        private void QL_EcoStraws_Load(object sender, EventArgs e)
        {
            loaddata(); // Gọi hàm tải dữ liệu khi mở form
            LoadKhachHang_DH();
            LoadSanPham_DH();
            LoadTrangThai();
            dgvDonHang.CellClick += dgvDonHang_CellClick;
            cbSanPham.SelectedIndexChanged += cbSanPham_SelectedIndexChanged;
            panelKhachHang.Visible = false;
            panelLichSuKho.Visible = false;
            panelDonhang.Visible = false;
            panelDaiLy.Visible = false;
            sanp.Visible = false;
            InitPhieuNhapMoi();
            LoadSanPham();
        }

        List<sanpham> allProducts = new List<sanpham>();
        private void sp_Click(object sender, EventArgs e)
        {
            // Toggle panel sản phẩm
            sanp.Visible = !sanp.Visible;

            // Nếu đang mở sản phẩm thì tắt các panel khác
            if (sanp.Visible)
            {
                panelKhachHang.Visible = false;
                panelLichSuKho.Visible = false;
                panelDonhang.Visible = false;
                panelDaiLy.Visible = false;
                loaddata();
            }
        }
        private void k_Click(object sender, EventArgs e)
        {
            panelkho.Visible = !panelkho.Visible;
        }
        private void loaddata()
        {
            string query = "Select * from sanpham";
            datasp.DataSource = modify.GetDataTable(query);
        }
        List<sanpham> ds = new List<sanpham>();
        bool dangThemSanPham = false;
        private void loadKhachHang()
        {
            string query = "SELECT * FROM khachhang";
            dGVKhachHang.DataSource = modify.GetDataTable(query);
        }
        List<khachhang> dskh = new List<khachhang>();
        private void LoadKhachHang_DH()
        {
            string query = "SELECT MaKH, Hoten FROM khachhang";
            DataTable dt = modify.GetDataTable(query);
            cbKhachHang.DataSource = dt;
            cbKhachHang.DisplayMember = "Hoten";
            cbKhachHang.ValueMember = "MaKH";
        }

        private void LoadSanPham_DH()
        {
            allProducts = modify.sp("SELECT * FROM sanpham");

            var distinctNames = allProducts
                .Select(sp => sp.Tensanpham)
                .Distinct()
                .ToList();

            cbSanPham.DataSource = distinctNames;
            // cbSanPham không cần ValueMember vì chỉ chứa chuỗi tên
        }
        private void LoadTrangThai()
        {
            cbTrangThai.Items.Clear();
            cbTrangThai.Items.Add("Chờ xử lý");
            cbTrangThai.Items.Add("Chưa Thanh Toán");
            cbTrangThai.Items.Add("Đã Thanh Toán");
            cbTrangThai.SelectedIndex = 0;
        }
        private void loadDonHang()
        {
            string query = @"
                SELECT dh.MaDH, kh.Hoten, dh.NgayLap, dh.TongTien, dh.TrangThai
                FROM DonHang dh
                JOIN khachhang kh ON dh.MaKH = kh.MaKH
                ORDER BY dh.MaDH DESC";
            dgvDonHang.DataSource = modify.GetDataTable(query);
        }
        List<ChiTietGioHang> gioHang = new List<ChiTietGioHang>();
        bool dangThemKhachHang = false; // Cờ xác định đang trong chế độ thêm
        private void LoadDaiLy()
        {
            string query = "SELECT * FROM daily"; // Lấy tất cả cột, hoặc chỉ chọn các cột cần thiết
            DataTable dt = modify.GetDataTable(query);
            dgvDaiLy.DataSource = dt;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(msp.Text, out int masp))
            {
                MessageBox.Show("Mã sản phẩm không hợp lệ!");
                return;
            }

            if (string.IsNullOrWhiteSpace(t.Text) || string.IsNullOrWhiteSpace(g.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên sản phẩm và giá.");
                return;
            }

            if (!decimal.TryParse(g.Text, out decimal gia))
            {
                MessageBox.Show("Giá không hợp lệ!");
                return;
            }

            if (ds.Any(sp => sp.MaSP == masp))
            {
                MessageBox.Show("Mã sản phẩm đã tồn tại trong danh sách tạm!");
                return;
            }

            if (!int.TryParse(txtSLTon.Text, out int soLuongTon))
            {
                MessageBox.Show("Số lượng tồn không hợp lệ!");
                return;
            }

            sanpham sp = new sanpham
            {
                MaSP = masp,
                Tensanpham = t.Text,
                Kichthuoc = kt.Text,
                Mausac = m.Text,
                Dongia = gia,
                SoLuongTon = soLuongTon  // Thêm dòng này
            };

            ds.Add(sp);
            datasp.DataSource = null;
            datasp.DataSource = ds;

            dangThemSanPham = true;

            ClearSanPhamForm();
        }
        private void btnluu_Click(object sender, EventArgs e)
        {
            if (ds.Count == 0)
            {
                MessageBox.Show("Không có sản phẩm nào để lưu.");
                return;
            }

            int demThanhCong = 0;
            foreach (var sp in ds)
            {
                bool thanhCong = modify.ThemSanPham(sp); // Sửa phương thức này cho phù hợp
                if (thanhCong)
                    demThanhCong++;
            }

            MessageBox.Show($"Đã lưu {demThanhCong} sản phẩm vào cơ sở dữ liệu.");

            ds.Clear();
            dangThemSanPham = false;

            datasp.DataSource = null;
            loaddata(); // Load từ CSDL

        }
        private void btntimkiem_Click(object sender, EventArgs e)
        {
            if (int.TryParse(tk.Text, out int masp))
            {
                string query = $"SELECT * FROM sanpham WHERE MaSP = {masp}";
                datasp.DataSource = modify.GetDataTable(query);

                dangThemSanPham = false;
            }
            else
            {
                MessageBox.Show("Mã sản phẩm không hợp lệ!");
            }
        }
        private void btnsua_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(msp.Text, out int masp)) { MessageBox.Show("Chọn sản phẩm để sửa!"); return; }

            if (!decimal.TryParse(g.Text, out decimal dongia))
            {
                MessageBox.Show("Giá không hợp lệ!"); return;
            }

            if (!int.TryParse(txtSLTon.Text, out int soLuongTon))
            {
                MessageBox.Show("Số lượng tồn không hợp lệ!");
                return;
            }

            string query = $@"
                    UPDATE sanpham 
                    SET 
                    TenSP = N'{t.Text}', 
                    Kichthuoc = N'{kt.Text}', 
                    Mausac = N'{m.Text}', 
                    Giaban = {dongia.ToString(System.Globalization.CultureInfo.InvariantCulture)}, 
                    SoLuongTon = {soLuongTon}
                    WHERE MaSP = {masp}";

            using (SqlConnection conn = ketnoi.GetSqlConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Cập nhật thành công!");
            loaddata();
        }
        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(msp.Text, out int masp))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm hợp lệ để xóa!");
                return;
            }

            // Xác nhận người dùng
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    string query = $"DELETE FROM sanpham WHERE MaSP = {masp}";
                    modify.Commad(query);

                    MessageBox.Show("Đã xóa sản phẩm thành công!");
                    loaddata();          // Reload DataGridView
                    ClearSanPhamForm();  // Xoá dữ liệu nhập trên form
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                }
            }
        }
        private void datasp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = datasp.Rows[e.RowIndex];

                msp.Text = row.Cells["MaSP"].Value.ToString();
                t.Text = row.Cells["TenSP"].Value.ToString();
                kt.Text = row.Cells["Kichthuoc"].Value.ToString();
                m.Text = row.Cells["Mausac"].Value.ToString();
                g.Text = row.Cells["Giaban"].Value.ToString();
                txtSLTon.Text = row.Cells["SoLuongTon"].Value.ToString();
            }
        }
        private void ClearSanPhamForm()
        {
            msp.Text = "";
            t.Text = "";
            kt.Text = "";
            m.Text = "";
            g.Text = "";
            tk.Text = "";
            txtSLTon.Text = "";
        }
        private void rs_Click(object sender, EventArgs e)
        {
            ClearSanPhamForm();
            datasp.ClearSelection();

            if (dangThemSanPham)
            {
                datasp.DataSource = null;
                datasp.DataSource = ds;
            }
            else
            {
                loaddata();
            }
        }
        private void kh_Click(object sender, EventArgs e)
        {
            panelKhachHang.Visible = !panelKhachHang.Visible;

            if (panelKhachHang.Visible)
            {
                sanp.Visible = false;
                panelLichSuKho.Visible = false;
                panelDonhang.Visible = false;
                panelDaiLy.Visible = false;
                loadKhachHang();
            }
        }
        private void sdGVKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dGVKhachHang.Rows[e.RowIndex];
                txtMaKH.Text = row.Cells["MaKH"].Value.ToString();
                txtHoTen.Text = row.Cells["Hoten"].Value.ToString();
                txtSDT.Text = row.Cells["SDT"].Value.ToString();
                txtDiaChi.Text = row.Cells["Diachi"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtTenTK.Text = row.Cells["Tentaikhoan"].Value.ToString();
            }
        }
        private void SuaBtnKH_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtMaKH.Text, out int makh))
            {
                MessageBox.Show("Chọn khách để sửa!");
                return;
            }

            string query = @"UPDATE khachhang 
                     SET Hoten = @hoten, SDT = @sdt, Diachi = @diachi, Email = @email, Tentaikhoan = @tentk 
                     WHERE MaKH = @makh";

            using (SqlConnection conn = ketnoi.GetSqlConnection())
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@hoten", txtHoTen.Text);
                    cmd.Parameters.AddWithValue("@sdt", txtSDT.Text);
                    cmd.Parameters.AddWithValue("@diachi", txtDiaChi.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@tentk", txtTenTK.Text);
                    cmd.Parameters.AddWithValue("@makh", makh);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Cập nhật thành công!");
                        loadKhachHang();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy khách hàng để cập nhật.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }
        private void XoaBtnKH_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtMaKH.Text, out int makh))
            {
                MessageBox.Show("Vui lòng chọn khách hàng để xóa.");
                return;
            }

            // Kiểm tra xem khách có đơn hàng không
            string checkQuery = $"SELECT COUNT(*) FROM DonHang WHERE MaKH = {makh}";
            int count = (int)modify.ExecuteScalar(checkQuery); // Giả sử bạn có hàm này trong lớp Modify

            if (count > 0)
            {
                MessageBox.Show("Không thể xóa khách hàng vì đang có đơn hàng liên kết.");
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string query = $"DELETE FROM khachhang WHERE MaKH = {makh}";
                modify.Commad(query);
                MessageBox.Show("Xóa thành công!");
                loadKhachHang();
                LamMoiBtnKH_Click(sender, e);
            }
        }
        private void ClearKhachHangForm()
        {
            txtMaKH.Text = "";
            txtHoTen.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
            txtEmail.Text = "";
            txtTenTK.Text = "";
            txtTimKiem.Text = "";
            txtHoTen.Focus();
        }
        private void LamMoiBtnKH_Click(object sender, EventArgs e)
        {
            ClearKhachHangForm();
            dGVKhachHang.ClearSelection();

            if (dangThemKhachHang)
            {
                dGVKhachHang.DataSource = null;
                dGVKhachHang.DataSource = dskh;
            }
            else
            {
                loadKhachHang();
            }
        }
        private void TimKiemBtnKH_Click(object sender, EventArgs e)
        {
            string tukhoa = txtTimKiem.Text.Trim();

            if (string.IsNullOrEmpty(tukhoa))
            {
                MessageBox.Show("Vui lòng nhập tên hoặc email để tìm kiếm.");
                return;
            }

            string query = $"SELECT * FROM khachhang WHERE Hoten LIKE N'%{tukhoa}%' OR Email LIKE N'%{tukhoa}%'";
            dGVKhachHang.DataSource = modify.GetDataTable(query);

            dangThemKhachHang = false;
        }
        private void linkThoat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Dangnhap dn = new Dangnhap();
            dn.Show();
            this.Hide();
        }
        private void ThemKHBtn_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtMaKH.Text, out int makh))
            {
                MessageBox.Show("Mã khách hàng không hợp lệ!");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên khách hàng.");
                return;
            }

            // Kiểm tra trùng mã trong danh sách tạm
            if (dskh.Any(x => x.MaKH == makh))
            {
                MessageBox.Show("Mã khách hàng đã tồn tại trong danh sách tạm!");
                return;
            }

            khachhang kh = new khachhang
            {
                MaKH = makh,
                Hoten = txtHoTen.Text,
                SDT = txtSDT.Text,
                Diachi = txtDiaChi.Text,
                Email = txtEmail.Text,
                Tentaikhoan = string.IsNullOrWhiteSpace(txtTenTK.Text) ? null : txtTenTK.Text
            };

            dskh.Add(kh);
            dGVKhachHang.DataSource = null;
            dGVKhachHang.DataSource = dskh;

            dangThemKhachHang = true;

            ClearKhachHangForm();
        }
        private void btnLuuKH_Click(object sender, EventArgs e)
        {
            if (dskh.Count == 0)
            {
                MessageBox.Show("Không có khách hàng nào để lưu.");
                return;
            }

            foreach (var kh in dskh)
            {
                bool thanhCong = modify.ThemKhachHang(kh);
                if (!thanhCong)
                {
                    MessageBox.Show($"Không thể thêm khách hàng có mã: {kh.MaKH}");
                }
            }

            MessageBox.Show("Lưu thành công vào cơ sở dữ liệu!");

            dskh.Clear(); // Xoá danh sách tạm
            dangThemKhachHang = false;

            dGVKhachHang.DataSource = null;
            loadKhachHang(); // Load lại danh sách từ DB
        }

        private void panelKhachHang_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dh_Click(object sender, EventArgs e)
        {
            panelDonhang.Visible = !panelDonhang.Visible;

            if (panelDonhang.Visible)
            {
                sanp.Visible = false;
                panelKhachHang.Visible = false;
                panelLichSuKho.Visible = false;
                panelDaiLy.Visible = false;
                // Gọi hàm load đơn hàng nếu bạn có
                loadDonHang();
            }
        }

        private void btThemSP_Click(object sender, EventArgs e)
        {
            if (cbKichThuoc.SelectedItem == null || string.IsNullOrWhiteSpace(txtSoLuong.Text) || string.IsNullOrWhiteSpace(txtDonGia.Text))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm, kích thước và nhập số lượng, đơn giá.");
                return;
            }

            int masp = (int)cbKichThuoc.SelectedValue;     // Lấy MaSP
            string tensp = cbSanPham.Text + " " + ((sanpham)cbKichThuoc.SelectedItem).Kichthuoc; // Hoặc cbSize.Text
            int sl = int.Parse(txtSoLuong.Text);
            decimal gia = decimal.Parse(txtDonGia.Text);

            // Tạo mới chi tiết giỏ hàng
            ChiTietGioHang spMoi = new ChiTietGioHang
            {
                MaSP = masp,
                TenSP = tensp,
                SoLuong = sl,
                DonGia = gia
            };

            gioHang.Add(spMoi);
            dgvGioHang.DataSource = null;
            dgvGioHang.DataSource = gioHang;

            lbTongTien.Text = "Tổng: " + gioHang.Sum(x => x.ThanhTien).ToString("N0") + " VNĐ";
        }

        private void btLuuDH_Click(object sender, EventArgs e)
        {
            if (cbKhachHang.SelectedItem == null || gioHang.Count == 0)
            {
                MessageBox.Show("Chọn khách hàng và thêm sản phẩm!");
                return;
            }

            using (SqlConnection conn = ketnoi.GetSqlConnection())
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    int makh = (int)cbKhachHang.SelectedValue;
                    DateTime ngay = dtpNgayLap.Value;
                    decimal tong = gioHang.Sum(x => x.ThanhTien);

                    // Insert DonHang
                    SqlCommand cmd = new SqlCommand("INSERT INTO DonHang(NgayLap, MaKH, TongTien, TrangThai) OUTPUT INSERTED.MaDH VALUES (@ngay, @kh, @tong, @tt)", conn, tran);
                    cmd.Parameters.AddWithValue("@tt", cbTrangThai.Text);
                    cmd.Parameters.AddWithValue("@ngay", ngay);
                    cmd.Parameters.AddWithValue("@kh", makh);
                    cmd.Parameters.AddWithValue("@tong", tong);
                    int madh = (int)cmd.ExecuteScalar();

                    // Insert chi tiết
                    foreach (var item in gioHang)
                    {
                        SqlCommand ctdh = new SqlCommand("INSERT INTO CT_DonHang(MaDH, MaSP, Tensanpham, SoLuong, DonGia) VALUES (@madh, @masp, @ten, @sl, @gia)", conn, tran);
                        ctdh.Parameters.AddWithValue("@madh", madh);
                        ctdh.Parameters.AddWithValue("@masp", item.MaSP);
                        ctdh.Parameters.AddWithValue("@ten", item.TenSP);
                        ctdh.Parameters.AddWithValue("@sl", item.SoLuong);
                        ctdh.Parameters.AddWithValue("@gia", item.DonGia);
                        ctdh.ExecuteNonQuery();
                    }

                    tran.Commit();
                    MessageBox.Show("Lưu đơn hàng thành công!");

                    gioHang.Clear();
                    dgvGioHang.DataSource = null;
                    lbTongTien.Text = "Tổng: 0 VNĐ";
                    loadDonHang();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void btTimKiemDH_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiemDH.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập mã đơn hàng hoặc tên khách hàng để tìm.");
                return;
            }

            string query = $@"
                SELECT dh.MaDH, kh.Hoten, dh.NgayLap, dh.TongTien, dh.TrangThai 
                FROM DonHang dh
                JOIN khachhang kh ON dh.MaKH = kh.MaKH
                WHERE dh.MaDH LIKE '%{keyword}%' OR kh.Hoten LIKE N'%{keyword}%'
                ORDER BY dh.MaDH DESC";

            dgvDonHang.DataSource = modify.GetDataTable(query);
        }

        private void btSuaDh_Click(object sender, EventArgs e)
        {
            if (dgvDonHang.CurrentRow != null)
            {
                int maDH = Convert.ToInt32(dgvDonHang.CurrentRow.Cells["MaDH"].Value);
                DateTime ngayLap = dtpNgayLap.Value;
                decimal tongTien = gioHang.Sum(x => x.ThanhTien);
                string trangThai = cbTrangThai.Text;

                string query = @"UPDATE DonHang SET NgayLap = @ngay, TongTien = @tong, TrangThai = @trangthai WHERE MaDH = @madh";
                using (SqlConnection conn = ketnoi.GetSqlConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ngay", ngayLap);
                    cmd.Parameters.AddWithValue("@tong", tongTien);
                    cmd.Parameters.AddWithValue("@trangthai", trangThai);
                    cmd.Parameters.AddWithValue("@madh", maDH);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Cập nhật đơn hàng thành công!");
                loadDonHang();
            }
        }

        private void btXoaDH_Click(object sender, EventArgs e)
        {
            if (dgvDonHang.CurrentRow != null)
            {
                int maDH = Convert.ToInt32(dgvDonHang.CurrentRow.Cells["MaDH"].Value);

                DialogResult result = MessageBox.Show("Xác nhận xoá đơn hàng này?", "Xác nhận", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    using (SqlConnection conn = ketnoi.GetSqlConnection())
                    {
                        conn.Open();

                        SqlCommand cmdCT = new SqlCommand("DELETE FROM CT_DonHang WHERE MaDH = @madh", conn);
                        cmdCT.Parameters.AddWithValue("@madh", maDH);
                        cmdCT.ExecuteNonQuery();

                        SqlCommand cmdDH = new SqlCommand("DELETE FROM DonHang WHERE MaDH = @madh", conn);
                        cmdDH.Parameters.AddWithValue("@madh", maDH);
                        cmdDH.ExecuteNonQuery();
                    }

                    MessageBox.Show("Đã xoá đơn hàng.");
                    loadDonHang();
                }
            }
        }

        private void LoadChiTietDonHang(int maDH)
        {
            gioHang.Clear();

            string query = @"SELECT MaSP, Tensanpham, SoLuong, DonGia 
                     FROM CT_DonHang 
                     WHERE MaDH = @madh";
            using (SqlConnection conn = ketnoi.GetSqlConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@madh", maDH);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ChiTietGioHang item = new ChiTietGioHang
                    {
                        MaSP = reader.GetInt32(0),
                        TenSP = reader.GetString(1),
                        SoLuong = reader.GetInt32(2),
                        DonGia = reader.GetDecimal(3)
                    };
                    gioHang.Add(item);
                }
            }

            // Hiển thị lên dgvGioHang
            dgvGioHang.DataSource = null;
            dgvGioHang.DataSource = gioHang;

            // Cập nhật tổng tiền
            lbTongTien.Text = "Tổng: " + gioHang.Sum(x => x.ThanhTien).ToString("N0") + " VNĐ";
        }

        private void dgvDonHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDonHang.Rows[e.RowIndex];
                if (row.Cells["TrangThai"].Value != null)
                {
                    cbTrangThai.Text = row.Cells["TrangThai"].Value.ToString();
                }
                // Lấy mã đơn hàng
                int maDH = Convert.ToInt32(row.Cells["MaDH"].Value);

                // Load chi tiết giỏ hàng
                LoadChiTietDonHang(maDH);
            }
        }

        private void cbSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedName = cbSanPham.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedName))
            {
                var listByName = allProducts
                    .Where(sp => sp.Tensanpham == selectedName)
                    .ToList();

                cbKichThuoc.DataSource = listByName;
                cbKichThuoc.DisplayMember = "KichThuoc";  // hiển thị kích thước
                cbKichThuoc.ValueMember = "MaSP";         // giá trị là MaSP
            }
            txtDonGia.Text = "";
        }

        private void panelLichSuKho_Paint(object sender, PaintEventArgs e)
        {
            tu.Value = DateTime.Now.AddMonths(-1); // mặc định từ 1 tháng trước
            den.Value = DateTime.Now;
            btntk.PerformClick(); // tự động tìm luôn
        }

        private void btntk_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = tu.Value;
            DateTime denNgay = den.Value;

            var dt = Modify.TimKiemLichSuKho(tuNgay, denNgay);

            dgvKho.DataSource = dt;
            ketq.Text = $"Tìm thấy {dt.Rows.Count} kết quả từ {tuNgay:dd/MM/yyyy} đến {denNgay:dd/MM/yyyy}";
        }

        private void lsk_Click(object sender, EventArgs e)
        {
            panelLichSuKho.Visible = !panelLichSuKho.Visible;
            if (panelLichSuKho.Visible)
            {
                sanp.Visible = false;
                panelKhachHang.Visible = false;
                panelDonhang.Visible = false;
                panelDaiLy.Visible = false;
            }
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbSanPham_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string selectedName = cbSanPham.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedName))
            {
                var listByName = allProducts
                    .Where(sp => sp.Tensanpham == selectedName)
                    .ToList();

                cbKichThuoc.DataSource = listByName;
                cbKichThuoc.DisplayMember = "KichThuoc";  // hiển thị kích thước
                cbKichThuoc.ValueMember = "MaSP";         // giá trị là MaSP
                txtDonGia.Clear();
            }
        }

        private void lbSanPham_Click(object sender, EventArgs e)
        {

        }

        private void cbKichThuoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbKichThuoc.SelectedValue != null && cbKichThuoc.SelectedValue is int maSP)
            {
                var spInfo = modify.LayThongTinSanPham(maSP);
                if (spInfo != null)
                {
                    txtDonGia.Text = spInfo.DonGia.ToString("N0"); // định dạng giá tiền
                }
                else
                {
                    txtDonGia.Clear();
                }
            }
        }

        private void linkCTDH_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dgvKho.CurrentRow != null)
            {
                int maSP = Convert.ToInt32(dgvKho.CurrentRow.Cells["MaSP"].Value);
                string ghiChu = dgvKho.CurrentRow.Cells["GhiChu"].Value.ToString();
                DateTime ngayTao = Convert.ToDateTime(dgvKho.CurrentRow.Cells["NgayThayDoi"].Value);

                // 1. Tách MaDH từ GhiChu (VD: "Đơn hàng: 1052")
                int maDH = -1;
                if (ghiChu.StartsWith("Đơn hàng:"))
                {
                    string[] parts = ghiChu.Split(':');
                    if (parts.Length > 1 && int.TryParse(parts[1].Trim(), out int parsedMaDH))
                    {
                        maDH = parsedMaDH;
                    }
                }

                // Nếu MaDH không hợp lệ thì thoát
                if (maDH == -1)
                {
                    MessageBox.Show("Không thể xác định đơn hàng từ ghi chú!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 2. Lấy dữ liệu chi tiết đơn hàng
                DataTable dtChiTiet = Modify.LayChiTietDonHang(maDH);
                DataRow[] chiTietSP = dtChiTiet.Select("MaSP = " + maSP);
                if (chiTietSP.Length == 0)
                {
                    MessageBox.Show("Không tìm thấy chi tiết sản phẩm trong đơn hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int soLuong = Convert.ToInt32(chiTietSP[0]["SoLuong"]);
                decimal donGia = Convert.ToDecimal(chiTietSP[0]["DonGia"]);
                string tenSP = chiTietSP[0]["Tensanpham"].ToString();

                // 3. Lấy ngày lập và mã KH từ đơn hàng
                DataTable dtDH = Modify.LayDonHang(maDH);
                if (dtDH.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy đơn hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime ngayLap = Convert.ToDateTime(dtDH.Rows[0]["NgayLap"]);
                int maKH = Convert.ToInt32(dtDH.Rows[0]["MaKH"]);

                // 4. Lấy tên khách hàng
                DataTable dtKH = Modify.LayThongTinKhachHang(maKH);
                string khachHang = (dtKH.Rows.Count > 0) ? dtKH.Rows[0]["Hoten"].ToString() : "Khách lẻ";

                // 5. Mở form chi tiết
                FormChiTietDonHang f = new FormChiTietDonHang(tenSP, soLuong, donGia, ngayLap, khachHang, ghiChu);
                f.ShowDialog();
            }
        }

        private void btLamMoiDH_Click(object sender, EventArgs e)
        {
            txtTimKiemDH.Clear();          // Xóa ô tìm kiếm
            loadDonHang();                 // Load lại toàn bộ đơn hàng
            gioHang.Clear();              // Nếu bạn muốn reset giỏ hàng luôn
            dgvGioHang.DataSource = null;
            lbTongTien.Text = "Tổng: 0 VNĐ";
        }

        private void btDaiLy_Click(object sender, EventArgs e)
        {
            panelDaiLy.Visible = !panelDaiLy.Visible;
            if (panelDaiLy.Visible)
            {
                sanp.Visible = false;
                panelKhachHang.Visible = false;
                panelDonhang.Visible = false;
                panelLichSuKho.Visible = false;

                LoadDaiLy();
            }
        }

        private void xuatexcel_Click(object sender, EventArgs e)
        {
            // Tạo DataTable từ DataGridView
            DataTable dt = new DataTable();
            foreach (DataGridViewColumn column in dgvKho.Columns)
            {
                dt.Columns.Add(column.HeaderText); // tên cột
            }
            foreach (DataGridViewRow row in dgvKho.Rows)
            {
                if (!row.IsNewRow)
                {
                    DataRow dataRow = dt.NewRow();
                    for (int i = 0; i < dgvKho.Columns.Count; i++)
                    {
                        dataRow[i] = row.Cells[i].Value;
                    }
                    dt.Rows.Add(dataRow);
                }
            }

            // Mở hộp thoại lưu file
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Workbook|*.xlsx";
            saveFileDialog.Title = "Lưu file Excel";
            saveFileDialog.FileName = "DanhSachLichSuKho.xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dt, "DanhSach");
                    wb.SaveAs(saveFileDialog.FileName);
                }
                MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void ClearDaiLyForm()
        {
            txtma.Text = "";
            txttendaily.Text = "";
            txttensp.Text = "";
            txtdchi.Text = "";
            txtsodt.Text = "";
            txtE.Text = "";
        }
        private void label16_Click(object sender, EventArgs e)
        {

        }
        List<daily> dailies = new List<daily>();
        private void them_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtma.Text, out int MaDaiLy))
            {
                MessageBox.Show("Mã sản đại lý không hợp lệ!");
                return;
            }

            if (string.IsNullOrWhiteSpace(txttendaily.Text) ||
                string.IsNullOrWhiteSpace(txttensp.Text) ||
                string.IsNullOrWhiteSpace(txtdchi.Text) ||
                string.IsNullOrWhiteSpace(txtsodt.Text) ||
                string.IsNullOrWhiteSpace(txtE.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            if (dailies.Any(dl => dl.Madaily == MaDaiLy))
            {
                MessageBox.Show("Mã sản đại lý đã tồn tại trong danh sách tạm!");
                return;
            }

            daily dl = new daily
            {
                Madaily = MaDaiLy,
                Tendaily = txttendaily.Text,
                Tensanpham = txttensp.Text,
                Diachi = txtdchi.Text,   // ❗ Sửa từ `m.Text` sang đúng textbox
                Email = txtE.Text,
                Sdt = txtsodt.Text
            };

            dailies.Add(dl);

            // ✅ Cập nhật lại DataGridView với danh sách mới
            dgvDaiLy.DataSource = null;
            dgvDaiLy.DataSource = dailies;

            dangThemSanPham = true;

            ClearDaiLyForm();
        }

        private void luu_Click(object sender, EventArgs e)
        {
            if (dailies.Count == 0)
            {
                MessageBox.Show("Không có đại lý nào để lưu.");
                return;
            }

            int demThanhCong = 0;
            foreach (var dl in dailies)
            {
                bool thanhCong = modify.ThemDaiLy(dl);
                if (thanhCong)
                    demThanhCong++;
            }

            MessageBox.Show($"Đã lưu {demThanhCong} đại lý vào cơ sở dữ liệu.");

            dailies.Clear(); // ✅ Clear danh sách tạm
            dangThemSanPham = false;

            dgvDaiLy.DataSource = null;
            LoadDaiLy(); // ✅ Load lại từ bảng daily
        }
        private void dgvDaiLy_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDaiLy.Rows[e.RowIndex];

                txtma.Text = row.Cells[0].Value?.ToString();
                txttendaily.Text = row.Cells[1].Value?.ToString();
                txttensp.Text = row.Cells[2].Value?.ToString();
                txtdchi.Text = row.Cells[3].Value?.ToString();
                txtsodt.Text = row.Cells[4].Value?.ToString();
                txtE.Text = row.Cells[5].Value?.ToString();
            }
        }

        private void sua_Click(object sender, EventArgs e)
        {
            int ma;
            if (!int.TryParse(txtma.Text, out ma))
            {
                MessageBox.Show("Mã đại lý không hợp lệ.");
                return;
            }

            string query = $"UPDATE daily SET " +
                           $"TenDaiLy = N'{txttendaily.Text}', " +
                           $"Tensanpham = N'{txttensp.Text}', " +
                           $"Diachi = N'{txtdchi.Text}', " +
                           $"Sdt = '{txtsodt.Text}', " +
                           $"Email = '{txtE.Text}' " +
                           $"WHERE MaDaiLy = {ma}";

            if (modify.ExecuteNonQuery(query))
            {
                MessageBox.Show("Cập nhật thành công.");
                LoadDaiLy();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại.");
            }
        }

        private void xoaDL_Click(object sender, EventArgs e)
        {
            int ma;
            if (!int.TryParse(txtma.Text, out ma))
            {
                MessageBox.Show("Mã đại lý không hợp lệ.");
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa đại lý này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string query = $"DELETE FROM daily WHERE MaDaiLy = {ma}";
                if (modify.ExecuteNonQuery(query))
                {
                    MessageBox.Show("Xóa thành công.");
                    LoadDaiLy();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại.");
                }
            }
        }

        private void timkiemDL_Click(object sender, EventArgs e)
        {
            string tensp = txttimk.Text.Trim();

            if (string.IsNullOrEmpty(tensp))
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm cần tìm.");
                return;
            }

            string query = $"SELECT * FROM daily WHERE Tensanpham LIKE N'%{tensp}%'";
            dgvDaiLy.DataSource = modify.GetDataTable(query);
        }

        private void lmDL_Click(object sender, EventArgs e)
        {
            txtma.Clear();
            txttendaily.Clear();
            txttensp.Clear();
            txtdchi.Clear();
            txtsodt.Clear();
            txtE.Clear();
            txtma.Focus();
            txttimk.Clear();
            LoadDaiLy();

            DateTime start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime end = start.AddMonths(1).AddDays(-1);
            txtDlTen.Clear(); // hoặc cbTenDaiLy.SelectedIndex = -1;
            dateNgayTu.Value = start;
            dateDen.Value = end;

            LoadPhieuNhap(start, end, null);

            txtDlTen.Clear(); // Xóa ô tìm kiếm tên đại lý nếu có
            dgvChiTietPhieu.DataSource = null; // Xóa chi tiết phiếu
        }
        private void LoadPhieuNhap(DateTime tuNgay, DateTime denNgay, string tenDaiLy)
        {
            string query = @"
    SELECT 
        pn.MaPhieuNhap, 
        pn.NgayNhap, 
        dl.TenDaiLy, 
        pn.GhiChu,
        SUM(ISNULL(ct.SoLuongNhap, 0)) AS TongSoSP,
        SUM(ISNULL(ct.SoLuongNhap, 0) * ISNULL(ct.DonGiaNhap, 0)) AS TongTien
    FROM PhieuNhap pn
    JOIN daily dl ON pn.MaDaiLy = dl.MaDaiLy
    JOIN CT_PhieuNhap ct ON pn.MaPhieuNhap = ct.MaPhieuNhap
    WHERE pn.NgayNhap BETWEEN @tuNgay AND @denNgay";

            if (!string.IsNullOrEmpty(tenDaiLy))
                query += " AND dl.TenDaiLy LIKE @tenDaiLy";

            query += @"
    GROUP BY pn.MaPhieuNhap, pn.NgayNhap, dl.TenDaiLy, pn.GhiChu
    ORDER BY pn.NgayNhap DESC";

            using (SqlConnection conn = ketnoi.GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tuNgay", tuNgay);
                cmd.Parameters.AddWithValue("@denNgay", denNgay);

                if (!string.IsNullOrEmpty(tenDaiLy))
                    cmd.Parameters.AddWithValue("@tenDaiLy", "%" + tenDaiLy + "%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvPhieuNhap.DataSource = dt;
                dgvPhieuNhap.ClearSelection(); // tránh bị chọn sai dòng

                // ✅ nếu có dữ liệu thì chọn dòng đầu tiên
                if (dgvPhieuNhap.Rows.Count > 0)
                {
                    dgvPhieuNhap.Rows[0].Selected = true;
                    int maPN = Convert.ToInt32(dgvPhieuNhap.Rows[0].Cells["MaPhieuNhap"].Value);
                    LoadChiTietPhieuNhap(maPN);
                }
                else
                {
                    dgvChiTietPhieu.DataSource = null;
                }
            }
        }
        private void dgvPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int maPN = Convert.ToInt32(dgvPhieuNhap.Rows[e.RowIndex].Cells[0].Value);
                MessageBox.Show("Mã phiếu nhập: " + maPN);
                LoadChiTietPhieuNhap(maPN);
            }
        }
        private void LoadChiTietPhieuNhap(int maPhieuNhap)
        {
            string query = @"
    SELECT 
        sp.MaSP, 
        sp.TenSP, 
        ct.SoLuongNhap, 
        ct.DonGiaNhap
    FROM CT_PhieuNhap ct
    JOIN sanpham sp ON ct.MaSP = sp.MaSP
    WHERE ct.MaPhieuNhap = @MaPN";

            using (SqlConnection conn = ketnoi.GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaPN", maPhieuNhap);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvChiTietPhieu.AutoGenerateColumns = true; // để cột tự sinh từ dữ liệu
                dgvChiTietPhieu.DataSource = dt;
            }
        }

        private void btTimkiemLS_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = dateNgayTu.Value.Date;
            DateTime denNgay = dateDen.Value.Date;
            string tenDL = txtDlTen.Text.Trim();

            LoadPhieuNhap(tuNgay, denNgay, tenDL);
        }

        BindingList<SanPhamNhap> danhSachNhap = new BindingList<SanPhamNhap>();

        private void InitPhieuNhapMoi()
        {
            dgvChonSanPham.AutoGenerateColumns = false;
            dgvChonSanPham.DataSource = danhSachNhap;

            // Load đại lý
            using (SqlConnection conn = ketnoi.GetSqlConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT MaDaily, TenDaily FROM daily", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cbDaiLy.DataSource = dt;
                cbDaiLy.DisplayMember = "TenDaily";
                cbDaiLy.ValueMember = "MaDaily";
            }
        }

        private void btLuuSPDL_Click(object sender, EventArgs e)
        {
            if (danhSachNhap.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm ít nhất 1 sản phẩm trước khi lưu.");
                return;
            }

            using (SqlConnection conn = ketnoi.GetSqlConnection())
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    // 1. Thêm phiếu nhập mới
                    string insertPN = "INSERT INTO PhieuNhap (NgayNhap, MaDaily, GhiChu) " +
                                      "VALUES (@NgayNhap, @MaDaily, @GhiChu); SELECT SCOPE_IDENTITY();";

                    SqlCommand cmdPN = new SqlCommand(insertPN, conn, tran);
                    cmdPN.Parameters.AddWithValue("@NgayNhap", dateNgayNhapPhieu.Value);
                    cmdPN.Parameters.AddWithValue("@MaDaily", cbDaiLy.SelectedValue);
                    cmdPN.Parameters.AddWithValue("@GhiChu", txtGhiChu.Text);

                    int maPhieuNhap = Convert.ToInt32(cmdPN.ExecuteScalar());

                    // 2. Thêm chi tiết từng sản phẩm nhập
                    foreach (var sp in danhSachNhap)
                    {
                        string insertCT = "INSERT INTO CT_PhieuNhap (MaPhieuNhap, MaSP, SoLuongNhap, DonGiaNhap) " +
                                          "VALUES (@MaPN, @MaSP, @SL, @DG)";
                        SqlCommand cmdCT = new SqlCommand(insertCT, conn, tran);
                        cmdCT.Parameters.AddWithValue("@MaPN", maPhieuNhap);
                        cmdCT.Parameters.AddWithValue("@MaSP", sp.MaSP);
                        cmdCT.Parameters.AddWithValue("@SL", sp.SoLuongNhap);
                        cmdCT.Parameters.AddWithValue("@DG", sp.DonGiaNhap);
                        cmdCT.ExecuteNonQuery();

                        // 3. Cập nhật tồn kho sản phẩm
                        string updateTonKho = "UPDATE sanpham SET SoLuongTon = ISNULL(SoLuongTon, 0) + @SL WHERE MaSP = @MaSP";
                        SqlCommand cmdUpdate = new SqlCommand(updateTonKho, conn, tran);
                        cmdUpdate.Parameters.AddWithValue("@SL", sp.SoLuongNhap);
                        cmdUpdate.Parameters.AddWithValue("@MaSP", sp.MaSP);
                        cmdUpdate.ExecuteNonQuery();

                        // 4. Ghi vào Lịch sử kho
                        string insertLSK = "INSERT INTO LichSuKho (MaSP, NgayThayDoi, SoLuong, LoaiThayDoi, GhiChu) " +
                                           "VALUES (@MaSP, @Ngay, @SL, @Loai, @GhiChu)";
                        SqlCommand cmdLSK = new SqlCommand(insertLSK, conn, tran);
                        cmdLSK.Parameters.AddWithValue("@MaSP", sp.MaSP);
                        cmdLSK.Parameters.AddWithValue("@Ngay", dateNgayNhapPhieu.Value);
                        cmdLSK.Parameters.AddWithValue("@SL", sp.SoLuongNhap);
                        cmdLSK.Parameters.AddWithValue("@Loai", "Nhập kho");
                        cmdLSK.Parameters.AddWithValue("@GhiChu", "Phiếu nhập #" + maPhieuNhap);
                        cmdLSK.ExecuteNonQuery();
                    }

                    tran.Commit();
                    MessageBox.Show("Lưu phiếu nhập thành công!");

                    danhSachNhap.Clear(); // Reset danh sách
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("Lỗi khi lưu phiếu nhập: " + ex.Message);
                }
            }
        }
        private void btThemSPDL_Click(object sender, EventArgs e)
        {
            if (cbSP.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm.");
                return;
            }

            DataRowView row = cbSP.SelectedItem as DataRowView;
            int maSP = Convert.ToInt32(row["MaSP"]);
            string tenSP = row["TenSP"].ToString();

            // Kiểm tra và ép kiểu từ TextBox
            if (!int.TryParse(txtSL.Text.Trim(), out int soLuong))
            {
                MessageBox.Show("Vui lòng nhập đúng số lượng (số nguyên).");
                return;
            }

            if (!decimal.TryParse(txtGiaNhap.Text.Trim(), out decimal donGia))
            {
                MessageBox.Show("Vui lòng nhập đúng đơn giá (số thập phân).");
                return;
            }

            var sp = new SanPhamNhap
            {
                MaSP = maSP,
                TenSP = tenSP,
                SoLuongNhap = soLuong,
                DonGiaNhap = donGia
            };

            danhSachNhap.Add(sp);
            dgvChonSanPham.Refresh();
            TinhTongThanhTien();
        }

        private void LoadSanPham()
        {
            using (SqlConnection conn = ketnoi.GetSqlConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT MaSP, TenSP FROM sanpham", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cbSP.DataSource = dt;
                cbSP.DisplayMember = "TenSP";
                cbSP.ValueMember = "MaSP";
            }
        }
        private void TinhTongThanhTien()
        {
            decimal tong = 0;
            foreach (var sp in danhSachNhap)
            {
                tong += sp.SoLuongNhap * sp.DonGiaNhap;
            }

            // Gán lên Label/TextBox để hiển thị
            lbTongTienDL.Text = tong.ToString("N0") + " đ"; // Định dạng tiền đẹp hơn
        }

    }
}