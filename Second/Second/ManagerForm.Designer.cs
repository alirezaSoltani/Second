namespace Second
{
    partial class ManagerForm
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
            this.manager_main_tc = new System.Windows.Forms.TabControl();
            this.manager_dashbord_tp = new System.Windows.Forms.TabPage();
            this.manager_teachers_tp = new System.Windows.Forms.TabPage();
            this.manager_students_tp = new System.Windows.Forms.TabPage();
            this.manager_cours_tp = new System.Windows.Forms.TabPage();
            this.manager_meesaging_tp = new System.Windows.Forms.TabPage();
            this.manager_settnigs_tp = new System.Windows.Forms.TabPage();
            this.manager_main_tc.SuspendLayout();
            this.SuspendLayout();
            // 
            // manager_main_tc
            // 
            this.manager_main_tc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.manager_main_tc.Controls.Add(this.manager_dashbord_tp);
            this.manager_main_tc.Controls.Add(this.manager_teachers_tp);
            this.manager_main_tc.Controls.Add(this.manager_students_tp);
            this.manager_main_tc.Controls.Add(this.manager_cours_tp);
            this.manager_main_tc.Controls.Add(this.manager_meesaging_tp);
            this.manager_main_tc.Controls.Add(this.manager_settnigs_tp);
            this.manager_main_tc.Location = new System.Drawing.Point(12, 12);
            this.manager_main_tc.Name = "manager_main_tc";
            this.manager_main_tc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.manager_main_tc.RightToLeftLayout = true;
            this.manager_main_tc.SelectedIndex = 0;
            this.manager_main_tc.Size = new System.Drawing.Size(1338, 717);
            this.manager_main_tc.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.manager_main_tc.TabIndex = 0;
            // 
            // manager_dashbord_tp
            // 
            this.manager_dashbord_tp.Location = new System.Drawing.Point(4, 22);
            this.manager_dashbord_tp.Name = "manager_dashbord_tp";
            this.manager_dashbord_tp.Padding = new System.Windows.Forms.Padding(3);
            this.manager_dashbord_tp.Size = new System.Drawing.Size(1330, 691);
            this.manager_dashbord_tp.TabIndex = 0;
            this.manager_dashbord_tp.Text = "داشبورد";
            this.manager_dashbord_tp.UseVisualStyleBackColor = true;
            // 
            // manager_teachers_tp
            // 
            this.manager_teachers_tp.Location = new System.Drawing.Point(4, 22);
            this.manager_teachers_tp.Name = "manager_teachers_tp";
            this.manager_teachers_tp.Padding = new System.Windows.Forms.Padding(3);
            this.manager_teachers_tp.Size = new System.Drawing.Size(1330, 691);
            this.manager_teachers_tp.TabIndex = 1;
            this.manager_teachers_tp.Text = "اساتید";
            this.manager_teachers_tp.UseVisualStyleBackColor = true;
            // 
            // manager_students_tp
            // 
            this.manager_students_tp.Location = new System.Drawing.Point(4, 22);
            this.manager_students_tp.Name = "manager_students_tp";
            this.manager_students_tp.Padding = new System.Windows.Forms.Padding(3);
            this.manager_students_tp.Size = new System.Drawing.Size(1330, 691);
            this.manager_students_tp.TabIndex = 2;
            this.manager_students_tp.Text = "دانشجویان";
            this.manager_students_tp.UseVisualStyleBackColor = true;
            // 
            // manager_cours_tp
            // 
            this.manager_cours_tp.Location = new System.Drawing.Point(4, 22);
            this.manager_cours_tp.Name = "manager_cours_tp";
            this.manager_cours_tp.Padding = new System.Windows.Forms.Padding(3);
            this.manager_cours_tp.Size = new System.Drawing.Size(1330, 691);
            this.manager_cours_tp.TabIndex = 3;
            this.manager_cours_tp.Text = "درس ها";
            this.manager_cours_tp.UseVisualStyleBackColor = true;
            // 
            // manager_meesaging_tp
            // 
            this.manager_meesaging_tp.Location = new System.Drawing.Point(4, 22);
            this.manager_meesaging_tp.Name = "manager_meesaging_tp";
            this.manager_meesaging_tp.Padding = new System.Windows.Forms.Padding(3);
            this.manager_meesaging_tp.Size = new System.Drawing.Size(1330, 691);
            this.manager_meesaging_tp.TabIndex = 4;
            this.manager_meesaging_tp.Text = "پیام رسانی";
            this.manager_meesaging_tp.UseVisualStyleBackColor = true;
            // 
            // manager_settnigs_tp
            // 
            this.manager_settnigs_tp.Location = new System.Drawing.Point(4, 22);
            this.manager_settnigs_tp.Name = "manager_settnigs_tp";
            this.manager_settnigs_tp.Padding = new System.Windows.Forms.Padding(3);
            this.manager_settnigs_tp.Size = new System.Drawing.Size(1330, 691);
            this.manager_settnigs_tp.TabIndex = 5;
            this.manager_settnigs_tp.Text = "تنظیمات";
            this.manager_settnigs_tp.UseVisualStyleBackColor = true;
            this.manager_settnigs_tp.Click += new System.EventHandler(this.manager_settnigs_tp_Click);
            // 
            // ManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 741);
            this.Controls.Add(this.manager_main_tc);
            this.Name = "ManagerForm";
            this.Text = "ManagerForm";
            this.Load += new System.EventHandler(this.ManagerForm_Load);
            this.manager_main_tc.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl manager_main_tc;
        private System.Windows.Forms.TabPage manager_dashbord_tp;
        private System.Windows.Forms.TabPage manager_teachers_tp;
        private System.Windows.Forms.TabPage manager_students_tp;
        private System.Windows.Forms.TabPage manager_cours_tp;
        private System.Windows.Forms.TabPage manager_meesaging_tp;
        private System.Windows.Forms.TabPage manager_settnigs_tp;
    }
}