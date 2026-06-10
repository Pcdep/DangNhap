using Application.Services;
using Domain.Entities;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
            try
            {
                flpSanPham.Controls.Clear();
                flpSanPham.WrapContents = true;
                flpSanPham.AutoScroll = true;

                // 1. GỌI TẦNG APPLICATION (Thay vì viết SQL trực tiếp)
                LayDanhSachSanPhamUseCase useCase = new LayDanhSachSanPhamUseCase();
                List<SanPham> danhSachSP = useCase.Execute();

                // 2. DUYỆT DANH SÁCH VÀ ĐỔ LÊN GIAO DIỆN
                foreach (SanPham sp in danhSachSP)
                {
                    UC_SanPham uc = new UC_SanPham();
                    uc.CapNhatDuLieu(sp.MaSP, sp.TenSP, sp.GiaBan);

                    // SỰ KIỆN CLICK MỞ CHI TIẾT VÀ HÓA ĐƠN
                    uc.Click += (sender, e) =>
                    {
                        FrmChiTietSanPham frmCT = new FrmChiTietSanPham(sp.TenSP, sp.GiaBan, sp.MaSP);

                        // Đón tín hiệu OK từ Form Chi Tiết (như bạn đã làm)
                        if (frmCT.ShowDialog() == DialogResult.OK)
                        {
                            if (frmCT.HanhDong == "DatNgay")
                            {
                                // Mở Form Hóa Đơn và truyền dữ liệu sang
                                FrmHoaDon frmHD = new FrmHoaDon(sp.TenSP, frmCT.SoLuongChon, sp.GiaBan);
                                frmHD.ShowDialog();
                            }
                        }
                    };

                    flpSanPham.Controls.Add(uc);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
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

