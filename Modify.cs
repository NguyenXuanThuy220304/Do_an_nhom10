using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Do_an_P10
{
    internal class Modify
    {
        public Modify() { }
        SqlCommand sqlCommand;// truy vấn
        SqlDataReader dataReader; //dùng để đặt dữ liệu trong bảng
        public List<sanpham> sp(string query)
        {
            List<sanpham> ds = new List<sanpham>();
            using (SqlConnection sqlConnection = ketnoi.GetSqlConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        int maSP = dataReader.GetInt32(0);
                        string tensanpham = dataReader.GetString(1);
                        decimal dongia = dataReader.IsDBNull(4) ? 0 : dataReader.GetDecimal(4);
                        int soluong = dataReader.IsDBNull(5) ? 0 : dataReader.GetInt32(5);
                        string kichthuoc = dataReader.IsDBNull(2) ? "" : dataReader.GetString(2);
                        string mausac = dataReader.IsDBNull(3) ? "" : dataReader.GetString(3);


                        // Hinhanh tạm thời null, sẽ gán sau
                        sanpham spItem = new sanpham(maSP, tensanpham, dongia, soluong, null, kichthuoc, mausac);
                        ds.Add(spItem);
                    }
                }
            }
            return ds;
        }

        public List<khachhang> kh(string query)
        {
            List<khachhang> kh = new List<khachhang>();
            using (SqlConnection sqlConnection = ketnoi.GetSqlConnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    kh.Add(new khachhang(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(3), dataReader.GetString(4), dataReader.GetString(5)));
                }

                sqlConnection.Close();
            }
            return kh;
        }
        public List<taikhoan> tk(string query)
        {
            List<taikhoan> tk = new List<taikhoan>();
            using (SqlConnection sqlConnection = ketnoi.GetSqlConnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    tk.Add(new taikhoan(dataReader.GetString(0), dataReader.GetString(1), dataReader.GetString(2)));
                }

                sqlConnection.Close();
            }
            return tk;
        }
        public bool ThemDaiLy(daily  dl)
        {
            string sql = @"INSERT INTO daily (TenDaiLy, Tensanpham, Diachi, SDT, Email) 
                       VALUES (@tendl, @tensp, @diac, @sdt,@email)";
            using (SqlConnection conn = ketnoi.GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@tendl", dl.Tendaily);
                cmd.Parameters.AddWithValue("@tensp", dl.Tensanpham);
                cmd.Parameters.AddWithValue("@diac", dl.Diachi);
                cmd.Parameters.AddWithValue("@sdt", dl.Sdt);
                cmd.Parameters.AddWithValue("@email", dl.Email);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public int ThemDonHang(donhang dh)
        {
            int maDH = -1;
            using (SqlConnection conn = ketnoi.GetSqlConnection())
            {
                conn.Open();
                string sql = @"INSERT INTO DonHang (NgayLap, MaKH, TongTien) 
                       OUTPUT INSERTED.MaDH 
                       VALUES (@ngaylap, @makh, @tongtien)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ngaylap", dh.NgayLap);
                cmd.Parameters.AddWithValue("@makh", dh.MaKH);
                cmd.Parameters.AddWithValue("@tongtien", dh.TongTien);

                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    maDH = Convert.ToInt32(result);
                }
            }
            return maDH;
        }
        public List<donhang> dh(string query)
        {
            List<donhang> dh = new List<donhang>();
            using (SqlConnection sqlConnection = ketnoi.GetSqlConnection())
            {

                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    dh.Add(new donhang(dataReader.GetDateTime(0), dataReader.GetInt32(1), dataReader.GetDecimal(2)));
                }
                sqlConnection.Close();

            }
            return dh;
        }
        public DataTable GetDataTable(string query)
        {
            using (SqlConnection sqlConnection = ketnoi.GetSqlConnection())
            {
                sqlConnection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }
        public bool ThemSanPham(sanpham sp)
        {
            string query = "INSERT INTO sanpham (MaSP, TenSP, Kichthuoc, Mausac, Giaban, SoLuongTon) " +
                    "VALUES (@MaSP, @TenSP, @Kichthuoc, @Mausac, @Giaban, @SoLuongTon)";
            using (SqlConnection conn = ketnoi.GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaSP", sp.MaSP);
                cmd.Parameters.AddWithValue("@TenSP", sp.Tensanpham);
                cmd.Parameters.AddWithValue("@Kichthuoc", sp.Kichthuoc);
                cmd.Parameters.AddWithValue("@Mausac", sp.Mausac);
                cmd.Parameters.AddWithValue("@Giaban", sp.Dongia);
                cmd.Parameters.AddWithValue("@SoLuongTon", sp.SoLuongTon);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool ThemKhachHang(khachhang kh)
        {
            using (SqlConnection conn = ketnoi.GetSqlConnection())
            {
                conn.Open();

                // 1. Kiểm tra MaKH trùng
                string checkMaKHQuery = "SELECT COUNT(*) FROM khachhang WHERE MaKH = @MaKH";
                using (SqlCommand checkCmd = new SqlCommand(checkMaKHQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@MaKH", kh.MaKH);
                    int count = (int)checkCmd.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show("Mã khách hàng đã tồn tại!");
                        return false;
                    }
                }
                // 2. Nếu có tài khoản, kiểm tra tồn tại trong bảng taikhoan
                if (!string.IsNullOrEmpty(kh.Tentaikhoan))
                {
                    string checkTKQuery = "SELECT COUNT(*) FROM taikhoan WHERE Tentaikhoan = @tk";
                    using (SqlCommand checkTKCmd = new SqlCommand(checkTKQuery, conn))
                    {
                        checkTKCmd.Parameters.AddWithValue("@tk", kh.Tentaikhoan);
                        int countTK = (int)checkTKCmd.ExecuteScalar();
                        // Nếu chưa có thì thêm mới tài khoản
                        if (countTK == 0)
                        {
                            string insertTK = "INSERT INTO taikhoan (Tentaikhoan, Matkhau, Email) VALUES (@tk, @pass, @email)";
                            using (SqlCommand insertTKCmd = new SqlCommand(insertTK, conn))
                            {
                                insertTKCmd.Parameters.AddWithValue("@tk", kh.Tentaikhoan);
                                insertTKCmd.Parameters.AddWithValue("@pass", "123"); // Mật khẩu mặc định
                                insertTKCmd.Parameters.AddWithValue("@email", string.IsNullOrEmpty(kh.Email) ? "unknown@email.com" : kh.Email);
                                insertTKCmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
                // 3. Thêm khách hàng
                string insertKH = @"INSERT INTO khachhang (MaKH, Hoten, SDT, Diachi, Email, Tentaikhoan)
                            VALUES (@MaKH, @HoTen, @SDT, @Diachi, @Email, @Tentaikhoan)";
                using (SqlCommand cmd = new SqlCommand(insertKH, conn))
                {
                    cmd.Parameters.AddWithValue("@MaKH", kh.MaKH);
                    cmd.Parameters.AddWithValue("@HoTen", kh.Hoten);
                    cmd.Parameters.AddWithValue("@SDT", string.IsNullOrEmpty(kh.SDT) ? (object)DBNull.Value : kh.SDT);
                    cmd.Parameters.AddWithValue("@Diachi", string.IsNullOrEmpty(kh.Diachi) ? (object)DBNull.Value : kh.Diachi);
                    cmd.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(kh.Email) ? (object)DBNull.Value : kh.Email);
                    cmd.Parameters.AddWithValue("@Tentaikhoan", string.IsNullOrEmpty(kh.Tentaikhoan) ? (object)DBNull.Value : kh.Tentaikhoan);
                    cmd.ExecuteNonQuery();
                }
            }

            return true;
        }
        public void Commad(string query)// dùng để đăng ký tài khoản
        {
            using (SqlConnection sqlConnection = ketnoi.GetSqlConnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        public static DataRow LayThongTinKhachHang(string tenTaiKhoan)
        {
            using (SqlConnection conn = ketnoi.GetSqlConnection())
            {
                string query = "SELECT * FROM khachhang WHERE Tentaikhoan = @tk";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tk", tenTaiKhoan);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                    return dt.Rows[0];
                else
                    return null;
            }
        }
        public static int ThemDonHangVaLayMa(DateTime ngayLap, int maKH, decimal tongTien)
        {
            string query = "INSERT INTO DonHang (NgayLap, MaKH, TongTien, TrangThai) " +
                           "OUTPUT INSERTED.MaDH " +
                           "VALUES (@ngayLap, @maKH, @tongTien, N'Chưa thanh toán!')";

            using (SqlConnection conn = ketnoi.GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ngayLap", ngayLap);
                cmd.Parameters.AddWithValue("@maKH", maKH);
                cmd.Parameters.AddWithValue("@tongTien", tongTien);

                conn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        public static void ThemChiTietDonHang(int maDonHang, int maSP, string tensp, int soLuong, decimal donGia)
        {
            string query = "INSERT INTO CT_DonHang (MaDH, MaSP, Tensanpham, SoLuong, DonGia) " +
                           "VALUES (@maDonHang, @maSP, @tensp, @soLuong, @donGia)";

            using (SqlConnection conn = ketnoi.GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@maDonHang", maDonHang);
                cmd.Parameters.AddWithValue("@maSP", maSP);
                cmd.Parameters.AddWithValue("@tensp", tensp);
                cmd.Parameters.AddWithValue("@soLuong", soLuong);
                cmd.Parameters.AddWithValue("@donGia", donGia);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static int LayMaKhachHang(string tenTaiKhoan)
        {
            int maKH = -1;

            string query = "SELECT MaKH FROM khachhang WHERE Tentaikhoan = @tk";

            using (SqlConnection conn = ketnoi.GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@tk", tenTaiKhoan);

                conn.Open();
                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    maKH = Convert.ToInt32(result);
                }
            }

            return maKH;
        }
        public static DataTable LayDonHang(int maDonHang)
        {
            DataTable dt = new DataTable();

            string query = "SELECT MaDH, NgayLap, MaKH, TongTien, TrangThai FROM DonHang WHERE MaDH = @maDonHang";

            using (SqlConnection conn = ketnoi.GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@maDonHang", maDonHang);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }

            return dt;
        }
        public static DataTable LayChiTietDonHang(int maDonHang)
        {
            DataTable dt = new DataTable();

            string query = "SELECT MaSP, Tensanpham, SoLuong, DonGia FROM CT_DonHang WHERE MaDH = @maDonHang";

            using (SqlConnection conn = ketnoi.GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@maDonHang", maDonHang);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }

            return dt;
        }
        public static DataTable LayThongTinKhachHang(int maKH)
        {
            DataTable dt = new DataTable();

            string query = "SELECT Hoten, SDT, Diachi, Email FROM khachhang WHERE MaKH = @maKH";

            using (SqlConnection conn = ketnoi.GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@maKH", maKH);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }

            return dt;
        }
        public static void CapNhatTrangThaiDonHang(int maDH, string trangThai)
        {
            string query = "UPDATE DonHang SET TrangThai = @trangThai WHERE MaDH = @maDH";

            using (SqlConnection conn = ketnoi.GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@trangThai", trangThai);
                cmd.Parameters.AddWithValue("@maDH", maDH);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public object ExecuteScalar(string query)
        {
            using (SqlConnection conn = ketnoi.GetSqlConnection())
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    return cmd.ExecuteScalar(); // Trả về giá trị duy nhất
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi truy vấn: " + ex.Message);
                    return null;
                }
            }
        }
        public SanPhamInfo LayThongTinSanPham(int maSP)
        {
            string query = "SELECT KichThuoc, GiaBan FROM sanpham WHERE MaSP = @MaSP";
            using (SqlConnection conn = ketnoi.GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaSP", maSP);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new SanPhamInfo
                    {
                        KichThuoc = reader["KichThuoc"].ToString(),
                        DonGia = Convert.ToDecimal(reader["GiaBan"])
                    };
                }
            }
            return null;
        }
        public static void TruSoLuongSanPham(int maSP, int soLuongMua)
        {
            using (SqlConnection conn = ketnoi.GetSqlConnection())
            {
                conn.Open();
                string sql = "UPDATE sanpham SET SoLuongTon = SoLuongTon - @SoLuongMua WHERE MaSP = @MaSP";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@SoLuongMua", soLuongMua);
                    cmd.Parameters.AddWithValue("@MaSP", maSP);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void GhiLichSuKho(int maSP, int soLuong, string loaiThayDoi, string ghiChu)
        {
            using (SqlConnection conn = ketnoi.GetSqlConnection())
            {
                conn.Open();
                string sql = @"INSERT INTO LichSuKho (MaSP, SoLuong, LoaiThayDoi, GhiChu) 
                       VALUES (@MaSP, @SoLuong, @LoaiThayDoi, @GhiChu)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSP", maSP);
                    cmd.Parameters.AddWithValue("@SoLuong", soLuong);
                    cmd.Parameters.AddWithValue("@LoaiThayDoi", loaiThayDoi);
                    cmd.Parameters.AddWithValue("@GhiChu", ghiChu);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static DataTable TimKiemLichSuKho(DateTime tuNgay, DateTime denNgay)
        {
            using (SqlConnection conn = ketnoi.GetSqlConnection())
            {
                string sql = @"SELECT MaLSK, MaSP, NgayThayDoi, SoLuong, LoaiThayDoi, GhiChu
                       FROM LichSuKho
                       WHERE NgayThayDoi >= @TuNgay AND NgayThayDoi <= @DenNgay
                       ORDER BY NgayThayDoi DESC";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TuNgay", tuNgay.Date); // lấy từ 00:00:00
                    cmd.Parameters.AddWithValue("@DenNgay", denNgay.Date.AddDays(1).AddTicks(-1)); // đến 23:59:59

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }
        public string LayTenSanPham(int maSP)
        {
            string tenSP = null;
            string query = "SELECT TenSP FROM sanpham WHERE MaSP = @MaSP";

            using (SqlConnection conn = ketnoi.GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaSP", maSP);
                conn.Open();
                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    tenSP = result.ToString();
                }
            }

            return tenSP;
        }
        public bool ExecuteNonQuery(string query)
        {
            using (SqlConnection conn = ketnoi.GetSqlConnection())
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi truy vấn: " + ex.Message);
                    return false;
                }
            }
        }

    }
}