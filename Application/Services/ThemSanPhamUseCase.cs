using Domain;
using Domain.Entities;
using Infracstructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ThemSanPhamUseCase
    {
        private SanPhamRepository _repository;

        public ThemSanPhamUseCase()
        {
            _repository = new SanPhamRepository();
        }

        public void Execute(SanPham sp)
        {
            _repository.ThemSanPham(sp);
        }
    }
}
