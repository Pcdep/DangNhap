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
using static Presentation.FrmGioHang;

namespace Presentation
{

    public partial class FrmBanHang : Form
    {
        public FrmBanHang()
        {
            InitializeComponent();
            LoadSanPhamDong();

            this.VisibleChanged += (sender, e) =>
            {
             
                if (this.Visible == true)
                {
                    // Thì ngay lập tức load lại danh sách mới nhất
                    LoadSanPhamDong();
                }
            };

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
                List<Domain.Entities.SanPham> danhSachSP = useCase.Execute()
            .Where(sp => sp.TrangThai == true && sp.SoLuongTon > 0).ToList();

                // 2. DUYỆT DANH SÁCH VÀ ĐỔ LÊN GIAO DIỆN
                foreach (SanPham sp in danhSachSP)
                {
                    UC_SanPham uc = new UC_SanPham();
                    uc.CapNhatDuLieu(sp.MaSP, sp.TenSP, sp.GiaBan);

                    string pathAnh = System.Windows.Forms.Application.StartupPath + "\\Images\\" + sp.MaSP + ".jpg";

                    // SỰ KIỆN CLICK MỞ CHI TIẾT VÀ HÓA ĐƠN
                    uc.Click += (sender, e) =>
                    {
                        FrmChiTietSanPham frmCT = new FrmChiTietSanPham(sp.TenSP, sp.GiaBan, sp.MaSP, pathAnh, sp.ThongTinSanPham);

                        // Đón tín hiệu OK từ Form Chi Tiết (như bạn đã làm)
                        if (frmCT.ShowDialog() == DialogResult.OK)
                        {
                            if (frmCT.HanhDong == "DatNgay")
                            {
                                LoadSanPhamDong();
                                List<ItemGioHang> danhSachMuaNgay = new List<ItemGioHang>();
                                ItemGioHang monHang = new ItemGioHang();
                                monHang.MaSP = sp.MaSP;
                                monHang.TenSP = sp.TenSP;
                                monHang.SoLuong = frmCT.SoLuongChon;
                                monHang.GiaBan = sp.GiaBan;
                                danhSachMuaNgay.Add(monHang);
                                decimal tongTienBill = monHang.ThanhTien;

                                // 👉 4. BÂY GIỜ THÌ GỌI HÓA ĐƠN SẼ KHÔNG CÒN LỖI NỮA
                                FrmHoaDon frmHD = new FrmHoaDon(danhSachMuaNgay, tongTienBill);
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

