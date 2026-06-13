using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PhieuTra
    {
        public string MaPhieu { get; set; }
        public string MaHoaDon { get; set; }
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public int SoLuongTra { get; set; }
        public string LyDo { get; set; }
        public DateTime NgayLap { get; set; }
        public string TrangThai { get; set; } // Có 3 trạng thái: "Chờ duyệt", "Đã duyệt", "Từ chối"
    }
}
