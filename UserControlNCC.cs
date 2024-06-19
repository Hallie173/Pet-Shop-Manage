using DoHoaC_.BusinessLogicLayer;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DoHoaC_
{
    public partial class UserControlNCC : UserControl
    {
        public UserControlNCC()
        {
            InitializeComponent();
            ShowAllNCC();
        }

        public void ShowAllNCC()
        {
            dataGridView1.DataSource = null;
            BLL_QLNCC.Instance.GetAllNCC(dataGridView1);
            refreshTextbox();
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận thêm thông tin nhà cung cấp mới?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                var ncc = new NHACUNGCAP
                {
                    TEN_NHA_CUNG_CAP = textBoxTen.Text,
                    DIACHI = textBoxDiachi.Text,
                    SDT = textBoxSDT.Text,
                    INFOR = textBoxMota.Text
                };

                try
                {
                    BLL_QLNCC.Instance.AddNCC(ncc); // Thêm Nhà Cung Cấp mới
                    MessageBox.Show("Thêm Nhà Cung Cấp thành công.");
                    ShowAllNCC(); // Tải lại dữ liệu sau khi thêm
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        row.Selected = false;
                        if (Convert.ToInt32(row.Cells["ID_NCC"].Value) == ncc.ID_NCC)
                        {
                            row.Selected = true; // Chọn toàn bộ hàng
                            DGVViewClick();
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi thêm Nhà Cung Cấp: {ex.Message}");
                }
            }
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận chỉnh sửa thông tin nhà cung cấp?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int ID_NCC = (int)dataGridView1.SelectedRows[0].Cells["ID_NCC"].Value;
                    var ncc = new NHACUNGCAP
                    {
                        TEN_NHA_CUNG_CAP = textBoxTen.Text,
                        DIACHI = textBoxDiachi.Text,
                        SDT = textBoxSDT.Text,
                        INFOR = textBoxMota.Text
                    };

                    try
                    {
                        BLL_QLNCC.Instance.UpdateNCC(ID_NCC, ncc); // Cập nhật thông tin Nhà Cung Cấp
                        MessageBox.Show("Cập nhật Nhà Cung Cấp thành công.");
                        ShowAllNCC(); // Tải lại dữ liệu sau khi sửa
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            row.Selected = false;
                            if (Convert.ToInt32(row.Cells["ID_NCC"].Value) == ID_NCC)
                            {
                                row.Selected = true; // Chọn toàn bộ hàng
                                DGVViewClick();
                                break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi cập nhật Nhà Cung Cấp: {ex.Message}");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một Nhà Cung Cấp để sửa.");
                }
            }
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận xóa nhà cung cấp này?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int ID_NCC = (int)dataGridView1.SelectedRows[0].Cells["ID_NCC"].Value;
                    try
                    {
                        BLL_QLNCC.Instance.DeleteNCC(ID_NCC); // Xóa Nhà Cung Cấp
                        MessageBox.Show("Xóa Nhà Cung Cấp thành công.");
                        ShowAllNCC(); // Tải lại dữ liệu sau khi xóa
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xóa Nhà Cung Cấp: {ex.Message}");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một Nhà Cung Cấp để xóa.");
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) // Sự kiện click vào một ô trong DataGridView
        {
            DGVViewClick();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string keyword = textBoxSearch.Text;
                dataGridView1.DataSource = BLL_QLNCC.Instance.SearchNCC(keyword);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm Nhà Cung Cấp: {ex.Message}");
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
                textBoxTen.Text = dataGridView1.SelectedRows[0].Cells["TEN_NHA_CUNG_CAP"].Value.ToString();
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
