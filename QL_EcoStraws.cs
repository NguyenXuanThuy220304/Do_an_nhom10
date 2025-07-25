﻿using ClosedXML.Excel;
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
using System.Windows.Forms.DataVisualization.Charting;


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
                panelThongke.Visible = false;
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
        #region Quản lý khách hàng
        private void kh_Click(object sender, EventArgs e)
        {
            panelKhachHang.Visible = !panelKhachHang.Visible;

            if (panelKhachHang.Visible)
            {
                sanp.Visible = false;
                panelLichSuKho.Visible = false;
                panelDonhang.Visible = false;
                panelDaiLy.Visible = false;
                panelThongke.Visible = false;
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
        #endregion
        #region Quản lý đơn hàng
        private void dh_Click(object sender, EventArgs e)
        {
            panelDonhang.Visible = !panelDonhang.Visible;

            if (panelDonhang.Visible)
            {
                sanp.Visible = false;
                panelKhachHang.Visible = false;
                panelLichSuKho.Visible = false;
                panelDaiLy.Visible = false;
                panelThongke.Visible = false;
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

                // ✅ Bước 1: Kiểm tra tồn kho trước khi lưu
                foreach (var item in gioHang)
                {
                    string queryTon = "SELECT SoLuongTon FROM sanpham WHERE MaSP = @masp";
                    SqlCommand cmdCheck = new SqlCommand(queryTon, conn);
                    cmdCheck.Parameters.AddWithValue("@masp", item.MaSP);
                    object result = cmdCheck.ExecuteScalar();

                    if (result == null || result == DBNull.Value)
                    {
                        MessageBox.Show($"Không tìm thấy sản phẩm '{item.TenSP}' trong kho.");
                        return;
                    }

                    int ton = Convert.ToInt32(result);
                    if (item.SoLuong > ton)
                    {
                        MessageBox.Show($"Sản phẩm '{item.TenSP}' không đủ tồn kho! Chỉ còn {ton} hộp.");
                        return;
                    }
                }

                // ✅ Bước 2: Lưu đơn hàng và chi tiết trong transaction
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    int makh = (int)cbKhachHang.SelectedValue;
                    DateTime ngay = dtpNgayLap.Value;
                    decimal tong = gioHang.Sum(x => x.ThanhTien);

                    // Lưu đơn hàng
                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO DonHang(NgayLap, MaKH, TongTien, TrangThai) OUTPUT INSERTED.MaDH " +
                        "VALUES (@ngay, @kh, @tong, @tt)", conn, tran);

                    cmd.Parameters.AddWithValue("@ngay", ngay);
                    cmd.Parameters.AddWithValue("@kh", makh);
                    cmd.Parameters.AddWithValue("@tong", tong);
                    cmd.Parameters.AddWithValue("@tt", cbTrangThai.Text);  // Hoặc "Đã thanh toán"
                    int madh = (int)cmd.ExecuteScalar();

                    // Lưu chi tiết đơn hàng + cập nhật kho + ghi lịch sử kho
                    foreach (var item in gioHang)
                    {
                        // Thêm chi tiết đơn hàng
                        SqlCommand ctdh = new SqlCommand(
                            "INSERT INTO CT_DonHang(MaDH, MaSP, Tensanpham, SoLuong, DonGia) " +
                            "VALUES (@madh, @masp, @ten, @sl, @gia)", conn, tran);
                        ctdh.Parameters.AddWithValue("@madh", madh);
                        ctdh.Parameters.AddWithValue("@masp", item.MaSP);
                        ctdh.Parameters.AddWithValue("@ten", item.TenSP);
                        ctdh.Parameters.AddWithValue("@sl", item.SoLuong);
                        ctdh.Parameters.AddWithValue("@gia", item.DonGia);
                        ctdh.ExecuteNonQuery();

                        // Trừ kho
                        SqlCommand capnhatTonKho = new SqlCommand(
                            "UPDATE sanpham SET SoLuongTon = SoLuongTon - @sl WHERE MaSP = @masp", conn, tran);
                        capnhatTonKho.Parameters.AddWithValue("@sl", item.SoLuong);
                        capnhatTonKho.Parameters.AddWithValue("@masp", item.MaSP);
                        capnhatTonKho.ExecuteNonQuery();

                        // Ghi lịch sử kho
                        SqlCommand lsKho = new SqlCommand(@"
                    INSERT INTO LichSuKho (MaSP, SoLuong, LoaiThayDoi, GhiChu) 
                    VALUES (@masp, @sl, @loai, @ghichu)", conn, tran);
                        lsKho.Parameters.AddWithValue("@masp", item.MaSP);
                        lsKho.Parameters.AddWithValue("@sl", $"- {item.SoLuong}");
                        lsKho.Parameters.AddWithValue("@loai", "Xuất bán");
                        lsKho.Parameters.AddWithValue("@ghichu", $"Đơn hàng: {madh}");
                        lsKho.ExecuteNonQuery();
                    }

                    tran.Commit();
                    MessageBox.Show("Lưu đơn hàng thành công!");
                    LoadChiTietDonHang(madh);
                    // Reset giao diện
                    gioHang.Clear();
                    dgvGioHang.DataSource = null;
                    lbTongTien.Text = "Tổng: 0 VNĐ";
                    loadDonHang();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("Lỗi khi lưu đơn hàng: " + ex.Message);
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
        #endregion
        #region Quản lý kho
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
                panelThongke.Visible = false;
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
        #endregion
        #region Quản lý Đại lý
        private void btDaiLy_Click(object sender, EventArgs e)
        {
            panelDaiLy.Visible = !panelDaiLy.Visible;
            if (panelDaiLy.Visible)
            {
                sanp.Visible = false;
                panelKhachHang.Visible = false;
                panelDonhang.Visible = false;
                panelLichSuKho.Visible = false;
                panelThongke.Visible = false;
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
        #endregion
        #region Quản lý Phiếu nhập & Sản phẩm nhập
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
            string tenSP = row["TenDayDu"].ToString(); // ✅ đúng cột tên hiển thị đã gộp

            // 🔍 Lấy tên sản phẩm mà đại lý được phép bán
            string tenSP_DaiLy = "";
            using (SqlConnection conn = ketnoi.GetSqlConnection())
            {
                string query = "SELECT Tensanpham FROM daily WHERE MaDaiLy = @MaDL";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaDL", cbDaiLy.SelectedValue);
                conn.Open();
                object result = cmd.ExecuteScalar();
                tenSP_DaiLy = result?.ToString();
            }

            if (string.IsNullOrWhiteSpace(tenSP_DaiLy) || !tenSP.StartsWith(tenSP_DaiLy))
            {
                MessageBox.Show("Sản phẩm này không thuộc danh mục đại lý đang bán.");
                return;
            }

            // Kiểm tra số lượng và đơn giá
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

            // ✅ Gộp sản phẩm nếu trùng (không tạo dòng mới)
            var spTonTai = danhSachNhap.FirstOrDefault(sp => sp.MaSP == maSP);
            if (spTonTai != null)
            {
                spTonTai.SoLuongNhap += soLuong;
                spTonTai.DonGiaNhap = donGia; // Cập nhật giá nếu cần
            }
            else
            {
                var sp = new SanPhamNhap
                {
                    MaSP = maSP,
                    TenSP = tenSP,
                    SoLuongNhap = soLuong,
                    DonGiaNhap = donGia
                };
                danhSachNhap.Add(sp);
            }

            dgvChonSanPham.Refresh();
            TinhTongThanhTien();
        }

        private void LoadSanPham()
        {
            using (SqlConnection conn = ketnoi.GetSqlConnection())
            {
                string query = "SELECT MaSP, TenSP + ' - ' + KichThuoc AS TenDayDu FROM sanpham";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbSP.DataSource = dt;
                cbSP.DisplayMember = "TenDayDu";  // Gộp tên + kích thước
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

        private void cbDaiLy_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Tránh lỗi cast khi SelectedValue đang là DataRowView
            if (cbDaiLy.SelectedValue == null || cbDaiLy.SelectedValue is DataRowView)
                return;

            int maDL = Convert.ToInt32(cbDaiLy.SelectedValue);

            using (SqlConnection conn = ketnoi.GetSqlConnection())
            {
                conn.Open();

                // 1. Lấy tên sản phẩm mà đại lý đó bán
                string queryTenSP = "SELECT Tensanpham FROM daily WHERE MaDaiLy = @MaDL";
                SqlCommand cmd = new SqlCommand(queryTenSP, conn);
                cmd.Parameters.AddWithValue("@MaDL", maDL);
                string tenSP = cmd.ExecuteScalar()?.ToString();

                if (string.IsNullOrWhiteSpace(tenSP))
                {
                    MessageBox.Show("Đại lý chưa có sản phẩm nào được gán.");
                    cbSP.DataSource = null;
                    return;
                }

                // 2. Lấy danh sách sản phẩm theo tên + gộp kích thước
                string querySP = @"
            SELECT MaSP, TenSP + ' - ' + KichThuoc AS TenDayDu 
            FROM sanpham 
            WHERE TenSP = @TenSP";

                SqlCommand cmd2 = new SqlCommand(querySP, conn);
                cmd2.Parameters.AddWithValue("@TenSP", tenSP);

                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                DataTable dtSP = new DataTable();
                da.Fill(dtSP);

                if (dtSP.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy sản phẩm phù hợp trong danh mục.");
                    cbSP.DataSource = null;
                    return;
                }

                cbSP.DataSource = dtSP;
                cbSP.DisplayMember = "TenDayDu"; // Gộp tên và kích thước
                cbSP.ValueMember = "MaSP";
            }
        }

        #endregion
        #region Báo cáo & Thống kê
        private void LoadDoanhThuTheoThang()
        {
            DateTime tuNgay = dtpTuNgay.Value;
            DateTime denNgay = dtpDenNgay.Value;

            DataTable dt = new Modify().LayBaoCaoDoanhThuTheoThang(tuNgay, denNgay);

            chartTheoThang.Series.Clear();
            chartTheoThang.Titles.Clear();

            chartTheoThang.Titles.Add("Doanh thu và lợi nhuận theo tháng");
            chartTheoThang.Titles[0].Font = new Font("Times New Roman", 10, FontStyle.Bold);

            chartTheoThang.Series.Add("Doanh thu");
            chartTheoThang.Series.Add("Lợi nhuận");

            chartTheoThang.Series["Doanh thu"].ChartType = SeriesChartType.Column;
            chartTheoThang.Series["Lợi nhuận"].ChartType = SeriesChartType.Column;

            foreach (DataRow row in dt.Rows)
            {
                string thang = row["Thang"].ToString(); // yyyy-MM
                decimal doanhThu = Convert.ToDecimal(row["DoanhThu"]);
                decimal loiNhuan = Convert.ToDecimal(row["LoiNhuan"]);

                chartTheoThang.Series["Doanh thu"].Points.AddXY(thang, doanhThu);
                chartTheoThang.Series["Lợi nhuận"].Points.AddXY(thang, loiNhuan);
            }
        }


        private void LoadDoanhThuTheoNgay()
        {
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date;

            // Gọi đúng hàm báo cáo theo ngày
            DataTable dt = new Modify().LayBaoCaoDoanhThuTheoNgay(tuNgay, denNgay);

            chartTheoNgay.Series.Clear();
            chartTheoNgay.Titles.Clear();

            chartTheoNgay.Titles.Add("Doanh thu theo từng ngày");
            chartTheoNgay.Titles[0].Font = new Font("Times New Roman", 10, FontStyle.Bold);

            Series series = new Series("Doanh thu")
            {
                ChartType = SeriesChartType.Line,
                Color = Color.DodgerBlue,
                BorderWidth = 2,
                XValueType = ChartValueType.Date
            };

            foreach (DataRow row in dt.Rows)
            {
                if (DateTime.TryParse(row["NgayLap"].ToString(), out DateTime ngay))
                {
                    decimal doanhThu = Convert.ToDecimal(row["DoanhThu"]);
                    series.Points.AddXY(ngay, doanhThu);
                }
            }

            chartTheoNgay.Series.Add(series);

            var chartArea = chartTheoNgay.ChartAreas[0];
            chartArea.AxisX.LabelStyle.Format = "dd/MM";
            chartArea.AxisX.Interval = 1;
            chartArea.AxisX.IntervalType = DateTimeIntervalType.Days;
            chartArea.AxisX.Title = "Ngày";
            chartArea.AxisY.Title = "Doanh thu (VNĐ)";
            chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
        }



        private void LoadTyLeHinhThucBan()
        {
            string query = "SELECT TrangThai, COUNT(*) AS SoLuong FROM DonHang GROUP BY TrangThai";
            DataTable dt = new Modify().GetDataTable(query);

            chartHinhThuc.Series.Clear();
            chartHinhThuc.Titles.Clear();

            // Tiêu đề
            chartHinhThuc.Titles.Add("Tỷ lệ trạng thái đơn hàng");
            chartHinhThuc.Titles[0].Font = new Font("Segoe UI", 10, FontStyle.Bold);

            // Series dạng biểu đồ tròn
            Series series = new Series("Trạng thái đơn");
            series.ChartType = SeriesChartType.Pie;
            series.IsValueShownAsLabel = true; // Hiện số lượng trên pie
            series.LabelForeColor = Color.Black;
            series.Font = new Font("Segoe UI", 9);

            foreach (DataRow row in dt.Rows)
            {
                string trangThai = row["TrangThai"].ToString();
                int soLuong = Convert.ToInt32(row["SoLuong"]);
                series.Points.AddXY(trangThai, soLuong);
            }

            chartHinhThuc.Series.Add(series);
        }

        private void LoadTopSanPham()
        {
            string query = "SELECT TOP 5 Tensanpham, SUM(SoLuong) AS TongSoLuong FROM CT_DonHang GROUP BY Tensanpham ORDER BY TongSoLuong DESC";
            DataTable dt = new Modify().GetDataTable(query);

            flowTopSP.Controls.Clear();

            // Cài đặt hiển thị theo cột dọc
            flowTopSP.FlowDirection = FlowDirection.TopDown;
            flowTopSP.WrapContents = false;
            flowTopSP.AutoScroll = true;

            // Tiêu đề
            Label title = new Label();
            title.Text = "📌 Sản phẩm bán chạy nhất";
            title.Font = new Font("Time New Roman", 11, FontStyle.Bold);
            title.AutoSize = true;
            title.Padding = new Padding(0, 5, 0, 10);
            flowTopSP.Controls.Add(title);

            // Danh sách sản phẩm
            foreach (DataRow row in dt.Rows)
            {
                Label lbl = new Label();
                lbl.Text = $"• {row["Tensanpham"]}: {row["TongSoLuong"]} hộp";
                lbl.AutoSize = true;
                lbl.Font = new Font("Time New Roman", 10);
                lbl.Padding = new Padding(10, 2, 0, 2);
                flowTopSP.Controls.Add(lbl);
            }
        }

        private void TongThanhTien()
        {
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date;

            // 1. Tính tổng doanh thu (theo ngày cho chính xác)
            DataTable dtNgay = new Modify().LayBaoCaoDoanhThuTheoNgay(tuNgay, denNgay);
            decimal tongDoanhThu = 0;

            foreach (DataRow row in dtNgay.Rows)
            {
                if (row["DoanhThu"] != DBNull.Value)
                    tongDoanhThu += Convert.ToDecimal(row["DoanhThu"]);
            }

            // 2. Tính tổng tiền nhập
            decimal tongNhap = new Modify().LayTongTienNhap(tuNgay, denNgay);

            // 3. Tính lợi nhuận = Doanh thu - Nhập
            decimal loiNhuan = tongDoanhThu - tongNhap;

            // 4. Hiển thị kết quả
            lblTongDoanhThu.Text = $"Tổng doanh thu: {tongDoanhThu:N0} đ";
            lblTongLoiNhuan.Text = $"Tổng lợi nhuận: {loiNhuan:N0} đ";
        }
        private void btnThongKe_Click_1(object sender, EventArgs e)
        {
            LoadDoanhThuTheoThang();
            LoadDoanhThuTheoNgay();
            LoadTyLeHinhThucBan();
            LoadTopSanPham();
            TongThanhTien();
         
        }
        private void TkandBc_Click_1(object sender, EventArgs e)
        {
            panelThongke.Visible = !panelThongke.Visible;
            if (panelThongke.Visible)
            {
                panelKhachHang.Visible = false;
                panelLichSuKho.Visible = false;
                panelDonhang.Visible = false;
                panelDaiLy.Visible = false;
            }
        }
        private void XuatBaoCaoRaExcel()
        {
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date;

            var modify = new Modify();

            // Lấy dữ liệu
            DataTable dtThang = modify.LayBaoCaoDoanhThuTheoThang(tuNgay, denNgay);
            DataTable dtNgay = modify.LayBaoCaoDoanhThuTheoNgay(tuNgay, denNgay);
            decimal tongNhap = modify.LayTongTienNhap(tuNgay, denNgay);
            // Lấy đơn hàng theo thời gian
            string queryDH = @"
        SELECT dh.MaDH, kh.Hoten, dh.NgayLap, dh.TongTien, dh.TrangThai
        FROM DonHang dh
        JOIN KhachHang kh ON dh.MaKH = kh.MaKH
        WHERE dh.NgayLap BETWEEN @tuNgay AND @denNgay
        ORDER BY dh.NgayLap DESC";

            DataTable dtDonHang = new DataTable();
            using (SqlConnection conn = ketnoi.GetSqlConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(queryDH, conn);
                cmd.Parameters.AddWithValue("@tuNgay", tuNgay);
                cmd.Parameters.AddWithValue("@denNgay", denNgay);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtDonHang);
            }

            // Lấy báo cáo sản phẩm
            DataTable dtSanPham = modify.LayBaoCaoSanPham(tuNgay, denNgay);
            // Lấy báo cáo khách hàng
            string queryKH = @"
    SELECT kh.MaKH, kh.Hoten, kh.SDT, COUNT(dh.MaDH) AS SoDonHang, SUM(dh.TongTien) AS TongTienMua
    FROM KhachHang kh
    LEFT JOIN DonHang dh ON kh.MaKH = dh.MaKH
    WHERE dh.NgayLap BETWEEN @tuNgay AND @denNgay
    GROUP BY kh.MaKH, kh.Hoten, kh.SDT
    ORDER BY TongTienMua DESC";

            DataTable dtKhachHang = new DataTable();
            using (SqlConnection conn = ketnoi.GetSqlConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(queryKH, conn);
                cmd.Parameters.AddWithValue("@tuNgay", tuNgay);
                cmd.Parameters.AddWithValue("@denNgay", denNgay);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtKhachHang);
            }

            // Tính tổng doanh thu & lợi nhuận từ dtThang
            decimal tongDoanhThu = 0;
            decimal tongLoiNhuan = 0;
            foreach (DataRow row in dtThang.Rows)
            {
                tongDoanhThu += row["DoanhThu"] != DBNull.Value ? Convert.ToDecimal(row["DoanhThu"]) : 0;
                tongLoiNhuan += row["LoiNhuan"] != DBNull.Value ? Convert.ToDecimal(row["LoiNhuan"]) : 0;
            }

            decimal tySuatLN = tongDoanhThu == 0 ? 0 : tongLoiNhuan / tongDoanhThu * 100;

            using (var wb = new XLWorkbook())
            {
                // Sheet 1: Doanh thu theo tháng
                var ws1 = wb.Worksheets.Add("Doanh thu theo tháng");
                ws1.Cell("A1").Value = "Tháng";
                ws1.Cell("B1").Value = "Doanh thu (VNĐ)";
                ws1.Cell("C1").Value = "Lợi nhuận (VNĐ)";
                ws1.Range("A1:C1").Style.Font.Bold = true;

                int r1 = 2;
                foreach (DataRow dr in dtThang.Rows)
                {
                    ws1.Cell(r1, 1).Value = dr["Thang"].ToString();
                    ws1.Cell(r1, 2).Value = Convert.ToDecimal(dr["DoanhThu"]);
                    ws1.Cell(r1, 3).Value = Convert.ToDecimal(dr["LoiNhuan"]);
                    r1++;
                }
                ws1.Columns().AdjustToContents();

                // Sheet 2: Doanh thu theo ngày
                var ws2 = wb.Worksheets.Add("Doanh thu theo ngày");
                ws2.Cell("A1").Value = "Ngày";
                ws2.Cell("B1").Value = "Doanh thu (VNĐ)";
                ws2.Range("A1:B1").Style.Font.Bold = true;

                int r2 = 2;
                foreach (DataRow dr in dtNgay.Rows)
                {
                    ws2.Cell(r2, 1).Value = Convert.ToDateTime(dr["NgayLap"]).ToString("dd/MM/yyyy");
                    ws2.Cell(r2, 2).Value = Convert.ToDecimal(dr["DoanhThu"]);
                    r2++;
                }
                ws2.Columns().AdjustToContents();

                // Sheet 3: Đơn hàng
                var ws3 = wb.Worksheets.Add("Đơn hàng");
                ws3.Cell("A1").Value = "Mã ĐH";
                ws3.Cell("B1").Value = "Khách hàng";
                ws3.Cell("C1").Value = "Ngày lập";
                ws3.Cell("D1").Value = "Tổng tiền (VNĐ)";
                ws3.Cell("E1").Value = "Trạng thái";
                ws3.Range("A1:E1").Style.Font.Bold = true;

                int r3 = 2;
                foreach (DataRow dr in dtDonHang.Rows)
                {
                    ws3.Cell(r3, 1).Value = dr["MaDH"] != DBNull.Value ? Convert.ToInt32(dr["MaDH"]) : 0;
                    ws3.Cell(r3, 2).Value = dr["Hoten"].ToString();
                    ws3.Cell(r3, 3).Value = Convert.ToDateTime(dr["NgayLap"]).ToString("dd/MM/yyyy");
                    ws3.Cell(r3, 4).Value = Convert.ToDecimal(dr["TongTien"]);
                    ws3.Cell(r3, 5).Value = dr["TrangThai"].ToString();
                    r3++;
                }
                ws3.Columns().AdjustToContents();

                // Sheet 4: Báo cáo sản phẩm
                var ws4 = wb.Worksheets.Add("Báo cáo sản phẩm");
                ws4.Cell("A1").Value = "Sản phẩm";
                ws4.Cell("B1").Value = "Số lượng bán";
                ws4.Cell("C1").Value = "Tổng doanh thu";
                ws4.Cell("D1").Value = "Tổng tiền vốn";
                ws4.Cell("E1").Value = "Lợi nhuận";
                ws4.Range("A1:E1").Style.Font.Bold = true;

                int r4 = 2;
                foreach (DataRow dr in dtSanPham.Rows)
                {
                    ws4.Cell(r4, 1).Value = dr["Tensanpham"].ToString();
                    ws4.Cell(r4, 2).Value = Convert.ToInt32(dr["TongSoLuong"]);
                    ws4.Cell(r4, 3).Value = Convert.ToDecimal(dr["TongDoanhThu"]);
                    ws4.Cell(r4, 4).Value = Convert.ToDecimal(dr["TongTienVon"]);
                    ws4.Cell(r4, 5).Value = Convert.ToDecimal(dr["LoiNhuan"]);
                    r4++;
                }
                ws4.Columns(3, 5).Style.NumberFormat.Format = "#,##0 đ";
                ws4.Columns().AdjustToContents();

                // Sheet 5: Tổng kết
                var ws5 = wb.Worksheets.Add("Tổng kết");
                ws5.Cell("A1").Value = "Tổng doanh thu:";
                ws5.Cell("B1").Value = tongDoanhThu;
                ws5.Cell("A2").Value = "Tổng lợi nhuận (tính từ đơn hàng):";
                ws5.Cell("B2").Value = tongLoiNhuan;
                ws5.Cell("A3").Value = "Tổng tiền nhập kho:";
                ws5.Cell("B3").Value = tongNhap;
                ws5.Cell("A4").Value = "Lợi nhuận thực tế:";
                ws5.Cell("B4").Value = tongDoanhThu - tongNhap;
                ws5.Cell("A5").Value = "Tỷ suất lợi nhuận (%):";
                ws5.Cell("B5").Value = tySuatLN;
                ws5.Cell("B5").Style.NumberFormat.Format = "0.##\\%";
                ws5.Range("A1:A5").Style.Font.Bold = true;
                ws5.Columns(2, 2).Style.NumberFormat.Format = "#,##0 đ";
                ws5.Columns().AdjustToContents();
                // Sheet 6: Khách hàng/Đại lý
                var ws6 = wb.Worksheets.Add("Khách hàng");
                ws6.Cell("A1").Value = "Mã KH";
                ws6.Cell("B1").Value = "Họ tên";
                ws6.Cell("C1").Value = "SĐT";
                ws6.Cell("D1").Value = "Số đơn hàng";
                ws6.Cell("E1").Value = "Tổng tiền mua (VNĐ)";
                ws6.Range("A1:E1").Style.Font.Bold = true;

                int r6 = 2;
                foreach (DataRow dr in dtKhachHang.Rows)
                {
                    ws6.Cell(r6, 1).Value = Convert.ToInt32(dr["MaKH"]);
                    ws6.Cell(r6, 2).Value = dr["Hoten"].ToString();
                    ws6.Cell(r6, 3).Value = dr["SDT"].ToString();
                    ws6.Cell(r6, 4).Value = Convert.ToInt32(dr["SoDonHang"]);
                    ws6.Cell(r6, 5).Value = dr["TongTienMua"] != DBNull.Value ? Convert.ToDecimal(dr["TongTienMua"]) : 0;
                    r6++;
                }
                ws6.Columns(5, 5).Style.NumberFormat.Format = "#,##0 đ";
                ws6.Columns().AdjustToContents();

                // Xuất file
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
                    sfd.Title = "Lưu báo cáo tổng hợp";
                    sfd.FileName = $"BaoCaoTongHop_{DateTime.Now:yyyyMMdd}.xlsx";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        wb.SaveAs(sfd.FileName);
                        MessageBox.Show("Xuất báo cáo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }





        private void btnxuatex_Click(object sender, EventArgs e)
        {
            XuatBaoCaoRaExcel();
        }
        #endregion

        private void lblTongDoanhThu_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dtpDenNgay_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtE_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chartSP_Click(object sender, EventArgs e)
        {

        }

        private void panelThongke_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
