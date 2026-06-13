using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public enum TrangThaiPhieuTra
    {
       
        [Description("Chờ duyệt")]
        ChoDuyet = 0,

        [Description("Đã duyệt")]
        DaDuyet = 1,

        [Description("Từ chối")]
        TuChoi = 2
    }
}
