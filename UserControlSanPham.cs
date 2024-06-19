using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using DoHoaC_.BusinessLogicLayer;

namespace DoHoaC_
{
    public partial class UserControlSanPham : UserControl
    {
        public UserControlSanPham()
        {
            InitializeComponent();
            ShowAllSanPham();
            ShowComboBox();
        }
        public void HandleDonHangChiTietOpened(FormDonHangChiTiet f)
        {
            f.TaoDonHangCreated += (s, ev) => ShowAllSanPham();
        }
        public void ShowAllSanPham()
        {
                dataGridView.DataSource = null;
                BLL_QLSP.Instance.GetAllSanPham(dataGridView); 
                refreshTextbox();
        }
        private void buttonThem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận thêm thông tin sản phẩm mới?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                var sanPham = new SANPHAM
                {
                    TEN_DANH_MUC = comboBoxDanhMuc.Text,
                    TEN_SAN_PHAM = textBoxTen.Text,
                    ID_NCC = int.TryParse(cbbIdNCC.Text, out var idNcc) ? idNcc : 0,
                    DON_VI = textBoxDonVi.Text,
                    DON_GIA = decimal.TryParse(textBoxDonGia.Text, out var donGia) ? donGia : 0,
                    SO_LUONG_CON_LAI = int.TryParse(textBoxSL.Text, out var soLuong) ? soLuong : 0
                };
                try
                {
                    BLL_QLSP.Instance.AddSP(sanPham); // Thêm Sản Phẩm mới
                    MessageBox.Show("Thêm Sản Phẩm thành công.");
                    ShowComboBox();
                    ShowAllSanPham();

                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        row.Selected = false;
                        if (Convert.ToInt32(row.Cells["ID_SP"].Value) == sanPham.ID_SP)
                        {
                            row.Selected = true; // Chọn toàn bộ hàng
                            DGVViewClick();
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi thêm Sản Phẩm: {ex.Message}");
                }
            }
        }
        private void buttonSua_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận sửa thông tin sản phẩm?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (dataGridView.SelectedRows.Count > 0)
                {
                    int idSp = (int)dataGridView.SelectedRows[0].Cells["ID_SP"].Value;
                    var sanPham = new SANPHAM
                    {
                        //ID_SP = idSp,
                        TEN_DANH_MUC = comboBoxDanhMuc.Text,
                        TEN_SAN_PHAM = textBoxTen.Text,
                        ID_NCC = int.TryParse(cbbIdNCC.Text, out var idNcc) ? idNcc : 0,
                        DON_VI = textBoxDonVi.Text,
                        DON_GIA = decimal.TryParse(textBoxDonGia.Text, out var donGia) ? donGia : 0,
                        SO_LUONG_CON_LAI = int.TryParse(textBoxSL.Text, out var soLuong) ? soLuong : 0
                    };
                    try
                    {
                        BLL_QLSP.Instance.UpdateSP(idSp, sanPham); // Cập nhật thông tin Sản Phẩm
                        MessageBox.Show("Cập nhật Sản Phẩm thành công.");
                        ShowComboBox();
                        ShowAllSanPham(); // Tải lại dữ liệu sau khi sửa
                        
                        foreach (DataGridViewRow row in dataGridView.Rows)
                        {
                            row.Selected = false;
                            if (Convert.ToInt32(row.Cells["ID_SP"].Value) == idSp)
                            {
                                row.Selected = true; // Chọn toàn bộ hàng
                                DGVViewClick();
                                break;
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi cập nhật Sản Phẩm: {ex.Message}");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một Sản Phẩm để sửa.");
                }
            }
        }
        private void buttonXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận xóa thông tin sản phẩm?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (dataGridView.SelectedRows.Count > 0)
                {
                    int idSp = (int)dataGridView.SelectedRows[0].Cells["ID_SP"].Value;
                    try
                    {
                        BLL_QLSP.Instance.DeleteSP(idSp); // Xóa Sản Phẩm
                        MessageBox.Show("Xóa Sản Phẩm thành công.");
                        ShowAllSanPham(); // Tải lại dữ liệu sau khi xóa
                        ShowComboBox();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xóa Sản Phẩm: {ex.Message}");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một Sản Phẩm để xóa.");
                }
            }
        }
        public void refreshTextbox()
        {
            textBoxTen.Text = string.Empty;
            cbbIdNCC.SelectedIndex = -1; // Clear ComboBox selection
            comboBoxDanhMuc.SelectedIndex = -1;
            textBoxDonVi.Text = string.Empty;
            textBoxDonGia.Text = string.Empty;
            textBoxSL.Text = string.Empty;
        }
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DGVViewClick();
        }
        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = textBoxSearch.Text;
            dataGridView.DataSource = BLL_QLSP.Instance.SearchSP(keyword);
        }
        private void Search_Danhmuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = Search_Danhmuc.Text;
            if (str == "Tất cả")
            {
                ShowAllSanPham();
            }
            else
            {
                dataGridView.DataSource = BLL_QLSP.Instance.SearchSP(str);
            }
        }
        public void ShowComboBox()
        {
            comboBoxDanhMuc.DataSource = BLL_QLSP.Instance.ShowUniqueDanhMuc();
            var danhMucList = BLL_QLSP.Instance.ShowUniqueDanhMuc().Prepend("Tất cả").ToList();
            Search_Danhmuc.DataSource = danhMucList;
            cbbIdNCC.DataSource = BLL_QLSP.Instance.ShowIDNCC();
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            refreshTextbox();
        }
        private void DGVViewClick()
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                comboBoxDanhMuc.Text = dataGridView.SelectedRows[0].Cells["TEN_DANH_MUC"].Value.ToString();
                textBoxTen.Text = dataGridView.SelectedRows[0].Cells["TEN_SAN_PHAM"].Value.ToString();
                cbbIdNCC.Text = dataGridView.SelectedRows[0].Cells["ID_NCC"].Value.ToString();
                textBoxDonVi.Text = dataGridView.SelectedRows[0].Cells["DON_VI"].Value.ToString();
                textBoxDonGia.Text = dataGridView.SelectedRows[0].Cells["DON_GIA"].Value.ToString();
                textBoxSL.Text = dataGridView.SelectedRows[0].Cells["SO_LUONG_CON_LAI"].Value.ToString();
            }
        }
    }
}