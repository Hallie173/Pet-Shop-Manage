using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DoHoaC_
{
    public class DAL_QLNV
    {
        private PBL3_CSDLEntities _context;

        public DAL_QLNV()
        {
            _context = new PBL3_CSDLEntities(); // Đối tượng Entity Framework
        }

        public dynamic GetAllNhanVien()
        {
            try
            {
                var nv = _context.NHANVIENs.Select(s => new
                {
                    s.ID_NV,
                    s.TEN_NHAN_VIEN,
                    s.DIACHI,
                    s.SDT,
                    s.CHUCVU
                }).ToList();
                return nv;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách Nhân viên từ cơ sở dữ liệu.", ex);
            }
        }

        public void AddNhanVien(NHANVIEN nv)
        {
            try
            {
                _context.NHANVIENs.Add(nv);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm Nhân viên vào cơ sở dữ liệu.", ex);
            }
        }

        public void UpdateNhanVien(int ID_NV, NHANVIEN nv)
        {
            try
            {
                var existingNV = _context.NHANVIENs.Find(ID_NV);
                if (existingNV == null)
                {
                    throw new Exception("Nhân viên không tồn tại.");
                }

                existingNV.TEN_NHAN_VIEN = nv.TEN_NHAN_VIEN;
                existingNV.DIACHI = nv.DIACHI;
                existingNV.SDT = nv.SDT;
                existingNV.CHUCVU = nv.CHUCVU;
                _context.Entry(existingNV).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật Nhân viên trong cơ sở dữ liệu.", ex);
            }
        }

        public void DeleteNhanVien(int ID_NV)
        {
            try
            {
                var nv = _context.NHANVIENs.Find(ID_NV);
                if (nv == null)
                {
                    throw new Exception("Nhân viên không tồn tại.");
                }

                _context.NHANVIENs.Remove(nv);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa Nhân viên khỏi cơ sở dữ liệu.", ex);
            }
        }

        public IEnumerable<NHANVIEN> SearchNhanVien(string keyword)
        {
            try
            {
                return _context.NHANVIENs.Where(nv => nv.TEN_NHAN_VIEN.Contains(keyword)
                                                  || nv.DIACHI.Contains(keyword)
                                                  || nv.SDT.Contains(keyword)
                                                  || nv.CHUCVU.Contains(keyword)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm Nhân viên trong cơ sở dữ liệu.", ex);
            }
        }

        public bool IsNhanVienExists(string tenNV, string diachi, string sdt)
        {
            try
            {
                return _context.NHANVIENs.Any(nv => nv.TEN_NHAN_VIEN == tenNV && nv.DIACHI == diachi && nv.SDT == sdt);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi kiểm tra Nhân Viên trong cơ sở dữ liệu.", ex);
            }
        }
    }
}
