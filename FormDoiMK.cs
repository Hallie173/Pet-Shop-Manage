using DoHoaC_.BusinessLogicLayer;
using System;
using System.Linq;
using System.Windows.Forms;

namespace DoHoaC_
{
    public partial class FormDoiMK : Form
    {
        public FormDoiMK()
        {
            InitializeComponent();
        }

        private void buttonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonLuuMK_Click(object sender, EventArgs e)
        {
            string currentUsername = BLL_QLTK.LoaiTaiKhoan ? "admin" : "nhanvien";

            // Lấy thông tin tài khoản từ BLL_QLTK
            TAIKHOAN currentAccount = BLL_QLTK.Instance.GetTaiKhoanByTenTaiKhoan(currentUsername);

            if (currentAccount != null && currentAccount.MatKhau == textBoxMKcu.Text)
            {
                if (!string.IsNullOrEmpty(textBoxMKmoi.Text))
                {
                    if (textBoxMKmoi.Text == textBoxMKmoi2.Text)
                    {
                        if (MessageBox.Show("Xác nhận đổi mật khẩu?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            try
                            {
                                // Thực hiện đổi mật khẩu
                                BLL_QLTK.Instance.ChangePassword(currentUsername, textBoxMKmoi.Text);
                                MessageBox.Show("Đổi mật khẩu thành công.");
                                this.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Lỗi khi đổi mật khẩu: {ex.Message}");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu mới không trùng khớp!");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng điền mật khẩu mới");
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu cũ không đúng!");
            }
        }
    }
}
