namespace Presentation
{
    partial class FrmBanHang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBanHang));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panelImage = new Guna.UI2.WinForms.Guna2Panel();
            ProductCard5 = new Guna.UI2.WinForms.Guna2ImageButton();
            label16 = new Label();
            flpSanPham = new FlowLayoutPanel();
            panelImage.SuspendLayout();
            flpSanPham.SuspendLayout();
            SuspendLayout();
            // 
            // panelImage
            // 
            panelImage.BackgroundImage = (Image)resources.GetObject("panelImage.BackgroundImage");
            panelImage.BackgroundImageLayout = ImageLayout.Stretch;
            panelImage.Controls.Add(ProductCard5);
            panelImage.Controls.Add(label16);
            panelImage.CustomizableEdges = customizableEdges2;
            panelImage.Location = new Point(2, 2);
            panelImage.Margin = new Padding(2);
            panelImage.Name = "panelImage";
            panelImage.ShadowDecoration.CustomizableEdges = customizableEdges3;
            panelImage.Size = new Size(920, 1410);
            panelImage.TabIndex = 40;
            // 
            // ProductCard5
            // 
            ProductCard5.CheckedState.ImageSize = new Size(64, 64);
            ProductCard5.HoverState.Image = (Image)resources.GetObject("resource.Image");
            ProductCard5.HoverState.ImageSize = new Size(260, 260);
            ProductCard5.Image = (Image)resources.GetObject("ProductCard5.Image");
            ProductCard5.ImageOffset = new Point(0, -60);
            ProductCard5.ImageRotate = 0F;
            ProductCard5.ImageSize = new Size(200, 200);
            ProductCard5.Location = new Point(443, 722);
            ProductCard5.Margin = new Padding(2);
            ProductCard5.Name = "ProductCard5";
            ProductCard5.PressedState.Image = (Image)resources.GetObject("resource.Image1");
            ProductCard5.PressedState.ImageSize = new Size(260, 260);
            ProductCard5.ShadowDecoration.CustomizableEdges = customizableEdges1;
            ProductCard5.Size = new Size(0, 0);
            ProductCard5.TabIndex = 39;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.BackColor = Color.Transparent;
            label16.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label16.ForeColor = Color.Black;
            label16.Location = new Point(41, 34);
            label16.Margin = new Padding(2, 0, 2, 0);
            label16.Name = "label16";
            label16.Size = new Size(131, 29);
            label16.TabIndex = 41;
            label16.Text = "Sản Phẩm";
            // 
            // flpSanPham
            // 
            flpSanPham.AutoScroll = true;
            flpSanPham.Controls.Add(panelImage);
            flpSanPham.Location = new Point(44, 36);
            flpSanPham.Name = "flpSanPham";
            flpSanPham.Size = new Size(949, 787);
            flpSanPham.TabIndex = 41;
            // 
            // FrmBanHang
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1035, 835);
            Controls.Add(flpSanPham);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmBanHang";
            Text = "FrmBanHang";
            panelImage.ResumeLayout(false);
            panelImage.PerformLayout();
            flpSanPham.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panelImage;
        private Guna.UI2.WinForms.Guna2ImageButton ProductCard5;
        private Label label16;
        private FlowLayoutPanel flpSanPham;
    }
}