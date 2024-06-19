using DoHoaC_.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DoHoaC_.BusinessLogicLayer
{
    public class BLL_QLTK
    {
        private DAL_QLTK dalQLTK;
        private BLL_QLTK()
        {
            dalQLTK = DAL_QLTK.Instance;
        }
        public static bool LoaiTaiKhoan { get; private set; }
        private static BLL_QLTK instance;
        public static BLL_QLTK Instance
        {
            get
            {
                if (instance == null)
                    instance = new BLL_QLTK();
                return instance;
            }
            private set { }
        }
        public TAIKHOAN GetTaiKhoanByTenTaiKhoan(string tenTaiKhoan)
        {
            var account = dalQLTK.GetTaiKhoanByTenTaiKhoan(tenTaiKhoan);
            if (account == null)
            {
                throw new Exception($"Không tìm thấy tài khoản với tên đăng nhập '{tenTaiKhoan}'");
            }
            return account;
        }

        public bool KiemTraDangNhap(string tenTaiKhoan, string matKhau)
        {
            if (string.IsNullOrEmpty(tenTaiKhoan) || string.IsNullOrEmpty(matKhau))
            {
                throw new ArgumentException("Tên tài khoản và mật khẩu không được để trống.");
            }
            var isValidLogin = dalQLTK.KiemTraTaiKhoan(tenTaiKhoan, matKhau);
            if (!isValidLogin)
            {
                throw new Exception("Tên tài khoản hoặc mật khẩu không đúng.");
            }
            else
            {
                LoaiTaiKhoan = (bool)dalQLTK.GetTaiKhoanByTenTaiKhoan(tenTaiKhoan).LoaiTaiKhoan;
            }
            return true;
        }

        public bool ChangePassword(string tenTaiKhoan, string matKhauMoi)
        {
            if (string.IsNullOrEmpty(tenTaiKhoan) || string.IsNullOrEmpty(matKhauMoi))
            {
                throw new ArgumentException("Tên tài khoản và mật khẩu mới không được để trống.");
            }

            var isSuccess = dalQLTK.ChangePassword(tenTaiKhoan, matKhauMoi);
            if (!isSuccess)
            {
                throw new Exception("Đổi mật khẩu không thành công.");
            }
            return true;
        }

        public bool? GetLoaiTaiKhoan(string tenTaiKhoan)
        {
            var account = dalQLTK.GetTaiKhoanByTenTaiKhoan(tenTaiKhoan);
            if (account == null)
            {
                throw new Exception($"Không tìm thấy tài khoản với tên đăng nhập '{tenTaiKhoan}'");
            }
            return account.LoaiTaiKhoan;
        }
    }
}
