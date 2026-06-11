using Domain.Entities;
using Infracstructure;
using Infracstructure.Services;
using System.Collections.Generic;
using Infracstructure;

namespace Application.Services
{
    public class LaySanPhamTheoNCCUseCase
    {
        private SanPhamRepository _repo;

        public LaySanPhamTheoNCCUseCase()
        {
            // Khởi tạo Repository
            _repo = new SanPhamRepository();
        }

        // Nhận Mã NCC từ giao diện và gọi xuống hàm vừa tạo ở Bước 1
        public List<SanPham> Execute(string maNCC)
        {
            return _repo.LaySanPhamTheoNhaCungCap(maNCC);
        }
    }
}