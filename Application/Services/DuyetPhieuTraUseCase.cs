using Infracstructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class DuyetPhieuTraUseCase
    {
        private PhieuTraRepository _phieuRepo = new PhieuTraRepository();
        // Giả định bạn đã có SanPhamRepository để update kho
        private SanPhamRepository _spRepo = new SanPhamRepository();

        public bool Execute(string maPhieu, string trangThaiMoi, string maSP, int soLuongTra)
        {
            // 1. Đổi trạng thái phiếu (Đã duyệt / Từ chối)
            bool capNhatPhieu = _phieuRepo.CapNhatTrangThai(maPhieu, trangThaiMoi);

            // 2. Bám sát biểu đồ: Nếu Đồng ý duyệt -> Phải cộng trả lại số lượng vào kho
            if (capNhatPhieu && trangThaiMoi == "Đã duyệt")
            {
                // Lệnh này bạn gọi hàm UPDATE SanPham SET SoLuongTon = SoLuongTon + soLuongTra bên SanPhamRepository
                _spRepo.CongTonKho(maSP, soLuongTra);
            }

            return capNhatPhieu;
        }
    }
}
