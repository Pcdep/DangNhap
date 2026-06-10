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
    public partial class FrmQuenMatKhau_1 : Form
    {
        public FrmQuenMatKhau_1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void gdQuenMatKhau_Load(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Vui lòng nhập Email đã đăng ký!");
                return;
            }

            // 1. Kiểm tra Email có tồn tại trong SQL không?
            bool emailExists = false;
            try
            {
                // BẮT ĐẦU COPY ĐOẠN NÀY
                using (SqlConnection cn = Db.Open())
                {
                    string query = "UPDATE Users SET Password = @pass WHERE Email = @email";
                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("@email", email);
                        int count = (int)cmd.ExecuteScalar();
                        if (count > 0) emailExists = true;
                    }
                }
                // KẾT THÚC COPY
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối SQL: " + ex.Message);
                return;
            }

            if (!emailExists)
            {
                MessageBox.Show("Email này chưa được đăng ký trong hệ thống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Nếu Email đúng -> Gửi OTP
            Random rand = new Random();
            string otp = rand.Next(100000, 999999).ToString();

            // Lưu thông tin vào bộ nhớ tạm
            EmailService.OtpCode = otp;
            EmailService.UserEmail = email;

            bool sent = EmailService.SendMail(email, otp);

            if (sent)
            {
                MessageBox.Show("Mã xác thực đã được gửi vào Email của bạn.");

                // Chuyển sang bước xác thực
                FrmXacThucMaMK frmVerify = new FrmXacThucMaMK();
                frmVerify.Show();
                this.Close();
            }
        }

        private void btnBackToLogin_Click(object sender, EventArgs e)
        {
            FrmDangNhap frmLogin = new FrmDangNhap();
            frmLogin.Show();
            this.Close();
        }
    }
}
