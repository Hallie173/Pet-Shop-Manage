using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoHoaC_
{
    public class DTB_DH
    {
        public string ID_DH { get; set; }
        public string ID_NV { get; set; }
        public string TEN_NHAN_VIEN { get; set; }
        public string ID_KH { get; set; }
        public string TEN_KHACH_HANG { get; set; }
        public string ID_SP { get; set; }
        public DateTime NGAY_MUA { get; set; }
        public string TEN_SAN_PHAM { get; set; }
        public string DONVI { get; set; }
        public int DONGIA { get; set; }
        public int SOLUONG { get; set; }
        public int THANHTIEN { get; set; }
        public int TONGTHANHTOAN { get; set; }
        public bool TRANG_THAI {  get; set; }
    }
}