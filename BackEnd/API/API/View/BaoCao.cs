using System;
using System.Collections.Generic;

namespace API.View
{
    public class BaoCao
    {
        public class BaoCaoParameter
        {
            public DateTime FromDate { get; set; }
            public DateTime ToDate { get; set; }
            public int TypeReport { get; set; }
        }

        public class BaoCaoResponseCongNo
        {
           public string Total { get; set; }
           public string TotalPaid { get; set; }
           public string TotalDept { get; set; }
           public List<BaoCaoResponseCongNoDetail> lst { get; set; }
        }

        public class BaoCaoResponseCongNoDetail
        {
            public string NameSup { get; set; }
            public string TotalInvoice { get; set; }
            public string Paid { get; set; }
            public string Dept { get; set; }
        }

        public class BaocaoThuChiResponse
        {
            public string Total { get; set; }
            public List<BaocaoThuChiResponseDetail> lst { get; set; }
        }

        public class BaocaoThuChiResponseDetail
        {
            public string NameCus { get; set; }
            public string TotalInvoice { get; set; }
            public string DateCreate { get; set; }
        }

        public class Dashboard
        {
            public string HDN { get; set; }
            public string TotalHDN { get; set; }
            public string HDX { get; set; }
            public string TotalHDX { get; set; }
            public string DoanhThu { get; set; }
            public string TongSoThuoc { get; set; }
            public string ThuocHetHan { get; set; }
            public string ThuocSapHetHang { get; set; }
        }
    }
}
