using System;
using System.Linq;
using System.Windows.Forms;
using DoHoaC_.BusinessLogicLayer;

namespace DoHoaC_
{
    public partial class FormDonHangChiTiet : Form
    {
        private int currentIddh;
        public event EventHandler TaoDonHangCreated;

        public FormDonHangChiTiet(int iddh, bool trangthai)
        {
            InitializeComponent();
            if(iddh != -1)
            {
                if (trangthai)
                {
                    DisableControlsForEditing(); // Tắt các control khi không cho phép chỉnh sửa
                }
                else
                {
                    textBoxIDDH.Enabled = false; // Không cho phép chỉnh sửa ID đơn hàng
                }
            }
            currentIddh = iddh;
            ShowDHCT(currentIddh);
        }

        private void DisableControlsForEditing()
        {
            textBoxIDDH.Enabled = false;
            comboBoxIDKH.Enabled = false;
            comboBoxIDNV.Enabled = false;
            comboBoxTenKH.Enabled = false;
            comboBoxTenNV.Enabled = false;
            comboBoxDM.Enabled = false;
            comboBoxIDSP.Enabled = false;
            comboBoxTenSP.Enabled = false;
            buttonThemSP.Enabled = false;
            dataGridView1.Enabled = false;
            TaoBT.Enabled = false;
            NhapBT.Enabled = false;
        }

        private void ShowDHCT(int iddh)
        {
            if (iddh != -1)
            {
                BLL_QLDHCT.Instance.GetDHCT(iddh, dataGridView1);
                textBoxIDDH.Text = currentIddh.ToString();
                comboBoxTenKH.DataSource = BLL_QLDHCT.Instance.ShowComBoBoxTenKH();
                comboBoxTenNV.DataSource = BLL_QLDHCT.Instance.ShowComBoBoxTenNV();
                comboBoxDM.DataSource = BLL_QLSP.Instance.ShowUniqueDanhMuc();
                comboBoxTenKH.Text = BLL_QLDH.Instance.GetKHNV(iddh, "kh");
                comboBoxTenNV.SelectedItem = BLL_QLDH.Instance.GetKHNV(iddh, "nv");
                textBoxThanhToan.Text = BLL_QLDHCT.Instance.TongThanhToan(iddh).ToString();
            }
            else
            {
                BLL_QLDHCT.Instance.GetDHCT(0, dataGridView1);
                comboBoxTenKH.DataSource = BLL_QLDHCT.Instance.ShowComBoBoxTenKH();
                comboBoxTenNV.DataSource = BLL_QLDHCT.Instance.ShowComBoBoxTenNV();
                comboBoxDM.DataSource = BLL_QLSP.Instance.ShowUniqueDanhMuc();
                textBoxThanhToan.Text = BLL_QLDHCT.Instance.TongThanhToan(iddh).ToString();
            }
        }

