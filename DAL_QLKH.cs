using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace DoHoaC_.DataAccessLayer
{
    public class DAL_QLKH
    {
        private PBL3_CSDLEntities _context;

        public DAL_QLKH()
        {
            _context = new PBL3_CSDLEntities(); // Đối tượng Entity Framework
        }

        public dynamic GetAllKHACHHANG()
        {
            try
            {
                var kh = _context.KHACHHANGs.Select(s => new
                {
                    s.ID_KH,
                    s.TEN_KHACH_HANG,
                    s.DIACHI,
                    s.SDT,
                    s.INFOR
                }).ToList();
                return kh;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách Khách hàng từ cơ sở dữ liệu.", ex);
            }
        }

        public void AddKH(KHACHHANG kh)
        {
            try
            {
                _context.KHACHHANGs.Add(kh);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm Khách Hàng vào cơ sở dữ liệu.", ex);
            }
        }

        public void UpdateKH(int ID_KH, KHACHHANG kh)
        {
            try
            {
                var existingKH = _context.KHACHHANGs.Find(ID_KH);
                if (existingKH == null)
                {
                    throw new Exception("Khách Hàng không tồn tại.");
                }

                existingKH.TEN_KHACH_HANG = kh.TEN_KHACH_HANG;
                existingKH.DIACHI = kh.DIACHI;
                existingKH.SDT = kh.SDT;
                existingKH.INFOR = kh.INFOR;
                _context.Entry(existingKH).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật Khách Hàng trong cơ sở dữ liệu.", ex);
            }
        }

        public void DeleteKH(int ID_KH)
        {
            try
            {
                var kh = _context.KHACHHANGs.Find(ID_KH);
                if (kh == null)
                {
                    throw new Exception("Khách Hàng không tồn tại.");
                }

                _context.KHACHHANGs.Remove(kh);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa Khách Hàng khỏi cơ sở dữ liệu.", ex);
            }
        }

        public IEnumerable<KHACHHANG> SearchKH(string keyword)
        {
            try
            {
                return _context.KHACHHANGs.Where(kh => kh.TEN_KHACH_HANG.Contains(keyword)
                                                    || kh.DIACHI.Contains(keyword)
                                                    || kh.SDT.Contains(keyword)
                                                    || kh.INFOR.Contains(keyword)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm Khách Hàng trong cơ sở dữ liệu.", ex);
            }
        }

        public bool IsKHExists(string tenKH, string diachi, string sdt)
        {
            try
            {
                return _context.KHACHHANGs.Any(kh => kh.TEN_KHACH_HANG == tenKH && kh.DIACHI == diachi && kh.SDT == sdt);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi kiểm tra Khách Hàng trong cơ sở dữ liệu.", ex);
            }
        }
    }
}
