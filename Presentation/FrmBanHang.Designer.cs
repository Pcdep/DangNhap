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
            flpSanPham = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // flpSanPham
            // 
            flpSanPham.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flpSanPham.AutoScroll = true;
            flpSanPham.BackgroundImage = (Image)resources.GetObject("flpSanPham.BackgroundImage");
            flpSanPham.BackgroundImageLayout = ImageLayout.Stretch;
            flpSanPham.Location = new Point(0, 0);
            flpSanPham.Name = "flpSanPham";
            flpSanPham.Size = new Size(960, 790);
            flpSanPham.TabIndex = 41;
            // 
            // FrmBanHang
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(960, 790);
            Controls.Add(flpSanPham);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmBanHang";
            Text = "FrmBanHang";
            ResumeLayout(false);
        }

        #endregion
        private FlowLayoutPanel flpSanPham;
    }
}