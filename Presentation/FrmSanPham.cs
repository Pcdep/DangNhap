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
    public partial class FrmSanPham : Form
    {
        public FrmSanPham()
        {
            InitializeComponent();

            if (dgvSanPham != null)
            {
                dgvSanPham.CellFormatting += DgvSanPham_CellFormatting;
                dgvSanPham.CellClick += DgvSanPham_CellClick;
            }

        }

        private void LoadDuLieuGiaLap()
        {
            // Thiết lập số cột nết chưa Add Column trong Designer
            if (dgvSanPham.ColumnCount == 0)
            {
                dgvSanPham.Columns.Add("MaSP", "Mã SP");
                dgvSanPham.Columns.Add("TenSP", "Tên Sản Phẩm");
                dgvSanPham.Columns.Add("GiaBan", "Giá Bán");
                dgvSanPham.Columns.Add("TonKho", "Tồn Kho");
                dgvSanPham.Columns.Add("TrangThai", "Trạng thái");
            }


            dgvSanPham.Rows.Add("SP01", "Son Mac Ruby", "350000", "50", "Đang bán");
            dgvSanPham.Rows.Add("SP02", "Kem Nền Innisfree", "420000", "3", "Đang bán"); // Cái này sẽ bị bôi đỏ
            dgvSanPham.Rows.Add("SP03", "Phấn Phủ Dior (Cũ)", "500000", "0", "Ngừng kinh doanh"); // Cái này tắt công tắc

        }

        private void DgvSanPham_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Kiểm tra nếu đang render dòng dữ liệu (không phải header)
            if (e.RowIndex >= 0)
            {
                // Lấy giá trị cột Tồn kho (Cột số 3 theo index 0,1,2,3)
                int tonKho = 0;
                if (int.TryParse(dgvSanPham.Rows[e.RowIndex].Cells[3].Value?.ToString(), out tonKho))
                {
                    if (tonKho <= 5)
                    {
                        // Đổi màu nền dòng thành Hồng nhạt, chữ Đỏ để cảnh báo Quản lý nhập hàng
                        dgvSanPham.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightPink;
                        dgvSanPham.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.DarkRed;
                    }
                }
            }
        }


        private void DgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSanPham.Rows[e.RowIndex];

                // Đổ dữ liệu vào các TextBox (Sửa lại tên txt cho đúng với Designer của bạn)
                // txtMaSP.Text = row.Cells[0].Value?.ToString();
                // txtTenSP.Text = row.Cells[1].Value?.ToString();
                // txtGiaBan.Text = row.Cells[2].Value?.ToString();
                // txtTonKho.Text = row.Cells[3].Value?.ToString();

                // Bật tắt nút Gạt theo trạng thái
                string trangThai = row.Cells[4].Value?.ToString();
                // if(tsTrangThai != null) tsTrangThai.Checked = (trangThai == "Đang bán");
            }
        }



        private void LoadDanhSachSanPhamGrid()
        {
            if (dgvSanPham == null) return;

            dgvSanPham.Rows.Clear();
            string query = "SELECT MaSP, TenSP, GiaBan, SoLuongTon, TrangThai FROM Products";

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
                                int soLuongTon = Convert.ToInt32(reader["SoLuongTon"]);
                                bool trangThai = Convert.ToBoolean(reader["TrangThai"]);

                                string tinhTrang = trangThai ? "Đang bán" : "Ngừng kinh doanh";

                                // Thêm một dòng mới vào lưới DataGridView
                                dgvSanPham.Rows.Add(maSP, tenSP, giaBan.ToString("N0"), soLuongTon, tinhTrang);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị danh sách quản lý: " + ex.Message, "Lỗi hệ thống");
            }
        }



    }




}
