﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test;

namespace Second
{
    public partial class ManagerForm1 : Form
    {
        /// <summary>
        /// Data gridview attributes
        /// </summary>
            private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        /// <summary>
        /// Data gridview attributes
        /// </summary>





        /// <summary>
        /// Multiple teacher attributes
        /// </summary>
            private List<TextBox> teacher_txtbx_List = new List<TextBox>();
            private List<Label> teacher_lbl_List = new List<Label>();
            private int x = 550, y = 25;
            private int numberOfTeachers = 0;
        /// <summary>
        /// Multiple teacher attributes
        /// </summary>





        /// <summary>
        /// MultiResolution Attributes
        /// </summary>
            private int width; //Width of system resolution
            private int height;  //Height of system resolution
        /// <summary>
        /// MultiResolution Attributes
        /// </summary>



        public ManagerForm1()
        {
            InitializeComponent();
        }


        private void ManagerForm1_Load(object sender, EventArgs e)
        {
            /// <summary>
            /// MultiResolution
            /// </summary>
            width = SystemInformation.PrimaryMonitorSize.Width;
            height = SystemInformation.PrimaryMonitorSize.Height;

            MessageBox.Show(SystemInformation.PrimaryMonitorSize.ToString());


            /*Manager form*/
            this.SetBounds(0, 0, width, ((955*height)/1000));
            /*Manager form*/


            /*teachers tab*/
            manager_main_tc.SetBounds( 0, ((125* height)/1000), ((99* width)/100) , ((80* height)/100));
            logo_pictureBox.SetBounds( ((79 * width) / 100), ((24 * height) / 1000), ((192 * width) / 1000), ((74 * height) / 1000));
            teachers_panel.SetBounds( ((5 * width) / 400), ((2 * height) / 100) , ((96 * width) / 100), ((29 * height) / 100));
            dataGridView1.SetBounds( ((5* width)/400), (38*height)/100 , ((96*width)/100), ((36*height)/100)  );
            information_lbl.SetBounds( ((50 * width) / 100) , ((34 * height) / 100) , ((47 * width) / 100), ((5 * height) / 100) );

            teachers_teacherNumber_lbl.SetBounds( ((85*width)/100) , ((15 * height) / 300) , ((83 * width) / 1000), ((27 * height) / 1000));
            teachers_teacherName_lbl.SetBounds(((85 * width) / 100), ((29 * height) / 300), ((83 * width) / 1000), ((27 * height) / 1000));
            teachers_teacherFamily_lbl.SetBounds(((85 * width) / 100), ((43 * height) / 300), ((83 * width) / 1000), ((27 * height) / 1000));
            teachers_teacher_password_lbl.SetBounds(((85 * width) / 100), ((57 * height) / 300), ((83 * width) / 1000), ((30 * height) / 1000));

            teachers_teacherNumber_txtbx.SetBounds( ((72 * width) / 100), ((15 * height) / 300), ((110 * width) / 1000), ((27 * height) / 1000));
            teachers_teacherName_txtbx.SetBounds(((72 * width) / 100), ((29 * height) / 300), ((110 * width) / 1000), ((27 * height) / 1000));
            teachers_teacherFamily_txtbx.SetBounds(((72 * width) / 100), ((43 * height) / 300), ((110 * width) / 1000), ((27 * height) / 1000));
            teachers_teacher_password_txtbx.SetBounds(((72 * width) / 100), ((57 * height) / 300), ((110 * width) / 1000), ((27 * height) / 1000));

            teachers_addTeacher_btn.SetBounds(((72 * width) / 100), ((80 * height) / 300), ((100 * width) / 1000), ((30 * height) / 1000));
            teachers_clear_btn.SetBounds(((167 * width) / 200), ((80 * height) / 300), ((10 * width) / 100), ((30 * height) / 1000));
            /*teachers tab*/


            /// <summary>
            /// MultiResolution
            /// </summary>





            /// <summary>
            /// datagridview intialization
            /// </summary>
            dataGridView1.DataSource = bindingSource1;
            GetData("SELECT * FROM teacherTable");

            dataGridView1.Columns[0].Width = 250;
            dataGridView1.Columns[0].HeaderText = "شماره استاد";

            dataGridView1.Columns[1].Width = 250;
            dataGridView1.Columns[1].HeaderText = "نام استاد";

            dataGridView1.Columns[2].Width = 250;
            dataGridView1.Columns[2].HeaderText = "نام خانوادگی استاد";

            dataGridView1.Columns[3].Width = 250;
            dataGridView1.Columns[3].HeaderText = "رمز عبور";

            dataGridView1.Columns[4].Width = 250;
            dataGridView1.Columns[4].HeaderText = "آدرس اینترنتی";

            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }

            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                dataGridView1.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
            }





