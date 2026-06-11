using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ChiTietPhieuNhap
    {
        public string MaPN { get; set; }        // Khóa ngoại nối với bảng PhieuNhap
        public string MaSP { get; set; }        // Khóa ngoại nối với bảng SanPham
        public int SoLuongNhap { get; set; }   // Số lượng nhập về của món này
        public decimal GiaNhap { get; set; }    // Giá gốc nhập vào từ nhà cung cấp
    }
}
