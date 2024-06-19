using System;
using System.Collections.Generic;
using System.Linq;

namespace DoHoaC_.DataAccessLayer
{
    public class DAL_QLThongKe
    {
        public IEnumerable<dynamic> LayDonHangTheoKhoangThoiGian(DateTime ngayBatDau, DateTime ngayKetThuc, string loai)
        {
            using (var context = new PBL3_CSDLEntities())
            {
                var query = context.DONHANGs.Where(d => d.NGAY_MUA >= ngayBatDau && d.NGAY_MUA <= ngayKetThuc);

                if (loai == "NhanVien")
                {
                    return query.GroupBy(d => new { d.ID_NV, d.TEN_NHAN_VIEN })
                                .Select(g => new
                                {
                                    ID_NV = g.Key.ID_NV,
                                    TEN_NHAN_VIEN = g.Key.TEN_NHAN_VIEN,
                                    DoanhThu = g.Sum(d => d.TONG_THANH_TOAN)
                                }).ToList<dynamic>();
                }
                else if (loai == "KhachHang")
                {
                    return query.GroupBy(d => new { d.ID_KH, d.TEN_KHACH_HANG })
                                .Select(g => new
                                {
                                    ID_KH = g.Key.ID_KH,
                                    TEN_KHACH_HANG = g.Key.TEN_KHACH_HANG,
                                    DoanhThu = g.Sum(d => d.TONG_THANH_TOAN)
                                }).ToList<dynamic>();
                }
                else // Tổng doanh thu
                {
                    return query.GroupBy(d => d.NGAY_MUA)
                                .Select(g => new
                                {
                                    NGAY_MUA = g.Key,
                                    DoanhThu = g.Sum(d => d.TONG_THANH_TOAN)
                                }).ToList<dynamic>();
                }
            }
        }

        public IEnumerable<dynamic> LayDonHangTheoThang(int thang, string loai)
        {
            using (var context = new PBL3_CSDLEntities())
            {
                var query = context.DONHANGs.Where(d => d.NGAY_MUA.Value.Month == thang);

                if (loai == "NhanVien")
                {
                    return query.GroupBy(d => new { d.ID_NV, d.TEN_NHAN_VIEN })
                                .Select(g => new
                                {
                                    ID_NV = g.Key.ID_NV,
                                    TEN_NHAN_VIEN = g.Key.TEN_NHAN_VIEN,
                                    DoanhThu = g.Sum(d => d.TONG_THANH_TOAN)
                                }).ToList<dynamic>();
                }
                else if (loai == "KhachHang")
                {
                    return query.GroupBy(d => new { d.ID_KH, d.TEN_KHACH_HANG })
                                .Select(g => new
                                {
                                    ID_KH = g.Key.ID_KH,
                                    TEN_KHACH_HANG = g.Key.TEN_KHACH_HANG,
                                    DoanhThu = g.Sum(d => d.TONG_THANH_TOAN)
                                }).ToList<dynamic>();
                }
                else // Tổng doanh thu
                {
                    return query.GroupBy(d => d.NGAY_MUA.Value.Day)
                                .Select(g => new
                                {
                                    NGAY = g.Key,
                                    DoanhThu = g.Sum(d => d.TONG_THANH_TOAN)
                                }).ToList<dynamic>();
                }
            }
        }

        public IEnumerable<dynamic> LayDonHangTheoNam(int nam, string loai)
        {
            using (var context = new PBL3_CSDLEntities())
            {
                var query = context.DONHANGs.Where(d => d.NGAY_MUA.Value.Year == nam);

                if (loai == "NhanVien")
                {
                    return query.GroupBy(d => new { d.ID_NV, d.TEN_NHAN_VIEN })
                                .Select(g => new
                                {
                                    ID_NV = g.Key.ID_NV,
                                    TEN_NHAN_VIEN = g.Key.TEN_NHAN_VIEN,
                                    DoanhThu = g.Sum(d => d.TONG_THANH_TOAN)
                                }).ToList<dynamic>();
                }
                else if (loai == "KhachHang")
                {
                    return query.GroupBy(d => new { d.ID_KH, d.TEN_KHACH_HANG })
                                .Select(g => new
                                {
                                    ID_KH = g.Key.ID_KH,
                                    TEN_KHACH_HANG = g.Key.TEN_KHACH_HANG,
                                    DoanhThu = g.Sum(d => d.TONG_THANH_TOAN)
                                }).ToList<dynamic>();
                }
                else // Tổng doanh thu
                {
                    return query.GroupBy(d => d.NGAY_MUA.Value.Month)
                                .Select(g => new
                                {
                                    THANG = g.Key,
                                    DoanhThu = g.Sum(d => d.TONG_THANH_TOAN)
                                }).ToList<dynamic>();
                }
            }
        }
    }
}
