using Application.Services;
using Domain;
using Domain.Entities;
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
        private string duDuongDanAnhSelected = "";
        public FrmSanPham()
        {
            InitializeComponent();
            LoadDanhSachSanPhamGrid();

            if (dgvSanPham != null)
            {
                dgvSanPham.CellFormatting += DgvSanPham_CellFormatting;
                dgvSanPham.CellClick += DgvSanPham_CellClick;
            }

            if (btnChonAnh != null)
            {
                btnChonAnh.Click += btnChonAnh_Click;
            }

            if (btnLuu != null)
            {
                btnLuu.Click += btnLuu_Click;
            }

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

                // Đổ dữ liệu chữ vào các TextBox dựa theo thứ tự cột lúc thêm vào lưới
                if (txtMaSP != null) txtMaSP.Text = row.Cells[0].Value?.ToString();
                if (txtTenSP != null) txtTenSP.Text = row.Cells[1].Value?.ToString();

                // Giá bán loại bỏ dấu phẩy phân cách định dạng nếu có trước khi nạp vào ô nhập
                if (txtGiaBan != null)
                    txtGiaBan.Text = row.Cells[2].Value?.ToString().Replace(",", "").Replace(".", "");

                if (txtSoLuongTon != null) txtSoLuongTon.Text = row.Cells[3].Value?.ToString();

                // Xử lý nút gạt trạng thái: Nếu chữ là "Đang bán" thì bật công tắc gạt (True), ngược lại tắt (False)
                string tinhTrang = row.Cells[4].Value?.ToString();
                if (tsTrangThai != null)
                {
                    tsTrangThai.Checked = (tinhTrang == "Đang bán");
                }

                // Phần xử lý ảnh từ database hiển thị lên picHinhAnh sẽ bổ sung khi làm hàm lưu/tải ảnh
            }
        }



        private void LoadDanhSachSanPhamGrid()
        {
            // Đồng bộ câu lệnh SELECT theo các trường dữ liệu Tiếng Anh
            string query = "SELECT MaSP, TenSP, GiaBan, SoLuongTon, TrangThai FROM SanPham";

            try
            {
                using (SqlConnection conn = Db.Open())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            dgvSanPham.Rows.Clear();

                            while (reader.Read())
                            {
                                // Trả lại toàn bộ về Tiếng Việt
                                string maSP = reader["MaSP"].ToString();
                                string tenSP = reader["TenSP"].ToString();
                                decimal giaBan = Convert.ToDecimal(reader["GiaBan"]);
                                int soLuongTon = Convert.ToInt32(reader["SoLuongTon"]);
                                bool trangThai = Convert.ToBoolean(reader["TrangThai"]);

                                string tinhTrang = trangThai ? "Đang bán" : "Ngừng kinh doanh";

                                dgvSanPham.Rows.Add(maSP, tenSP, giaBan.ToString("N0"), soLuongTon, tinhTrang);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải bảng quản lý sản phẩm: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                // Bộ lọc định dạng hình ảnh thông dụng
                ofd.Filter = "Hình ảnh (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
                ofd.Title = "Chọn ảnh sản phẩm mỹ phẩm";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Lưu lại đường dẫn tệp tin phục vụ việc copy lưu trữ sau này
                        duDuongDanAnhSelected = ofd.FileName;

                        // Hiển thị trực quan hình ảnh lên Khung PictureBox
                        if (picHinhAnh != null)
                        {
                            picHinhAnh.Image = Image.FromFile(ofd.FileName);
                            picHinhAnh.SizeMode = PictureBoxSizeMode.Zoom; // Tự động co giãn ảnh vừa khung
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể tải hình ảnh này: " + ex.Message, "Lỗi tệp tin");
                    }
                }
            }
        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Kiểm tra rỗng (Validation bắt buộc)
                if (string.IsNullOrWhiteSpace(txtMaSP.Text) || string.IsNullOrWhiteSpace(txtTenSP.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ Mã và Tên sản phẩm trước khi khai sinh!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. Xử lý Giá Bán an toàn (Chống crash khi để trống hoặc gõ chữ)
                decimal giaBanAnToan = 0;
                if (!string.IsNullOrWhiteSpace(txtGiaBan.Text))
                {
                    // Xóa dấu phẩy định dạng (nếu có) và thử ép kiểu an toàn
                    string gia = txtGiaBan.Text.Replace(",", "").Replace(".", "");
                    decimal.TryParse(gia, out giaBanAnToan);
                }

                // 3. Đóng gói dữ liệu vào Entity (Tầng Domain)
                SanPham spMoi = new SanPham();
                spMoi.MaSP = txtMaSP.Text;
                spMoi.TenSP = txtTenSP.Text;
                spMoi.GiaBan = giaBanAnToan;
                spMoi.SoLuongTon = 0; // Khai sinh mặc định bằng 0 vì hàng chưa về kho
                spMoi.TrangThai = tsTrangThai.Checked;

                // 4. Gọi UseCase thực thi (Tầng Application)
                ThemSanPhamUseCase useCase = new ThemSanPhamUseCase();
                useCase.Execute(spMoi);

                MessageBox.Show("Khai sinh sản phẩm mới thành công!", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 5. Nạp lại bảng dữ liệu để hiển thị ngay sản phẩm vừa thêm
                LoadDanhSachSanPhamGrid();
            }
            catch (SqlException sqlEx)
            {
                // 2627 là mã lỗi kinh điển của SQL Server khi bị trùng Khóa chính (Primary Key)
                if (sqlEx.Number == 2627)
                {
                    MessageBox.Show("Mã sản phẩm này đã tồn tại trong danh mục! Vui lòng tự gõ một Mã SP khác.", "Lỗi trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Lỗi CSDL: " + sqlEx.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống không xác định: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    }


