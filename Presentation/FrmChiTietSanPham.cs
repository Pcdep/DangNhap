using Application.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Presentation.FrmGioHang;

namespace Presentation
{
    public partial class FrmChiTietSanPham : Form
    {
        public int SoLuongChon { get; private set; }
        public string HanhDong { get; private set; }

        private string maSP_DuocChon = "";

        private decimal giaBan_DuocChon = 0;

        public FrmChiTietSanPham(string tenSP, decimal giaBan, string maSP, string duongDanAnh, string thongTinSP)
        {
            InitializeComponent();
            maSP_DuocChon = maSP;
            giaBan_DuocChon = giaBan;

            // Gán chữ lên Label
            if (lblTenSP != null) lblTenSP.Text = tenSP;
            if (lblGiaSP != null) lblGiaSP.Text = giaBan.ToString("N0") + " VNĐ";

            // 👉 GÁN THÔNG TIN SẢN PHẨM LÊN LABEL/TEXTBOX MỚI
            // (Giả sử bạn đã kéo 1 Label tên là lblThongTinSanPham vào giao diện)
            if (lblThongTinSanPham != null)
            {
                lblThongTinSanPham.Text = string.IsNullOrEmpty(thongTinSP) ? "Chưa có thông tin mô tả." : thongTinSP;
            }

            // 👉 GÁN HÌNH ẢNH LÊN PICTUREBOX
            if (picHinhAnh != null && !string.IsNullOrEmpty(duongDanAnh) && System.IO.File.Exists(duongDanAnh))
            {
                picHinhAnh.ImageLocation = duongDanAnh;
                picHinhAnh.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                if (picHinhAnh != null) picHinhAnh.ImageLocation = null;
            }
        }



        private void btnThemGioHang_Click(object sender, EventArgs e)
        {
            SoLuongChon = (int)numSoLuong.Value;
            if (SoLuongChon <= 0) return;

            // 1. Kiểm tra xem sản phẩm này đã có trong giỏ hàng chưa
            var monHangDaCo = SessionGioHang.GioHangCuaToi.FirstOrDefault(x => x.MaSP == maSP_DuocChon);

            if (monHangDaCo != null)
            {
                // Nếu có rồi thì chỉ việc cộng dồn số lượng
                monHangDaCo.SoLuong += SoLuongChon;
            }
            else
            {
                // Nếu chưa có thì ném nguyên món mới vào giỏ
                SessionGioHang.GioHangCuaToi.Add(new ItemGioHang
                {
                    ChonMua = false, // Mặc định chưa tick
                    MaSP = maSP_DuocChon,
                    TenSP = lblTenSP.Text,
                    GiaBan = giaBan_DuocChon, // Lấy từ biến bạn đã lưu
                    SoLuong = SoLuongChon,
                    ThongTin = lblThongTinSanPham != null ? lblThongTinSanPham.Text : ""
                });
            }

            MessageBox.Show("Đã thêm sản phẩm vào giỏ hàng thành công!", "Giỏ hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Đóng Form chi tiết lại để khách quay về quầy chọn tiếp
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnDatNgay_Click(object sender, EventArgs e)
        {
            try
            {
                SoLuongChon = (int)numSoLuong.Value;

                if (SoLuongChon <= 0)
                {
                    MessageBox.Show("Vui lòng chọn số lượng lớn hơn 0!", "Cảnh báo");
                    return;
                }

                // 👉 THỰC HIỆN TRỪ KHO NGAY LẬP TỨC
                BanHangUseCase useCase = new BanHangUseCase();
                // Gọi hàm trừ kho (Chúng ta sẽ viết hàm này ở Bước 3)
                bool thanhCong = useCase.TruTonKho(maSP_DuocChon, SoLuongChon);

                if (thanhCong)
                {
                    HanhDong = "DatNgay";
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Rất tiếc, số lượng trong kho không đủ để đáp ứng!", "Hết hàng");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đặt hàng: " + ex.Message);
            }
        }
        

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
