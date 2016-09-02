namespace Second
{
    partial class login1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login1));
            this.login_panel = new System.Windows.Forms.Panel();
            this.showPassword_pictureBox = new System.Windows.Forms.PictureBox();
            this.exit_pictureBox = new System.Windows.Forms.PictureBox();
            this.logo_pictureBox = new System.Windows.Forms.PictureBox();
            this.login_enter_lbl = new System.Windows.Forms.Label();
            this.login_password_txtbx = new System.Windows.Forms.TextBox();
            this.login_username_txtbx = new System.Windows.Forms.TextBox();
            this.login_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.showPassword_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exit_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logo_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // login_panel
            // 
            this.login_panel.BackColor = System.Drawing.Color.Transparent;
            this.login_panel.BackgroundImage = global::Second.Properties.Resources.loginBackGround;
            this.login_panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.login_panel.Controls.Add(this.showPassword_pictureBox);
            this.login_panel.Controls.Add(this.exit_pictureBox);
            this.login_panel.Controls.Add(this.logo_pictureBox);
            this.login_panel.Controls.Add(this.login_enter_lbl);
            this.login_panel.Controls.Add(this.login_password_txtbx);
            this.login_panel.Controls.Add(this.login_username_txtbx);
            this.login_panel.Font = new System.Drawing.Font("B Yekan+", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.login_panel.Location = new System.Drawing.Point(1, 4);
            this.login_panel.Margin = new System.Windows.Forms.Padding(4);
            this.login_panel.Name = "login_panel";
            this.login_panel.Size = new System.Drawing.Size(394, 396);
            this.login_panel.TabIndex = 6;
            // 
            // showPassword_pictureBox
            // 
            this.showPassword_pictureBox.BackgroundImage = global::Second.Properties.Resources._21312;
            this.showPassword_pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.showPassword_pictureBox.Location = new System.Drawing.Point(310, 227);
            this.showPassword_pictureBox.Name = "showPassword_pictureBox";
            this.showPassword_pictureBox.Size = new System.Drawing.Size(32, 29);
            this.showPassword_pictureBox.TabIndex = 7;
            this.showPassword_pictureBox.TabStop = false;
            this.showPassword_pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.showPassword_pictureBox_MouseDown);
            this.showPassword_pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.showPassword_pictureBox_MouseUp);
            // 
            // exit_pictureBox
            // 
            this.exit_pictureBox.BackgroundImage = global::Second.Properties.Resources.exit_1;
            this.exit_pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.exit_pictureBox.Location = new System.Drawing.Point(339, 30);
            this.exit_pictureBox.Name = "exit_pictureBox";
            this.exit_pictureBox.Size = new System.Drawing.Size(30, 30);
            this.exit_pictureBox.TabIndex = 6;
            this.exit_pictureBox.TabStop = false;
            this.exit_pictureBox.Click += new System.EventHandler(this.exit_pictureBox_Click);
            this.exit_pictureBox.MouseEnter += new System.EventHandler(this.exit_pictureBox_MouseEnter);
            this.exit_pictureBox.MouseLeave += new System.EventHandler(this.exit_pictureBox_MouseLeave);
            // 
            // logo_pictureBox
            // 
            this.logo_pictureBox.BackgroundImage = global::Second.Properties.Resources.logo_01_fa;
            this.logo_pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.logo_pictureBox.Location = new System.Drawing.Point(59, 54);
            this.logo_pictureBox.Name = "logo_pictureBox";
            this.logo_pictureBox.Size = new System.Drawing.Size(280, 71);
            this.logo_pictureBox.TabIndex = 5;
            this.logo_pictureBox.TabStop = false;
            // 
            // login_enter_lbl
            // 
            this.login_enter_lbl.BackColor = System.Drawing.Color.Transparent;
            this.login_enter_lbl.Font = new System.Drawing.Font("B Yekan+", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.login_enter_lbl.ForeColor = System.Drawing.Color.White;
            this.login_enter_lbl.Location = new System.Drawing.Point(53, 287);
            this.login_enter_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.login_enter_lbl.Name = "login_enter_lbl";
            this.login_enter_lbl.Size = new System.Drawing.Size(292, 44);
            this.login_enter_lbl.TabIndex = 3;
            this.login_enter_lbl.Text = "ورود";
            this.login_enter_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.login_enter_lbl.Click += new System.EventHandler(this.label1_Click);
            this.login_enter_lbl.MouseEnter += new System.EventHandler(this.login_enter_lbl_MouseEnter);
            this.login_enter_lbl.MouseLeave += new System.EventHandler(this.login_enter_lbl_MouseLeave);
            // 
            // login_password_txtbx
            // 
            this.login_password_txtbx.BackColor = System.Drawing.Color.White;
            this.login_password_txtbx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.login_password_txtbx.Font = new System.Drawing.Font("B Yekan+", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.login_password_txtbx.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.login_password_txtbx.Location = new System.Drawing.Point(59, 224);
            this.login_password_txtbx.Margin = new System.Windows.Forms.Padding(4);
            this.login_password_txtbx.Name = "login_password_txtbx";
            this.login_password_txtbx.PasswordChar = '●';
            this.login_password_txtbx.Size = new System.Drawing.Size(242, 26);
            this.login_password_txtbx.TabIndex = 2;
            this.login_password_txtbx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.login_password_txtbx_KeyPress);
            // 
            // login_username_txtbx
            // 
            this.login_username_txtbx.BackColor = System.Drawing.Color.White;
            this.login_username_txtbx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.login_username_txtbx.Font = new System.Drawing.Font("B Yekan+", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.login_username_txtbx.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.login_username_txtbx.Location = new System.Drawing.Point(59, 164);
            this.login_username_txtbx.Margin = new System.Windows.Forms.Padding(4);
            this.login_username_txtbx.Name = "login_username_txtbx";
            this.login_username_txtbx.Size = new System.Drawing.Size(242, 26);
            this.login_username_txtbx.TabIndex = 1;
            this.login_username_txtbx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.login_username_txtbx_KeyPress);
            // 
            // login1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 399);
            this.Controls.Add(this.login_panel);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "login1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "login";
            this.Load += new System.EventHandler(this.login1_Load);
            this.login_panel.ResumeLayout(false);
            this.login_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.showPassword_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exit_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logo_pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox login_password_txtbx;
        private System.Windows.Forms.TextBox login_username_txtbx;
        private System.Windows.Forms.Label login_enter_lbl;
        private System.Windows.Forms.Panel login_panel;
        private System.Windows.Forms.PictureBox logo_pictureBox;
        private System.Windows.Forms.PictureBox exit_pictureBox;
        private System.Windows.Forms.PictureBox showPassword_pictureBox;
    }
}