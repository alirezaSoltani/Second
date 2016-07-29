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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeacherForm));
            this.teacher_main_tc = new System.Windows.Forms.TabControl();
            this.teacher_dashbord_tp = new System.Windows.Forms.TabPage();
            this.teacher_students_tp = new System.Windows.Forms.TabPage();
            this.teacher_lessonName_cb = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.teacher_show_btn = new System.Windows.Forms.Button();
            this.teacher_lessonGroupNumber_txt = new System.Windows.Forms.Label();
            this.teacher_lessonNumber_txt = new System.Windows.Forms.Label();
            this.teacher_lessonGroupNumber_tb = new System.Windows.Forms.TextBox();
            this.teacher_lessonNumber_tb = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.teacher_cours_tp = new System.Windows.Forms.TabPage();
            this.teacher_show2_btn = new System.Windows.Forms.Button();
            this.teacher_teacherNumber_txt = new System.Windows.Forms.Label();
            this.teacher_teacherNumber_tb = new System.Windows.Forms.TextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.teacher_messaging_tp = new System.Windows.Forms.TabPage();
            this.teacher_settings_tp = new System.Windows.Forms.TabPage();
            this.teacher_main_tc.SuspendLayout();
            this.teacher_students_tp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.teacher_cours_tp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // teacher_main_tc
            // 
            this.teacher_main_tc.Controls.Add(this.teacher_dashbord_tp);
            this.teacher_main_tc.Controls.Add(this.teacher_students_tp);
            this.teacher_main_tc.Controls.Add(this.teacher_cours_tp);
            this.teacher_main_tc.Controls.Add(this.teacher_messaging_tp);
            this.teacher_main_tc.Controls.Add(this.teacher_settings_tp);
            this.teacher_main_tc.Cursor = System.Windows.Forms.Cursors.Default;
            this.teacher_main_tc.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.teacher_main_tc.Location = new System.Drawing.Point(2, 103);
            this.teacher_main_tc.Multiline = true;
            this.teacher_main_tc.Name = "teacher_main_tc";
            this.teacher_main_tc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.teacher_main_tc.RightToLeftLayout = true;
            this.teacher_main_tc.SelectedIndex = 0;
            this.teacher_main_tc.Size = new System.Drawing.Size(1349, 606);
            this.teacher_main_tc.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.teacher_main_tc.TabIndex = 0;
            // 
            // teacher_dashbord_tp
            // 
            this.teacher_dashbord_tp.BackColor = System.Drawing.Color.LightBlue;
            this.teacher_dashbord_tp.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.teacher_dashbord_tp.Location = new System.Drawing.Point(4, 28);
            this.teacher_dashbord_tp.Name = "teacher_dashbord_tp";
            this.teacher_dashbord_tp.Padding = new System.Windows.Forms.Padding(3);
            this.teacher_dashbord_tp.Size = new System.Drawing.Size(1341, 574);
            this.teacher_dashbord_tp.TabIndex = 0;
            this.teacher_dashbord_tp.Text = "داشبورد";
            // 
            // teacher_students_tp
            // 
            this.teacher_students_tp.BackColor = System.Drawing.Color.LightBlue;
            this.teacher_students_tp.Controls.Add(this.teacher_lessonName_cb);
            this.teacher_students_tp.Controls.Add(this.label1);
            this.teacher_students_tp.Controls.Add(this.teacher_show_btn);
            this.teacher_students_tp.Controls.Add(this.teacher_lessonGroupNumber_txt);
            this.teacher_students_tp.Controls.Add(this.teacher_lessonNumber_txt);
            this.teacher_students_tp.Controls.Add(this.teacher_lessonGroupNumber_tb);
            this.teacher_students_tp.Controls.Add(this.teacher_lessonNumber_tb);
            this.teacher_students_tp.Controls.Add(this.dataGridView1);
            this.teacher_students_tp.Location = new System.Drawing.Point(4, 28);
            this.teacher_students_tp.Name = "teacher_students_tp";
            this.teacher_students_tp.Padding = new System.Windows.Forms.Padding(3);
            this.teacher_students_tp.Size = new System.Drawing.Size(1341, 574);
            this.teacher_students_tp.TabIndex = 1;
            this.teacher_students_tp.Text = "حضور و غیاب";
            this.teacher_students_tp.Click += new System.EventHandler(this.teacher_students_tp_Click);
            // 
            // teacher_lessonName_cb
            // 
            this.teacher_lessonName_cb.FormattingEnabled = true;
            this.teacher_lessonName_cb.Location = new System.Drawing.Point(1009, 14);
            this.teacher_lessonName_cb.Name = "teacher_lessonName_cb";
            this.teacher_lessonName_cb.Size = new System.Drawing.Size(182, 27);
            this.teacher_lessonName_cb.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(1239, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "شماره گروه درس";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // teacher_show_btn
            // 
            this.teacher_show_btn.BackColor = System.Drawing.Color.White;
            this.teacher_show_btn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.teacher_show_btn.Location = new System.Drawing.Point(585, 118);
            this.teacher_show_btn.Name = "teacher_show_btn";
            this.teacher_show_btn.Size = new System.Drawing.Size(170, 30);
            this.teacher_show_btn.TabIndex = 5;
            this.teacher_show_btn.Text = "نمایش";
            this.teacher_show_btn.UseVisualStyleBackColor = false;
            // 
            // teacher_lessonGroupNumber_txt
            // 
            this.teacher_lessonGroupNumber_txt.AutoSize = true;
            this.teacher_lessonGroupNumber_txt.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.teacher_lessonGroupNumber_txt.Location = new System.Drawing.Point(1268, 72);
            this.teacher_lessonGroupNumber_txt.Name = "teacher_lessonGroupNumber_txt";
            this.teacher_lessonGroupNumber_txt.Size = new System.Drawing.Size(72, 19);
            this.teacher_lessonGroupNumber_txt.TabIndex = 4;
            this.teacher_lessonGroupNumber_txt.Text = "شماره درس";
            // 
            // teacher_lessonNumber_txt
            // 
            this.teacher_lessonNumber_txt.AutoSize = true;
            this.teacher_lessonNumber_txt.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.teacher_lessonNumber_txt.ForeColor = System.Drawing.Color.Black;
            this.teacher_lessonNumber_txt.Location = new System.Drawing.Point(1287, 22);
            this.teacher_lessonNumber_txt.Name = "teacher_lessonNumber_txt";
            this.teacher_lessonNumber_txt.Size = new System.Drawing.Size(53, 19);
            this.teacher_lessonNumber_txt.TabIndex = 3;
            this.teacher_lessonNumber_txt.Text = "نام درس";
            this.teacher_lessonNumber_txt.Click += new System.EventHandler(this.label1_Click);
            // 
            // teacher_lessonGroupNumber_tb
            // 
            this.teacher_lessonGroupNumber_tb.Location = new System.Drawing.Point(1009, 111);
            this.teacher_lessonGroupNumber_tb.Name = "teacher_lessonGroupNumber_tb";
            this.teacher_lessonGroupNumber_tb.Size = new System.Drawing.Size(182, 26);
            this.teacher_lessonGroupNumber_tb.TabIndex = 2;
            // 
            // teacher_lessonNumber_tb
            // 
            this.teacher_lessonNumber_tb.Location = new System.Drawing.Point(1009, 65);
            this.teacher_lessonNumber_tb.Name = "teacher_lessonNumber_tb";
            this.teacher_lessonNumber_tb.Size = new System.Drawing.Size(182, 26);
            this.teacher_lessonNumber_tb.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.PowderBlue;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 167);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1359, 532);
            this.dataGridView1.TabIndex = 0;
            // 
            // teacher_cours_tp
            // 
            this.teacher_cours_tp.BackColor = System.Drawing.Color.LightBlue;
            this.teacher_cours_tp.Controls.Add(this.teacher_show2_btn);
            this.teacher_cours_tp.Controls.Add(this.teacher_teacherNumber_txt);
            this.teacher_cours_tp.Controls.Add(this.teacher_teacherNumber_tb);
            this.teacher_cours_tp.Controls.Add(this.dataGridView2);
            this.teacher_cours_tp.Location = new System.Drawing.Point(4, 28);
            this.teacher_cours_tp.Name = "teacher_cours_tp";
            this.teacher_cours_tp.Padding = new System.Windows.Forms.Padding(3);
            this.teacher_cours_tp.Size = new System.Drawing.Size(1341, 574);
            this.teacher_cours_tp.TabIndex = 2;
            this.teacher_cours_tp.Text = "درس ها";
            // 
            // teacher_show2_btn
            // 
            this.teacher_show2_btn.BackColor = System.Drawing.Color.White;
            this.teacher_show2_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.teacher_show2_btn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.teacher_show2_btn.Location = new System.Drawing.Point(585, 118);
            this.teacher_show2_btn.Name = "teacher_show2_btn";
            this.teacher_show2_btn.Size = new System.Drawing.Size(170, 30);
            this.teacher_show2_btn.TabIndex = 6;
            this.teacher_show2_btn.Text = "نمایش";
            this.teacher_show2_btn.UseVisualStyleBackColor = false;
            this.teacher_show2_btn.Click += new System.EventHandler(this.teacher_show2_btn_Click);
            // 
            // teacher_teacherNumber_txt
            // 
            this.teacher_teacherNumber_txt.AutoSize = true;
            this.teacher_teacherNumber_txt.BackColor = System.Drawing.Color.LightBlue;
            this.teacher_teacherNumber_txt.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.teacher_teacherNumber_txt.ForeColor = System.Drawing.Color.Black;
            this.teacher_teacherNumber_txt.Location = new System.Drawing.Point(1261, 38);
            this.teacher_teacherNumber_txt.Name = "teacher_teacherNumber_txt";
            this.teacher_teacherNumber_txt.Size = new System.Drawing.Size(73, 19);
            this.teacher_teacherNumber_txt.TabIndex = 4;
            this.teacher_teacherNumber_txt.Text = "شماره استاد";
            // 
            // teacher_teacherNumber_tb
            // 
            this.teacher_teacherNumber_tb.BackColor = System.Drawing.Color.White;
            this.teacher_teacherNumber_tb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.teacher_teacherNumber_tb.Location = new System.Drawing.Point(1049, 35);
            this.teacher_teacherNumber_tb.Name = "teacher_teacherNumber_tb";
            this.teacher_teacherNumber_tb.Size = new System.Drawing.Size(182, 26);
            this.teacher_teacherNumber_tb.TabIndex = 2;
            // 
            // dataGridView2
            // 
            this.dataGridView2.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(1, 165);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(1358, 544);
            this.dataGridView2.TabIndex = 0;
            // 
            // teacher_messaging_tp
            // 
            this.teacher_messaging_tp.BackColor = System.Drawing.Color.LightBlue;
            this.teacher_messaging_tp.Location = new System.Drawing.Point(4, 28);
            this.teacher_messaging_tp.Name = "teacher_messaging_tp";
            this.teacher_messaging_tp.Padding = new System.Windows.Forms.Padding(3);
            this.teacher_messaging_tp.Size = new System.Drawing.Size(1341, 574);
            this.teacher_messaging_tp.TabIndex = 3;
            this.teacher_messaging_tp.Text = "پیام رسانی";
            // 
            // teacher_settings_tp
            // 
            this.teacher_settings_tp.BackColor = System.Drawing.Color.LightBlue;
            this.teacher_settings_tp.Location = new System.Drawing.Point(4, 28);
            this.teacher_settings_tp.Name = "teacher_settings_tp";
            this.teacher_settings_tp.Padding = new System.Windows.Forms.Padding(3);
            this.teacher_settings_tp.Size = new System.Drawing.Size(1341, 574);
            this.teacher_settings_tp.TabIndex = 4;
            this.teacher_settings_tp.Text = "تنظیمات";
            // 
            // TeacherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1354, 733);
            this.Controls.Add(this.teacher_main_tc);
            this.Name = "TeacherForm";
            this.Text = "استاد";
            this.Load += new System.EventHandler(this.TeacherForm_Load);
            this.teacher_main_tc.ResumeLayout(false);
            this.teacher_students_tp.ResumeLayout(false);
            this.teacher_students_tp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.teacher_cours_tp.ResumeLayout(false);
            this.teacher_cours_tp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl teacher_main_tc;
        private System.Windows.Forms.TabPage teacher_dashbord_tp;
        private System.Windows.Forms.TabPage teacher_students_tp;
        private System.Windows.Forms.TabPage teacher_cours_tp;
        private System.Windows.Forms.TabPage teacher_messaging_tp;
        private System.Windows.Forms.TabPage teacher_settings_tp;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label teacher_teacherNumber_txt;
        private System.Windows.Forms.TextBox teacher_teacherNumber_tb;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button teacher_show2_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button teacher_show_btn;
        private System.Windows.Forms.Label teacher_lessonGroupNumber_txt;
        private System.Windows.Forms.Label teacher_lessonNumber_txt;
        private System.Windows.Forms.TextBox teacher_lessonGroupNumber_tb;
        private System.Windows.Forms.TextBox teacher_lessonNumber_tb;
        private System.Windows.Forms.ComboBox teacher_lessonName_cb;
    }
}