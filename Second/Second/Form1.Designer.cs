namespace Second
{
    partial class Login
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
            this.login_user_txt = new System.Windows.Forms.Label();
            this.login_pass_txt = new System.Windows.Forms.Label();
            this.login_user_tb = new System.Windows.Forms.TextBox();
            this.login_pass_tb = new System.Windows.Forms.TextBox();
            this.login_enter_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // login_user_txt
            // 
            this.login_user_txt.AutoSize = true;
            this.login_user_txt.Location = new System.Drawing.Point(414, 175);
            this.login_user_txt.Name = "login_user_txt";
            this.login_user_txt.Size = new System.Drawing.Size(57, 13);
            this.login_user_txt.TabIndex = 0;
            this.login_user_txt.Text = "کد کاربری";
            // 
            // login_pass_txt
            // 
            this.login_pass_txt.AutoSize = true;
            this.login_pass_txt.Location = new System.Drawing.Point(424, 221);
            this.login_pass_txt.Name = "login_pass_txt";
            this.login_pass_txt.Size = new System.Drawing.Size(47, 13);
            this.login_pass_txt.TabIndex = 1;
            this.login_pass_txt.Text = "رمز عبور";
            // 
            // login_user_tb
            // 
            this.login_user_tb.Location = new System.Drawing.Point(218, 175);
            this.login_user_tb.Name = "login_user_tb";
            this.login_user_tb.Size = new System.Drawing.Size(146, 20);
            this.login_user_tb.TabIndex = 2;
            // 
            // login_pass_tb
            // 
            this.login_pass_tb.Location = new System.Drawing.Point(218, 221);
            this.login_pass_tb.Name = "login_pass_tb";
            this.login_pass_tb.Size = new System.Drawing.Size(146, 20);
            this.login_pass_tb.TabIndex = 3;
            // 
            // login_enter_btn
            // 
            this.login_enter_btn.Location = new System.Drawing.Point(251, 268);
            this.login_enter_btn.Name = "login_enter_btn";
            this.login_enter_btn.Size = new System.Drawing.Size(75, 23);
            this.login_enter_btn.TabIndex = 4;
            this.login_enter_btn.Text = "ورود";
            this.login_enter_btn.UseVisualStyleBackColor = true;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 439);
            this.Controls.Add(this.login_enter_btn);
            this.Controls.Add(this.login_pass_tb);
            this.Controls.Add(this.login_user_tb);
            this.Controls.Add(this.login_pass_txt);
            this.Controls.Add(this.login_user_txt);
            this.Name = "Login";
            this.Text = "login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label login_user_txt;
        private System.Windows.Forms.Label login_pass_txt;
        private System.Windows.Forms.TextBox login_user_tb;
        private System.Windows.Forms.TextBox login_pass_tb;
        private System.Windows.Forms.Button login_enter_btn;
    }
}

