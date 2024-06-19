using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DoHoaC_.DataAccessLayer;

namespace DoHoaC_.BusinessLogicLayer
{
    public class BLL_QLDHCT
    {
        private DAL_QLDHCT _dal;

        public BLL_QLDHCT()
        {
            _dal = new DAL_QLDHCT();
        }
        public static BLL_QLDHCT Instance { get; } = new BLL_QLDHCT();
        public void GetDHCT(int iddh, DataGridView dgv)
        {
            dgv.DataSource = _dal.GetDHCT(iddh);
        }

        public void AddSP_DHCT(DONHANGCHITIET dhct)
        {
            if (KiemTraSoLuongSPTrongKho(dhct.ID_DH, dhct.ID_SP, dhct.SO_LUONG ?? 0))
            {
                _dal.AddSP_DHCT(dhct);
            }
            else
            {
                throw new Exception("Vượt quá số lượng trong kho");
            }
        }

        public void UpdateSoLuong(int ID_DH, int ID_SP, int soLuong)
        {
            if (KiemTraSoLuongSPTrongKho(ID_DH, ID_SP, soLuong))
            {
                _dal.UpdateSoLuong(ID_DH, ID_SP, soLuong);
            }
            else
            {
                throw new Exception("Vượt quá số lượng trong kho");
            }
        }

        public void XoaSP_DHCT(int ID_SP, int ID_DH)
        {
            _dal.XoaSP_DHCT(ID_SP, ID_DH);
        }

        public List<string> ShowComBoBoxTenNV()
        {
            return _dal.ShowComBoBoxTenNV();
        }

        public List<string> ShowComBoBoxTenKH()
        {
            return _dal.ShowComBoBoxTenKH();
        }

        public List<string> ShowComboBoxSanPham(string TEN_DANH_MUC)
        {
            return _dal.ShowComboBoxSanPham(TEN_DANH_MUC);
        }

        public List<string> ShowComboBoxIDNV(string TEN_NHAN_VIEN)
        {
            return _dal.ShowComboBoxIDNV(TEN_NHAN_VIEN);
        }

        public List<string> ShowComboBoxIDKH(string TEN_KHACH_HANG)
        {
            return _dal.ShowComboBoxIDKH(TEN_KHACH_HANG);
        }

        public List<string> ShowComBoBoxIDSP(string TEN_SAN_PHAM)
        {
            return _dal.ShowComBoBoxIDSP(TEN_SAN_PHAM);
        }

        public decimal? GetDonGia(int ID_SP)
        {
            return _dal.GetDonGia(ID_SP);
        }

        public string GetDonVi(int ID_SP)
        {
            return _dal.GetDonVi(ID_SP);
        }

        public decimal? ThanhTien(int ID_SP, int sl)
        {
            return _dal.ThanhTien(ID_SP, sl);
        }

        public decimal? TongThanhToan(int ID_DH)
        {
            return _dal.TongThanhToan(ID_DH);
        }

        public bool KiemTraSPTonTai(int ID_DH, int ID_SP)
        {
            return _dal.KiemTraSPTonTai(ID_DH, ID_SP);
        }

        public bool KiemTraSoLuongSPTrongKho(int ID_DH, int ID_SP, int sl)
        {
            return _dal.KiemTraSoLuongSPTrongKho(ID_DH, ID_SP, sl);
        }

        public bool KiemTraDHCTTonTai(int ID_DH)
        {
            return _dal.KiemTraDHCTTonTai(ID_DH);
        }

        public void DeleteDHCT(int id_dh)
        {
            _dal.DeleteDHCT(id_dh);
        }
    }
}
