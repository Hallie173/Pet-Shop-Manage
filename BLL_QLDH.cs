using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DoHoaC_.DataAccessLayer;

namespace DoHoaC_.BusinessLogicLayer
{
    public class BLL_QLDH
    {
        private  DAL_QLDH _dal;
        public  BLL_QLDH()
        {
            _dal = new DAL_QLDH();
        }
        public static BLL_QLDH Instance { get; } = new BLL_QLDH();
        public void GetDH(DataGridView dgv)
        {
            dgv.DataSource = _dal.GetDH();
        }

        public string GetKHNV(int iddh, string ten)
        {
            return _dal.GetKHNV(iddh, ten);
        }

        public void AddDH(DONHANG dh)
        {
            if (dh == null)
                throw new ArgumentNullException(nameof(dh), "Thông tin sản phẩm không được để trống.");
            if (string.IsNullOrWhiteSpace(dh.ID_NV.ToString()))
                throw new ArgumentException("Thông tin Nhân viên không được để trống.");
            if (string.IsNullOrWhiteSpace(dh.ID_KH.ToString()))
                throw new ArgumentException("Thông tin Khách hàng không được để trống.");
            if (KiemTraDHTonTai(dh.ID_DH))
            {
                throw new InvalidOperationException("Đơn hàng đã tồn tại trong cơ sở dữ liệu.");
            }
            _dal.AddDH(dh);
        }

        public void UpdateDH(DONHANG dh)
        {
            if (dh == null)
                throw new ArgumentNullException(nameof(dh), "Thông tin sản phẩm không được để trống.");
            if (string.IsNullOrWhiteSpace(dh.ID_NV.ToString()))
                throw new ArgumentException("Thông tin Nhân viên không được để trống.");
            if (string.IsNullOrWhiteSpace(dh.ID_KH.ToString()))
                throw new ArgumentException("Thông tin Khách hàng không được để trống.");
            _dal.UpdateDH(dh);
        }

        public void DeleteDH(int id_dh)
        {
            _dal.DeleteDH(id_dh);
        }

        public List<DONHANG> SearchDH(string keyword)
        {
            return _dal.SearchDH(keyword);
        }

        public bool KiemTraDHTonTai(int ID_DH)
        {
            return _dal.KiemTraDHTonTai(ID_DH);
        }
    }
}