        private void HuyBT_Click(object sender, EventArgs e)
        {
            if (currentIddh == -1)
            {
                if (MessageBox.Show("Bạn muốn hủy đơn hàng này không?", "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    BLL_QLDHCT.Instance.DeleteDHCT(int.Parse(textBoxIDDH.Text));
                    BLL_QLDH.Instance.DeleteDH(int.Parse(textBoxIDDH.Text));
                    TaoDonHangCreated?.Invoke(this, EventArgs.Empty);
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        private void NhapBT_Click(object sender, EventArgs e)
        {
            var dh = new DONHANG
            {
                ID_DH = int.Parse(textBoxIDDH.Text),
                ID_NV = int.Parse(comboBoxIDNV.Text),
                TEN_NHAN_VIEN = comboBoxTenNV.Text,
                ID_KH = int.Parse(comboBoxIDKH.Text),
                TEN_KHACH_HANG = comboBoxTenKH.Text,
                NGAY_MUA = DateTime.Now,
                TONG_THANH_TOAN = (int)BLL_QLDHCT.Instance.TongThanhToan(int.Parse(textBoxIDDH.Text)),
                TRANG_THAI = false,
            };

            try
            {
                if (BLL_QLDH.Instance.KiemTraDHTonTai(int.Parse(textBoxIDDH.Text)))
                {
                    BLL_QLDH.Instance.UpdateDH(dh);
                }
                else
                {
                    BLL_QLDH.Instance.AddDH(dh);
                }
                TaoDonHangCreated?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm & cập nhật đơn hàng: {ex.Message}");
            }

            this.Close();
        }

        private void TaoBT_Click(object sender, EventArgs e)
        {
            var dh = new DONHANG
            {
                ID_DH = int.Parse(textBoxIDDH.Text),
                ID_NV = int.Parse(comboBoxIDNV.Text),
                TEN_NHAN_VIEN = comboBoxTenNV.Text,
                ID_KH = int.Parse(comboBoxIDKH.Text),
                TEN_KHACH_HANG = comboBoxTenKH.Text,
                NGAY_MUA = DateTime.Now,
                TONG_THANH_TOAN = (int)BLL_QLDHCT.Instance.TongThanhToan(int.Parse(textBoxIDDH.Text)),
                TRANG_THAI = true,
            };

            try
            {
                if (BLL_QLDH.Instance.KiemTraDHTonTai(int.Parse(textBoxIDDH.Text)))
                {
                    BLL_QLDH.Instance.UpdateDH(dh);
                }
                else
                {
                    BLL_QLDH.Instance.AddDH(dh);
                }
                TaoDonHangCreated?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm & cập nhật đơn hàng: {ex.Message}");
            }

            this.Close();
        }
        int count = 0;
        private void buttonThemSP_Click(object sender, EventArgs e)
        {
            // Create DONHANGCHITIET object
            var dhct = new DONHANGCHITIET
            {
                ID_DH = int.Parse(textBoxIDDH.Text),
                ID_SP = int.Parse(comboBoxIDSP.Text),
                TEN_SAN_PHAM = comboBoxTenSP.Text,
                NGAY_MUA = DateTime.Now,
                DON_VI = BLL_QLDHCT.Instance.GetDonVi(int.Parse(textBoxIDDH.Text)),
                DON_GIA = (int)(BLL_QLDHCT.Instance.GetDonGia(int.Parse(comboBoxIDSP.Text)) ?? 0),
                SO_LUONG = (int)domainSL.Value,
                THANH_TIEN = (int)(BLL_QLDHCT.Instance.ThanhTien(int.Parse(comboBoxIDSP.Text), (int)domainSL.Value) ?? 0),
                TONG_THANH_TOAN = (int)(BLL_QLDHCT.Instance.TongThanhToan(int.Parse(textBoxIDDH.Text)) ?? 0),
            };

            // Create DONHANG object
            var dh = new DONHANG
            {
                ID_DH = int.Parse(textBoxIDDH.Text),
                ID_NV = int.Parse(comboBoxIDNV.Text),
                TEN_NHAN_VIEN = comboBoxTenNV.Text,
                ID_KH = int.Parse(comboBoxIDKH.Text),
                TEN_KHACH_HANG = comboBoxTenKH.Text,
                NGAY_MUA = DateTime.Now,
                TONG_THANH_TOAN = (int)(BLL_QLDHCT.Instance.TongThanhToan(int.Parse(textBoxIDDH.Text)) ?? 0),
                TRANG_THAI = false,
            };

            try
            {
                // Check if SO_LUONG is not zero
                if (dhct.SO_LUONG != 0)
                {
                    // Handle different scenarios based on currentIddh
                    if (currentIddh == -1)
                    {
                        if (!BLL_QLDH.Instance.KiemTraDHTonTai(dhct.ID_DH))
                        {
                            BLL_QLDH.Instance.AddDH(dh);
                            AddSP(dhct);
                            count++;
                            textBoxIDDH.Enabled = false;
                        }
                        else if (BLL_QLDH.Instance.KiemTraDHTonTai(dhct.ID_DH) && count != 0)
                        {
                            AddSP(dhct);
                        }
                        else
                        {
                            MessageBox.Show("Mã đơn hàng đã tồn tại", "Error");
                        }
                    }
                    else
                    {
                        AddSP(dhct);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn số lượng sản phẩm", "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm Sản phẩm: {ex.Message}");
            }
        }


        private void AddSP(DONHANGCHITIET dhct)
        {
            if (BLL_QLDHCT.Instance.KiemTraSPTonTai(dhct.ID_DH, dhct.ID_SP))
            {
                BLL_QLDHCT.Instance.UpdateSoLuong(dhct.ID_DH, dhct.ID_SP, (int)dhct.SO_LUONG);
                BLL_QLDHCT.Instance.GetDHCT(dhct.ID_DH, dataGridView1);
            }
            else
            {
                BLL_QLDHCT.Instance.AddSP_DHCT(dhct); // Thêm mới
                BLL_QLDHCT.Instance.GetDHCT(dhct.ID_DH, dataGridView1);
            }
            textBoxThanhToan.Text = BLL_QLDHCT.Instance.TongThanhToan(int.Parse(textBoxIDDH.Text)).ToString();
        }


        private void comboBoxDM_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxTenSP.DataSource = BLL_QLDHCT.Instance.ShowComboBoxSanPham(comboBoxDM.Text);
        }

        private void comboBoxTenSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxIDSP.DataSource = BLL_QLDHCT.Instance.ShowComBoBoxIDSP(comboBoxTenSP.Text);
        }

        private void comboBoxTenNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxIDNV.DataSource = BLL_QLDHCT.Instance.ShowComboBoxIDNV(comboBoxTenNV.Text);
        }

        private void comboBoxTenKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxIDKH.DataSource = BLL_QLDHCT.Instance.ShowComboBoxIDKH(comboBoxTenKH.Text);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("Bạn muốn xóa sản phẩm này?", "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                BLL_QLDHCT.Instance.XoaSP_DHCT(int.Parse(dataGridView1.Rows[e.RowIndex].Cells["ID_SP"].Value.ToString()), int.Parse(textBoxIDDH.Text));
                ShowDHCT(currentIddh);
            }
        }
    }
}
        