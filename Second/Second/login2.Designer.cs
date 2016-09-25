namespace Second
{
    partial class login2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login2));
            this.login_panel = new System.Windows.Forms.Panel();
            this.login_gpb = new System.Windows.Forms.GroupBox();
            this.login_password_txtbx = new System.Windows.Forms.TextBox();
            this.login_enter_lbl = new System.Windows.Forms.Label();
            this.login_username_txtbx = new System.Windows.Forms.TextBox();
            this.login_buttons_gpb = new System.Windows.Forms.GroupBox();
            this.exit_pictureBox = new System.Windows.Forms.PictureBox();
            this.login_password_pictureBox = new System.Windows.Forms.PictureBox();
            this.login_username_pictureBox = new System.Windows.Forms.PictureBox();
            this.logo_pictureBox = new System.Windows.Forms.PictureBox();
            this.login_panel.SuspendLayout();
            this.login_gpb.SuspendLayout();
            this.login_buttons_gpb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exit_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.login_password_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.login_username_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logo_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // login_panel
            // 
            this.login_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.login_panel.Controls.Add(this.login_buttons_gpb);
            this.login_panel.Controls.Add(this.exit_pictureBox);
            this.login_panel.Controls.Add(this.login_gpb);
            this.login_panel.Location = new System.Drawing.Point(0, 0);
            this.login_panel.Name = "login_panel";
            this.login_panel.Size = new System.Drawing.Size(428, 464);
            this.login_panel.TabIndex = 0;
            // 
            // login_gpb
            // 
            this.login_gpb.BackColor = System.Drawing.Color.Transparent;
            this.login_gpb.Controls.Add(this.login_password_pictureBox);
            this.login_gpb.Controls.Add(this.login_username_pictureBox);
            this.login_gpb.Controls.Add(this.login_password_txtbx);
            this.login_gpb.Controls.Add(this.logo_pictureBox);
            this.login_gpb.Controls.Add(this.login_username_txtbx);
            this.login_gpb.Location = new System.Drawing.Point(22, 27);
            this.login_gpb.Name = "login_gpb";
            this.login_gpb.Size = new System.Drawing.Size(380, 322);
            this.login_gpb.TabIndex = 12;
            this.login_gpb.TabStop = false;
            // 
            // login_password_txtbx
            // 
            this.login_password_txtbx.BackColor = System.Drawing.SystemColors.Control;
            this.login_password_txtbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.login_password_txtbx.Font = new System.Drawing.Font("B Yekan+", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.login_password_txtbx.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.login_password_txtbx.Location = new System.Drawing.Point(46, 207);
            this.login_password_txtbx.Margin = new System.Windows.Forms.Padding(4);
            this.login_password_txtbx.Name = "login_password_txtbx";
            this.login_password_txtbx.PasswordChar = '●';
            this.login_password_txtbx.Size = new System.Drawing.Size(219, 33);
            this.login_password_txtbx.TabIndex = 8;
            this.login_password_txtbx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.login_password_txtbx_KeyPress);
            // 
            // login_enter_lbl
            // 
            this.login_enter_lbl.BackColor = System.Drawing.Color.White;
            this.login_enter_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.login_enter_lbl.Font = new System.Drawing.Font("B Yekan+", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.login_enter_lbl.ForeColor = System.Drawing.Color.Black;
            this.login_enter_lbl.Location = new System.Drawing.Point(7, 18);
            this.login_enter_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.login_enter_lbl.Name = "login_enter_lbl";
            this.login_enter_lbl.Size = new System.Drawing.Size(366, 67);
            this.login_enter_lbl.TabIndex = 10;
            this.login_enter_lbl.Text = "ورود";
            this.login_enter_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.login_enter_lbl.Click += new System.EventHandler(this.label1_Click);
            this.login_enter_lbl.MouseEnter += new System.EventHandler(this.login_enter_lbl_MouseEnter);
            this.login_enter_lbl.MouseLeave += new System.EventHandler(this.login_enter_lbl_MouseLeave);
            // 
            // login_username_txtbx
            // 
            this.login_username_txtbx.BackColor = System.Drawing.SystemColors.Control;
            this.login_username_txtbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.login_username_txtbx.Font = new System.Drawing.Font("B Yekan+", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.login_username_txtbx.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.login_username_txtbx.Location = new System.Drawing.Point(46, 152);
            this.login_username_txtbx.Margin = new System.Windows.Forms.Padding(4);
            this.login_username_txtbx.Name = "login_username_txtbx";
            this.login_username_txtbx.Size = new System.Drawing.Size(219, 33);
            this.login_username_txtbx.TabIndex = 7;
            this.login_username_txtbx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.login_username_txtbx_KeyPress);
            // 
            // login_buttons_gpb
            // 
            this.login_buttons_gpb.Controls.Add(this.login_enter_lbl);
            this.login_buttons_gpb.Location = new System.Drawing.Point(22, 355);
            this.login_buttons_gpb.Name = "login_buttons_gpb";
            this.login_buttons_gpb.Size = new System.Drawing.Size(380, 97);
            this.login_buttons_gpb.TabIndex = 13;
            this.login_buttons_gpb.TabStop = false;
            // 
            // exit_pictureBox
            // 
            this.exit_pictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(5)))));
            this.exit_pictureBox.BackgroundImage = global::Second.Properties.Resources.exit_1;
            this.exit_pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.exit_pictureBox.Location = new System.Drawing.Point(396, 2);
            this.exit_pictureBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.exit_pictureBox.Name = "exit_pictureBox";
            this.exit_pictureBox.Size = new System.Drawing.Size(29, 30);
            this.exit_pictureBox.TabIndex = 11;
            this.exit_pictureBox.TabStop = false;
            this.exit_pictureBox.Click += new System.EventHandler(this.exit_pictureBox_Click);
            this.exit_pictureBox.MouseEnter += new System.EventHandler(this.exit_pictureBox_MouseEnter);
            this.exit_pictureBox.MouseLeave += new System.EventHandler(this.exit_pictureBox_MouseLeave);
            // 
            // login_password_pictureBox
            // 
            this.login_password_pictureBox.BackgroundImage = global::Second.Properties.Resources.password_icon_wallpaper_3_jpg;
            this.login_password_pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.login_password_pictureBox.Location = new System.Drawing.Point(293, 206);
            this.login_password_pictureBox.Name = "login_password_pictureBox";
            this.login_password_pictureBox.Size = new System.Drawing.Size(33, 34);
            this.login_password_pictureBox.TabIndex = 11;
            this.login_password_pictureBox.TabStop = false;
            this.login_password_pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.login_password_pictureBox_MouseDown);
            this.login_password_pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.login_password_pictureBox_MouseUp);
            // 
            // login_username_pictureBox
            // 
            this.login_username_pictureBox.BackgroundImage = global::Second.Properties.Resources.user_ico;
            this.login_username_pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.login_username_pictureBox.Location = new System.Drawing.Point(293, 151);
            this.login_username_pictureBox.Name = "login_username_pictureBox";
            this.login_username_pictureBox.Size = new System.Drawing.Size(33, 34);
            this.login_username_pictureBox.TabIndex = 10;
            this.login_username_pictureBox.TabStop = false;
            // 
            // logo_pictureBox
            // 
            this.logo_pictureBox.BackgroundImage = global::Second.Properties.Resources.logo_01_fa;
            this.logo_pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.logo_pictureBox.Location = new System.Drawing.Point(46, 31);
            this.logo_pictureBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.logo_pictureBox.Name = "logo_pictureBox";
            this.logo_pictureBox.Size = new System.Drawing.Size(280, 71);
            this.logo_pictureBox.TabIndex = 6;
            this.logo_pictureBox.TabStop = false;
            // 
            // login2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(429, 464);
            this.ControlBox = false;
            this.Controls.Add(this.login_panel);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "login2";
            this.Load += new System.EventHandler(this.login2_Load);
            this.login_panel.ResumeLayout(false);
            this.login_gpb.ResumeLayout(false);
            this.login_gpb.PerformLayout();
            this.login_buttons_gpb.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.exit_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.login_password_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.login_username_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logo_pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel login_panel;
        private System.Windows.Forms.PictureBox logo_pictureBox;
        private System.Windows.Forms.TextBox login_password_txtbx;
        private System.Windows.Forms.TextBox login_username_txtbx;
        private System.Windows.Forms.Label login_enter_lbl;
        private System.Windows.Forms.PictureBox exit_pictureBox;
        private System.Windows.Forms.GroupBox login_gpb;
        private System.Windows.Forms.GroupBox login_buttons_gpb;
        private System.Windows.Forms.PictureBox login_password_pictureBox;
        private System.Windows.Forms.PictureBox login_username_pictureBox;
    }
}