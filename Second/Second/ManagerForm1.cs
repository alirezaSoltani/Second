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
        /// Project temp attributes
        /// </summary>
            private string currentNumber = "";
            private string currentLessonNumber = "";
            private string currentLessonGroupNumber = "";
        /// <summary>
        /// Project temp attributes
        /// </summary>
        /// 





        /// <summary>
        /// designing attributes
        /// </summary>
            private ToolTip tooltip = new ToolTip();
        /// <summary>
        /// designing attributes
        /// </summary>





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


            /*Manager form design*/
            this.SetBounds(0, 0, width, ((955 * height) / 1000));
            /*Manager form design*/



            /****************************************************teachers tab design**********************************************************/
            manager_main_tc.SetBounds(0, ((125 * height) / 1000), ((99 * width) / 100), ((80 * height) / 100));
            logo_pictureBox.SetBounds(((79 * width) / 100), ((24 * height) / 1000), ((192 * width) / 1000), ((74 * height) / 1000));
            teachers_addEditDelete_panel.SetBounds(((5 * width) / 400), ((2 * height) / 100), ((96 * width) / 100), ((31 * height) / 100));
            dataGridView1.SetBounds(((5 * width) / 400), (38 * height) / 100, ((96 * width) / 100), ((36 * height) / 100));
            teachers_information_lbl.SetBounds(((50 * width) / 100), ((35 * height) / 100), ((47 * width) / 100), ((5 * height) / 100));
            teachers_cancel_btn.SetBounds(((5 * width) / 400), ((34 * height) / 100), ((80 * width) / 1000), ((25 * height) / 1000));
            tooltip.SetToolTip(teachers_cancel_btn, "لغو تغییرات");
            //***add
            teachers_add_teacherNumber_lbl.SetBounds(((17 * width) / 100), ((8 * height) / 300), ((83 * width) / 1000), ((27 * height) / 1000));
            teachers_add_teacherName_lbl.SetBounds(((17 * width) / 100), ((20 * height) / 300), ((83 * width) / 1000), ((27 * height) / 1000));
            teachers_add_teacherFamily_lbl.SetBounds(((17 * width) / 100), ((32 * height) / 300), ((83 * width) / 1000), ((27 * height) / 1000));
            teachers_add_teacher_password_lbl.SetBounds(((17 * width) / 100), ((44 * height) / 300), ((83 * width) / 1000), ((27 * height) / 1000));
            teachers_add_teacherNumber_txtbx.SetBounds(((4 * width) / 100), ((8 * height) / 300), ((110 * width) / 1000), ((27 * height) / 1000));
            teachers_add_teacherName_txtbx.SetBounds(((4 * width) / 100), ((20 * height) / 300), ((110 * width) / 1000), ((27 * height) / 1000));
            teachers_add_teacherFamily_txtbx.SetBounds(((4 * width) / 100), ((32 * height) / 300), ((110 * width) / 1000), ((27 * height) / 1000));
            teachers_add_teacher_password_txtbx.SetBounds(((4 * width) / 100), ((44 * height) / 300), ((110 * width) / 1000), ((27 * height) / 1000));
            teachers_add_addTeacher_btn.SetBounds(((4 * width) / 100), ((73 * height) / 300), ((10 * width) / 100), ((30 * height) / 1000));
            teachers_add_clear_btn.SetBounds(((30 * width) / 200), ((73 * height) / 300), ((10 * width) / 100), ((30 * height) / 1000));
            //***edit
            teachers_edit_teacherNumber_lbl.SetBounds(((17 * width) / 100), ((8 * height) / 300), ((83 * width) / 1000), ((27 * height) / 1000));
            teachers_edit_teacherName_lbl.SetBounds(((17 * width) / 100), ((22 * height) / 300), ((83 * width) / 1000), ((27 * height) / 1000));
            teachers_edit_teacherFamily_lbl.SetBounds(((17 * width) / 100), ((36 * height) / 300), ((83 * width) / 1000), ((27 * height) / 1000));
            teachers_edit_teacher_password_lbl.SetBounds(((17 * width) / 100), ((50 * height) / 300), ((83 * width) / 1000), ((30 * height) / 1000));
            teachers_edit_teacherNumber_txtbx.SetBounds(((4 * width) / 100), ((8 * height) / 300), ((110 * width) / 1000), ((27 * height) / 1000));
            teachers_edit_teacherName_txtbx.SetBounds(((4 * width) / 100), ((22 * height) / 300), ((110 * width) / 1000), ((27 * height) / 1000));
            teachers_edit_teacherFamily_txtbx.SetBounds(((4 * width) / 100), ((36 * height) / 300), ((110 * width) / 1000), ((27 * height) / 1000));
            teachers_edit_teacher_password_txtbx.SetBounds(((4 * width) / 100), ((50 * height) / 300), ((110 * width) / 1000), ((27 * height) / 1000));
            teachers_editTeacher_btn.SetBounds(((4 * width) / 100), ((73 * height) / 300), ((100 * width) / 1000), ((30 * height) / 1000));
            teachers_edit_clear_btn.SetBounds(((30 * width) / 200), ((73 * height) / 300), ((10 * width) / 100), ((30 * height) / 1000));
            //***delete
            teachers_delete_teacherNumber_lbl.SetBounds(((17 * width) / 100), ((30 * height) / 300), ((83 * width) / 1000), ((27 * height) / 1000));
            teachers_delete_teacherNumber_txtbx.SetBounds(((4 * width) / 100), ((30 * height) / 300), ((110 * width) / 1000), ((27 * height) / 1000));
            teachers_deleteTeacher_btn.SetBounds(((4 * width) / 100), ((73 * height) / 300), ((100 * width) / 1000), ((30 * height) / 1000));
            teachers_delete_clear_btn.SetBounds(((30 * width) / 200), ((73 * height) / 300), ((10 * width) / 100), ((30 * height) / 1000));
            //***groupBoxes
            teachers_addTeacher_gpb.SetBounds(((65 * width) / 100), ((1 * height) / 300), ((282 * width) / 1000), ((290 * height) / 1000));
            teachers_editTeacher_gpb.SetBounds(((34 * width) / 100), ((1 * height) / 300), ((282 * width) / 1000), ((290 * height) / 1000));
            teachers_deleteTeacher_gpb.SetBounds(((3 * width) / 100), ((1 * height) / 300), ((282 * width) / 1000), ((290 * height) / 1000));
            /// <summary>
            /// datagridview intialization
            /// </summary>
            
            dataGridView1.DataSource = bindingSource1;
            GetData("SELECT * FROM teacherTable");

            dataGridView1.RowHeadersWidth = (width / 25);
            dataGridView1.Columns[0].HeaderText = "شماره استاد";
            dataGridView1.Columns[1].HeaderText = "نام استاد";
            dataGridView1.Columns[2].HeaderText = "نام خانوادگی استاد";
            dataGridView1.Columns[3].HeaderText = "رمز عبور";
            dataGridView1.Columns[4].HeaderText = "آدرس اینترنتی";

            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

        /// <summary>
        /// datagridview intialization
        /// </summary>
        /****************************************************teachers tab design**********************************************************/





        /****************************************************students tab design**********************************************************/
            students_addEditDelete_panel.SetBounds(((5 * width) / 400), ((2 * height) / 100), ((96 * width) / 100), ((31 * height) / 100));
            students_dataGridView_panel.SetBounds(((5 * width) / 400), (38 * height) / 100, ((96 * width) / 100), ((36 * height) / 100));
            dataGridView2.SetBounds(0, 0, ((96 * width) / 100), ((36 * height) / 100));
            students_information_lbl.SetBounds(((50 * width) / 100), ((35 * height) / 100), ((47 * width) / 100), ((5 * height) / 100));
            students_return_btn.SetBounds(((5 * width) / 400), ((34 * height) / 100), ((80 * width) / 1000), ((25 * height) / 1000));
            students_cancel_btn.SetBounds(((40 * width) / 400), ((34 * height) / 100), ((80 * width) / 1000), ((25 * height) / 1000));
            tooltip.SetToolTip(students_return_btn, "مشاهده جدول دروس");
            tooltip.SetToolTip(students_cancel_btn, "لغو تغییرات");
            //***add
            students_add_studentNumber_lbl.SetBounds(((17 * width) / 100), ((8 * height) / 300), ((83 * width) / 1000), ((27 * height) / 1000));
            students_add_studentName_lbl.SetBounds(((17 * width) / 100), ((20 * height) / 300), ((83 * width) / 1000), ((27 * height) / 1000));
            students_add_studentFamily_lbl.SetBounds(((17 * width) / 100), ((32 * height) / 300), ((83 * width) / 1000), ((27 * height) / 1000));
            students_add_lessonNumber_lbl.SetBounds(((17 * width) / 100), ((44 * height) / 300), ((83 * width) / 1000), ((27 * height) / 1000));
            students_add_lessonGroupNumber_lbl.SetBounds(((17 * width) / 100), ((56 * height) / 300), ((83 * width) / 1000), ((27 * height) / 1000));
            students_add_studentNumber_txtbx.SetBounds(((4 * width) / 100), ((8 * height) / 300), ((110 * width) / 1000), ((27 * height) / 1000));
            students_add_studentName_txtbx.SetBounds(((4 * width) / 100), ((20 * height) / 300), ((110 * width) / 1000), ((27 * height) / 1000));
            students_add_studentFamily_txtbx.SetBounds(((4 * width) / 100), ((32 * height) / 300), ((110 * width) / 1000), ((27 * height) / 1000));
            students_add_lessonNumber_txtbx.SetBounds(((4 * width) / 100), ((44 * height) / 300), ((110 * width) / 1000), ((27 * height) / 1000));
            students_add_lessonGroupNumber_txtbx.SetBounds(((4 * width) / 100), ((56 * height) / 300), ((110 * width) / 1000), ((27 * height) / 1000));
            students_add_addStudent_btn.SetBounds(((8 * width) / 200), ((73 * height) / 300), ((20 * width) / 300), ((30 * height) / 1000));
            students_add_groupAdd_btn.SetBounds(((45 * width) / 400), ((73 * height) / 300), ((20 * width) / 300), ((30 * height) / 1000));
            students_add_clear_btn.SetBounds(((37 * width) / 200), ((73 * height) / 300), ((20 * width) / 300), ((30 * height) / 1000));
            //***edit
            students_edit_studentNumber_lbl.SetBounds(((17 * width) / 100), ((8 * height) / 300), ((83 * width) / 1000), ((27 * height) / 1000));
            students_edit_studentName_lbl.SetBounds(((17 * width) / 100), ((20 * height) / 300), ((83 * width) / 1000), ((27 * height) / 1000));
            students_edit_studentFamily_lbl.SetBounds(((17 * width) / 100), ((32 * height) / 300), ((83 * width) / 1000), ((27 * height) / 1000));
            students_edit_studentNumber_txtbx.SetBounds(((4 * width) / 100), ((8 * height) / 300), ((110 * width) / 1000), ((27 * height) / 1000));
            students_edit_studentName_txtbx.SetBounds(((4 * width) / 100), ((20 * height) / 300), ((110 * width) / 1000), ((27 * height) / 1000));
            students_edit_studentFamily_txtbx.SetBounds(((4 * width) / 100), ((32 * height) / 300), ((110 * width) / 1000), ((27 * height) / 1000));
            students_edit_editStudent_btn.SetBounds(((4 * width) / 100), ((73 * height) / 300), ((10 * width) / 100), ((30 * height) / 1000));
            students_edit_clear_btn.SetBounds(((30 * width) / 200), ((73 * height) / 300), ((10 * width) / 100), ((30 * height) / 1000));
            //***delete
            students_delete_studentNumber_lbl.SetBounds(((17 * width) / 100), ((15 * height) / 300), ((83 * width) / 1000), ((27 * height) / 1000));
            students_delete_studentNumber_txtbx.SetBounds(((4 * width) / 100), ((15 * height) / 300), ((110 * width) / 1000), ((27 * height) / 1000));
            students_delete_lessonNumber_lbl.SetBounds(((17 * width) / 100), ((30 * height) / 300), ((83 * width) / 1000), ((27 * height) / 1000));
            students_delete_lessonNumber_txtbx.SetBounds(((4 * width) / 100), ((30 * height) / 300), ((110 * width) / 1000), ((27 * height) / 1000));
            students_delete_lessonGroupNumber_lbl.SetBounds(((17 * width) / 100), ((45 * height) / 300), ((83 * width) / 1000), ((27 * height) / 1000));
            students_delete_lessonGroupNumber_txtbx.SetBounds(((4 * width) / 100), ((45 * height) / 300), ((110 * width) / 1000), ((27 * height) / 1000));
            students_delete_deleteStudent_btn.SetBounds(((4 * width) / 100), ((73 * height) / 300), ((100 * width) / 1000), ((30 * height) / 1000));
            students_delete_clear_btn.SetBounds(((30 * width) / 200), ((73 * height) / 300), ((10 * width) / 100), ((30 * height) / 1000));
            //***groupBoxes
            students_addStudent_gpb.SetBounds(((65 * width) / 100), ((1 * height) / 300), ((282 * width) / 1000), ((290 * height) / 1000));
            students_editStudent_gpb.SetBounds(((34 * width) / 100), ((1 * height) / 300), ((282 * width) / 1000), ((290 * height) / 1000));
            students_deleteStudent_gpb.SetBounds(((3 * width) / 100), ((1 * height) / 300), ((282 * width) / 1000), ((290 * height) / 1000));

            /// <summary>
            /// datagridview intialization
            /// </summary>
            dataGridView2.DataSource = bindingSource2;
            GetData2("SELECT DISTINCT lesson# , lessonGroup# ,lessonName FROM lessonTable");

            dataGridView2.RowHeadersWidth = (width / 25);
            dataGridView2.Columns[0].HeaderText = "شماره درس";
            dataGridView2.Columns[1].HeaderText = "شماره گروه ";
            dataGridView2.Columns[2].HeaderText = "عنوان درس";



            foreach (DataGridViewColumn col in dataGridView2.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                //////row.HeaderCell.Value = String.Format("{0}", row.Index + 1);
                row.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            /// <summary>
            /// datagridview intialization
            /// </summary>
            /****************************************************students tab design**********************************************************/

            /// <summary>
            /// MultiResolution
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

        private void manager_studentAdd_bt_Click(object sender, EventArgs e)
        {
            try
            {
                StudentModel studentObj = new StudentModel();
                studentObj.setStudentNumber(long.Parse(students_add_studentNumber_txtbx.Text));
                studentObj.setStudentFName(students_add_studentName_txtbx.Text);
                studentObj.setStudentLName(students_add_studentFamily_txtbx.Text);
                studentObj.addStudent(long.Parse(students_add_lessonNumber_txtbx.Text), int.Parse(students_add_lessonGroupNumber_txtbx.Text));
                MessageBox.Show("اطلاعات با موفقیت ثبت شد", "ثبت موفقیت آمیز", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //***clear textBoxes
                students_add_studentNumber_txtbx.Clear();
                students_add_studentName_txtbx.Clear();
                students_add_studentFamily_txtbx.Clear();

                try
                {
                    /// <summary>
                    /// Reset dataGridView to the desired class
                    /// </summary>
                    GetData2("SELECT * FROM [dbo].[" + currentLessonNumber + "-" + currentLessonGroupNumber + "_Table]");

                    dataGridView2.Columns[0].HeaderText = "شماره دانشجویی";
                    dataGridView2.Columns[1].HeaderText = "نام دانشجو";
                    dataGridView2.Columns[2].HeaderText = "نام خانوادگی دانشجو";

                    foreach (DataGridViewColumn col in dataGridView2.Columns)
                    {
                        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    }
                    /// <summary>
                    /// Reset dataGridView to the desired class
                    /// </summary>
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    MessageBox.Show("!بر روی رکورد کلیک کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch(FormatException)
            {
                MessageBox.Show(".اطلاعات ورودی ناقص یا اشتباه هستند", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            
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
                dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);

            }
            catch (SqlException)
            {
                MessageBox.Show("1- To run this example, replace the value of the " +
                    "connectionString variable with a connection string that is " +
                    "valid for your system.");
            }
        }

        private void GetData2(string selectCommand)
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
                dataGridView2.AutoResizeColumns(
                    DataGridViewAutoSizeColumnsMode.AllCells);
                dataGridView2.AutoResizeRows(
                   DataGridViewAutoSizeRowsMode.AllCells);

            }
            catch (SqlException)
            {
                MessageBox.Show("2- To run this example, replace the value of the " +
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
                bindingSource3.DataSource = table2;


                // Resize the DataGridView columns to fit the newly loaded content.
                dataGridView2.AutoResizeColumns(
                    DataGridViewAutoSizeColumnsMode.AllCells);
                dataGridView2.AutoResizeRows(
                   DataGridViewAutoSizeRowsMode.AllCells);

            }
            catch (SqlException)
            {
                MessageBox.Show("2- To run this example, replace the value of the " +
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
            teachers_add_teacherNumber_txtbx.Clear();
            teachers_add_teacherName_txtbx.Clear();
            teachers_add_teacherFamily_txtbx.Clear();
            teachers_add_teacher_password_txtbx.Clear();
        }

        private void teachers_addTeacher_btn_Click(object sender, EventArgs e)
        {
            try
            {
                /// <summary>
                /// Checks whether strings have integers or not
                /// </summary>

                bool fnameContainsInt = false;
                bool lnameContainsInt = false;

                fnameContainsInt = teachers_add_teacherName_txtbx.Text.Any(char.IsDigit);
                lnameContainsInt = teachers_add_teacherFamily_txtbx.Text.Any(char.IsDigit);

                if (fnameContainsInt || lnameContainsInt || teachers_add_teacherNumber_txtbx.Text == "" || teachers_add_teacherName_txtbx.Text == "" || teachers_add_teacherFamily_txtbx.Text == "" || teachers_add_teacher_password_txtbx.Text == "")
                {
                    throw new System.FormatException(".اطلاعات را تصحیح کنید");
                }
                /// <summary>
                /// Checks whether strings have integers or not
                /// </summary>
                /// 


                TeacherModel teacherObj = new TeacherModel();

                teacherObj.setTeacherNumber(long.Parse(teachers_add_teacherNumber_txtbx.Text));
                teacherObj.setTeacherFName(teachers_add_teacherName_txtbx.Text);
                teacherObj.setTeacherLName(teachers_add_teacherFamily_txtbx.Text);
                teacherObj.setTeacherPassword(teachers_add_teacher_password_txtbx.Text);
                teacherObj.setTeacherURL("");

                teacherObj.addTeacher();


                /// <summary>
                /// Clear textBoxes
                /// </summary>
                teachers_add_teacherNumber_txtbx.Clear();
                teachers_add_teacherName_txtbx.Clear();
                teachers_add_teacherFamily_txtbx.Clear();
                teachers_add_teacher_password_txtbx.Clear();
                /// <summary>
                /// Clear textBoxes
                /// </summary>



                /// <summary>
                /// Reset dataGridView
                /// </summary>
                dataGridView1.DataSource = bindingSource1;
                GetData("SELECT * FROM teacherTable");

                dataGridView1.Columns[0].HeaderText = "شماره استاد";
                dataGridView1.Columns[1].HeaderText = "نام استاد";
                dataGridView1.Columns[2].HeaderText = "نام خانوادگی استاد";
                dataGridView1.Columns[3].HeaderText = "رمز عبور";
                dataGridView1.Columns[4].HeaderText = "آدرس اینترنتی";

                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }

                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    dataGridView1.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
                }
                /// <summary>
                /// Reset dataGridView
                /// </summary>
            }

            catch (FormatException e1)
            {
                MessageBox.Show(".اطلاعات را تصحیح کنید");
            }
        }

        private void teachers_delete_clear_btn_Click(object sender, EventArgs e)
        {
            teachers_delete_teacherNumber_txtbx.Clear();
        }

        private void teachers_edit_clear_btn_Click(object sender, EventArgs e)
        {
            teachers_edit_teacherNumber_txtbx.Clear();
            teachers_edit_teacherName_txtbx.Clear();
            teachers_edit_teacherFamily_txtbx.Clear();
            teachers_edit_teacher_password_txtbx.Clear();
        }

        private void teachers_editTeacher_btn_Click(object sender, EventArgs e)
        {
            try
            {
                bool fnameContainsInt = false;
                bool lnameContainsInt = false;

                fnameContainsInt = teachers_edit_teacherName_txtbx.Text.Any(char.IsDigit);
                lnameContainsInt = teachers_edit_teacherFamily_txtbx.Text.Any(char.IsDigit);

                if (fnameContainsInt || lnameContainsInt || teachers_edit_teacherNumber_txtbx.Text == "" || teachers_edit_teacherName_txtbx.Text == "" || teachers_edit_teacherFamily_txtbx.Text == "" || teachers_edit_teacher_password_txtbx.Text == "")
                {
                    throw new System.FormatException("اطلاعات را تصحیح کنید.");
                }

                //PasswordRequest k = new PasswordRequest();
                //k.Show();

                if (/*k.authenPass() ==*/ true)
                {
                    TeacherModel teacherObj = new TeacherModel();
                    teacherObj.setTeacherNewNumber(Int64.Parse(teachers_edit_teacherNumber_txtbx.Text));
                    teacherObj.setTeacherNumber(Int64.Parse(currentNumber));
                    teacherObj.setTeacherFName(teachers_edit_teacherName_txtbx.Text);
                    teacherObj.setTeacherLName(teachers_edit_teacherFamily_txtbx.Text);
                    teacherObj.setTeacherPassword(teachers_edit_teacher_password_txtbx.Text);
                    teacherObj.setTeacherURL("");
                    teacherObj.updateTeacher();
                }



                /// <summary>
                /// Reset GroupBoxes and their components
                /// </summary>
                //***disable cancel button
                teachers_cancel_btn.Enabled = false;
                //***enable add components
                teachers_add_teacherNumber_txtbx.Enabled = true;
                teachers_add_teacherName_txtbx.Enabled = true;
                teachers_add_teacherFamily_txtbx.Enabled = true;
                teachers_add_teacher_password_txtbx.Enabled = true;
                teachers_add_teacherNumber_lbl.Enabled = true;
                teachers_add_teacherName_lbl.Enabled = true;
                teachers_add_teacherFamily_lbl.Enabled = true;
                teachers_add_teacher_password_lbl.Enabled = true;
                teachers_add_addTeacher_btn.Enabled = true;
                teachers_add_clear_btn.Enabled = true;
                //***disable edit & delete components
                teachers_edit_teacherNumber_txtbx.Enabled = false;
                teachers_edit_teacherName_txtbx.Enabled = false;
                teachers_edit_teacherFamily_txtbx.Enabled = false;
                teachers_edit_teacher_password_txtbx.Enabled = false;
                teachers_edit_teacherNumber_lbl.Enabled = false;
                teachers_edit_teacherName_lbl.Enabled = false;
                teachers_edit_teacherFamily_lbl.Enabled = false;
                teachers_edit_teacher_password_lbl.Enabled = false;
                teachers_edit_clear_btn.Enabled = false;
                teachers_editTeacher_btn.Enabled = false;
                teachers_delete_teacherNumber_lbl.Enabled = false;
                teachers_delete_teacherNumber_txtbx.Enabled = false;
                teachers_delete_clear_btn.Enabled = false;
                teachers_deleteTeacher_btn.Enabled = false;
                //***clear textBoxes
                teachers_edit_teacherNumber_txtbx.Clear();
                teachers_edit_teacherName_txtbx.Clear();
                teachers_edit_teacherFamily_txtbx.Clear();
                teachers_edit_teacher_password_txtbx.Clear();
                teachers_delete_teacherNumber_txtbx.Clear();
                /// <summary>
                /// Reset GroupBoxes and their components
                /// </summary>



                /// <summary>
                /// Reset dataGridView
                /// </summary>
                dataGridView1.DataSource = bindingSource1;
                GetData("SELECT * FROM teacherTable");

                dataGridView1.Columns[0].HeaderText = "شماره استاد";
                dataGridView1.Columns[1].HeaderText = "نام استاد";
                dataGridView1.Columns[2].HeaderText = "نام خانوادگی استاد";
                dataGridView1.Columns[3].HeaderText = "رمز عبور";
                dataGridView1.Columns[4].HeaderText = "آدرس اینترنتی";

                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }

                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    dataGridView1.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
                }
                /// <summary>
                /// Reset dataGridView
                /// </summary>
                /// 


            }
            catch (FormatException)
            {
                MessageBox.Show("!اطلاعات را تصحیح نمایید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //***enable cancel button
                teachers_cancel_btn.Enabled = true;
                //***disable add components
                teachers_add_teacherNumber_txtbx.Enabled = false;
                teachers_add_teacherName_txtbx.Enabled = false;
                teachers_add_teacherFamily_txtbx.Enabled = false;
                teachers_add_teacher_password_txtbx.Enabled = false;
                teachers_add_teacherNumber_lbl.Enabled = false;
                teachers_add_teacherName_lbl.Enabled = false;
                teachers_add_teacherFamily_lbl.Enabled = false;
                teachers_add_teacher_password_lbl.Enabled = false;
                teachers_add_addTeacher_btn.Enabled = false;
                teachers_add_clear_btn.Enabled = false;
                //***enable edit & delete components
                teachers_edit_teacherNumber_txtbx.Enabled = true;
                teachers_edit_teacherName_txtbx.Enabled = true;
                teachers_edit_teacherFamily_txtbx.Enabled = true;
                teachers_edit_teacher_password_txtbx.Enabled = true;
                teachers_edit_teacherNumber_lbl.Enabled = true;
                teachers_edit_teacherName_lbl.Enabled = true;
                teachers_edit_teacherFamily_lbl.Enabled = true;
                teachers_edit_teacher_password_lbl.Enabled = true;
                teachers_delete_teacherNumber_lbl.Enabled = true;
                teachers_edit_clear_btn.Enabled = true;
                teachers_editTeacher_btn.Enabled = true;
                teachers_delete_teacherNumber_lbl.Enabled = true;
                teachers_delete_teacherNumber_txtbx.Enabled = true;
                teachers_delete_clear_btn.Enabled = true;
                teachers_deleteTeacher_btn.Enabled = true;

                currentNumber = dataGridView1.Rows[e.RowIndex].Cells["teacher#"].Value.ToString();

                teachers_delete_teacherNumber_txtbx.Text = dataGridView1.Rows[e.RowIndex].Cells["teacher#"].Value.ToString();
                teachers_edit_teacherNumber_txtbx.Text = dataGridView1.Rows[e.RowIndex].Cells["teacher#"].Value.ToString();
                teachers_edit_teacherName_txtbx.Text = dataGridView1.Rows[e.RowIndex].Cells["teacherFName"].Value.ToString();
                teachers_edit_teacherFamily_txtbx.Text = dataGridView1.Rows[e.RowIndex].Cells["teacherLName"].Value.ToString();
                teachers_edit_teacher_password_txtbx.Text = dataGridView1.Rows[e.RowIndex].Cells["teacherPassword"].Value.ToString();
            }
            catch (System.ArgumentOutOfRangeException)
            {
                MessageBox.Show("!بر روی رکورد کلیک کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void teachers_deleteTeacher_btn_Click(object sender, EventArgs e)
        {
            if(teachers_delete_teacherNumber_txtbx.Text != "")
            {
                /*PasswordRequest k = new PasswordRequest();
                k.Show();*/

                if (/*k.authenPass() == */true)
                {
                    TeacherModel teacherObj = new TeacherModel();
                    teacherObj.setTeacherNumber(Int64.Parse(teachers_delete_teacherNumber_txtbx.Text));
                    teacherObj.deleteTeacher();


                    /// <summary>
                    /// Reset GroupBoxes and their components
                    /// </summary>
                    
                    //***disable cancel button
                    teachers_cancel_btn.Enabled = false;
                    //***enable add components
                    teachers_add_teacherNumber_txtbx.Enabled = true;
                    teachers_add_teacherName_txtbx.Enabled = true;
                    teachers_add_teacherFamily_txtbx.Enabled = true;
                    teachers_add_teacher_password_txtbx.Enabled = true;
                    teachers_add_teacherNumber_lbl.Enabled = true;
                    teachers_add_teacherName_lbl.Enabled = true;
                    teachers_add_teacherFamily_lbl.Enabled = true;
                    teachers_add_teacher_password_lbl.Enabled = true;
                    teachers_add_addTeacher_btn.Enabled = true;
                    teachers_add_clear_btn.Enabled = true;
                    //***disable edit & delete components
                    teachers_edit_teacherNumber_txtbx.Enabled = false;
                    teachers_edit_teacherName_txtbx.Enabled = false;
                    teachers_edit_teacherFamily_txtbx.Enabled = false;
                    teachers_edit_teacher_password_txtbx.Enabled = false;
                    teachers_edit_teacherNumber_lbl.Enabled = false;
                    teachers_edit_teacherName_lbl.Enabled = false;
                    teachers_edit_teacherFamily_lbl.Enabled = false;
                    teachers_edit_teacher_password_lbl.Enabled = false;
                    teachers_edit_clear_btn.Enabled = false;
                    teachers_editTeacher_btn.Enabled = false;
                    teachers_delete_teacherNumber_lbl.Enabled = false;
                    teachers_delete_teacherNumber_txtbx.Enabled = false;
                    teachers_delete_clear_btn.Enabled = false;
                    teachers_deleteTeacher_btn.Enabled = false;
                    //***clear textBoxes
                    teachers_edit_teacherNumber_txtbx.Clear();
                    teachers_edit_teacherName_txtbx.Clear();
                    teachers_edit_teacherFamily_txtbx.Clear();
                    teachers_edit_teacher_password_txtbx.Clear();
                    teachers_delete_teacherNumber_txtbx.Clear();
                    /// <summary>
                    /// Reset GroupBoxes and their components
                    /// </summary>




                    /// <summary>
                    /// Reset dataGridView
                    /// </summary>
                    dataGridView1.DataSource = bindingSource1;
                    GetData("SELECT * FROM teacherTable");

                    dataGridView1.Columns[0].HeaderText = "شماره استاد";
                    dataGridView1.Columns[1].HeaderText = "نام استاد";
                    dataGridView1.Columns[2].HeaderText = "نام خانوادگی استاد";
                    dataGridView1.Columns[3].HeaderText = "رمز عبور";
                    dataGridView1.Columns[4].HeaderText = "آدرس اینترنتی";

                    foreach (DataGridViewColumn col in dataGridView1.Columns)
                    {
                        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    }
                    /// <summary>
                    /// Reset dataGridView
                    /// </summary>
                }
            }
            else
            {
                MessageBox.Show("!اطلاعات را تصحیح نمایید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void manager_student_lessonNumber_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void manager_student_lessonGroupNumber_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void manager_studentNumber_add_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void manager_studentFName_add_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void manager_studentLName_add_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void students_return_btn_Click(object sender, EventArgs e)
        {
            /// <summary>
            /// datagridview intialization
            /// </summary>
            GetData2("SELECT DISTINCT lesson# , lessonGroup# ,lessonName FROM lessonTable");

            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.Columns[0].HeaderText = "شماره درس";
            dataGridView2.Columns[1].HeaderText = "شماره گروه ";
            dataGridView2.Columns[2].HeaderText = "عنوان درس";

            foreach (DataGridViewColumn col in dataGridView2.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                dataGridView2.Rows[row.Index].HeaderCell.Value = (row.Index + 1).ToString();
            }

            /// <summary>
            /// datagridview intialization
            /// </summary>
            


            //***disable cancel button
            students_cancel_btn.Enabled = false;
            //***disable add components
            students_add_studentNumber_lbl.Enabled = false;
            students_add_studentName_lbl.Enabled = false;
            students_add_studentFamily_lbl.Enabled = false;
            students_add_lessonNumber_lbl.Enabled = true;
            students_add_lessonGroupNumber_lbl.Enabled = true;
            students_add_studentNumber_txtbx.Enabled = false;
            students_add_studentName_txtbx.Enabled = false;
            students_add_studentFamily_txtbx.Enabled = false;
            students_add_addStudent_btn.Enabled = false;
            students_add_groupAdd_btn.Enabled = false;
            students_add_clear_btn.Enabled = false;
            //***disable edit components
            students_edit_studentNumber_lbl.Enabled = false;
            students_edit_studentName_lbl.Enabled = false;
            students_edit_studentFamily_lbl.Enabled = false;
            students_edit_studentNumber_txtbx.Enabled = false;
            students_edit_studentName_txtbx.Enabled = false;
            students_edit_studentFamily_txtbx.Enabled = false;
            students_edit_editStudent_btn.Enabled = false;
            students_edit_clear_btn.Enabled = false;
            //***disable delete components
            students_delete_studentNumber_lbl.Enabled = false;
            students_delete_studentNumber_txtbx.Enabled = false;
            students_delete_lessonNumber_lbl.Enabled = false;
            students_delete_lessonNumber_txtbx.Enabled = false;
            students_delete_lessonGroupNumber_lbl.Enabled = false;
            students_delete_lessonGroupNumber_txtbx.Enabled = false;
            students_delete_deleteStudent_btn.Enabled = false;
            students_delete_clear_btn.Enabled = false;
            //***Clear add & edit & delete textBoxes
            students_add_studentNumber_txtbx.Clear();
            students_add_studentName_txtbx.Clear();
            students_add_studentFamily_txtbx.Clear();
            students_add_lessonNumber_txtbx.Clear();
            students_add_lessonGroupNumber_txtbx.Clear();
            students_edit_studentNumber_txtbx.Clear();
            students_edit_studentName_txtbx.Clear();
            students_edit_studentFamily_txtbx.Clear();
            students_delete_studentNumber_txtbx.Clear();
            students_delete_lessonNumber_txtbx.Clear();
            students_delete_lessonGroupNumber_txtbx.Clear();
            //***Disable return button
            students_return_btn.Enabled = false;
        }

        private void manager_main_tc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (manager_main_tc.SelectedTab == manager_main_tc.TabPages["teachers"])
            {
                /// <summary>
                /// datagridview reintialization
                /// </summary>
                dataGridView1.DataSource = bindingSource1;
                GetData("SELECT * FROM teacherTable");

                //***change mode of columns to Fill
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.RowHeadersWidth = (width / 25);
                dataGridView1.Columns[0].HeaderText = "شماره استاد";
                dataGridView1.Columns[1].HeaderText = "نام استاد";
                dataGridView1.Columns[2].HeaderText = "نام خانوادگی استاد";
                dataGridView1.Columns[3].HeaderText = "رمز عبور";
                dataGridView1.Columns[4].HeaderText = "آدرس اینترنتی";
                dataGridView1.Columns[4].Width = (width / 3);


                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    dataGridView1.Rows[row.Index].HeaderCell.Value = (row.Index + 1).ToString();
                    //row.HeaderCell.Value = String.Format("{0}", row.Index + 1);
                    //row.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
                /// <summary>
                /// datagridview reintialization
                /// </summary>
            }

            else if (manager_main_tc.SelectedTab == manager_main_tc.TabPages["students"])
            {
                /// <summary>
                /// datagridview intialization
                /// </summary>
                dataGridView2.DataSource = bindingSource2;
                GetData2("SELECT DISTINCT lesson# , lessonGroup# ,lessonName FROM lessonTable");

                dataGridView2.RowHeadersWidth = (width / 25);
                dataGridView2.Columns[0].HeaderText = "شماره درس";
                dataGridView2.Columns[1].HeaderText = "شماره گروه";
                dataGridView2.Columns[2].HeaderText = "عنوان درس";
                dataGridView2.Columns[2].Width = (width / 3);



                foreach(DataGridViewColumn col in dataGridView2.Columns)
                {
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }

                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    //row.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView2.Rows[row.Index].HeaderCell.Value = (row.Index + 1).ToString();
                    //row.HeaderCell.Value = String.Format("{0}", row.Index + 1);
                }

                /// <summary>
                /// datagridview intialization
                /// </summary>
            }

        }

        private void students_edit_clear_btn_Click(object sender, EventArgs e)
        {
            students_edit_studentNumber_txtbx.Clear();
            students_edit_studentName_txtbx.Clear();
            students_edit_studentFamily_txtbx.Clear();
        }

        private void students_delete_clear_btn_Click(object sender, EventArgs e)
        {
            students_delete_studentNumber_txtbx.Clear();
            students_delete_lessonNumber_txtbx.Clear();
            students_delete_lessonGroupNumber_txtbx.Clear();
        }

        private void students_cancel_btn_Click(object sender, EventArgs e)
        {
            //***enable add components
            students_add_studentNumber_lbl.Enabled = true;
            students_add_studentName_lbl.Enabled = true;
            students_add_studentFamily_lbl.Enabled = true;
            students_add_studentNumber_txtbx.Enabled = true;
            students_add_studentName_txtbx.Enabled = true;
            students_add_studentFamily_txtbx.Enabled = true;
            students_add_lessonNumber_lbl.Enabled = true;
            //students_add_lessonNumber_txtbx.Enabled = true;
            students_add_lessonGroupNumber_lbl.Enabled = true;
            //students_add_lessonGroupNumber_txtbx.Enabled = true;
            students_add_addStudent_btn.Enabled = true;
            students_add_groupAdd_btn.Enabled = true;
            students_add_clear_btn.Enabled = true;
            //***disable edit components
            students_edit_studentNumber_lbl.Enabled = false;
            students_edit_studentName_lbl.Enabled = false;
            students_edit_studentFamily_lbl.Enabled = false;
            students_edit_studentNumber_txtbx.Enabled = false;
            students_edit_studentName_txtbx.Enabled = false;
            students_edit_studentFamily_txtbx.Enabled = false;
            students_edit_editStudent_btn.Enabled = false;
            students_edit_clear_btn.Enabled = false;
            //***disable delete components
            students_delete_studentNumber_lbl.Enabled = false;
            students_delete_studentNumber_txtbx.Enabled = false;
            students_delete_lessonNumber_lbl.Enabled = false;
            students_delete_lessonNumber_txtbx.Enabled = false;
            students_delete_lessonGroupNumber_lbl.Enabled = false;
            students_delete_lessonGroupNumber_txtbx.Enabled = false;
            students_delete_deleteStudent_btn.Enabled = false;
            students_delete_clear_btn.Enabled = false;
            //***Clear edit & delete textBoxes
            students_edit_studentNumber_txtbx.Clear();
            students_edit_studentName_txtbx.Clear();
            students_edit_studentFamily_txtbx.Clear();
            students_delete_studentNumber_txtbx.Clear();
            students_delete_lessonNumber_txtbx.Clear();
            students_delete_lessonGroupNumber_txtbx.Clear();
            //***Disable Cancel Button
            students_cancel_btn.Enabled = false;
        }

        private void teachers_cancel_btn_Click(object sender, EventArgs e)
        {
            //***enable add components
            teachers_add_teacherNumber_txtbx.Enabled = true;
            teachers_add_teacherName_txtbx.Enabled = true;
            teachers_add_teacherFamily_txtbx.Enabled = true;
            teachers_add_teacher_password_txtbx.Enabled = true;
            teachers_add_teacherNumber_lbl.Enabled = true;
            teachers_add_teacherName_lbl.Enabled = true;
            teachers_add_teacherFamily_lbl.Enabled = true;
            teachers_add_teacher_password_lbl.Enabled = true;
            teachers_add_addTeacher_btn.Enabled = true;
            teachers_add_clear_btn.Enabled = true;
            //***disable cancel button
            teachers_cancel_btn.Enabled = false;
            //***disable edit & delete components
            teachers_edit_teacherNumber_txtbx.Enabled = false;
            teachers_edit_teacherName_txtbx.Enabled = false;
            teachers_edit_teacherFamily_txtbx.Enabled = false;
            teachers_edit_teacher_password_txtbx.Enabled = false;
            teachers_edit_teacherNumber_lbl.Enabled = false;
            teachers_edit_teacherName_lbl.Enabled = false;
            teachers_edit_teacherFamily_lbl.Enabled = false;
            teachers_edit_teacher_password_lbl.Enabled = false;
            teachers_edit_clear_btn.Enabled = false;
            teachers_editTeacher_btn.Enabled = false;
            teachers_delete_teacherNumber_lbl.Enabled = false;
            teachers_delete_teacherNumber_lbl.Enabled = false;
            teachers_delete_teacherNumber_txtbx.Enabled = false;
            teachers_delete_clear_btn.Enabled = false;
            teachers_deleteTeacher_btn.Enabled = false;
            //***clear textBoxes
            teachers_delete_teacherNumber_txtbx.Clear();
            teachers_edit_teacherNumber_txtbx.Clear();
            teachers_edit_teacherName_txtbx.Clear();
            teachers_edit_teacherFamily_txtbx.Clear();
            teachers_edit_teacher_password_txtbx.Clear();
        }

        private void students_edit_addStudent_btn_Click(object sender, EventArgs e)
        {
            try
            {
                bool fnameContainsInt = false;
                bool lnameContainsInt = false;

                fnameContainsInt = students_edit_studentName_txtbx.Text.Any(char.IsDigit);
                lnameContainsInt = students_edit_studentFamily_txtbx.Text.Any(char.IsDigit);

                if (fnameContainsInt || lnameContainsInt || students_edit_studentName_txtbx.Text == "" || students_edit_studentFamily_txtbx.Text == "" || students_edit_studentNumber_txtbx.Text == "")
                {
                    throw new System.FormatException("اطلاعات را تصحیح کنید.");
                }

                //PasswordRequest k = new PasswordRequest();
                //k.Show();

                if (/*k.authenPass() ==*/ true)
                {
                    StudentModel studentObj = new StudentModel();
                    studentObj.setStudentNumber(Int64.Parse(currentNumber));
                    studentObj.setStudentNewNumber(Int64.Parse(students_edit_studentNumber_txtbx.Text));
                    studentObj.setStudentFName(students_edit_studentName_txtbx.Text);
                    studentObj.setStudentLName(students_edit_studentFamily_txtbx.Text);
                    studentObj.setStudentURL("");
                    studentObj.updateStudent(Int64.Parse(currentLessonNumber), Int32.Parse(currentLessonGroupNumber) );
                    disableStudentsTabComponents();
                    MessageBox.Show(".اطلاعات مورد نظر با موفقیت تغییر یافت");
                    /*studentObj.set
                    teacherObj.setTeacherNewNumber(Int64.Parse(teachers_edit_teacherNumber_txtbx.Text));
                    teacherObj.setTeacherNumber(Int64.Parse(currentNumber));
                    teacherObj.setTeacherFName(teachers_edit_teacherName_txtbx.Text);
                    teacherObj.setTeacherLName(teachers_edit_teacherFamily_txtbx.Text);
                    teacherObj.setTeacherPassword(teachers_edit_teacher_password_txtbx.Text);
                    teacherObj.setTeacherURL("");
                    teacherObj.updateTeacher();*/
                }

                dataGridView2.DataSource = bindingSource2;
                GetData2("SELECT * FROM [dbo].[" + currentLessonNumber + "-" + currentLessonGroupNumber + "_Table]");

                //***change mode of columns to Fill
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView2.Columns[0].HeaderText = "شماره دانشجویی";
                dataGridView2.Columns[1].HeaderText = "نام دانشجو";
                dataGridView2.Columns[2].HeaderText = "نام خانوادگی دانشجو";

                foreach (DataGridViewColumn col in dataGridView2.Columns)
                {
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    dataGridView2.Rows[row.Index].HeaderCell.Value = (row.Index + 1).ToString();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("!اطلاعات را تصحیح نمایید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //This "if" statement determines the dataGridView's dataSource then decides what should happen there.
            if (dataGridView2.Columns[0].HeaderText == "شماره درس")
            {
                //***enable return button
                students_return_btn.Enabled = true;
                //***enable add components
                students_add_addStudent_btn.Enabled = true;
                students_add_groupAdd_btn.Enabled = true;
                students_add_clear_btn.Enabled = true;
                students_add_studentNumber_txtbx.Enabled = true;
                students_add_studentName_txtbx.Enabled = true;
                students_add_studentFamily_txtbx.Enabled = true;
                students_add_studentNumber_lbl.Enabled = true;
                students_add_studentName_lbl.Enabled = true;
                students_add_studentFamily_lbl.Enabled = true;

                try
                {
                    currentLessonNumber = dataGridView2.Rows[e.RowIndex].Cells["lesson#"].Value.ToString();
                    currentLessonGroupNumber = dataGridView2.Rows[e.RowIndex].Cells["lessonGroup#"].Value.ToString();
                    
                    students_add_lessonNumber_txtbx.Text = currentLessonNumber;
                    students_add_lessonGroupNumber_txtbx.Text = currentLessonGroupNumber;

                    /// <summary>
                    /// Reset dataGridView to the desired class
                    /// </summary>
                    GetData2("SELECT * FROM [dbo].[" + dataGridView2.Rows[e.RowIndex].Cells["lesson#"].Value.ToString() + "-" + dataGridView2.Rows[e.RowIndex].Cells["lessonGroup#"].Value.ToString() + "_Table]");

                    //***change mode of columns to Fill
                    dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    dataGridView2.Columns[0].HeaderText = "شماره دانشجویی";
                    dataGridView2.Columns[1].HeaderText = "نام دانشجو";
                    dataGridView2.Columns[2].HeaderText = "نام خانوادگی دانشجو";

                    foreach (DataGridViewColumn col in dataGridView2.Columns)
                    {
                        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    }
                    foreach (DataGridViewRow row in dataGridView2.Rows)
                    {
                        dataGridView2.Rows[row.Index].HeaderCell.Value = (row.Index + 1).ToString();
                    }
                    /// <summary>
                    /// Reset dataGridView to the desired class
                    /// </summary>
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    MessageBox.Show("!بر روی رکورد کلیک کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else if (dataGridView2.Columns[0].HeaderText == "شماره دانشجویی")
            {
                try
                {
                    currentNumber = dataGridView2.Rows[e.RowIndex].Cells["student#"].Value.ToString();

                    //***enable cancel button
                    students_cancel_btn.Enabled = true;
                    //***disable add components
                    students_add_studentNumber_lbl.Enabled = false;
                    students_add_studentName_lbl.Enabled = false;
                    students_add_studentFamily_lbl.Enabled = false;
                    students_add_studentNumber_txtbx.Enabled = false;
                    students_add_studentName_txtbx.Enabled = false;
                    students_add_studentFamily_txtbx.Enabled = false;
                    students_add_lessonNumber_lbl.Enabled = false;
                    //students_add_lessonNumber_txtbx.Enabled = false;
                    students_add_lessonGroupNumber_lbl.Enabled = false;
                    //students_add_lessonGroupNumber_txtbx.Enabled = false;
                    students_add_addStudent_btn.Enabled = false;
                    students_add_groupAdd_btn.Enabled = false;
                    students_add_clear_btn.Enabled = false;
                    //***enable edit components
                    students_edit_studentNumber_lbl.Enabled = true;
                    students_edit_studentName_lbl.Enabled = true;
                    students_edit_studentFamily_lbl.Enabled = true;
                    students_edit_studentNumber_txtbx.Enabled = true;
                    students_edit_studentName_txtbx.Enabled = true;
                    students_edit_studentFamily_txtbx.Enabled = true;
                    students_edit_editStudent_btn.Enabled = true;
                    students_edit_clear_btn.Enabled = true;
                    //***enable delete components
                    students_delete_studentNumber_lbl.Enabled = true;
                    students_delete_studentNumber_txtbx.Enabled = true;
                    students_delete_lessonNumber_lbl.Enabled = true;
                    students_delete_lessonNumber_txtbx.Enabled = true;
                    students_delete_lessonGroupNumber_lbl.Enabled = true;
                    students_delete_lessonGroupNumber_txtbx.Enabled = true;
                    students_delete_deleteStudent_btn.Enabled = true;
                    students_delete_clear_btn.Enabled = true;

                    //***Fill edit & delete textBoxes
                    currentNumber = dataGridView2.Rows[e.RowIndex].Cells["student#"].Value.ToString();

                    students_edit_studentNumber_txtbx.Text = dataGridView2.Rows[e.RowIndex].Cells["student#"].Value.ToString();
                    students_edit_studentName_txtbx.Text = dataGridView2.Rows[e.RowIndex].Cells["studentFName"].Value.ToString();
                    students_edit_studentFamily_txtbx.Text = dataGridView2.Rows[e.RowIndex].Cells["studentLName"].Value.ToString();

                    students_delete_studentNumber_txtbx.Text = dataGridView2.Rows[e.RowIndex].Cells["student#"].Value.ToString();
                    students_delete_lessonNumber_txtbx.Text = currentLessonNumber;
                    students_delete_lessonGroupNumber_txtbx.Text = currentLessonGroupNumber;
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    MessageBox.Show("!بر روی رکورد کلیک کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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

        private void students_delete_deleteStudent_btn_Click(object sender, EventArgs e)
        {
            if (students_delete_studentNumber_txtbx.Text != "" && students_delete_lessonNumber_txtbx.Text != "" && students_delete_lessonGroupNumber_txtbx.Text != "")
            {
                /*PasswordRequest k = new PasswordRequest();
                k.Show();*/

                if (/*k.authenPass() == */true)
                {
                    try
                    {
                        StudentModel studentObj = new StudentModel();
                        studentObj.setStudentNumber(Int64.Parse(students_delete_studentNumber_txtbx.Text));
                        studentObj.deleteStudent(long.Parse(students_delete_lessonNumber_txtbx.Text) , int.Parse(students_delete_lessonGroupNumber_txtbx.Text));
                        disableStudentsTabComponents();
                        MessageBox.Show(".اطلاعات مورد نظر با موفقیت حذف شد");

                        /// <summary>
                        /// Reset dataGridView
                        /// </summary>
                        dataGridView2.DataSource = bindingSource2;
                        GetData2("SELECT * FROM [dbo].[" + currentLessonNumber + "-" + currentLessonGroupNumber + "_Table]");

                        //***change mode of columns to Fill
                        dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                        dataGridView2.Columns[0].HeaderText = "شماره دانشجویی";
                        dataGridView2.Columns[1].HeaderText = "نام دانشجو";
                        dataGridView2.Columns[2].HeaderText = "نام خانوادگی دانشجو";

                        foreach (DataGridViewColumn col in dataGridView2.Columns)
                        {
                            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        }
                        foreach (DataGridViewRow row in dataGridView2.Rows)
                        {
                            dataGridView2.Rows[row.Index].HeaderCell.Value = (row.Index + 1).ToString();
                        }
                        /// <summary>
                        /// Reset dataGridView
                    }
                    catch(FormatException)
                    {
                        MessageBox.Show("!اطلاعات را تصحیح نمایید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("!اطلاعات را تصحیح نمایید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void students_add_clear_btn_Click(object sender, EventArgs e)
        {
            students_add_studentNumber_txtbx.Clear();
            students_add_studentName_txtbx.Clear();
            students_add_studentFamily_txtbx.Clear();
        }

        private void students_add_groupAdd_btn_Click(object sender, EventArgs e)
        {
            Excel_Import excel_Import_object = new Excel_Import(currentLessonNumber, currentLessonGroupNumber);
            excel_Import_object.Show();
            students_return_btn.PerformClick();
        }

        private void disableStudentsTabComponents()
        {
            //***disable cancel button
            students_cancel_btn.Enabled = false;
            //***enable add components
            students_add_studentNumber_lbl.Enabled = true;
            students_add_studentName_lbl.Enabled = true;
            students_add_studentFamily_lbl.Enabled = true;
            students_add_studentNumber_txtbx.Enabled = true;
            students_add_studentName_txtbx.Enabled = true;
            students_add_studentFamily_txtbx.Enabled = true;
            students_add_lessonNumber_lbl.Enabled = true;
            //students_add_lessonNumber_txtbx.Enabled = true;
            students_add_lessonGroupNumber_lbl.Enabled = true;
            //students_add_lessonGroupNumber_txtbx.Enabled = true;
            students_add_addStudent_btn.Enabled = true;
            students_add_clear_btn.Enabled = true;
            //***disable edit components
            students_edit_studentNumber_lbl.Enabled = false;
            students_edit_studentName_lbl.Enabled = false;
            students_edit_studentFamily_lbl.Enabled = false;
            students_edit_studentNumber_txtbx.Enabled = false;
            students_edit_studentName_txtbx.Enabled = false;
            students_edit_studentFamily_txtbx.Enabled = false;
            students_edit_editStudent_btn.Enabled = false;
            students_edit_clear_btn.Enabled = false;
            //***disable delete components
            students_delete_studentNumber_lbl.Enabled = false;
            students_delete_studentNumber_txtbx.Enabled = false;
            students_delete_lessonNumber_lbl.Enabled = false;
            students_delete_lessonNumber_txtbx.Enabled = false;
            students_delete_lessonGroupNumber_lbl.Enabled = false;
            students_delete_lessonGroupNumber_txtbx.Enabled = false;
            students_delete_deleteStudent_btn.Enabled = false;
            students_delete_clear_btn.Enabled = false;
            //***Clear edit & delete textBoxes
            students_edit_studentNumber_txtbx.Clear();
            students_edit_studentName_txtbx.Clear();
            students_edit_studentFamily_txtbx.Clear();
            students_delete_studentNumber_txtbx.Clear();
            students_delete_lessonNumber_txtbx.Clear();
            students_delete_lessonGroupNumber_txtbx.Clear();
        }
    }
}
