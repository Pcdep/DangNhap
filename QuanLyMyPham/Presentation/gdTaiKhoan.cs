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

namespace gd_chính
{
    public partial class gdTaiKhoan : Form
    {
        public gdTaiKhoan()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gdTaiKhoan_Load(object sender, EventArgs e)
        {
            // Lấy ID người đang đăng nhập từ Form1
            int currentUserId = Form1.CurrentUserId;

            if (currentUserId == 0)
            {
                MessageBox.Show("Bạn chưa đăng nhập!");
                this.Close();
                return;
            }

            LoadUserProfile(currentUserId);
        }

        private void LoadUserProfile(int userId)
        {
            try
            {
                using (SqlConnection cn = Db.Open())
                {
                    string query = "SELECT FullName, Phone, Email, AvatarPath FROM Users WHERE UserId = @id";
                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("@id", userId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Gán dữ liệu lên giao diện
                                lblName.Text = reader["FullName"].ToString();
                                lblEmail.Text = reader["Email"].ToString();
                                lblPhone.Text = reader["Phone"].ToString();

                                string path = reader["AvatarPath"] != DBNull.Value ? reader["AvatarPath"].ToString() : "";

                                // Kiểm tra file ảnh có tồn tại trên máy tính không
                                if (!string.IsNullOrEmpty(path) && System.IO.File.Exists(path))
                                {
                                    // Load ảnh an toàn (tránh lỗi khóa file)
                                    using (var stream = new System.IO.FileStream(path, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                                    {
                                        picAvatar.Image = Image.FromStream(stream);
                                    }
                                }
                                else
                                {
                                    // Nếu không có ảnh thì để trống hoặc hiện ảnh mặc định
                                    picAvatar.Image = null; // Hoặc gán: Properties.Resources.DefaultAvatar
                                }

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thông tin: " + ex.Message);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                // 1. Reset ID về 0
                Form1.CurrentUserId = 0;

                // 2. Tìm Form1 và ĐÓNG nó lại
                // Vì gdTaiKhoan đang nằm trong Form1, ta phải tìm Form cha để đóng
                Form1 main = Application.OpenForms["Form1"] as Form1;

                if (main != null)
                {
                    main.Close(); // Đóng Form1 -> Tự động kích hoạt dòng this.Show() bên gdDangNhap
                }
            }
        }

        private void btnMyOrders_Click(object sender, EventArgs e)
        {
            // 1. Tìm Form1 đang chạy
            Form1 main = Application.OpenForms["Form1"] as Form1;

            if (main != null)
            {
                // 2. Nhờ Form1 kích hoạt nút "Giao Hàng"
                // (Nó sẽ tự động mở gdDonHang và làm sáng nút menu bên trái luôn)
                main.btnGiaoHang_Click(sender, e);
            }
        }

        private void btnDiaChi_Click(object sender, EventArgs e)
        {
            // Tìm Form1 cha
            Form1 main = Application.OpenForms["Form1"] as Form1;
            if (main != null)
            {
                // Mở gdDiaChi đè lên panel chính (giống như mở Giỏ hàng)
                main.OpenChildForm(new gdDiaChi());
            }
        }

        private void btnXoaTaiKhoan_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                 "CẢNH BÁO: Bạn có chắc chắn muốn xóa vĩnh viễn tài khoản này?",
                 "Xác nhận xóa",
                 MessageBoxButtons.YesNo,
                 MessageBoxIcon.Error);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection cn = Db.Open())
                    {
                        int uid = Form1.CurrentUserId;

                        // B1: Xóa giỏ hàng trước (để tránh lỗi khóa ngoại)
                        string sqlDeleteCart = "DELETE FROM CartItems WHERE UserId = @uid";
                        using (SqlCommand cmd = new SqlCommand(sqlDeleteCart, cn))
                        {
                            cmd.Parameters.AddWithValue("@uid", uid);
                            cmd.ExecuteNonQuery();
                        }

                        // B2: Xóa User
                        string sqlDeleteUser = "DELETE FROM Users WHERE UserId = @uid";
                        using (SqlCommand cmd = new SqlCommand(sqlDeleteUser, cn))
                        {
                            cmd.Parameters.AddWithValue("@uid", uid);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Tài khoản đã bị xóa. Tạm biệt!");
                    Logout(); // Gọi hàm đăng xuất
                }
                catch (Exception ex)
                {
                    // Lỗi này xảy ra nếu User đã có Đơn hàng (Orders) trong lịch sử
                    MessageBox.Show("Không thể xóa vì tài khoản này đã phát sinh đơn hàng!", "Lỗi bảo toàn dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void Logout()
        {
            Form1.CurrentUserId = 0; // Reset ID về 0

            // Đóng Form1 lại -> gdDangNhap sẽ tự hiện lên (do cơ chế ShowDialog ở FormLogin)
            Form1 main = Application.OpenForms["Form1"] as Form1;
            if (main != null)
            {
                main.Close();
            }
        }

        private void btnChinhSach_Click(object sender, EventArgs e)
        {
            Form1 main = Application.OpenForms["Form1"] as Form1;
            if (main != null)
            {
                main.OpenChildForm(new gdChinhSach());
            }
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            Form1 main = Application.OpenForms["Form1"] as Form1;
            if (main != null)
            {
                // Mở gdDiaChi đè lên panel chính (giống như mở Giỏ hàng)
                main.OpenChildForm(new gdDiaChi());
            }
        }

        private void picAvatar_Click(object sender, EventArgs e)
        {

        }
    }
}
