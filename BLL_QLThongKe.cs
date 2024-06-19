using System;
using System.Collections.Generic;
using System.Linq;
using DoHoaC_.DataAccessLayer;

namespace DoHoaC_.BusinessLogicLayer
{
    public class BLL_QLThongKe
    {
        private DAL_QLThongKe _dalThongKe;

        public BLL_QLThongKe()
        {
            _dalThongKe = new DAL_QLThongKe();
        }

        public List<dynamic> ThongKeTheoKhoangThoiGian(DateTime ngayBatDau, DateTime ngayKetThuc, string loai)
        {
            return _dalThongKe.LayDonHangTheoKhoangThoiGian(ngayBatDau, ngayKetThuc, loai).ToList();
        }

        public List<dynamic> ThongKeTheoThang(int thang, string loai)
        {
            return _dalThongKe.LayDonHangTheoThang(thang, loai).ToList();
        }

        public List<dynamic> ThongKeTheoNam(int nam, string loai)
        {
            return _dalThongKe.LayDonHangTheoNam(nam, loai).ToList();
        }
    }
}
