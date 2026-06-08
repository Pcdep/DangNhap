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
    public partial class FrmQuenMatKhau_2 : Form
    {
        public FrmQuenMatKhau_2()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string newPass = txtNewPass.Text.Trim();
            string confirmPass = txtConfirmPass.Text.Trim();

            if (string.IsNullOrEmpty(newPass) || string.IsNullOrEmpty(confirmPass))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            if (newPass != confirmPass)
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp!");
                return;
            }

            // --- CẬP NHẬT VÀO SQL ---
            try
            {
                using (SqlConnection cn = Db.Open())
                {
                    // Update mật khẩu dựa theo Email đã lưu ở bước 1
                    string query = "UPDATE Users SET Password = @pass WHERE Email = @email";

                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("@pass", newPass); // Nên mã hóa pass nếu có thể
                        cmd.Parameters.AddWithValue("@email", EmailService.UserEmail);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Đổi mật khẩu thành công! Vui lòng đăng nhập lại.");

                            // Quay về đăng nhập
                            FrmDangNhap frmLogin = new FrmDangNhap();
                            frmLogin.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Lỗi: Không tìm thấy tài khoản để cập nhật.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật: " + ex.Message);
            }
        }

        private void btnBackToLogin_Click(object sender, EventArgs e)
        {
            FrmDangNhap frmLogin = new FrmDangNhap();
            frmLogin.Show();
            this.Close();
        }

        private void gdQuenMatKhau2_Load(object sender, EventArgs e)
        {

        }
    }
}
