using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DoHoaC_.DataAccessLayer;

namespace DoHoaC_.BusinessLogicLayer
{
    public class BLL_QLKH
    {
        private DAL_QLKH _dal;

        public BLL_QLKH()
        {
            _dal = new DAL_QLKH();
        }
        public static BLL_QLKH Instance { get; } = new BLL_QLKH();

        public void GetAllKhachHang(DataGridView dgv)
        {
            dgv.DataSource = _dal.GetAllKHACHHANG();
        }

        public void AddKH(KHACHHANG kh)
        {
            if (kh == null)
                throw new ArgumentNullException(nameof(kh), "Thông tin Khách hàng không được để trống.");

            if (string.IsNullOrWhiteSpace(kh.TEN_KHACH_HANG))
                throw new ArgumentException("Tên Khách hàng không được để trống.", nameof(kh.TEN_KHACH_HANG));
            if (!KiemTraDinhDangSDT(kh.SDT))
                throw new ArgumentException("SĐT không hợp lệ");
            if (_dal.IsKHExists(kh.TEN_KHACH_HANG, kh.DIACHI, kh.SDT))
            {
                throw new InvalidOperationException("Sản Phẩm đã tồn tại trong cơ sở dữ liệu.");
            }
            _dal.AddKH(kh);
        }

        public void UpdateKH(int ID_KH, KHACHHANG kh)
        {
            if (kh == null)
                throw new ArgumentNullException(nameof(kh), "Thông tin Khách Hàng không được để trống.");

            if (string.IsNullOrWhiteSpace(kh.TEN_KHACH_HANG))
                throw new ArgumentException("Tên Khách hàng không được để trống.", nameof(kh.TEN_KHACH_HANG));
            if (!KiemTraDinhDangSDT(kh.SDT))
                throw new ArgumentException("SĐT không hợp lệ");

            _dal.UpdateKH(ID_KH, kh);
        }

        public void DeleteKH(int ID_KH)
        {
            _dal.DeleteKH(ID_KH);
        }

        public IEnumerable<KHACHHANG> SearchKH(string keyword)
        {
            return _dal.SearchKH(keyword);
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
