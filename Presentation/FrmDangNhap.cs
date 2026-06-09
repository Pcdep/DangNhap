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
            string username = txtUser.Text.Trim(); // Nhớ check đúng tên control txt của bạn
            string password = txtPass.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập tài khoản và mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "SELECT Role, FullName FROM Users WHERE Username = @User AND Password = @Pass";

            // Use a connection string from App.config/Web.config instead of the missing Infracstructure helper
            string connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"]?.ConnectionString;
            if (string.IsNullOrEmpty(connStr))
            {
                MessageBox.Show("Connection string 'DefaultConnection' not found in configuration.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@User", username);
                        cmd.Parameters.AddWithValue("@Pass", password);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read()) // Đăng nhập thành công
                            {
                                string quyen = reader["Role"].ToString();
                                string hoTen = reader["FullName"].ToString();

                                MessageBox.Show($"Xin chào {hoTen}!\nBạn đang đăng nhập với quyền: {quyen}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Mở Form Main và ẩn Form Đăng Nhập
                                FrmMain frmMain = new FrmMain();
                                frmMain.Show();
                                this.Hide();
                            }
                            else // Sai tài khoản
                            {
                                MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác!", "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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