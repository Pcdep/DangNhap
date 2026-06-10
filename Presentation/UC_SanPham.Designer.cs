namespace Presentation
{
    partial class UC_SanPham
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna2GradientPanel = new Guna.UI2.WinForms.Guna2GradientPanel();
            picHinhAnh = new PictureBox();
            lblTenSP = new Label();
            lblGiaSP = new Label();
            Guna2GradientPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picHinhAnh).BeginInit();
            SuspendLayout();
            // 
            // Guna2GradientPanel
            // 
            Guna2GradientPanel.BackColor = Color.Transparent;
            Guna2GradientPanel.BorderRadius = 25;
            Guna2GradientPanel.Controls.Add(picHinhAnh);
            Guna2GradientPanel.Controls.Add(lblTenSP);
            Guna2GradientPanel.Controls.Add(lblGiaSP);
            Guna2GradientPanel.CustomizableEdges = customizableEdges1;
            Guna2GradientPanel.FillColor = Color.FromArgb(200, 246, 246, 246);
            Guna2GradientPanel.FillColor2 = Color.FromArgb(200, 245, 245, 243);
            Guna2GradientPanel.ForeColor = Color.White;
            Guna2GradientPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            Guna2GradientPanel.Location = new Point(17, 26);
            Guna2GradientPanel.Margin = new Padding(2);
            Guna2GradientPanel.Name = "Guna2GradientPanel";
            Guna2GradientPanel.ShadowDecoration.CustomizableEdges = customizableEdges2;
            Guna2GradientPanel.Size = new Size(263, 344);
            Guna2GradientPanel.TabIndex = 48;
            Guna2GradientPanel.UseTransparentBackground = true;
            // 
            // picHinhAnh
            // 
            picHinhAnh.BackColor = Color.White;
            picHinhAnh.Location = new Point(34, 27);
            picHinhAnh.Name = "picHinhAnh";
            picHinhAnh.Size = new Size(198, 188);
            picHinhAnh.TabIndex = 47;
            picHinhAnh.TabStop = false;
            // 
            // lblTenSP
            // 
            lblTenSP.AutoSize = true;
            lblTenSP.BackColor = Color.Transparent;
            lblTenSP.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTenSP.ForeColor = Color.Black;
            lblTenSP.Location = new Point(34, 234);
            lblTenSP.Margin = new Padding(2, 0, 2, 0);
            lblTenSP.Name = "lblTenSP";
            lblTenSP.Size = new Size(198, 29);
            lblTenSP.TabIndex = 46;
            lblTenSP.Text = "Sữa rửa mặt N...";
            // 
            // lblGiaSP
            // 
            lblGiaSP.AutoSize = true;
            lblGiaSP.BackColor = Color.Transparent;
            lblGiaSP.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGiaSP.ForeColor = Color.Red;
            lblGiaSP.Location = new Point(34, 275);
            lblGiaSP.Margin = new Padding(2, 0, 2, 0);
            lblGiaSP.Name = "lblGiaSP";
            lblGiaSP.Size = new Size(119, 29);
            lblGiaSP.TabIndex = 45;
            lblGiaSP.Text = "280.000₫";
            // 
            // UC_SanPham
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(Guna2GradientPanel);
            Name = "UC_SanPham";
            Size = new Size(298, 396);
            Load += UC_SanPham_Load;
            Guna2GradientPanel.ResumeLayout(false);
            Guna2GradientPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picHinhAnh).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel Guna2GradientPanel;
        private PictureBox picHinhAnh;
        private Label lblTenSP;
        private Label lblGiaSP;
    }
}