using DoHoaC_.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DoHoaC_
{
    public class BLL_QLNV
    {
        private DAL_QLNV _dal;

        public BLL_QLNV()
        {
            _dal = new DAL_QLNV();
        }

        public static BLL_QLNV Instance { get; } = new BLL_QLNV();

        public void GetAllNhanVien(DataGridView dgv)
        {
            dgv.DataSource = _dal.GetAllNhanVien();
        }

        public void AddNhanVien(NHANVIEN nv)
        {
            if (nv == null)
                throw new ArgumentNullException(nameof(nv), "Thông tin Nhân viên không được để trống.");

            if (string.IsNullOrWhiteSpace(nv.TEN_NHAN_VIEN))
                throw new ArgumentException("Tên Nhân viên không được để trống.", nameof(nv.TEN_NHAN_VIEN));
            if (!KiemTraDinhDangSDT(nv.SDT))
                throw new ArgumentException("SĐT không hợp lệ");
            if (_dal.IsNhanVienExists(nv.TEN_NHAN_VIEN, nv.DIACHI, nv.SDT))
            {
                throw new InvalidOperationException("Nhân viên đã tồn tại trong cơ sở dữ liệu.");
            }
            _dal.AddNhanVien(nv);
        }

        public void UpdateNhanVien(int ID_NV, NHANVIEN nv)
        {
            if (nv == null)
                throw new ArgumentNullException(nameof(nv), "Thông tin Nhân viên không được để trống.");
            if (!KiemTraDinhDangSDT(nv.SDT))
                throw new ArgumentException("SĐT không hợp lệ");

            if (string.IsNullOrWhiteSpace(nv.TEN_NHAN_VIEN))
                throw new ArgumentException("Tên Nhân viên không được để trống.", nameof(nv.TEN_NHAN_VIEN));

            _dal.UpdateNhanVien(ID_NV, nv);
        }

        public void DeleteNhanVien(int ID_NV)
        {
            _dal.DeleteNhanVien(ID_NV);
        }

        public IEnumerable<NHANVIEN> SearchNhanVien(string keyword)
        {
            return _dal.SearchNhanVien(keyword);
        }
        public bool KiemTraDinhDangSDT(string sdt)
        {
            // Kiểm tra độ dài của chuỗi
            if (sdt.Length != 10)
            {
                return false;
            }

            // Kiểm tra từng ký tự trong chuỗi
            foreach (char c in sdt)
            {
                // Nếu ký tự không phải là số thì trả về false
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }

            // Nếu vượt qua các điều kiện trên thì chuỗi hợp lệ
            return true;
        }

    }
}
