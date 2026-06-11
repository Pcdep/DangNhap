using System.Collections.Generic;
using Domain.Entities;
using Infracstructure;

namespace Application.Services
{
    public class LayTatCaNhaCungCapUseCase
    {
        private NhaCungCapRepository _repo = new NhaCungCapRepository();
        public List<NhaCungCap> Execute()
        {
            return _repo.LayTatCaNhaCungCap();
        }
    }
}