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
            // 1. Kiểm tra xem người dùng đã chọn sản phẩm chưa
            if (string.IsNullOrEmpty(txtMaSP.Text))
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm từ bảng để lưu!", "Thông báo");
                return;
            }

            try
            {
                // 2. CẬP NHẬT DỮ LIỆU CHỮ VÀO SQL
                using (SqlConnection conn = Db.Open())
                {
                    string query = "UPDATE SanPham SET TenSP = @TenSP, GiaBan = @GiaBan, TrangThai = @TrangThai WHERE MaSP = @MaSP";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaSP", txtMaSP.Text);
                        cmd.Parameters.AddWithValue("@TenSP", txtTenSP.Text);

                        // Lọc bỏ dấu phẩy phân cách hàng nghìn (nếu có) trước khi đẩy vào SQL
                        string gia = txtGiaBan.Text.Replace(",", "").Replace(".", "");
                        cmd.Parameters.AddWithValue("@GiaBan", Convert.ToDecimal(gia));

                        cmd.Parameters.AddWithValue("@TrangThai", tsTrangThai.Checked);

                        cmd.ExecuteNonQuery();
                    }
                }

                // 3. XỬ LÝ LƯU ẢNH VÀO Ổ CỨNG MÁY TÍNH
                if (!string.IsNullOrEmpty(duDuongDanAnhSelected))
                {
                    // Tạo thư mục "Images" nằm ngay bên trong thư mục chạy của phần mềm
                    string folderPath = Application.StartupPath + "\\Images";
                    if (!System.IO.Directory.Exists(folderPath))
                    {
                        System.IO.Directory.CreateDirectory(folderPath);
                    }

                    // Đổi tên ảnh thành Mã Sản Phẩm (VD: SP01.jpg) và chép vào thư mục
                    string destPath = folderPath + "\\" + txtMaSP.Text + ".jpg";
                    System.IO.File.Copy(duDuongDanAnhSelected, destPath, true); // true: cho phép ghi đè ảnh cũ

                    duDuongDanAnhSelected = ""; // Reset lại biến đường dẫn
                }

                MessageBox.Show("Cập nhật thông tin sản phẩm thành công!", "Thành công");

                // Tải lại bảng để thấy trạng thái mới được cập nhật
                LoadDanhSachSanPhamGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message, "Lỗi hệ thống");
            }
        }

    }




}