            dataGridView3.DataSource = bindingSource2;
            GetData3("SELECT DISTINCT lesson# , lessonGroup# ,lessonName FROM lessonTable");
            /// <summary>
            /// datagridview intialization
            /// </summary>





            /// <summary>
            /// Multiple teacher
            /// </summary>
            panel5.CreateControl();

            teacher_txtbx_List.Add(new TextBox());
            teacher_txtbx_List[numberOfTeachers].SetBounds(x, y, 150, 30);

            teacher_lbl_List.Add(new Label());
            teacher_lbl_List[numberOfTeachers].SetBounds(x + 100, y, 150, 30);
            teacher_lbl_List[numberOfTeachers].Text = "شماره استاد " + (numberOfTeachers + 1);

            panel5.Controls.Add(teacher_txtbx_List[numberOfTeachers]);
            panel5.Controls.Add(teacher_lbl_List[numberOfTeachers]);

            y += 45;
            numberOfTeachers++;
            /// <summary>
            /// Multiple teacher
            /// </summary>


        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void manager_studentAdd_bt_Click(object sender, EventArgs e)
        {
            Manager_student_change k = new Manager_student_change();
            k.Show();
        }

        private void manager_lesson_add_bt_Click(object sender, EventArgs e)
        {
            LessonModel lessonObj = new LessonModel();

            lessonObj.setLessonNumber(long.Parse(manager_lessonNumber_add_txt.Text));
            lessonObj.setLessonGroupNumber(int.Parse(manager_lessonGroupNumbet_add_txt.Text));
            lessonObj.setLessonName(manager_lessonName_add_txt.Text);

            for (int counter = 0; counter < numberOfTeachers; counter++)
            {
                lessonObj.setLessonTeacherNumber(long.Parse(teacher_txtbx_List[counter].Text));
                lessonObj.addLesson();
            }

            lessonObj.createLessonTable();

            Manager_lesson_change k = new Manager_lesson_change();
            k.Show();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*OpenFileDialog dlg = new OpenFileDialog();
            dlg.ShowDialog();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string fileName;
                fileName = dlg.FileName;
                MessageBox.Show(fileName);
            }
            */

