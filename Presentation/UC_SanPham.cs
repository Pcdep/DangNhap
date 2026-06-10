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
    public partial class UC_SanPham : UserControl
    {
        public UC_SanPham()
        {
            InitializeComponent();
            WireAllControls(this);
        }

        private void WireAllControls(Control control)
        {
            foreach (Control child in control.Controls)
            {
                child.Click += Control_Click;
                WireAllControls(child);
            }
        }

        private void Control_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        
        public void CapNhatDuLieu(string maSP, string tenSP, decimal giaSP)
        {
            lblTenSP.Text = tenSP;
            lblGiaSP.Text = giaSP.ToString("N0") + " VNĐ";

            // 2. Code tự động tìm và nạp hình ảnh
            string imagePath = System.Windows.Forms.Application.StartupPath + "\\Images\\" + maSP + ".jpg";
            if (System.IO.File.Exists(imagePath))
            {
                using (System.IO.FileStream fs = new System.IO.FileStream(imagePath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {
                    
                    if (picHinhAnh != null)
                    {
                        picHinhAnh.Image = Image.FromStream(fs);
                        picHinhAnh.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                }
            }
            else
            {
                if (picHinhAnh != null) picHinhAnh.Image = null; // Làm trống nếu chưa có ảnh
            }
        }

        // Tạo sự kiện khi bấm vào Component này
        private void Guna2GradientPanel_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        private void UC_SanPham_Load(object sender, EventArgs e)
        {

        }
    }
}
