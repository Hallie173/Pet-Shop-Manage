using System;
using System.Linq;

namespace DoHoaC_.DataAccessLayer
{
    public class DAL_QLTK
    {
        private static DAL_QLTK instance;
        private PBL3_CSDLEntities dbContext;

        public static DAL_QLTK Instance
        {
            get
            {
                if (instance == null)
                    instance = new DAL_QLTK();
                return instance;
            }
            private set { }
        }

        private DAL_QLTK()
        {
            dbContext = new PBL3_CSDLEntities(); // Thay thế PBL3_CSDLEntities bằng tên DbContext của bạn
        }

        public TAIKHOAN GetTaiKhoanByTenTaiKhoan(string tenTaiKhoan)
        {
            using (var context = new PBL3_CSDLEntities()) // Thay thế PBL3_CSDLEntities bằng tên DbContext của bạn
            {
                return context.TAIKHOANs.FirstOrDefault(acc => acc.TenTaiKhoan == tenTaiKhoan);
            }
        }


        public bool KiemTraTaiKhoan(string tenTaiKhoan, string matKhau)
        {
            return dbContext.TAIKHOANs.Any(acc => acc.TenTaiKhoan == tenTaiKhoan && acc.MatKhau == matKhau);
        }

        public bool ChangePassword(string tenTaiKhoan, string matKhauMoi)
        {
            var account = dbContext.TAIKHOANs.FirstOrDefault(acc => acc.TenTaiKhoan == tenTaiKhoan);
            if (account != null)
            {
                account.MatKhau = matKhauMoi;
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
