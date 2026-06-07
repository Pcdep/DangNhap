using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace gd_chính
{
    public partial class gdDangKy2 : Form
    {
        public gdDangKy2()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void gdDangKy2_Load(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtPass.Text != txtConfirmPass.Text)
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp!");
                return;
            }

            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtPass.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                return;
            }

            // 2. Lưu vào CSDL (SQL Server)
            try
            {
                // Dùng chuỗi kết nối từ class Db của bạn
                using (SqlConnection cn = Db.Open()) // Hoặc new SqlConnection("chuoi_ket_noi")
                {
                    // Lấy Email từ biến tạm đã lưu ở bước 1
                    string email = EmailService.UserEmail;

                    string query = @"INSERT INTO Users (FullName, Email, Phone, Password, Role) 
                                     VALUES (@name, @email, @phone, @pass, 'User')";

                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("@name", txtName.Text);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                        cmd.Parameters.AddWithValue("@pass", txtPass.Text); // Nên mã hóa password trước khi lưu

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Đăng ký tài khoản thành công!");

                // 3. Chuyển về trang Đăng nhập
                gdDangNhap frmLogin = new gdDangNhap();
                frmLogin.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đăng ký: " + ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Quay lại trang 1
            gdDangKy1 frmReg1 = new gdDangKy1();
            frmReg1.Show();
            this.Close();
        }

        private void btnLoginNav_Click(object sender, EventArgs e)
        {
            gdDangNhap frmLogin = new gdDangNhap();
            frmLogin.Show();
            this.Close();
        }
    }
}
