using DoHoaC_.BusinessLogicLayer;
using System;
using System.Windows.Forms;

namespace DoHoaC_
{
    public partial class UserControlNhanVien : UserControl
    {
        public UserControlNhanVien()
        {
            InitializeComponent();
            ShowAllNV();
        }

        private void ShowAllNV()
        {
            dataGridView1.DataSource = null;
            BLL_QLNV.Instance.GetAllNhanVien(dataGridView1);
            refreshTextbox();
        }
        
        private void buttonThemNV_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận thêm thông tin nhân viên mới?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                var nv = new NHANVIEN
                {
                    TEN_NHAN_VIEN = textBoxTen.Text,
                    DIACHI = textBoxDiachi.Text,
                    SDT = textBoxSDT.Text,
                    CHUCVU = textBoxChucvu.Text
                };

                try
                {
                    BLL_QLNV.Instance.AddNhanVien(nv);
                    MessageBox.Show("Thêm Nhân viên thành công.");
                    ShowAllNV();
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        row.Selected = false;
                        if (Convert.ToInt32(row.Cells["ID_NV"].Value) == nv.ID_NV)
                        {
                            row.Selected = true; // Chọn toàn bộ hàng
                            DGVViewClick();
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi thêm Nhân viên: {ex.Message}");
                }
            }
        }

        private void buttonSuaNV_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận chỉnh sửa thông tin nhân viên?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int ID_NV = int.Parse(dataGridView1.SelectedRows[0].Cells["ID_NV"].Value.ToString());
                    var nv = new NHANVIEN
                    {
                        TEN_NHAN_VIEN = textBoxTen.Text,
                        DIACHI = textBoxDiachi.Text,
                        SDT = textBoxSDT.Text,
                        CHUCVU = textBoxChucvu.Text
                    };

                    try
                    {
                        BLL_QLNV.Instance.UpdateNhanVien(ID_NV, nv);
                        MessageBox.Show("Cập nhật Nhân viên thành công.");
                        ShowAllNV();
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            row.Selected = false;
                            if (Convert.ToInt32(row.Cells["ID_NV"].Value) == ID_NV)
                            {
                                row.Selected = true; // Chọn toàn bộ hàng
                                DGVViewClick();
                                break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi cập nhật Nhân viên: {ex.Message}");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một Nhân viên để sửa.");
                }
            }
        }

        private void buttonXoaNV_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận xóa nhân viên này?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int ID_NV = int.Parse(dataGridView1.SelectedRows[0].Cells["ID_NV"].Value.ToString());
                    try
                    {
                        BLL_QLNV.Instance.DeleteNhanVien(ID_NV);
                        MessageBox.Show("Xóa Nhân viên thành công.");
                        ShowAllNV();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xóa Nhân viên: {ex.Message}");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một Nhân viên để xóa.");
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DGVViewClick();
        }

        private void textBoxTimkiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string keyword = textBoxTimkiem.Text;
                dataGridView1.DataSource = BLL_QLNV.Instance.SearchNhanVien(keyword);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm Khách Hàng: {ex.Message}");
            }
        }
        private void Refresh_Click(object sender, EventArgs e)
        {
            refreshTextbox();
        }
        private void DGVViewClick()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                textBoxTen.Text = dataGridView1.SelectedRows[0].Cells["TEN_NHAN_VIEN"].Value.ToString();
                textBoxDiachi.Text = dataGridView1.SelectedRows[0].Cells["DIACHI"].Value.ToString();
                textBoxSDT.Text = dataGridView1.SelectedRows[0].Cells["SDT"].Value.ToString();
                textBoxChucvu.Text = dataGridView1.SelectedRows[0].Cells["CHUCVU"].Value.ToString();
            }
        }
        private void refreshTextbox()
        {
            textBoxTen.Clear();
            textBoxDiachi.Clear();
            textBoxSDT.Clear();
            textBoxChucvu.Clear();
        }
    }
}
