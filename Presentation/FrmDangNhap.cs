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
using System.Configuration;

namespace Presentation
{
    public partial class FrmDangNhap : Form
    {
        public FrmDangNhap()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void gdDangNhap_Load(object sender, EventArgs e)
        {

        }

        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Chuyển sang giao diện Đăng ký bước 1
            FrmDangKy_1 frmReg1 = new FrmDangKy_1();
            frmReg1.StartPosition = FormStartPosition.CenterScreen;
            frmReg1.Show();
            this.Hide();
        }

        private void lblRegister_Click(object sender, EventArgs e)
        {
            FrmDangKy_1 frmReg1 = new FrmDangKy_1();
            frmReg1.StartPosition = FormStartPosition.CenterScreen;
            frmReg1.Show();

            this.Hide(); // QUAN TRỌNG: Ẩn form đăng nhập đi ngay lập tức
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtUser.Text.Trim();
            string pass = txtPass.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Vui lòng nhập tài khoản và mật khẩu!", "Thông báo");
                return;
            }

            string query = "SELECT UserId, FullName FROM Users WHERE Email = @email AND Password = @pass";
            MessageBox.Show("Câu lệnh chuẩn bị chạy là:\n" + query, "Test Câu Lệnh");
            try
            {
                // BẮT ĐẦU COPY ĐOẠN NÀY DÁN ĐÈ VÀO
                using (SqlConnection conn = Db.Open())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@pass", pass);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // 2. Lấy dữ liệu cũng bằng tên Tiếng Anh
                                int userId = Convert.ToInt32(reader["UserId"]);
                                string name = reader["FullName"].ToString();

                              

                                FrmMain main = new FrmMain();
                                main.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!", "Thông báo");
                            }
                        }
                    }
                }
                // KẾT THÚC COPY
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực thi SQL: " + ex.Message, "Lỗi hệ thống");
            }
        }


        private void linkmk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmQuenMatKhau_1 frmForgot = new FrmQuenMatKhau_1();
            frmForgot.Show();
            this.Hide();
        }
    }
}