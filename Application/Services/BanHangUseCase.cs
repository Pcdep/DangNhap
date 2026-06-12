using Infracstructure.Services;

namespace Application.Services
{
    public class BanHangUseCase
    {
        private SanPhamRepository _repo;

        public BanHangUseCase()
        {
            _repo = new SanPhamRepository();
        }

        public bool TruTonKho(string maSP, int soLuongBan)
        {
            return _repo.TruTonKhoKhiBanHang(maSP, soLuongBan);
        }
    }
}