using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace DoHoaC_.DataAccessLayer
{
    public class DAL_QLDH
    {
        PBL3_CSDLEntities _context;

        public DAL_QLDH()
        {
            _context = new PBL3_CSDLEntities();
        }

        public dynamic GetDH()
        {
            try
            {
                var dh = _context.DONHANGs
                .Select(s => new
                {
                    s.ID_DH,
                    s.ID_KH,
                    s.TEN_KHACH_HANG,
                    s.ID_NV,
                    s.TEN_NHAN_VIEN,
                    s.NGAY_MUA,
                    s.TONG_THANH_TOAN,
                    s.TRANG_THAI
                }).ToList();
                return dh;
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi lấy tất cả Đơn hàng từ cơ sở dữ liệu.", ex);
            }
            
        }

        public string GetKHNV(int iddh, string ten)
        {
            var donHang = _context.DONHANGs.FirstOrDefault(dh => dh.ID_DH == iddh);
            if (donHang == null) return null;
            if (ten == "kh") return donHang.TEN_KHACH_HANG;
            if (ten == "nv") return donHang.TEN_NHAN_VIEN;
            return null;
        }

        public void AddDH(DONHANG dh)
        {
            if (dh == null)
                throw new ArgumentNullException(nameof(dh), "Thông tin đơn hàng không được để trống.");

            _context.DONHANGs.Add(dh);
            _context.SaveChanges();
        }
        public void UpdateDH(DONHANG dh)
        {
            if (dh == null)
                throw new ArgumentNullException(nameof(dh), "Thông tin đơn hàng không được để trống.");

            var existingDH = _context.DONHANGs.FirstOrDefault(d => d.ID_DH == dh.ID_DH);
            if (existingDH == null)
            {
                throw new Exception("Sản Phẩm không tồn tại.");
            }
            else
            {
                existingDH.ID_NV = dh.ID_NV;
                existingDH.TEN_NHAN_VIEN = dh.TEN_NHAN_VIEN;
                existingDH.ID_KH = dh.ID_KH;
                existingDH.TEN_KHACH_HANG = dh.TEN_KHACH_HANG;
                existingDH.NGAY_MUA = dh.NGAY_MUA;
                existingDH.TONG_THANH_TOAN = dh.TONG_THANH_TOAN;
                existingDH.TRANG_THAI = dh.TRANG_THAI;
                _context.Entry(existingDH).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public void DeleteDH(int id_dh)
        {
            var donHang = _context.DONHANGs.FirstOrDefault(dh => dh.ID_DH == id_dh);
            if (donHang != null)
            {
                _context.DONHANGs.Remove(donHang);
                _context.SaveChanges();
            }
        }
        public List<DONHANG> SearchDH(string keyword)
        {
            return _context.DONHANGs
                .Where(dh => dh.TEN_NHAN_VIEN.Contains(keyword) ||
                             dh.ID_NV.ToString().Contains(keyword) ||
                             dh.TEN_KHACH_HANG.Contains(keyword) ||
                             dh.ID_KH.ToString().Contains(keyword))
                .ToList();
        }


        public bool KiemTraDHTonTai(int ID_DH)
        {
            return _context.DONHANGs.Any(dh => dh.ID_DH == ID_DH);
        }
    }
}
