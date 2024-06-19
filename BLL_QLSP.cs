using DoHoaC_.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace DoHoaC_.BusinessLogicLayer
{
    public class BLL_QLSP
    {
        private DAL_QLSP _dal;

        public BLL_QLSP()
        {
            _dal = new DAL_QLSP();
        }

        public static BLL_QLSP Instance { get; } = new BLL_QLSP();

        public void GetAllSanPham(DataGridView dgv)
        {
            dgv.DataSource = _dal.GetAllSanPham();
        }

        public void AddSP(SANPHAM sp)
        {
            if (sp == null)
                throw new ArgumentNullException(nameof(sp), "Thông tin Sản Phẩm không được để trống.");

            if (string.IsNullOrWhiteSpace(sp.TEN_SAN_PHAM))
                throw new ArgumentException("Tên Sản Phẩm không được để trống.", nameof(sp.TEN_SAN_PHAM));

            if (_dal.IsSPExists(sp.TEN_SAN_PHAM, sp.ID_NCC))
            {
                throw new InvalidOperationException("Sản Phẩm đã tồn tại trong cơ sở dữ liệu.");
            }
            _dal.AddSP(sp);
        }

        public void UpdateSP(int idsp, SANPHAM sp)
        {
            if (sp == null)
                throw new ArgumentNullException(nameof(sp), "Thông tin Sản Phẩm không được để trống.");

            if (string.IsNullOrWhiteSpace(sp.TEN_SAN_PHAM))
                throw new ArgumentException("Tên Sản Phẩm không được để trống.");

            _dal.UpdateSP(idsp, sp);
        }

        public void DeleteSP(int id)
        {
            _dal.DeleteSP(id);
        }

        public IEnumerable<SANPHAM> SearchSP(string keyword)
        {
            return _dal.SearchSP(keyword);
        }

        public IEnumerable<string> ShowUniqueDanhMuc()
        {
            return _dal.GetUniqueDanhMuc();
        }

        public IEnumerable<int> ShowIDNCC()
        {
            return _dal.GetIDNCC();
        }

        public void UpdateSLSP(int id, int quantitySold)
        {
            _dal.UpdateSLSP(id, quantitySold);
        }
    }
}
