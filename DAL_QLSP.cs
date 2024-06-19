using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace DoHoaC_.DataAccessLayer
{
    public class DAL_QLSP
    {
        PBL3_CSDLEntities _context;

        public DAL_QLSP()
        {
            _context = new PBL3_CSDLEntities();
        }

        public dynamic GetAllSanPham()
        {
            try
            {
                var sp = _context.SANPHAMs.Select(s => new
                {
                    s.ID_SP,
                    s.TEN_SAN_PHAM,
                    s.ID_NCC,
                    s.TEN_DANH_MUC,
                    s.DON_VI,
                    s.DON_GIA,
                    s.SO_LUONG_CON_LAI
                }).ToList();
                return sp;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy tất cả Sản Phẩm từ cơ sở dữ liệu.", ex);
            }
        }

        public void AddSP(SANPHAM sp)
        {
            try
            {
                _context.SANPHAMs.Add(sp);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm Sản Phẩm vào cơ sở dữ liệu.", ex);
            }
        }

        public void UpdateSP(int idsp, SANPHAM sp)
        {
            try
            {
                var existingSP = _context.SANPHAMs.Find(idsp);
                if (existingSP == null)
                {
                    throw new Exception("Sản Phẩm không tồn tại.");
                }

                existingSP.TEN_SAN_PHAM = sp.TEN_SAN_PHAM;
                existingSP.TEN_DANH_MUC = sp.TEN_DANH_MUC;
                existingSP.ID_NCC = sp.ID_NCC;
                existingSP.DON_VI = sp.DON_VI;
                existingSP.DON_GIA = sp.DON_GIA;
                existingSP.SO_LUONG_CON_LAI = sp.SO_LUONG_CON_LAI;
                _context.Entry(existingSP).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật Sản Phẩm trong cơ sở dữ liệu.", ex);
            }
        }

        public void DeleteSP(int id)
        {
            try
            {
                var sp = _context.SANPHAMs.Find(id);
                if (sp == null)
                {
                    throw new Exception("Sản Phẩm không tồn tại.");
                }

                _context.SANPHAMs.Remove(sp);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa Sản Phẩm khỏi cơ sở dữ liệu.", ex);
            }
        }

        public IEnumerable<SANPHAM> SearchSP(string keyword)
        {
            try
            {
                return _context.SANPHAMs.Where(sp => sp.TEN_SAN_PHAM.Contains(keyword)
                                                || sp.ID_NCC.ToString().Contains(keyword)
                                                || sp.TEN_DANH_MUC.Contains(keyword)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm Sản Phẩm trong cơ sở dữ liệu.", ex);
            }
        }

        public IEnumerable<string> GetUniqueDanhMuc()
        {
            try
            {
                return _context.SANPHAMs.Select(sp => sp.TEN_DANH_MUC).Distinct().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách danh mục duy nhất.", ex);
            }
        }

        public IEnumerable<int> GetIDNCC()
        {
            try
            {
                return _context.NHACUNGCAPs.Select(ncc => ncc.ID_NCC).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách nhà cung cấp.", ex);
            }
        }

        public void UpdateSLSP(int id, int quantitySold)
        {
            try
            {
                var sp = _context.SANPHAMs.Find(id);
                if (sp == null)
                {
                    throw new Exception("Sản Phẩm không tồn tại.");
                }

                sp.SO_LUONG_CON_LAI -= quantitySold;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật số lượng Sản Phẩm trong cơ sở dữ liệu.", ex);
            }
        }

        public bool IsSPExists(string tenSP, int idncc)
        {
            try
            {
                return _context.SANPHAMs.Any(sp => sp.TEN_SAN_PHAM == tenSP && sp.ID_NCC == idncc);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi kiểm tra Sản Phẩm trong cơ sở dữ liệu.", ex);
            }
        }
    }
}
