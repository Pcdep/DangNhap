using Domain.Entities;
using Infracstructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class LayDanhSachSanPhamUseCase
    {
        private SanPhamRepository _repository;

        public LayDanhSachSanPhamUseCase()
        {
            _repository = new SanPhamRepository();
        }

        // Lấy danh sách ném lên cho Presentation
        public List<SanPham> Execute()
        {
            return _repository.LayDanhSachSanPham();
        }
    }
}
