using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SanPham
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public decimal GiaBan { get; set; }
        public int SoLuongTon { get; set; }
        public bool TrangThai { get; set; }
        public decimal GiaNhap { get; set; }
        public DateTime? NgayNhapCuoi { get; set; }
        public string MaPNCuoi { get; set; }
        public string ThongTinSanPham { get; set; }
        public bool YeuCauNhap { get; set; }

        // =================================================================
        // --- BỔ SUNG CÁC THUỘC TÍNH MỚI THEO THIẾT KẾ GIAO DIỆN MỚI ---
        // =================================================================
        public string MaNCC { get; set; }          // Mã công ty/Nhà cung cấp
        public string TenNCC { get; set; }         // Tên công ty (dùng để hiển thị lên giao diện)
        public string DonViTinh { get; set; }       // Đơn vị tính (Chai, thỏi, hộp...)
        public string TrangThaiGiao { get; set; }   // Trạng thái giao (Đã giao, Đang vận chuyển...)
    }
}
