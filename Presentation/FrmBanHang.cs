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
            flpSanPham.Controls.Clear();

            // Chỉ lấy sản phẩm đang kinh doanh và còn hàng trong kho
            string query = "SELECT MaSP, TenSP, GiaBan FROM Products WHERE TrangThai = 1 AND SoLuongTon > 0";

            try
            {
                using (SqlConnection conn = Db.Open())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string maSP = reader["MaSP"].ToString();
                                string tenSP = reader["TenSP"].ToString();
                                decimal giaBan = Convert.ToDecimal(reader["GiaBan"]);

                                // Tạo thẻ hiển thị động cho từng sản phẩm
                                UC_SanPham uc = new UC_SanPham();
                                uc.CapNhatDuLieu(tenSP, giaBan);

                                // Gắn luồng sự kiện click mở màn hình Popup chi tiết đặt hàng
                                uc.Click += (sender, e) =>
                                {
                                    using (FrmChiTietSanPham frmPopup = new FrmChiTietSanPham(tenSP, giaBan))
                                    {
                                        if (frmPopup.ShowDialog() == DialogResult.OK)
                                        {
                                            int soLuong = frmPopup.SoLuongChon;
                                            if (frmPopup.HanhDong == "DatNgay")
                                            {
                                                using (FrmHoaDon frmHD = new FrmHoaDon(tenSP, soLuong, giaBan))
                                                {
                                                    frmHD.ShowDialog();
                                                }
                                            }
                                        }
                                    }
                                };

                                flpSanPham.Controls.Add(uc);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải danh sách sản phẩm: " + ex.Message, "Lỗi CSDL");
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

