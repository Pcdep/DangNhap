using Domain.Entities;
using Infracstructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Enums;
using Domain.Extensions;

namespace Application.Services
{
    public class LapPhieuTraUseCase
    {
        private PhieuTraRepository _repo = new PhieuTraRepository();

        public string Execute(PhieuTra phieu, DateTime ngayMuaHang)
        {
            // Bám sát biểu đồ: Kiểm tra điều kiện 7 ngày
            TimeSpan khoangCach = DateTime.Now - ngayMuaHang;
            if (khoangCach.TotalDays > 7)
            {
                return "Hóa đơn đã vượt quá 7 ngày hỗ trợ đổi trả!";
            }

            // Sinh mã phiếu tự động
            phieu.MaPhieu = "PT" + DateTime.Now.ToString("yyyyMMddHHmmss");
            phieu.NgayLap = DateTime.Now;

            // 👉 2. BỔ SUNG DÒNG NÀY: Gán trạng thái mặc định bằng Enum chuẩn
            phieu.TrangThai = TrangThaiPhieuTra.ChoDuyet.GetDescription();

            bool kq = _repo.ThemPhieuTra(phieu);
            return kq ? "Thành công" : "Lỗi khi lưu phiếu trả vào hệ thống.";
        }
    }
}