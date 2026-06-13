using Domain.Entities;
using Infrastructure.Services; // Đổi lại thành Infracstructure.Services nếu bạn viết sai chính tả tên thư mục
using System.Collections.Generic;

namespace Application.Services
{
    public class LuuHoaDonUseCase
    {
        private HoaDonRepository _repo = new HoaDonRepository();

        public bool Execute(HoaDon hd, List<ChiTietHoaDon> dsChiTiet)
        {
            // Kiểm tra nghiệp vụ cơ bản: Không có sản phẩm thì không lưu hóa đơn
            if (dsChiTiet == null || dsChiTiet.Count == 0) return false;

            return _repo.ThemHoaDon(hd, dsChiTiet);
        }
    }
}