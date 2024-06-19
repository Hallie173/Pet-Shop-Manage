using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using DoHoaC_.BusinessLogicLayer;
namespace DoHoaC_
{
    public partial class UserControlKhachHang : UserControl
    {
        public UserControlKhachHang()
        {
            InitializeComponent();
            ShowAllKH();
        }

        public void ShowAllKH()
        {
            dataGridView1.DataSource = null;
            BLL_QLKH.Instance.GetAllKhachHang(dataGridView1);
            refreshTextbox();
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận thêm thông tin khách hàng mới?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                var kh = new KHACHHANG
                {
                    TEN_KHACH_HANG = textBoxTen.Text,
                    DIACHI = textBoxDiachi.Text,
                    SDT = textBoxSDT.Text,
                    INFOR = textBoxMota.Text
                };

                try
                {
                    BLL_QLKH.Instance.AddKH(kh); // Thêm Khách hàng mới
                    MessageBox.Show("Thêm Khách Hàng thành công.");
                    ShowAllKH(); // Reload data after adding
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        row.Selected = false;
                        if (Convert.ToInt32(row.Cells["ID_KH"].Value) == kh.ID_KH)
                        {
                            row.Selected = true; // Chọn toàn bộ hàng
                            DGVViewClick();
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi thêm Khách Hàng: {ex.Message}");
                }
            }
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận chỉnh sửa thông tin khách hàng?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int ID_KH = (int) dataGridView1.SelectedRows[0].Cells["ID_KH"].Value;
                    var kh = new KHACHHANG
                    {
                        TEN_KHACH_HANG = textBoxTen.Text,
                        DIACHI = textBoxDiachi.Text,
                        SDT = textBoxSDT.Text,
                        INFOR = textBoxMota.Text
                    };

                    try
                    {
                        BLL_QLKH.Instance.UpdateKH(ID_KH, kh); // Update Khách Hàng
                        MessageBox.Show("Cập nhật Khách Hàng thành công.");
                        ShowAllKH(); // Reload data after updating
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            row.Selected = false;
                            if (Convert.ToInt32(row.Cells["ID_KH"].Value) == ID_KH)
                            {
                                row.Selected = true; // Chọn toàn bộ hàng
                                DGVViewClick();
                                break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi cập nhật Khách Hàng: {ex.Message}");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một Khách Hàng để sửa.");
                }
            }
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận xóa khách hàng này?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int ID_KH = (int)dataGridView1.SelectedRows[0].Cells["ID_KH"].Value;
                    try
                    {
                        BLL_QLKH.Instance.DeleteKH(ID_KH); // Xóa Khách Hàng
                        MessageBox.Show("Xóa Khách Hàng thành công.");
                        ShowAllKH(); // Reload data after deletion
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xóa Khách Hàng: {ex.Message}");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một Khách Hàng để xóa.");
                }
            }
        }
        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DGVViewClick();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string keyword = textBoxSearch.Text;
                dataGridView1.DataSource = BLL_QLKH.Instance.SearchKH(keyword);
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
                textBoxTen.Text = dataGridView1.SelectedRows[0].Cells["TEN_KHACH_HANG"].Value.ToString();
                textBoxDiachi.Text = dataGridView1.SelectedRows[0].Cells["DIACHI"].Value.ToString();
                textBoxSDT.Text = dataGridView1.SelectedRows[0].Cells["SDT"].Value.ToString();
                textBoxMota.Text = dataGridView1.SelectedRows[0].Cells["INFOR"].Value.ToString();
            }
        }
        private void refreshTextbox()
        {
            textBoxTen.Clear();
            textBoxDiachi.Clear();
            textBoxSDT.Clear();
            textBoxMota.Clear();
        }
    }
}
