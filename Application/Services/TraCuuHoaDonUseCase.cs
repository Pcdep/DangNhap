// Bạn nhớ kiểm tra lại tên thư mục chứa Db và Repository của bạn là Infrastructure hay Infracstructure nhé
using Infracstructure.Services;
using Infrastructure.Services;
using System;
using System.Data;

namespace Application.Services
{
    public class TraCuuHoaDonUseCase
    {
        private HoaDonRepository _repo = new HoaDonRepository();

        // 1. Hàm kéo toàn bộ lịch sử mua hàng
        public DataTable LayTatCaLichSu()
        {
            return _repo.LayTatCaLichSuMuaHang();
        }

        // 2. Hàm lấy ngày lập của 1 hóa đơn cụ thể
        public DateTime? LayNgayLap(string maHD)
        {
            if (string.IsNullOrWhiteSpace(maHD)) return null;
            return _repo.LayNgayLapHoaDon(maHD);
        }

        // 3. Hàm lấy chi tiết các món trong 1 hóa đơn
        public DataTable LayChiTietHoaDon(string maHD)
        {
            return _repo.LayChiTietHoaDon(maHD);
        }
    }
}