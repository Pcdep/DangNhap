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
    public partial class FrmDangKy_1 : Form
    {
        public FrmDangKy_1()
        {
            InitializeComponent();
        }

        private void gdDangKy1_Load(object sender, EventArgs e)
        {

        }

        private void btnSendOTP_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra điều khoản và nhập liệu (Code cũ)
            if (!chkTerms.Checked)
            {
                MessageBox.Show("Bạn vui lòng đồng ý với điều khoản sử dụng!", "Thông báo");
                return;
            }

            string email = txtEmail.Text.Trim();
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ Email!", "Thông báo");
                return;
            }

            // --- ĐOẠN CODE MỚI THÊM: KIỂM TRA EMAIL TRÙNG ---
            try
            {
                // BẮT ĐẦU COPY ĐOẠN NÀY
                using (SqlConnection cn = Db.Open())
                {
                    string query = "SELECT COUNT(*) FROM Users WHERE Email = @email";
                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("@email", email);
                        int count = (int)cmd.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Email này đã được đăng ký tài khoản rồi!\nVui lòng dùng Email khác hoặc Đăng nhập.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                // KẾT THÚC COPY
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message);
                return;
            }
            // ------------------------------------------------

            // 2. Nếu chưa trùng thì mới Gửi OTP (Code cũ giữ nguyên)
            Random rand = new Random();
            string otp = rand.Next(100000, 999999).ToString();

            EmailService.OtpCode = otp;
            EmailService.UserEmail = email;

            bool sent = EmailService.SendMail(email, otp);

            if (sent)
            {
                MessageBox.Show("Mã OTP đã được gửi! Vui lòng kiểm tra Email.");

                FrmXacNhanMa frmVerify = new FrmXacNhanMa();
                frmVerify.Show();
                this.Hide();
            }
        }

        private void btnLoginNav_Click(object sender, EventArgs e)
        {
            // Mở form đăng nhập có sẵn của bạn
            // Giả sử tên form đăng nhập là gdDangNhap
            FrmDangNhap frmLogin = new FrmDangNhap();
            frmLogin.Show();
            this.Close();
        }

        private void chkTerms_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
