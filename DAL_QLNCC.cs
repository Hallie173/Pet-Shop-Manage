using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DoHoaC_.DataAccessLayer
{
    public class DAL_QLNCC
    {
        private PBL3_CSDLEntities _context;

        public DAL_QLNCC()
        {
            _context = new PBL3_CSDLEntities(); // Đối tượng Entity Framework
        }

        public dynamic GetAllNHACUNGCAP()
        {
            try
            {
                var ncc = _context.NHACUNGCAPs.Select(s => new
                {
                    s.ID_NCC,
                    s.TEN_NHA_CUNG_CAP,
                    s.DIACHI,
                    s.SDT,
                    s.INFOR
                }).ToList();
                return ncc;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách Nhà Cung Cấp từ cơ sở dữ liệu.", ex);
            }
        }

        public void AddNCC(NHACUNGCAP ncc)
        {
            try
            {
                _context.NHACUNGCAPs.Add(ncc);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm Nhà Cung Cấp vào cơ sở dữ liệu.", ex);
            }
        }

        public void UpdateNCC(int ID_NCC, NHACUNGCAP ncc)
        {
            try
            {
                var existingNCC = _context.NHACUNGCAPs.Find(ID_NCC);
                if (existingNCC == null)
                {
                    throw new Exception("Nhà Cung Cấp không tồn tại.");
                }

                existingNCC.TEN_NHA_CUNG_CAP = ncc.TEN_NHA_CUNG_CAP;
                existingNCC.DIACHI = ncc.DIACHI;
                existingNCC.SDT = ncc.SDT;
                existingNCC.INFOR = ncc.INFOR;
                _context.Entry(existingNCC).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật Nhà Cung Cấp trong cơ sở dữ liệu.", ex);
            }
        }

        public void DeleteNCC(int ID_NCC)
        {
            try
            {
                var ncc = _context.NHACUNGCAPs.Find(ID_NCC);
                if (ncc == null)
                {
                    throw new Exception("Nhà Cung Cấp không tồn tại.");
                }

                _context.NHACUNGCAPs.Remove(ncc);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa Nhà Cung Cấp khỏi cơ sở dữ liệu.", ex);
            }
        }

        public IEnumerable<NHACUNGCAP> SearchNCC(string keyword)
        {
            try
            {
                return _context.NHACUNGCAPs.Where(ncc => ncc.TEN_NHA_CUNG_CAP.Contains(keyword)
                                                      || ncc.DIACHI.Contains(keyword)
                                                      || ncc.SDT.Contains(keyword)
                                                      || ncc.INFOR.Contains(keyword)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm Nhà Cung Cấp trong cơ sở dữ liệu.", ex);
            }
        }

        public bool IsNCCExists(string tenNCC, string diachi, string sdt)
        {
            try
            {
                return _context.NHACUNGCAPs.Any(ncc => ncc.TEN_NHA_CUNG_CAP == tenNCC && ncc.DIACHI == diachi && ncc.SDT == sdt);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi kiểm tra Nhà Cung Cấp trong cơ sở dữ liệu.", ex);
            }
        }
    }
}
