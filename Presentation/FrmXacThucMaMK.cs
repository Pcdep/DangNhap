using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation
{
    public partial class FrmXacThucMaMK : Form
    {
        private int _timeLeft = 120; // 2 phút
        public FrmXacThucMaMK()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gdXacThucMaMK_Load(object sender, EventArgs e)
        {
            lblDisplayEmail.Text = EmailService.UserEmail;
            timerCountDown.Start();
        }

        private void timerCountDown_Tick(object sender, EventArgs e)
        {
            if (_timeLeft > 0)
            {
                _timeLeft--;
                lblTimer.Text = $"{_timeLeft / 60}:{_timeLeft % 60:00}";
            }
            else
            {
                timerCountDown.Stop();
                MessageBox.Show("Mã đã hết hạn. Vui lòng thử lại.");
                btnBack.PerformClick(); // Tự động bấm nút Back
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            // Ghép mã
            string inputOTP = txtOTP1.Text + txtOTP2.Text + txtOTP3.Text +
                              txtOTP4.Text + txtOTP5.Text + txtOTP6.Text;

            if (inputOTP == EmailService.OtpCode)
            {
                timerCountDown.Stop();

                // --- CHUYỂN SANG FORM ĐỔI MẬT KHẨU ---
                FrmQuenMatKhau_2 frmReset = new FrmQuenMatKhau_2();
                frmReset.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Mã xác thực không đúng!");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FrmDangNhap frmLogin = new FrmDangNhap();
            frmLogin.Show();
            this.Close();
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
