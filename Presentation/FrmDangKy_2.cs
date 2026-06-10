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

namespace Presentation
{
    public partial class FrmDangKy_2 : Form
    {
        public FrmDangKy_2()
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
                // BẮT ĐẦU COPY ĐOẠN NÀY
                using (SqlConnection cn = Db.Open())
                {
                    string email = EmailService.UserEmail;

                    // Thay đổi toàn bộ tên cột thành Tiếng Anh: Username, FullName, Email, Phone, Password, Role
                    string query = @"INSERT INTO Users (Username, FullName, Email, Phone, Password, Role) 
                     VALUES (@email, @name, @email, @phone, @pass, 'User')";

                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@name", txtName.Text);
                        cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                        cmd.Parameters.AddWithValue("@pass", txtPass.Text);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Đăng ký tài khoản thành công!");
                FrmDangNhap frmLogin = new FrmDangNhap();
                frmLogin.Show();
                this.Close();
                // KẾT THÚC COPY
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đăng ký: " + ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Quay lại trang 1
            FrmDangKy_1 frmReg1 = new FrmDangKy_1();
            frmReg1.Show();
            this.Close();
        }

        private void btnLoginNav_Click(object sender, EventArgs e)
        {
            FrmDangNhap frmLogin = new FrmDangNhap();
            frmLogin.Show();
            this.Close();
        }
    }
}
