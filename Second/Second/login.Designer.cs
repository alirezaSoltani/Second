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
            this.login_exit_lbl = new System.Windows.Forms.Label();
            this.login_enter_lbl = new System.Windows.Forms.Label();
            this.login_password_txtbx = new System.Windows.Forms.TextBox();
            this.login_username_txtbx = new System.Windows.Forms.TextBox();
            this.login_panel = new System.Windows.Forms.Panel();
            this.login_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // login_exit_lbl
            // 
            this.login_exit_lbl.BackColor = System.Drawing.Color.Transparent;
            this.login_exit_lbl.Location = new System.Drawing.Point(323, 46);
            this.login_exit_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.login_exit_lbl.Name = "login_exit_lbl";
            this.login_exit_lbl.Size = new System.Drawing.Size(35, 30);
            this.login_exit_lbl.TabIndex = 5;
            this.login_exit_lbl.Click += new System.EventHandler(this.label2_Click);
            // 
            // login_enter_lbl
            // 
            this.login_enter_lbl.BackColor = System.Drawing.Color.Transparent;
            this.login_enter_lbl.Font = new System.Drawing.Font("B Yekan+", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.login_enter_lbl.ForeColor = System.Drawing.Color.White;
            this.login_enter_lbl.Location = new System.Drawing.Point(89, 272);
            this.login_enter_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.login_enter_lbl.Name = "login_enter_lbl";
            this.login_enter_lbl.Size = new System.Drawing.Size(246, 44);
            this.login_enter_lbl.TabIndex = 4;
            this.login_enter_lbl.Text = "ورود";
            this.login_enter_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.login_enter_lbl.Click += new System.EventHandler(this.label1_Click);
            // 
            // login_password_txtbx
            // 
            this.login_password_txtbx.BackColor = System.Drawing.Color.White;
            this.login_password_txtbx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.login_password_txtbx.Font = new System.Drawing.Font("B Yekan+", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.login_password_txtbx.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.login_password_txtbx.Location = new System.Drawing.Point(95, 216);
            this.login_password_txtbx.Margin = new System.Windows.Forms.Padding(4);
            this.login_password_txtbx.Name = "login_password_txtbx";
            this.login_password_txtbx.PasswordChar = '●';
            this.login_password_txtbx.Size = new System.Drawing.Size(200, 34);
            this.login_password_txtbx.TabIndex = 3;
            // 
            // login_username_txtbx
            // 
            this.login_username_txtbx.BackColor = System.Drawing.Color.White;
            this.login_username_txtbx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.login_username_txtbx.Font = new System.Drawing.Font("B Yekan+", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.login_username_txtbx.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.login_username_txtbx.Location = new System.Drawing.Point(95, 164);
            this.login_username_txtbx.Margin = new System.Windows.Forms.Padding(4);
            this.login_username_txtbx.Name = "login_username_txtbx";
            this.login_username_txtbx.Size = new System.Drawing.Size(200, 34);
            this.login_username_txtbx.TabIndex = 2;
            // 
            // login_panel
            // 
            this.login_panel.BackColor = System.Drawing.Color.Transparent;
            this.login_panel.BackgroundImage = global::Second.Properties.Resources.new_form;
            this.login_panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.login_panel.Controls.Add(this.login_exit_lbl);
            this.login_panel.Controls.Add(this.login_enter_lbl);
            this.login_panel.Controls.Add(this.login_password_txtbx);
            this.login_panel.Controls.Add(this.login_username_txtbx);
            this.login_panel.Font = new System.Drawing.Font("B Yekan+", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.login_panel.Location = new System.Drawing.Point(1, 4);
            this.login_panel.Margin = new System.Windows.Forms.Padding(4);
            this.login_panel.Name = "login_panel";
            this.login_panel.Size = new System.Drawing.Size(473, 387);
            this.login_panel.TabIndex = 6;
            // 
            // login1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 395);
            this.Controls.Add(this.login_panel);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "login1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "login";
            this.Load += new System.EventHandler(this.login1_Load);
            this.login_panel.ResumeLayout(false);
            this.login_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox login_password_txtbx;
        private System.Windows.Forms.TextBox login_username_txtbx;
        private System.Windows.Forms.Label login_enter_lbl;
        private System.Windows.Forms.Label login_exit_lbl;
        private System.Windows.Forms.Panel login_panel;
    }
}