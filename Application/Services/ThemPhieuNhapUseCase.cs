using System;
using System.Collections.Generic;
using Domain.Entities; // Gọi thực thể PhieuNhap và ChiTietPhieuNhap từ tầng Domain
using Infracstructure;   // Gọi PhieuNhapRepository từ tầng Infrastructure

namespace Application.Services
{
    public class ThemPhieuNhapUseCase
    {
        private PhieuNhapRepository _repository;

        public ThemPhieuNhapUseCase()
        {
            // Khởi tạo Repository để chuẩn bị làm việc với SQL Server
            _repository = new PhieuNhapRepository();
        }

        // Hàm Execute bám sát theo đúng tên hành động xử lý trong sơ đồ tuần tự ThemPN3
        public void Execute(PhieuNhap pn, List<ChiTietPhieuNhap> dsChiTiet)
        {
            // BẪY LOGIC NGHIỆP VỤ (Business Rules Validation)
            // Trước khi cho phép đẩy xuống CSDL, ta kiểm tra xem phiếu nhập có hàng không
            if (dsChiTiet == null || dsChiTiet.Count == 0)
            {
                throw new Exception("Không thể lưu phiếu nhập trống rỗng! Vui lòng chọn ít nhất một sản phẩm.");
            }

            // Nếu kiểm tra hợp lệ, ra lệnh cho tầng Infrastructure thực thi lưu dữ liệu
            _repository.LuuPhieuNhap(pn, dsChiTiet);
        }
    }
}