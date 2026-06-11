using Domain.Entities;
using Infracstructure.Services;

namespace Application.Services
{
    public class CapNhatSanPhamUseCase
    {
        private SanPhamRepository _repository;

        public CapNhatSanPhamUseCase()
        {
            _repository = new SanPhamRepository();
        }

        // Hàm Execute nhận đối tượng cần sửa từ giao diện và đẩy xuống Repository
        public void Execute(SanPham sp)
        {
            // Nơi xử lý các quy tắc nghiệp vụ nếu có (Ví dụ: Kiểm tra giá bán không được âm...)
            _repository.CapNhatSanPham(sp);
        }
    }
}