            /* int size = -1;
             DialogResult result = openFileDialog2.ShowDialog(); // Show the dialog.
             if (result == DialogResult.OK) // Test result.
             {
                 string file = openFileDialog2.FileName;
                 try
                 {
                     string text = File.ReadAllText(file);
                     size = text.Length;
                 }
                 catch (IOException)
                 {
                 }
             }
             Console.WriteLine(size); // <-- Shows file size in debugging mode.
             Console.WriteLine(result); // <-- For debugging use.*/


        }

        private void GetData(string selectCommand)
        {
            try
            {
                // Specify a connection string. Replace the given value with a 
                // valid connection string for a Northwind SQL Server sample
                // database accessible to your system.
                String connectionString = "Data Source= 185.159.152.5;" +
                    "Initial Catalog=youshita_Test;" +
                    "User id=youshita_co; " +
                    "Password=P@hn1395;";

                // Create a new data adapter based on the specified query.
                dataAdapter = new SqlDataAdapter(selectCommand, connectionString);

                // Create a command builder to generate SQL update, insert, and
                // delete commands based on selectCommand. These are used to
                // update the database.

                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                // Populate a new data table and bind it to the BindingSource.
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table);
                bindingSource1.DataSource = table;


                // Resize the DataGridView columns to fit the newly loaded content.
                dataGridView1.AutoResizeColumns(
                    DataGridViewAutoSizeColumnsMode.AllCells);
                dataGridView1.AutoResizeRows(
                   DataGridViewAutoSizeRowsMode.AllCells);



            }
            catch (SqlException)
            {
                MessageBox.Show("To run this example, replace the value of the " +
                    "connectionString variable with a connection string that is " +
                    "valid for your system.");
            }
        }
        private void GetData3(string selectCommand)
        {
            try
            {
                // Specify a connection string. Replace the given value with a 
                // valid connection string for a Northwind SQL Server sample
                // database accessible to your system.
                String connectionString = "Data Source= 185.159.152.5;" +
                    "Initial Catalog=youshita_Test;" +
                    "User id=youshita_co; " +
                    "Password=P@hn1395;";

                // Create a new data adapter based on the specified query.
                dataAdapter = new SqlDataAdapter(selectCommand, connectionString);

                // Create a command builder to generate SQL update, insert, and
                // delete commands based on selectCommand. These are used to
                // update the database.

                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                // Populate a new data table and bind it to the BindingSource.
                DataTable table2 = new DataTable();
                table2.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table2);
                bindingSource2.DataSource = table2;


                // Resize the DataGridView columns to fit the newly loaded content.
                dataGridView3.AutoResizeColumns(
                    DataGridViewAutoSizeColumnsMode.AllCells);
                dataGridView3.AutoResizeRows(
                   DataGridViewAutoSizeRowsMode.AllCells);

            }
            catch (SqlException)
            {
                MessageBox.Show("To run this example, replace the value of the " +
                    "connectionString variable with a connection string that is " +
                    "valid for your system.");
            }
        }

        private void add_lesson_teacher_bt_Click(object sender, EventArgs e)
        {
            if (numberOfTeachers == 7)
            {
                x = 150; y = 25;
            }
            if (numberOfTeachers == 9)
            {
                add_lesson_teacher_bt.Enabled = false;
            }

            del_lesson_teacher_bt.Enabled = true;
            teacher_txtbx_List.Add(new TextBox());
            teacher_txtbx_List[numberOfTeachers].SetBounds(x, y, 150, 30);

            teacher_lbl_List.Add(new Label());
            teacher_lbl_List[numberOfTeachers].SetBounds(x + 100, y, 150, 30);
            teacher_lbl_List[numberOfTeachers].Text = "شماره استاد " + (numberOfTeachers + 1);

            panel5.Controls.Add(teacher_txtbx_List[numberOfTeachers]);
            panel5.Controls.Add(teacher_lbl_List[numberOfTeachers]);
            y += 45;
            numberOfTeachers++;
        }

        private void teachers_clear_btn_Click_1(object sender, EventArgs e)
        {
            teachers_teacherNumber_txtbx.Clear();
            teachers_teacherName_txtbx.Clear();
            teachers_teacherFamily_txtbx.Clear();
            teachers_teacher_password_txtbx.Clear();
        }

        private void teachers_addTeacher_btn_Click(object sender, EventArgs e)
        {
            TeacherModel teacherObj = new TeacherModel();

            teacherObj.setTeacherNumber(long.Parse(teachers_teacherNumber_txtbx.Text));
            teacherObj.setTeacherFName(teachers_teacherName_txtbx.Text);
            teacherObj.setTeacherLName(teachers_teacherFamily_txtbx.Text);
            teacherObj.setTeacherPassword(teachers_teacher_password_txtbx.Text);
            teacherObj.setTeacherURL("");

            teacherObj.addTeacher();
            MessageBox.Show("استاد مورد نظر افزوده شد ");
            teachers_teacherNumber_txtbx.Text = "";
            teachers_teacherName_txtbx.Text = "";
            teachers_teacherFamily_txtbx.Text = "";
            teachers_teacher_password_txtbx.Text = "";
        }

        private void del_lesson_teacher_bt_Click(object sender, EventArgs e)
        {
            if (numberOfTeachers == 6)
            {
                x = 550; y = 295;
            }

            if (numberOfTeachers == 2)
            {
                del_lesson_teacher_bt.Enabled = false;
            }

            add_lesson_teacher_bt.Enabled = true;

            panel5.Controls.Remove(teacher_txtbx_List[numberOfTeachers - 1]);
            panel5.Controls.Remove(teacher_lbl_List[numberOfTeachers - 1]);

            teacher_txtbx_List.RemoveAt(numberOfTeachers - 1);
            teacher_lbl_List.RemoveAt(numberOfTeachers - 1);

            numberOfTeachers--;
            y -= 45;
        }
    }
}
