namespace Second
{
    partial class Error
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
            this.toolbar_lbl = new System.Windows.Forms.Label();
            this.icon_lbl = new System.Windows.Forms.PictureBox();
            this.context_lbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.icon_lbl)).BeginInit();
            this.SuspendLayout();
            // 
            // toolbar_lbl
            // 
            this.toolbar_lbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.toolbar_lbl.Font = new System.Drawing.Font("B Titr", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.toolbar_lbl.ForeColor = System.Drawing.Color.White;
            this.toolbar_lbl.Location = new System.Drawing.Point(0, 0);
            this.toolbar_lbl.Name = "toolbar_lbl";
            this.toolbar_lbl.Size = new System.Drawing.Size(538, 44);
            this.toolbar_lbl.TabIndex = 0;
            this.toolbar_lbl.Text = "خطا";
            this.toolbar_lbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // icon_lbl
            // 
            this.icon_lbl.BackColor = System.Drawing.Color.White;
            this.icon_lbl.BackgroundImage = global::Second.Properties.Resources.Status_dialog_error_isdfcon;
            this.icon_lbl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.icon_lbl.Location = new System.Drawing.Point(428, 73);
            this.icon_lbl.Name = "icon_lbl";
            this.icon_lbl.Size = new System.Drawing.Size(68, 66);
            this.icon_lbl.TabIndex = 1;
            this.icon_lbl.TabStop = false;
            // 
            // context_lbl
            // 
            this.context_lbl.BackColor = System.Drawing.Color.Transparent;
            this.context_lbl.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.context_lbl.Location = new System.Drawing.Point(43, 74);
            this.context_lbl.Name = "context_lbl";
            this.context_lbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.context_lbl.Size = new System.Drawing.Size(379, 130);
            this.context_lbl.TabIndex = 2;
            // 
            // Error
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(536, 242);
            this.Controls.Add(this.context_lbl);
            this.Controls.Add(this.icon_lbl);
            this.Controls.Add(this.toolbar_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Error";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Error";
            this.Load += new System.EventHandler(this.Error_Load);
            ((System.ComponentModel.ISupportInitialize)(this.icon_lbl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label toolbar_lbl;
        private System.Windows.Forms.PictureBox icon_lbl;
        private System.Windows.Forms.Label context_lbl;
    }
}