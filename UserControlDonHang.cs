using DoHoaC_.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DoHoaC_
{
    public partial class DonHang : UserControl
    {
        private BLL_QLDH _bllQLDH;

        public DonHang()
        {
            InitializeComponent();
            _bllQLDH = new BLL_QLDH();
            ShowDH();
        }

        public event EventHandler<FormDonHangChiTiet> DonHangChiTietOpened;

        public void ShowDH()
        {
            _bllQLDH.GetDH(dataGridView1);
            textBoxTenKH.Clear();
            textBoxTenNV.Clear();
            textBoxTongTien.Clear();
            RBTDaTT.Checked = false;
            RBTChuaTT.Checked = false;
        }

        private void ThemBT_Click(object sender, EventArgs e)
        {
            try
            {
                FormDonHangChiTiet f = new FormDonHangChiTiet(-1, false);
                DonHangChiTietOpened?.Invoke(this, f);
                f.TaoDonHangCreated += (s, ev) => ShowDH();
                f.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm Đơn hàng: {ex.Message}");
            }
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                bool trangthai = Convert.ToBoolean(dataGridView1.SelectedRows[0].Cells["TRANG_THAI"].Value);
                int iddh = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID_DH"].Value);
                try
                {
                    FormDonHangChiTiet f = new FormDonHangChiTiet(iddh, trangthai);
                    f.TaoDonHangCreated += (s, ev) => ShowDH();
                    DonHangChiTietOpened?.Invoke(this, f);
                    f.Show();
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        row.Selected = false;
                        if (Convert.ToInt32(row.Cells["ID_DH"].Value) == iddh)
                        {
                            row.Selected = true; // Chọn toàn bộ hàng
                            //DGVViewClick();
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi cập nhật Đơn hàng: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một Đơn hàng để sửa.");
            }
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                bool trangthai = Convert.ToBoolean(dataGridView1.SelectedRows[0].Cells["TRANG_THAI"].Value);
                int iddh = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID_DH"].Value);
                try
                {
                    if (!BLL_QLTK.LoaiTaiKhoan && trangthai)
                    {
                        MessageBox.Show("Bạn không có quyền hạn xóa đơn hàng đã được thanh toán");
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa đơn hàng này?", "Xác nhận xóa",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            _bllQLDH.DeleteDH(iddh);
                            ShowDH();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa Đơn hàng: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một Đơn hàng để xóa.");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                textBoxTenKH.Text = dataGridView1.SelectedRows[0].Cells["TEN_KHACH_HANG"].Value.ToString();
                textBoxTenNV.Text = dataGridView1.SelectedRows[0].Cells["TEN_NHAN_VIEN"].Value.ToString();
                textBoxTongTien.Text = dataGridView1.SelectedRows[0].Cells["TONG_THANH_TOAN"].Value.ToString();
                object trangThaiValue = dataGridView1.SelectedRows[0].Cells["TRANG_THAI"].Value;
                if (trangThaiValue != DBNull.Value)
                {
                    bool trangThai = Convert.ToBoolean(trangThaiValue);
                    RBTDaTT.Checked = trangThai;
                    RBTChuaTT.Checked = !trangThai;
                }
                else
                {
                    RBTDaTT.Checked = false;
                    RBTChuaTT.Checked = true;
                }
                object ngayMuaValue = dataGridView1.SelectedRows[0].Cells["NGAY_MUA"].Value;
                if (ngayMuaValue != DBNull.Value)
                {
                    DateTime ngayMua = Convert.ToDateTime(ngayMuaValue);
                    dateTimePicker1.Value = ngayMua;
                }
                else
                {
                    dateTimePicker1.Value = DateTime.Now;
                }
            }
        }

        private void textBoxFind_TextChanged(object sender, EventArgs e)
        {
            string keyword = textBoxFind.Text;
            dataGridView1.DataSource = _bllQLDH.SearchDH(keyword);
        }
    }
}
