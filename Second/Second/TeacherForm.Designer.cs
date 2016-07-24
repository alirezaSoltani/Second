namespace Second
{
    partial class TeacherForm
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
            this.teacher_main_tc = new System.Windows.Forms.TabControl();
            this.teacher_dashbord_tp = new System.Windows.Forms.TabPage();
            this.teacher_students_tp = new System.Windows.Forms.TabPage();
            this.teacher_cours_tp = new System.Windows.Forms.TabPage();
            this.teacher_messaging_tp = new System.Windows.Forms.TabPage();
            this.teacher_settings_tp = new System.Windows.Forms.TabPage();
            this.teacher_main_tc.SuspendLayout();
            this.SuspendLayout();
            // 
            // teacher_main_tc
            // 
            this.teacher_main_tc.Controls.Add(this.teacher_dashbord_tp);
            this.teacher_main_tc.Controls.Add(this.teacher_students_tp);
            this.teacher_main_tc.Controls.Add(this.teacher_cours_tp);
            this.teacher_main_tc.Controls.Add(this.teacher_messaging_tp);
            this.teacher_main_tc.Controls.Add(this.teacher_settings_tp);
            this.teacher_main_tc.Location = new System.Drawing.Point(12, 12);
            this.teacher_main_tc.Name = "teacher_main_tc";
            this.teacher_main_tc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.teacher_main_tc.RightToLeftLayout = true;
            this.teacher_main_tc.SelectedIndex = 0;
            this.teacher_main_tc.Size = new System.Drawing.Size(607, 465);
            this.teacher_main_tc.TabIndex = 0;
            // 
            // teacher_dashbord_tp
            // 
            this.teacher_dashbord_tp.Location = new System.Drawing.Point(4, 22);
            this.teacher_dashbord_tp.Name = "teacher_dashbord_tp";
            this.teacher_dashbord_tp.Padding = new System.Windows.Forms.Padding(3);
            this.teacher_dashbord_tp.Size = new System.Drawing.Size(599, 439);
            this.teacher_dashbord_tp.TabIndex = 0;
            this.teacher_dashbord_tp.Text = "داشبورد";
            this.teacher_dashbord_tp.UseVisualStyleBackColor = true;
            // 
            // teacher_students_tp
            // 
            this.teacher_students_tp.Location = new System.Drawing.Point(4, 22);
            this.teacher_students_tp.Name = "teacher_students_tp";
            this.teacher_students_tp.Padding = new System.Windows.Forms.Padding(3);
            this.teacher_students_tp.Size = new System.Drawing.Size(599, 439);
            this.teacher_students_tp.TabIndex = 1;
            this.teacher_students_tp.Text = "دانشجویان";
            this.teacher_students_tp.UseVisualStyleBackColor = true;
            // 
            // teacher_cours_tp
            // 
            this.teacher_cours_tp.Location = new System.Drawing.Point(4, 22);
            this.teacher_cours_tp.Name = "teacher_cours_tp";
            this.teacher_cours_tp.Padding = new System.Windows.Forms.Padding(3);
            this.teacher_cours_tp.Size = new System.Drawing.Size(599, 439);
            this.teacher_cours_tp.TabIndex = 2;
            this.teacher_cours_tp.Text = "درس ها";
            this.teacher_cours_tp.UseVisualStyleBackColor = true;
            // 
            // teacher_messaging_tp
            // 
            this.teacher_messaging_tp.Location = new System.Drawing.Point(4, 22);
            this.teacher_messaging_tp.Name = "teacher_messaging_tp";
            this.teacher_messaging_tp.Padding = new System.Windows.Forms.Padding(3);
            this.teacher_messaging_tp.Size = new System.Drawing.Size(599, 439);
            this.teacher_messaging_tp.TabIndex = 3;
            this.teacher_messaging_tp.Text = "پیام رسانی";
            this.teacher_messaging_tp.UseVisualStyleBackColor = true;
            // 
            // teacher_settings_tp
            // 
            this.teacher_settings_tp.Location = new System.Drawing.Point(4, 22);
            this.teacher_settings_tp.Name = "teacher_settings_tp";
            this.teacher_settings_tp.Padding = new System.Windows.Forms.Padding(3);
            this.teacher_settings_tp.Size = new System.Drawing.Size(599, 439);
            this.teacher_settings_tp.TabIndex = 4;
            this.teacher_settings_tp.Text = "تنظیمات";
            this.teacher_settings_tp.UseVisualStyleBackColor = true;
            // 
            // TeacherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 489);
            this.Controls.Add(this.teacher_main_tc);
            this.Name = "TeacherForm";
            this.Text = "استاد";
            this.Load += new System.EventHandler(this.TeacherForm_Load);
            this.teacher_main_tc.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl teacher_main_tc;
        private System.Windows.Forms.TabPage teacher_dashbord_tp;
        private System.Windows.Forms.TabPage teacher_students_tp;
        private System.Windows.Forms.TabPage teacher_cours_tp;
        private System.Windows.Forms.TabPage teacher_messaging_tp;
        private System.Windows.Forms.TabPage teacher_settings_tp;
    }
}