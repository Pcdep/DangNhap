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
    public partial class FrmHoaDon : Form
    {
        public FrmHoaDon(string tenSP, int soLuong, decimal donGia)
        {
            InitializeComponent();


            // 1. Tự động tạo Mã hóa đơn ngẫu nhiên dựa trên thời gian để nhìn cho thật
            string maNgauNhien = DateTime.Now.ToString("yyyyMMddHHmmss");
            lblMaHD.Text = "Mã HD: HD-" + maNgauNhien;

            // 2. Gán ngày giờ lập hóa đơn hiện tại
            lblNgayLap.Text = "Ngày lập: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            // 3. Đổ dữ liệu sản phẩm lên hóa đơn
            lblTenSP.Text = tenSP;
            lblSoLuong.Text = "x" + soLuong.ToString();
            lblDonGia.Text = donGia.ToString("N0") + " đ";

            // 4. Tính tổng tiền
            decimal tongTien = soLuong * donGia;
            lblTongTien.Text = tongTien.ToString("N0") + " VNĐ";
        }

        public FrmHoaDon()
        {
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            // Tạm thời giả lập lệnh in (Sau này kết nối máy in thật sẽ tính sau)
            MessageBox.Show("Hệ thống đang kết nối máy in Bill...\nIn hóa đơn thành công!",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // In xong thì đóng giao diện hóa đơn luôn theo yêu cầu của bạn
            this.Close();
        }

        // Sự kiện khi bấm nút "X" góc màn hình (Khách không muốn lấy hóa đơn)
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
