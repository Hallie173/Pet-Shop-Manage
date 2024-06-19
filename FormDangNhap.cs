using DoHoaC_.BusinessLogicLayer;
using System;
using System.Windows.Forms;

namespace DoHoaC_
{
    public partial class FormDangNhap : Form
    {
        public static FormDangNhap Instance { get; private set; }

        public FormDangNhap()
        {
            InitializeComponent();
            Instance = this;
        }

        private void DangNhapBT_Click(object sender, EventArgs e)
        {
            try
            {
                string tenTaiKhoan = textBoxTenDN.Text;
                string matKhau = textBoxMatkhau.Text;

                if (string.IsNullOrEmpty(tenTaiKhoan) || string.IsNullOrEmpty(matKhau))
                {
                    throw new ArgumentException("Tên tài khoản và mật khẩu không được để trống.");
                }

                bool isValidLogin = BLL_QLTK.Instance.KiemTraDangNhap(tenTaiKhoan, matKhau);

                if (isValidLogin)
                {
                    bool loaiTaiKhoan = BLL_QLTK.Instance.GetLoaiTaiKhoan(tenTaiKhoan) ?? false;
                    textBoxTenDN.Text = "";
                    textBoxMatkhau.Text = "";
                    textBoxTenDN.Focus();
                    this.Hide();
                    FormHeThong f = new FormHeThong();
                    f.Show();
                }
                else
                {
                    MessageBox.Show("Sai tên tài khoản hoặc mật khẩu");
                    textBoxTenDN.Focus();
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
                textBoxTenDN.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đăng nhập không thành công. Vui lòng thử lại sau." + ex.Message);
                textBoxTenDN.Focus();
            }
        }

        private void ThoatBT_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đóng ứng dụng: " + ex.Message);
            }
        }

        private void textBoxMatkhau_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    DangNhapBT_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đăng nhập không thành công. Vui lòng thử lại sau." + ex.Message);
                textBoxTenDN.Focus();
            }
        }

        private void FormDangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đóng ứng dụng: " + ex.Message);
            }
        }
    }
}
