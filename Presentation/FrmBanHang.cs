using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation
{
  
    public partial class FrmBanHang : Form
    {
        public FrmBanHang()
        {
            InitializeComponent();
            LoadSanPhamDong();
        }

        private void Guna2GradientPanel_Paint(object sender, PaintEventArgs e)
        {

        }
        // Tạm thời tạo class giả lập, sau này ta sẽ lấy từ Tầng Domain sang
        public class SanPhamDTO
        {
            public string MaSP { get; set; }
            public string TenSP { get; set; }
            public decimal GiaBan { get; set; }
        }
        private void LoadSanPhamDong()
        {
            flpSanPham.Controls.Clear(); // Làm sạch panel

            // Dữ liệu giả lập (Sau này sẽ select từ SQL)
            var danhSachSP = new List<SanPhamDTO>
    {
        new SanPhamDTO { MaSP = "SP01", TenSP = "Son Mac Ruby", GiaBan = 350000 },
        new SanPhamDTO { MaSP = "SP02", TenSP = "Kem Nền Innisfree", GiaBan = 420000 },
        new SanPhamDTO { MaSP = "SP03", TenSP = "Phấn Phủ Dior", GiaBan = 500000 }
    };

            // Bắt buộc phải có vòng lặp để sinh ra 3 cái Component
            foreach (var sp in danhSachSP)
            {
                // 1. Lấy cái khuôn UC_SanPham ra
                UC_SanPham uc = new UC_SanPham();

                // 2. Đổ dữ liệu vào khuôn
                uc.CapNhatDuLieu(sp.TenSP, sp.GiaBan);

                // 3. Đẩy vào FlowLayoutPanel để hiển thị
                flpSanPham.Controls.Add(uc);
            }
        }

        // Hàm xử lý khi bấm vào Panel Sản phẩm
        private void ThemVaoHoaDon(SanPhamDTO sp)
        {
            MessageBox.Show($"Bạn vừa chọn: {sp.TenSP} - {sp.GiaBan} VNĐ.\nCode đẩy vào DataGridView hóa đơn sẽ viết ở đây!");
        }
    }

}

