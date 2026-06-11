using Domain.Entities;
using Infracstructure;
using Infracstructure.Services;
using System.Collections.Generic;

namespace Application.Services
{
    public class LayTatCaSanPhamTrongKhoUseCase
    {
        private SanPhamRepository _repo;

        public LayTatCaSanPhamTrongKhoUseCase()
        {
            _repo = new SanPhamRepository();
        }

        // Gọi xuống tầng Infrastructure để lấy danh sách
        public List<SanPham> Execute()
        {
            return _repo.LayTatCaSanPhamTrongKho();
        }
    }
}