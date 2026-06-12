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
                //dgvSanPham.CellFormatting += DgvSanPham_CellFormatting;
               
            }

        

            if (btnLuu != null)
            {
                btnLuu.Click += btnLuu_Click;
            }

        }


        private bool isThemMoi = false;




        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            isThemMoi = false;
            DataGridViewRow row = dgvSanPham.Rows[e.RowIndex];
            string maSP = row.Cells[0].Value?.ToString() ?? "";

            if (txtMaSP != null) { txtMaSP.Text = maSP; txtMaSP.ReadOnly = true; }
            if (txtTenSP != null) txtTenSP.Text = row.Cells[1].Value?.ToString() ?? "";
            if (txtGiaBan != null) txtGiaBan.Text = (row.Cells[2].Value?.ToString() ?? "").Replace(",", "").Replace(".", "");
            if (txtSoLuongTon != null) txtSoLuongTon.Text = row.Cells[3].Value?.ToString() ?? "";
            if (tsTrangThai != null) tsTrangThai.Checked = row.Cells[4].Value?.ToString() == "Đang bán";
            if (txtThongTinSanPham != null)
                txtThongTinSanPham.Text = row.Cells[5].Value?.ToString() ?? "";

            // Load ảnh

            string imagePath = System.Windows.Forms.Application.StartupPath + "\\Images\\" + txtMaSP.Text + ".jpg";

            if (System.IO.File.Exists(imagePath))
            {
                if (picHinhAnh != null)
                {
                    picHinhAnh.ImageLocation = imagePath;
                    picHinhAnh.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
            else
            {
                // Nếu sản phẩm chưa có ảnh thì để trống PictureBox
                if (picHinhAnh != null) picHinhAnh.ImageLocation = null;
            }
        }

      



        private void LoadDanhSachSanPhamGrid()
        {
            string query = "SELECT MaSP, TenSP, GiaBan, SoLuongTon, TrangThai, ThongTinSanPham FROM SanPham";

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
                                string maSP = reader["MaSP"].ToString();
                                string tenSP = reader["TenSP"].ToString();
                                decimal giaBan = Convert.ToDecimal(reader["GiaBan"]);
                                int soLuongTon = Convert.ToInt32(reader["SoLuongTon"]);
                                bool trangThai = Convert.ToBoolean(reader["TrangThai"]);

                                // 👉 BƯỚC 2: Đọc luôn Thông tin sản phẩm
                                string thongTin = reader["ThongTinSanPham"] != DBNull.Value ? reader["ThongTinSanPham"].ToString() : "";
                                string tinhTrang = trangThai ? "Đang bán" : "Ngừng kinh doanh";

                                // 👉 BƯỚC 3: Nhét thêm thongTin vào cột số 5 (Cells[5])
                                dgvSanPham.Rows.Add(maSP, tenSP, giaBan.ToString("N0"), soLuongTon, tinhTrang, thongTin);
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
                ofd.Filter = "Hình ảnh (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
                ofd.Title = "Chọn ảnh sản phẩm mỹ phẩm";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // 1. Ghi nhớ đường dẫn file gốc
                    duDuongDanAnhSelected = ofd.FileName;

                    // 2. Dùng ImageLocation để nạp ảnh lên xem trước (Không gây lỗi khóa file)
                    if (picHinhAnh != null)
                    {
                        picHinhAnh.ImageLocation = duDuongDanAnhSelected;
                        picHinhAnh.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                }
            }
        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. CHỐT CHẶN AN TOÀN: Không cho lưu nếu chưa có Mã SP
                if (string.IsNullOrWhiteSpace(txtMaSP.Text))
                {
                    MessageBox.Show("Vui lòng click chọn một sản phẩm trong bảng trước khi lưu!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Domain.Entities.SanPham spUpdate = new Domain.Entities.SanPham();
                spUpdate.MaSP = txtMaSP.Text;
                spUpdate.TenSP = txtTenSP.Text;

                // 2. Ép kiểu Giá Bán an toàn (Nếu ô nhập rỗng thì gán = 0)
                string giaBanStr = txtGiaBan.Text.Replace(",", "").Replace(".", "");
                spUpdate.GiaBan = string.IsNullOrEmpty(giaBanStr) ? 0 : Convert.ToDecimal(giaBanStr);

                // 3. Ép kiểu Số Lượng an toàn
                spUpdate.SoLuongTon = string.IsNullOrEmpty(txtSoLuongTon.Text) ? 0 : Convert.ToInt32(txtSoLuongTon.Text);

                if (txtThongTinSanPham != null)
                    spUpdate.ThongTinSanPham = txtThongTinSanPham.Text;

                // 4. Bắt trạng thái On/Off
                if (tsTrangThai != null)
                {
                    spUpdate.TrangThai = tsTrangThai.Checked;
                }

                // 5. Cập nhật xuống CSDL
                if (isThemMoi)
                {
                    Application.Services.ThemSanPhamUseCase useCaseThem = new Application.Services.ThemSanPhamUseCase();
                    useCaseThem.Execute(spUpdate);
                    MessageBox.Show("Thêm mới thành công!", "Thông báo");
                }
                else
                {
                    Application.Services.CapNhatSanPhamUseCase useCaseSua = new Application.Services.CapNhatSanPhamUseCase();
                    useCaseSua.Execute(spUpdate);
                    MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo");
                }

                if (!string.IsNullOrEmpty(duDuongDanAnhSelected))
                {
                    try
                    {
                        // 1. Xác định thư mục Images nằm cạnh file chạy phần mềm
                        string thuMucAnh = System.Windows.Forms.Application.StartupPath + "\\Images";

                        // 2. Nếu thư mục chưa tồn tại, tự động tạo mới
                        if (!System.IO.Directory.Exists(thuMucAnh))
                        {
                            System.IO.Directory.CreateDirectory(thuMucAnh);
                        }

                        // 3. Ghép tên file mới (Ví dụ: SP01.jpg)
                        string duongDanDich = thuMucAnh + "\\" + spUpdate.MaSP + ".jpg";

                        // 4. Ngắt kết nối ảnh trên màn hình tạm thời để tránh xung đột khi chép đè
                        if (picHinhAnh != null) picHinhAnh.ImageLocation = null;

                        // 5. Copy file từ máy tính vào thư mục dự án (true = cho phép chép đè ảnh cũ)
                        System.IO.File.Copy(duDuongDanAnhSelected, duongDanDich, true);

                        // 6. Xóa trí nhớ sau khi đã lưu xong
                        duDuongDanAnhSelected = "";
                    }
                    catch (Exception exImg)
                    {
                        MessageBox.Show("Lưu thông tin thành công nhưng lỗi copy ảnh: " + exImg.Message, "Cảnh báo Ảnh");
                    }
                }

                // 6. Refresh lại bảng để thấy kết quả tức thì
                LoadDanhSachSanPhamGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message, "Cảnh báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


