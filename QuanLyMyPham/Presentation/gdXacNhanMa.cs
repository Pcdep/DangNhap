using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gd_chính
{
    public partial class gdXacNhanMa : Form
    {
        private int _timeLeft = 120; // 120 giây = 2 phút
        public gdXacNhanMa()
        {
            InitializeComponent();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rjCircularPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void gdXacNhanMa_Load(object sender, EventArgs e)
        {
            lblDisplayEmail.Text = EmailService.UserEmail;

            // 2. Bắt đầu đếm ngược
            timerCountDown.Start();
        }
        private void timerCountDown_Tick(object sender, EventArgs e)
        {
            if (_timeLeft > 0)
            {
                _timeLeft--;
                // Quy đổi ra phút:giây
                int minutes = _timeLeft / 60;
                int seconds = _timeLeft % 60;
                lblTimer.Text = $"{minutes}:{seconds:00}"; // Ví dụ 1:05
            }
            else
            {
                // Hết giờ
                timerCountDown.Stop();
                MessageBox.Show("Mã OTP đã hết hạn! Vui lòng đăng ký lại.");

                // Quay về Form đăng ký 1
                GoBackToRegister1();
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // 1. Ghép 6 ô textbox lại thành 1 chuỗi
            string inputOTP = txtOTP1.Text + txtOTP2.Text + txtOTP3.Text +
                              txtOTP4.Text + txtOTP5.Text + txtOTP6.Text;

            // 2. So sánh với mã OTP gốc (đã lưu ở bước trước)
            if (inputOTP == EmailService.OtpCode)
            {
                timerCountDown.Stop(); // Dừng đếm
                MessageBox.Show("Xác thực thành công!");

                // 3. Chuyển sang Form nhập thông tin (gdDangKy2)
                gdDangKy2 frmInfo = new gdDangKy2();
                frmInfo.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Mã OTP không đúng, vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            gdDangKy1 frmReg1 = new gdDangKy1();
            frmReg1.Show();

            this.Close(); // Đóng form xác thực
        }

        private void GoBackToRegister1()
        {
            gdDangKy1 frmReg1 = new gdDangKy1();
            frmReg1.Show();
            this.Close(); // Đóng form này luôn
        }

        private void txtOTP_TextChanged(object sender, EventArgs e)
        {
            var currentBox = sender as Guna.UI2.WinForms.Guna2TextBox;
            if (currentBox == null) return;
            if (currentBox.Text.Length >= 1)
            {
                this.SelectNextControl(currentBox, true, true, true, true);
            }
        }

        private void txtOTP_KeyDown(object sender, KeyEventArgs e)
        {
            var currentBox = sender as Guna.UI2.WinForms.Guna2TextBox;
            if (currentBox == null) return;

            // Nếu bấm nút Xóa (Back) và ô đang trống -> Nhảy lùi lại
            if (e.KeyCode == Keys.Back && currentBox.Text.Length == 0)
            {
                this.SelectNextControl(currentBox, false, true, true, true);
            }
        }

    }
}
