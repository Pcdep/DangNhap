using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation
{
    public static class EmailService
    {
        private static string _fromEmail = "phuclocle2@gmail.com";
        private static string _password = "ijac lqfc ooxa tyth";

        public static string OtpCode = "";    // Lưu OTP hiện tại
        public static string UserEmail = "";  // Lưu Email người đăng ký

        public static bool SendMail(string toEmail, string otp)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(_fromEmail);
                mail.To.Add(toEmail);
                mail.Subject = "Mã xác thực OTP - Mivorisa App";
                mail.Body = $"Mã OTP của bạn là: {otp}\nMã này sẽ hết hạn sau 2 phút.";

                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(_fromEmail, _password);

                smtp.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gửi mail: " + ex.Message);
                return false;
            }
        }
    }
}
