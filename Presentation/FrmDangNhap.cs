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
            string username = txtTenDangNhap.Text.Trim();
            string password = txtMatKhau.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập tài khoản và mật khẩu!", "Thông báo");
                return;
            }

            // Câu lệnh chuẩn hóa theo tên cột mới trong CSDL
            string query = "SELECT Quyen, HoTen FROM Users WHERE TaiKhoan = @User AND MatKhau = @Pass";

            try
            {
                // BẮT ĐẦU COPY ĐOẠN NÀY DÁN ĐÈ VÀO
                using (SqlConnection conn = Db.Open())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@User", username);
                        cmd.Parameters.AddWithValue("@Pass", password);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string quyen = reader["Quyen"].ToString();
                                string hoTen = reader["HoTen"].ToString();

                                MessageBox.Show($"Xin chào {hoTen}!\nQuyền: {quyen}", "Thành công");

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