using System.Data.SqlClient;

namespace Do_an_P10
{
    public partial class Dangnhap : Form
    {
        private bool isPasswordShown = false;
        public Dangnhap()
        {
            InitializeComponent();
            mk.UseSystemPasswordChar = true;
            piceyes.Image = Properties.Resources.hide; // Mặc định là ảnh mắt đóng
            piceyes.SizeMode = PictureBoxSizeMode.StretchImage;
            piceyes.Cursor = Cursors.Hand;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void qmk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            quenmatkhau qmk = new quenmatkhau();
            qmk.Show();
            this.Hide();
        }
        Modify modify = new Modify();

        private void dn_Click(object sender, EventArgs e)
        {
            String tentk = tk.Text;
            String matk = mk.Text;
            if (tentk.Trim() == "") { MessageBox.Show("Vui lòng nhập tên đăng nhập!"); return; }
            else if (matk.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!");
                return;
            }
            else
            {
                string query = "select * from taikhoan where tentaikhoan= '" + tentk + "' and matkhau= '" + matk + "'";
                if (modify.tk(query).Count() != 0)
                {
                    MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (tentk.Equals("admin"))
                    {
                        QL_EcoStraws ql = new QL_EcoStraws();
                        ql.Show();
                        this.Hide();
                    }
                    else
                    {
                        String sql = "Select * from khachhang where tentaikhoan = '" + tentk + "' ";
                        if (modify.kh(sql).Count() != 0)
                        {
                            MessageBox.Show("Đăng nhập thành công!");
                            EcoStraws ec = new EcoStraws(tentk);
                            ec.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Đăng nhập thành công! Bạn chưa có thông tin! Vui lòng nhập thông tin!");
                            Tt_khachhang tt_Khachhang = new Tt_khachhang(tentk);
                            tt_Khachhang.Show();
                            this.Hide();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Tên dăng nhập hoặc mật khẩu không chính xác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Dangky dk = new Dangky();
            dk.Show();
            this.Hide();
        }

        private void dk_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Dangky dk = new Dangky();
            dk.Show();
            this.Hide();
        }

        private void Dangnhap_Load(object sender, EventArgs e)
        {
            dn.BackColor = Color.Transparent;
        }

        private void piceyes_Click(object sender, EventArgs e)
        {
            if (isPasswordShown)
            {
                mk.UseSystemPasswordChar = true;
                piceyes.Image = Properties.Resources.hide;
                isPasswordShown = false;
            }
            else
            {
                mk.UseSystemPasswordChar = false;
                piceyes.Image = Properties.Resources.view;
                isPasswordShown = true;
            }
        }
    }
}
