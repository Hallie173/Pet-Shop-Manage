using DoHoaC_.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoHoaC_
{
    public partial class FormHeThong : Form
    {
        public bool isExit = true;
        public FormHeThong()
        {
            InitializeComponent();
            donHang1.DonHangChiTietOpened += DonHang_DonHangChiTietOpened;
        }
        private void DonHang_DonHangChiTietOpened(object sender, FormDonHangChiTiet e)
        {
            sanPham1.HandleDonHangChiTietOpened(e);
        }
        private void BThethong_Click(object sender, EventArgs e)
        {
            ShowUserControl(heThong1);
            SetButtonColor(BThethong);
        }
        private void BTSanPham_Click(object sender, EventArgs e)
        {
            ShowUserControl(sanPham1);
            SetButtonColor(BTSanPham);
        }
        private void BTdonhang_Click(object sender, EventArgs e)
        {
            ShowUserControl(donHang1);
            SetButtonColor(BTdonhang);
        }
        private void BTkhachhang_Click(object sender, EventArgs e)
        {
            ShowUserControl(khachHang1);
            SetButtonColor(BTkhachhang);
        }
        private void BTncc_Click(object sender, EventArgs e)
        {
            ShowUserControl(ncc1);
            SetButtonColor(BTncc);
        }
        private void BTnhanvien_Click(object sender, EventArgs e)
        {
            ShowUserControl(nhanVien1);
            SetButtonColor(BTnhanvien);
        }
        private void FormHeThong_Load(object sender, EventArgs e)
        {
            PhanQuyen();
            ShowUserControl(heThong1);
            SetButtonColor(BThethong);
        }
        private void BTthongke_Click(object sender, EventArgs e)
        {
            ShowUserControl(thongKe1);
            SetButtonColor(BTthongke);
        }
        private void ShowUserControl(UserControl userControl)
        {
            heThong1.Hide();
            sanPham1.Hide();
            khachHang1.Hide();
            ncc1.Hide();
            nhanVien1.Hide();
            donHang1.Hide();
            thongKe1.Hide();
            userControl.Show();
        }
        private void SetButtonColor(Button button)
        {
            BTthongke.BackColor = Color.FromArgb(5, 63, 92);
            BTSanPham.BackColor = Color.FromArgb(5, 63, 92);
            BThethong.BackColor = Color.FromArgb(5, 63, 92);
            BTkhachhang.BackColor = Color.FromArgb(5, 63, 92);
            BTncc.BackColor = Color.FromArgb(5, 63, 92);
            BTnhanvien.BackColor = Color.FromArgb(5, 63, 92);
            BTdonhang.BackColor = Color.FromArgb(5, 63, 92);
            button.BackColor = Color.AliceBlue;

            BTthongke.ForeColor = Color.FromArgb(224, 224, 224);
            BTSanPham.ForeColor = Color.FromArgb(224, 224, 224);
            BThethong.ForeColor = Color.FromArgb(224, 224, 224);
            BTkhachhang.ForeColor = Color.FromArgb(224, 224, 224);
            BTncc.ForeColor = Color.FromArgb(224, 224, 224);
            BTnhanvien.ForeColor = Color.FromArgb(224, 224, 224);
            BTdonhang.ForeColor = Color.FromArgb(224, 224, 224);
            button.ForeColor = Color.Black;
        }
        void PhanQuyen()
        {
            if (BLL_QLTK.LoaiTaiKhoan == false)
            {
                BTnhanvien.Enabled = false;
                BTncc.Enabled = false;
            }
        }
        private void FormHeThong_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isExit == true)
            {
                if (MessageBox.Show("Bạn muốn thoát chương trình không?", "Cảnh báo", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }
        private void FormHeThong_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isExit == true)
            {
                Application.Exit();
            }
        }
        
    }
}