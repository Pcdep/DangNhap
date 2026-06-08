namespace Presentation
{
    partial class FrmDangKy_1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDangKy_1));
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnLoginNav = new Guna.UI2.WinForms.Guna2Button();
            this.btnSendOTP = new Guna.UI2.WinForms.Guna2Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkTerms = new System.Windows.Forms.CheckBox();
            this.txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.White;
            this.guna2Panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("guna2Panel1.BackgroundImage")));
            this.guna2Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.guna2Panel1.Controls.Add(this.btnLoginNav);
            this.guna2Panel1.Controls.Add(this.btnSendOTP);
            this.guna2Panel1.Controls.Add(this.label2);
            this.guna2Panel1.Controls.Add(this.label3);
            this.guna2Panel1.Controls.Add(this.chkTerms);
            this.guna2Panel1.Controls.Add(this.txtEmail);
            this.guna2Panel1.Controls.Add(this.label5);
            this.guna2Panel1.Location = new System.Drawing.Point(1, -8);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1118, 945);
            this.guna2Panel1.TabIndex = 0;
            // 
            // btnLoginNav
            // 
            this.btnLoginNav.BackColor = System.Drawing.Color.Transparent;
            this.btnLoginNav.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLoginNav.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLoginNav.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLoginNav.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLoginNav.FillColor = System.Drawing.Color.Transparent;
            this.btnLoginNav.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.125F);
            this.btnLoginNav.ForeColor = System.Drawing.Color.Black;
            this.btnLoginNav.Location = new System.Drawing.Point(555, 651);
            this.btnLoginNav.Name = "btnLoginNav";
            this.btnLoginNav.Size = new System.Drawing.Size(188, 45);
            this.btnLoginNav.TabIndex = 52;
            this.btnLoginNav.Text = "Log in Now";
            this.btnLoginNav.Click += new System.EventHandler(this.btnLoginNav_Click);
            // 
            // btnSendOTP
            // 
            this.btnSendOTP.BorderRadius = 20;
            this.btnSendOTP.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSendOTP.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSendOTP.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSendOTP.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSendOTP.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(202)))), ((int)(((byte)(210)))));
            this.btnSendOTP.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSendOTP.ForeColor = System.Drawing.Color.White;
            this.btnSendOTP.Image = ((System.Drawing.Image)(resources.GetObject("btnSendOTP.Image")));
            this.btnSendOTP.ImageSize = new System.Drawing.Size(80, 80);
            this.btnSendOTP.Location = new System.Drawing.Point(160, 540);
            this.btnSendOTP.Name = "btnSendOTP";
            this.btnSendOTP.Size = new System.Drawing.Size(632, 79);
            this.btnSendOTP.TabIndex = 39;
            this.btnSendOTP.Text = "Send OTP code via Email";
            this.btnSendOTP.Click += new System.EventHandler(this.btnSendOTP_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.125F);
            this.label2.Location = new System.Drawing.Point(206, 654);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(354, 35);
            this.label2.TabIndex = 14;
            this.label2.Text = "Already have an account ?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 22.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(355, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(259, 68);
            this.label3.TabIndex = 12;
            this.label3.Text = "SIGN UP";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // chkTerms
            // 
            this.chkTerms.AutoSize = true;
            this.chkTerms.BackColor = System.Drawing.Color.Transparent;
            this.chkTerms.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.875F);
            this.chkTerms.Location = new System.Drawing.Point(166, 383);
            this.chkTerms.Name = "chkTerms";
            this.chkTerms.Size = new System.Drawing.Size(626, 60);
            this.chkTerms.TabIndex = 10;
            this.chkTerms.Text = "   By creating and/or using your account, you agree to our\r\n   Terms of Use and P" +
    "rivacy Policy.";
            this.chkTerms.UseVisualStyleBackColor = false;
            this.chkTerms.CheckedChanged += new System.EventHandler(this.chkTerms_CheckedChanged);
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.Transparent;
            this.txtEmail.BorderRadius = 15;
            this.txtEmail.BorderThickness = 2;
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmail.DefaultText = "";
            this.txtEmail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEmail.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEmail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEmail.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmail.Location = new System.Drawing.Point(160, 273);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PlaceholderText = "Name@gmail.com";
            this.txtEmail.SelectedText = "";
            this.txtEmail.Size = new System.Drawing.Size(632, 78);
            this.txtEmail.TabIndex = 9;
            this.txtEmail.TextOffset = new System.Drawing.Point(15, 0);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F);
            this.label5.Location = new System.Drawing.Point(166, 212);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(200, 39);
            this.label5.TabIndex = 8;
            this.label5.Text = "Địa chỉ Email";
            // 
            // gdDangKy1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 813);
            this.Controls.Add(this.guna2Panel1);
            this.Name = "gdDangKy1";
            this.Text = "gdDangKy1";
            this.Load += new System.EventHandler(this.gdDangKy1_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkTerms;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2Button btnSendOTP;
        private Guna.UI2.WinForms.Guna2Button btnLoginNav;
    }
}