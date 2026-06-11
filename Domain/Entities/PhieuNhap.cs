using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PhieuNhap
    {
        public string MaPN { get; set; }       // Mã phiếu nhập (Khóa chính)
        public DateTime NgayNhap { get; set; } // Ngày giờ nhập kho
        public decimal TongTien { get; set; }  // Tổng giá trị tiền của cả phiếu nhập

        
    }
}
