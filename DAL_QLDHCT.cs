using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace DoHoaC_.DataAccessLayer
{
    public class DAL_QLDHCT
    {
        private PBL3_CSDLEntities _context;

        public DAL_QLDHCT()
        {
            _context = new PBL3_CSDLEntities();
        }

        public dynamic GetDHCT(int iddh)
        {
            try
            {
                var dhct = _context.DONHANGCHITIETs.Where(s => s.ID_DH == iddh)
                    .Select(s => new
                {
                    s.ID_SP,
                    s.TEN_SAN_PHAM,
                    s.DON_VI,
                    s.SO_LUONG,
                    s.DON_GIA,
                    s.THANH_TIEN
                })
                .ToList();
                return dhct;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy đơn hàng chi tiết từ cơ sở dữ liệu.", ex);
            }
        }

        public void AddSP_DHCT(DONHANGCHITIET dhct)
        {
            try
            {
                _context.DONHANGCHITIETs.Add(dhct);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm Sản Phẩm vào cơ sở dữ liệu.", ex);
            }
        }

        public void UpdateSoLuong(int ID_DH, int ID_SP, int soLuong)
        {
            var dhct = _context.DONHANGCHITIETs.SingleOrDefault(d => d.ID_DH == ID_DH && d.ID_SP == ID_SP);
            if (dhct != null)
            {
                dhct.SO_LUONG += soLuong;
                dhct.THANH_TIEN = dhct.DON_GIA * dhct.SO_LUONG;
                _context.SaveChanges();
            }
        }

        public void XoaSP_DHCT(int ID_SP, int ID_DH)
        {
            var dhct = _context.DONHANGCHITIETs.SingleOrDefault(d => d.ID_SP == ID_SP && d.ID_DH == ID_DH);
            if (dhct != null)
            {
                _context.DONHANGCHITIETs.Remove(dhct);
                _context.SaveChanges();
            }
        }

        public bool KiemTraSPTonTai(int ID_DH, int ID_SP)
        {
            return _context.DONHANGCHITIETs.Any(d => d.ID_SP == ID_SP && d.ID_DH == ID_DH);
        }

        public List<string> ShowComBoBoxTenNV()
        {
            return _context.NHANVIENs.Select(nv => nv.TEN_NHAN_VIEN).ToList();
        }

        public List<string> ShowComBoBoxTenKH()
        {
            return _context.KHACHHANGs.Select(kh => kh.TEN_KHACH_HANG).ToList();
        }

        public List<string> ShowComboBoxSanPham(string TEN_DANH_MUC)
        {
            return _context.SANPHAMs
                           .Where(sp => sp.TEN_DANH_MUC == TEN_DANH_MUC)
                           .Select(sp => sp.TEN_SAN_PHAM)
                           .Distinct()
                           .ToList();
        }

        public List<string> ShowComboBoxIDNV(string TEN_NHAN_VIEN)
        {
            return _context.NHANVIENs
                           .Where(nv => nv.TEN_NHAN_VIEN == TEN_NHAN_VIEN)
                           .Select(nv => nv.ID_NV.ToString())
                           .ToList();
        }

        public List<string> ShowComboBoxIDKH(string TEN_KHACH_HANG)
        {
            return _context.KHACHHANGs
                           .Where(kh => kh.TEN_KHACH_HANG == TEN_KHACH_HANG)
                           .Select(kh => kh.ID_KH.ToString())
                           .ToList();
        }

        public List<string> ShowComBoBoxIDSP(string TEN_SAN_PHAM)
        {
            return _context.SANPHAMs
                           .Where(sp => sp.TEN_SAN_PHAM == TEN_SAN_PHAM)
                           .Select(sp => sp.ID_SP.ToString())
                           .ToList();
        }

        public decimal? GetDonGia(int ID_SP)
        {
            return _context.SANPHAMs
                           .Where(sp => sp.ID_SP == ID_SP)
                           .Select(sp => sp.DON_GIA)
                           .FirstOrDefault();
        }


        public string GetDonVi(int ID_SP)
        {
            return _context.SANPHAMs
                           .Where(sp => sp.ID_SP == ID_SP)
                           .Select(sp => sp.DON_VI)
                           .FirstOrDefault();
        }

        public decimal? ThanhTien(int ID_SP, int sl)
        {
            var donGia = GetDonGia(ID_SP);
            return donGia * sl;
        }

        public decimal? TongThanhToan(int ID_DH)
        {
            return _context.DONHANGCHITIETs
                           .Where(dhct => dhct.ID_DH == ID_DH)
                           .Sum(dhct => dhct.THANH_TIEN);
        }
        public bool KiemTraSoLuongSPTrongKho(int ID_DH, int ID_SP, int sl)
        {
            var soluongtrongkho = _context.SANPHAMs
                                          .Where(sp => sp.ID_SP == ID_SP)
                                          .Select(sp => sp.SO_LUONG_CON_LAI)
                                          .FirstOrDefault();

            if (KiemTraSPTonTai(ID_DH, ID_SP))
            {
                var soluongdhct = _context.DONHANGCHITIETs
                                          .Where(dhct => dhct.ID_SP == ID_SP && dhct.ID_DH == ID_DH)
                                          .Select(dhct => dhct.SO_LUONG)
                                          .FirstOrDefault();

                return sl + soluongdhct <= soluongtrongkho;
            }
            else
            {
                return sl <= soluongtrongkho;
            }
        }

        public bool KiemTraDHCTTonTai(int ID_DH)
        {
            return _context.DONHANGCHITIETs
                           .Any(dhct => dhct.ID_DH == ID_DH);
        }

        public void DeleteDHCT(int id_dh)
        {
            var dhctList = _context.DONHANGCHITIETs
                                   .Where(dhct => dhct.ID_DH == id_dh)
                                   .ToList();
            _context.DONHANGCHITIETs.RemoveRange(dhctList);
            _context.SaveChanges();
        }
    }

}

