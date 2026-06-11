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


        private bool isThemMoi = false;

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
            if (e.RowIndex >= 0 && dgvSanPham.Rows[e.RowIndex].DataBoundItem is SanPham sp)
            {
                isThemMoi = false;
                txtMaSP.Text = sp.MaSP;
                txtTenSP.Text = sp.TenSP;

                DataGridViewRow row = dgvSanPham.Rows[e.RowIndex];
                if (txtMaSP != null) { txtMaSP.Text = row.Cells[0].Value?.ToString(); txtMaSP.ReadOnly = true; } // Khóa mã lại không cho sửa
                if (txtTenSP != null) txtTenSP.Text = row.Cells[1].Value?.ToString();
                if (txtGiaBan != null) txtGiaBan.Text = row.Cells[2].Value?.ToString().Replace(",", "").Replace(".", "");
                if (txtSoLuongTon != null) txtSoLuongTon.Text = row.Cells[3].Value?.ToString();

                if (txtThongTinSanPham != null) txtThongTinSanPham.Text = sp.ThongTinSanPham;

                string tinhTrang = row.Cells[4].Value?.ToString();
                if (tsTrangThai != null) tsTrangThai.Checked = (tinhTrang == "Đang bán");

                // Code nạp ảnh từ thư mục Images
                string imagePath = System.Windows.Forms.Application.StartupPath + "\\Images\\" + txtMaSP.Text + ".jpg";
                if (System.IO.File.Exists(imagePath))
                {
                    using (System.IO.FileStream fs = new System.IO.FileStream(imagePath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                    {
                        if (picHinhAnh != null) { picHinhAnh.Image = Image.FromStream(fs); picHinhAnh.SizeMode = PictureBoxSizeMode.Zoom; }
                    }
                }
                else
                {
                    if (picHinhAnh != null) picHinhAnh.Image = null;
                }
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

        private void LamMoiGiaoDien()
        {
            // Xóa trắng toàn bộ ô nhập liệu để chuẩn bị cho sản phẩm tiếp theo
            if (txtMaSP != null) txtMaSP.Text = "";
            if (txtTenSP != null) txtTenSP.Text = "";
            if (txtGiaBan != null) txtGiaBan.Text = "";
            if (txtSoLuongTon != null) txtSoLuongTon.Text = "0";

            // Xóa hình ảnh hiện tại
            if (picHinhAnh != null) picHinhAnh.Image = null;
            duDuongDanAnhSelected = ""; // Reset đường dẫn ảnh

            // Đưa con trỏ chuột nhấp nháy vào ô Mã SP
            if (txtMaSP != null) txtMaSP.Focus();
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
                if (string.IsNullOrWhiteSpace(txtMaSP.Text) || string.IsNullOrWhiteSpace(txtTenSP.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal giaBanAnToan = 0;
                if (!string.IsNullOrWhiteSpace(txtGiaBan.Text))
                {
                    string gia = txtGiaBan.Text.Replace(",", "").Replace(".", "");
                    decimal.TryParse(gia, out giaBanAnToan);
                }

                // Đóng gói dữ liệu vào Entity
                SanPham sp = new SanPham();
                sp.MaSP = txtMaSP.Text;
                sp.TenSP = txtTenSP.Text;
                sp.GiaBan = giaBanAnToan;
                sp.SoLuongTon = Convert.ToInt32(txtSoLuongTon.Text); // Giữ nguyên số lượng tồn kho cũ
                sp.TrangThai = tsTrangThai.Checked;
                sp.ThongTinSanPham = txtThongTinSanPham.Text;

                // 🎯 KIỂM TRA ĐIỀU KIỆN ĐỂ GỌI ĐÚNG USECASE
                if (isThemMoi)
                {
                    // Gọi UseCase THÊM MỚI
                    ThemSanPhamUseCase themUseCase = new ThemSanPhamUseCase();
                    themUseCase.Execute(sp);
                    MessageBox.Show("Khai sinh sản phẩm mới thành công!", "Thông báo");
                }
                else
                {
                    // Gọi UseCase CẬP NHẬT (SỬA)
                    CapNhatSanPhamUseCase suaUseCase = new CapNhatSanPhamUseCase();
                    suaUseCase.Execute(sp);
                    MessageBox.Show("Cập nhật thông tin sản phẩm thành công!", "Thông báo");
                }

                // Xử lý copy lưu ảnh nếu có chọn ảnh mới
                if (!string.IsNullOrEmpty(duDuongDanAnhSelected))
                {
                    string folderPath = System.Windows.Forms.Application.StartupPath + "\\Images";
                    if (!System.IO.Directory.Exists(folderPath)) System.IO.Directory.CreateDirectory(folderPath);

                    string destPath = folderPath + "\\" + txtMaSP.Text + ".jpg";
                    System.IO.File.Copy(duDuongDanAnhSelected, destPath, true);
                    duDuongDanAnhSelected = "";
                }

                // Nạp lại bảng dữ liệu và đưa form về trạng thái tĩnh
                LoadDanhSachSanPhamGrid();
                isThemMoi = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            LamMoiGiaoDien();
            isThemMoi = true; // Bật cờ báo hệ thống chuẩn bị Thêm mới

            if (txtMaSP != null) { txtMaSP.ReadOnly = false; txtMaSP.Text = ""; }
            if (txtTenSP != null) txtTenSP.Text = "";
            if (txtGiaBan != null) txtGiaBan.Text = "";
            if (txtSoLuongTon != null) txtSoLuongTon.Text = "0";
            if (tsTrangThai != null) tsTrangThai.Checked = true;
            if (picHinhAnh != null) picHinhAnh.Image = null;
            duDuongDanAnhSelected = "";

            if (tsTrangThai != null)
            {
                tsTrangThai.Checked = false; // Ngừng kinh doanh
            }
            if (txtMaSP != null) txtMaSP.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void btnBaoHetHang_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaSP.Text)) return;

            try
            {
                string query = "UPDATE SanPham SET YeuCauNhap = 1 WHERE MaSP = '" + txtMaSP.Text + "'";
                using (SqlConnection conn = Db.Open())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Đã gửi cảnh báo hết hàng đến bộ phận Kho!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }
    }

}


