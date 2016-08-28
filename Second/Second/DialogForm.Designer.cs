namespace Second
{
    partial class DialogForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogForm));
            this.titleBar_lbl = new System.Windows.Forms.Label();
            this.error_panel = new System.Windows.Forms.Panel();
            this.ok_btn = new System.Windows.Forms.Button();
            this.context_lbl = new System.Windows.Forms.Label();
            this.icon_lbl = new System.Windows.Forms.PictureBox();
            this.error_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icon_lbl)).BeginInit();
            this.SuspendLayout();
            // 
            // titleBar_lbl
            // 
            this.titleBar_lbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.titleBar_lbl.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.titleBar_lbl.ForeColor = System.Drawing.Color.White;
            this.titleBar_lbl.Location = new System.Drawing.Point(0, 0);
            this.titleBar_lbl.Name = "titleBar_lbl";
            this.titleBar_lbl.Size = new System.Drawing.Size(538, 44);
            this.titleBar_lbl.TabIndex = 0;
            this.titleBar_lbl.Text = "خطا";
            this.titleBar_lbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // error_panel
            // 
            this.error_panel.BackColor = System.Drawing.Color.White;
            this.error_panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.error_panel.Controls.Add(this.ok_btn);
            this.error_panel.Controls.Add(this.context_lbl);
            this.error_panel.Controls.Add(this.icon_lbl);
            this.error_panel.Location = new System.Drawing.Point(12, 57);
            this.error_panel.Name = "error_panel";
            this.error_panel.Size = new System.Drawing.Size(512, 173);
            this.error_panel.TabIndex = 1;
            // 
            // ok_btn
            // 
            this.ok_btn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ok_btn.Font = new System.Drawing.Font("B Yekan+", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ok_btn.Location = new System.Drawing.Point(30, 126);
            this.ok_btn.Name = "ok_btn";
            this.ok_btn.Size = new System.Drawing.Size(124, 33);
            this.ok_btn.TabIndex = 6;
            this.ok_btn.Text = "تایید";
            this.ok_btn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ok_btn.UseVisualStyleBackColor = false;
            this.ok_btn.Click += new System.EventHandler(this.ok_btn_Click);
            // 
            // context_lbl
            // 
            this.context_lbl.AutoEllipsis = true;
            this.context_lbl.BackColor = System.Drawing.Color.Transparent;
            this.context_lbl.CausesValidation = false;
            this.context_lbl.Font = new System.Drawing.Font("B Nazanin", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.context_lbl.Location = new System.Drawing.Point(30, 14);
            this.context_lbl.Name = "context_lbl";
            this.context_lbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.context_lbl.Size = new System.Drawing.Size(379, 109);
            this.context_lbl.TabIndex = 5;
            this.context_lbl.UseCompatibleTextRendering = true;
            // 
            // icon_lbl
            // 
            this.icon_lbl.BackColor = System.Drawing.Color.Transparent;
            this.icon_lbl.BackgroundImage = global::Second.Properties.Resources.success_icon;
            this.icon_lbl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.icon_lbl.Location = new System.Drawing.Point(415, 13);
            this.icon_lbl.Name = "icon_lbl";
            this.icon_lbl.Size = new System.Drawing.Size(68, 66);
            this.icon_lbl.TabIndex = 4;
            this.icon_lbl.TabStop = false;
            // 
            // Error
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(536, 242);
            this.Controls.Add(this.error_panel);
            this.Controls.Add(this.titleBar_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Error";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Error";
            this.Load += new System.EventHandler(this.Error_Load);
            this.error_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.icon_lbl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label titleBar_lbl;
        private System.Windows.Forms.Panel error_panel;
        private System.Windows.Forms.Button ok_btn;
        private System.Windows.Forms.Label context_lbl;
        private System.Windows.Forms.PictureBox icon_lbl;
    }
}