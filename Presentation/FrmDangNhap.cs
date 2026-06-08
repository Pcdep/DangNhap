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
                MessageBox.Show("Vui lòng nhập Email và Mật khẩu!");
                return;
            }

            try
            {
                // Kiểm tra trong CSDL
                using (SqlConnection cn = Db.Open()) // Giả sử bạn đã có class Db kết nối SQL
                {
                    // Câu lệnh tìm user có Email và Pass trùng khớp
                    string query = "SELECT UserId, FullName FROM Users WHERE Email = @email AND Password = @pass";

                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@pass", pass);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read()) // Nếu tìm thấy (Đăng nhập thành công)
                            {
                                int userId = Convert.ToInt32(reader["UserId"]);
                                string name = reader["FullName"].ToString();

                                // 1. Cập nhật User ID
                                FrmMain.CurrentUserId = userId;

                                MessageBox.Show("Đăng nhập thành công! Xin chào " + name);

                                // 2. Ẩn form đăng nhập đi
                                

                                // 3. Khởi tạo và mở Form1 theo dạng HỘP THOẠI (Dialog)
                                FrmMain frmMain = new FrmMain();
                                frmMain.StartPosition = FormStartPosition.CenterScreen;
                                this.Hide();
                                

                                // --- DÒNG QUAN TRỌNG NHẤT ---
                                // Code sẽ dừng ở dòng này cho đến khi bạn Đăng xuất (tức là khi Form1 bị đóng)
                                frmMain.ShowDialog();

                                // 4. Khi Form1 đóng lại, dòng này mới chạy -> Tự hiện lại form Đăng nhập cũ
                                this.Show();

                                // (Tùy chọn) Xóa mật khẩu cũ đi cho an toàn
                                txtPass.Text = "";
                            }
                            else
                            {
                                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
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
