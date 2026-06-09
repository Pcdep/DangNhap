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
                UC_SanPham uc = new UC_SanPham();
                uc.CapNhatDuLieu(sp.TenSP, sp.GiaBan);

                // Gắn sự kiện: Khi click vào Component thì mở Popup
                uc.Click += (sender, e) =>
                {
                    // Mở FrmChiTietSanPham và truyền Tên, Giá sang
                    using (FrmChiTietSanPham frmPopup = new FrmChiTietSanPham(sp.TenSP, sp.GiaBan))
                    {
                        // Bắt kết quả trả về sau khi tắt Popup
                        if (frmPopup.ShowDialog() == DialogResult.OK)
                        {
                            int soLuong = frmPopup.SoLuongChon;

                            if (frmPopup.HanhDong == "ThemGio")
                            {
                                MessageBox.Show($"Đã thêm {soLuong} hộp {sp.TenSP} vào Giỏ hàng!");
                                // (Chức năng DataGridView Giỏ Hàng sẽ làm ở bước sau)
                            }
                            else if (frmPopup.HanhDong == "DatNgay")
                            {
                                // Lúc này FrmChiTietSanPham ĐÃ ĐÓNG HOÀN TOÀN (vì ShowDialog kết thúc)

                                // Gọi Form Hóa Đơn hiện lên ngay lập tức
                                using (FrmHoaDon frmHD = new FrmHoaDon(sp.TenSP, soLuong, sp.GiaBan))
                                {
                                    frmHD.ShowDialog(); // Hiện hóa đơn dạng Popup chèn lên màn hình chính
                                }
                            }
                        }
                    }
                };

                foreach (Control c in uc.Controls)
                {
                    c.Click += (sender, e) => { uc.Invoke(new Action(() => uc.PerformLayout())); /* Trigger lại click */ };
                }

                flpSanPham.Controls.Add(uc);

            }
        }





        // Hàm xử lý khi bấm vào Panel Sản phẩm
        private void ThemVaoHoaDon(SanPhamDTO sp)
        {
            MessageBox.Show($"Bạn vừa chọn: {sp.TenSP} - {sp.GiaBan} VNĐ.\nCode đẩy vào DataGridView hóa đơn sẽ viết ở đây!");
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }
    }

}

