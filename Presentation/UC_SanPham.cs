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

        // Hàm này dùng để đổ dữ liệu SQL vào UI
        public void CapNhatDuLieu(string tenSP, decimal giaSP)
        {
            lblTenSP.Text = tenSP;
            lblGiaSP.Text = giaSP.ToString("N0") + " VNĐ";
            // (Phần đổ hình ảnh picHinhAnh chúng ta sẽ làm sau khi kết nối SQL)
        }

        // Tạo sự kiện khi bấm vào Component này
        private void Guna2GradientPanel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn vừa chọn sản phẩm: " + lblTenSP.Text);
            // Sau này code đẩy sản phẩm sang Giỏ hàng sẽ viết ở đây
        }

        private void UC_SanPham_Load(object sender, EventArgs e)
        {

        }
    }
}
