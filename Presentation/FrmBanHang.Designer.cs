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
            label16 = new Label();
            flpSanPham = new FlowLayoutPanel();
            flpSanPham.SuspendLayout();
            SuspendLayout();
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.BackColor = Color.Transparent;
            label16.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label16.ForeColor = Color.Black;
            label16.Location = new Point(2, 0);
            label16.Margin = new Padding(2, 0, 2, 0);
            label16.Name = "label16";
            label16.Size = new Size(131, 29);
            label16.TabIndex = 41;
            label16.Text = "Sản Phẩm";
            label16.Click += label16_Click;
            // 
            // flpSanPham
            // 
            flpSanPham.AutoScroll = true;
            flpSanPham.BackgroundImage = (Image)resources.GetObject("flpSanPham.BackgroundImage");
            flpSanPham.BackgroundImageLayout = ImageLayout.Stretch;
            flpSanPham.Controls.Add(label16);
            flpSanPham.Location = new Point(0, 0);
            flpSanPham.Name = "flpSanPham";
            flpSanPham.Size = new Size(1036, 823);
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
            flpSanPham.ResumeLayout(false);
            flpSanPham.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label label16;
        private FlowLayoutPanel flpSanPham;
    }
}