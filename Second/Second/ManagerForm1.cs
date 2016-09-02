using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
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
        private long currentUserName;
        private string currentPassword;
        private string inbox_lessonGroupNumber;
        private long managerUsername = -2;
        private bool isWrong = false;

        private int totalRecords;
        private const int pageSize = 10;
        private string[,] s;
        private int userType;
        //private bool isAdded = false;
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

        public ManagerForm1(long username, string password, int user, long managerNumber)
        {
            InitializeComponent();
            currentUserName = username;
            currentPassword = password;
            userType = user;
            managerUsername = managerNumber;
        }


        private void ManagerForm1_Load(object sender, EventArgs e)
        {
            /// <summary>
            /// MultiResolution
            /// </summary>
            width = SystemInformation.PrimaryMonitorSize.Width;
            height = SystemInformation.PrimaryMonitorSize.Height;

            MessageBox.Show(SystemInformation.PrimaryMonitorSize.ToString() + "   pass = " + currentPassword);

            /*Manager form design*/
            this.SetBounds(0, 0, width, ((955 * height) / 1000));
            /*Manager form design*/


            /****************************************************dashboard tab design********************************************************/
            TeacherModel dashboardTeacherObj = new TeacherModel();
            if (userType == 2)
            {
                ///////////
                SqlConnection conn5 = new SqlConnection();
                conn5.ConnectionString =
                "Data Source= 185.159.152.5;" +
                        "Initial Catalog=youshita_Test;" +
                        "User id=youshita_co; " +
                        "Password=P@hn1395;";
                SqlCommand sc5 = new SqlCommand();
                sc5.CommandType = CommandType.Text;
                sc5.Connection = conn5;
                SqlDataReader reader5;

                sc5.CommandText = " SELECT managerFName , managerLName FROM managerTable WHERE manager# = '" + managerUsername + "'";
                conn5.Open();
                reader5 = sc5.ExecuteReader();
                reader5.Read();
                string FName = reader5.GetString(0);
                string LName = reader5.GetString(1);
                string fullName = FName + " " + LName;
                conn5.Close();
                dashboard_info_lbl.Text = "شما با شماره کاربری " + managerUsername + "وارد سامانه شده اید. \n" +fullName + " خوش آمدید.";
            }
            else if(userType == 3)
            {
                dashboard_info_lbl.Text = "شما با شماره کاربری " + currentUserName + "وارد سامانه شده اید. \n" + dashboardTeacherObj.getTeacherFullName(currentUserName) + " خوش آمدید.";
            }

            
            dashboard_greeting_panel.SetBounds(((354 * width) / 800), ((2 * height) / 100), ((53 * width) / 100), ((20 * height) / 100));
            dashboard_greeting_gpb.SetBounds(((3 * width) / 400), ((3 * height) / 400), ((51 * width) / 100), ((17 * height) / 100));
            dashboard_info_lbl.SetBounds(((5 * width) / 400), ((5 * height) / 100), ((48 * width) / 100), ((6 * height) / 100));
            dashboard_news_panel.SetBounds(((354 * width) / 800), ((24 * height) / 100), ((53 * width) / 100), ((45 * height) / 100));
            dashboard_news_gpb.SetBounds(((3 * width) / 400), ((3 * height) / 400), ((51 * width) / 100), ((42 * height) / 100));
            dashboard_news_cob.SetBounds(((70 * width) / 400), ((12 * height) / 400), ((14 * width) / 100), ((5 * height) / 100));
            dashboard_news_chooseAg_lbl.SetBounds(((130 * width) / 400), ((12 * height) / 400), ((14 * width) / 100), ((5 * height) / 100));
            dashboard_news_titr_lbl.SetBounds(((175 * width) / 400), ((22 * height) / 400), ((14 * width) / 100), ((5 * height) / 100));
            dataGridView4.SetBounds(((6 * width) / 400), ((33 * height) / 400), ((48 * width) / 100), ((15 * height) / 100));
            dashboard_news_descriptions_lbl.SetBounds(((6 * width) / 400), ((105 * height) / 400), ((48 * width) / 100), ((15 * height) / 100));
            dashboard_news_description_lbl.SetBounds(((180 * width) / 400), ((94 * height) / 400), ((14 * width) / 100), ((5 * height) / 100));


            dashboard_date_panel.SetBounds(((10 * width) / 800), ((2 * height) / 100), ((39 * width) / 100), ((67 * height) / 100));
            dashboard_date_gpb.SetBounds(((13 * width) / 400), ((11 * height) / 400), ((35 * width) / 100), ((64 * height) / 100));
            dashboard_date_calendar.SetBounds(((10 * width) / 400), ((22 * height) / 400), ((30 * width) / 100), ((30 * height) / 100));
            analogueClock1.SetBounds(((30 * width) / 400), ((160 * height) / 400), ((20 * width) / 100), ((20 * height) / 100));
            /*****************************************************dashboard tab design*******************************************************/



            /****************************************************teachers tab design**********************************************************/
            manager_main_tc.SetBounds(0, ((125 * height) / 1000), ((99 * width) / 100), ((80 * height) / 100));
            logo_pictureBox.SetBounds(((79 * width) / 100), ((24 * height) / 1000), ((192 * width) / 1000), ((74 * height) / 1000));
            facultyName_pictureBox.SetBounds(((2 * width) / 100), ((40 * height) / 1000), ((160 * width) / 1000), ((85 * height) / 1000));
            teachers_addEditDelete_panel.SetBounds(((5 * width) / 400), ((2 * height) / 100), ((96 * width) / 100), ((31 * height) / 100));
            teachers_dataGridView_panel.SetBounds(((5 * width) / 400), (38 * height) / 100, ((96 * width) / 100), ((36 * height) / 100));
            dataGridView1.SetBounds(0, 0, ((96 * width) / 100), ((36 * height) / 100));
            teachers_cancel_btn.SetBounds(((5 * width) / 400), ((34 * height) / 100), ((80 * width) / 1000), ((25 * height) / 1000));
            teachers_showPassword_pictureBox.SetBounds(((95 * width) / 400), ((34 * height) / 100), ((25 * height) / 1000), ((25 * height) / 1000));
            teachers_password_txtbx.SetBounds(((105 * width) / 400), ((34 * height) / 100), ((110 * width) / 1000), ((25 * height) / 1000));
            teachers_password_lbl.SetBounds(((125 * width) / 400), ((340 * height) / 1000), ((100 * width) / 1000), ((25 * height) / 1000));
            teachers_passwordInfo_lbl.SetBounds(((167 * width) / 400), ((340 * height) / 1000), ((200 * width) / 1000), ((25 * height) / 1000));
            teachers_information_lbl.SetBounds(((50 * width) / 100), ((34 * height) / 100), ((47 * width) / 100), ((5 * height) / 100));
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
            teachers_delete_teacherNumber_text_lbl.SetBounds(((4 * width) / 100), ((30 * height) / 300), ((110 * width) / 1000), ((27 * height) / 1000));
            teachers_deleteTeacher_btn.SetBounds(((4 * width) / 100), ((73 * height) / 300), ((215 * width) / 1000), ((30 * height) / 1000));
            //***groupBoxes
            teachers_addTeacher_gpb.SetBounds(((65 * width) / 100), ((1 * height) / 300), ((282 * width) / 1000), ((290 * height) / 1000));
            teachers_editTeacher_gpb.SetBounds(((34 * width) / 100), ((1 * height) / 300), ((282 * width) / 1000), ((290 * height) / 1000));
            teachers_deleteTeacher_gpb.SetBounds(((3 * width) / 100), ((1 * height) / 300), ((282 * width) / 1000), ((290 * height) / 1000));

            /****************************************************teachers tab design**********************************************************/





            /****************************************************students tab design**********************************************************/
            students_addEditDelete_panel.SetBounds(((5 * width) / 400), ((2 * height) / 100), ((96 * width) / 100), ((31 * height) / 100));
            students_dataGridView_panel.SetBounds(((5 * width) / 400), (38 * height) / 100, ((96 * width) / 100), ((36 * height) / 100));
            dataGridView2.SetBounds(0, 0, ((96 * width) / 100), ((36 * height) / 100));
            students_return_btn.SetBounds(((5 * width) / 400), ((34 * height) / 100), ((80 * width) / 1000), ((25 * height) / 1000));
            students_cancel_btn.SetBounds(((40 * width) / 400), ((34 * height) / 100), ((80 * width) / 1000), ((25 * height) / 1000));
            students_export_excel_btn.SetBounds(((74 * width) / 400), ((34 * height) / 100), ((80 * width) / 1000), ((25 * height) / 1000));
            students_showPassword_pictureBox.SetBounds(((120 * width) / 400), ((34 * height) / 100), ((25 * height) / 1000), ((25 * height) / 1000));
            students_password_txtbx.SetBounds(((130 * width) / 400), ((34 * height) / 100), ((110 * width) / 1000), ((25 * height) / 1000));
            students_password_lbl.SetBounds(((150 * width) / 400), ((340 * height) / 1000), ((100 * width) / 1000), ((25 * height) / 1000));
            students_passwordInfo_lbl.SetBounds(((190 * width) / 400), ((340 * height) / 1000), ((200 * width) / 1000), ((25 * height) / 1000));
            students_information_lbl.SetBounds(((50 * width) / 100), ((34 * height) / 100), ((47 * width) / 100), ((5 * height) / 100));
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
            students_delete_studentNumber_text_lbl.SetBounds(((4 * width) / 100), ((15 * height) / 300), ((110 * width) / 1000), ((27 * height) / 1000));
            students_delete_lessonNumber_lbl.SetBounds(((17 * width) / 100), ((30 * height) / 300), ((83 * width) / 1000), ((27 * height) / 1000));
            students_delete_lessonNumber_text_lbl.SetBounds(((4 * width) / 100), ((30 * height) / 300), ((110 * width) / 1000), ((27 * height) / 1000));
            students_delete_lessonGroupNumber_lbl.SetBounds(((17 * width) / 100), ((45 * height) / 300), ((83 * width) / 1000), ((27 * height) / 1000));
            students_delete_lessonGroupNumber_text_lbl.SetBounds(((4 * width) / 100), ((45 * height) / 300), ((110 * width) / 1000), ((27 * height) / 1000));
            students_delete_deleteStudent_btn.SetBounds(((4 * width) / 100), ((73 * height) / 300), ((215 * width) / 1000), ((30 * height) / 1000));
            //***groupBoxes
            students_addStudent_gpb.SetBounds(((65 * width) / 100), ((1 * height) / 300), ((282 * width) / 1000), ((290 * height) / 1000));
            students_editStudent_gpb.SetBounds(((34 * width) / 100), ((1 * height) / 300), ((282 * width) / 1000), ((290 * height) / 1000));
            students_deleteStudent_gpb.SetBounds(((3 * width) / 100), ((1 * height) / 300), ((282 * width) / 1000), ((290 * height) / 1000));

            /****************************************************students tab design**********************************************************/





            /****************************************************lessons tab design**********************************************************/
            lessons_addEditDelete_panel.SetBounds(((5 * width) / 400), ((2 * height) / 100), ((96 * width) / 100), ((31 * height) / 100));
            lessons_dataGridView_panel.SetBounds(((5 * width) / 400), (38 * height) / 100, ((96 * width) / 100), ((36 * height) / 100));
            lessons_add_teachers_panel.SetBounds(((5 * width) / 1000), ((12 * height) / 300), ((200 * width) / 1000), ((200 * height) / 1000));
            lessons_add_teachers_panel_hidden_lbl.SetBounds(((5 * width) / 1000), ((1 * height) / 300), ((10 * width) / 1000), ((200 * height) / 1000));
            lessons_return_btn.SetBounds(((5 * width) / 400), ((34 * height) / 100), ((80 * width) / 1000), ((25 * height) / 1000));
            lessons_cancel_btn.SetBounds(((40 * width) / 400), ((34 * height) / 100), ((80 * width) / 1000), ((25 * height) / 1000));
            lessons_showPassword_pictureBox.SetBounds(((95 * width) / 400), ((34 * height) / 100), ((25 * height) / 1000), ((25 * height) / 1000));
            lessons_password_txtbx.SetBounds(((105 * width) / 400), ((34 * height) / 100), ((110 * width) / 1000), ((25 * height) / 1000));
            lessons_password_lbl.SetBounds(((125 * width) / 400), ((340 * height) / 1000), ((100 * width) / 1000), ((25 * height) / 1000));
            lessons_passwordInfo_lbl.SetBounds(((167 * width) / 400), ((340 * height) / 1000), ((200 * width) / 1000), ((25 * height) / 1000));
            lessons_information_lbl.SetBounds(((50 * width) / 100), ((340 * height) / 1000), ((47 * width) / 100), ((5 * height) / 100));
            dataGridView3.SetBounds(0, 0, ((96 * width) / 100), ((36 * height) / 100));


            //***add
            lessons_add_lessonNumber_lbl.SetBounds(((315 * width) / 1000), ((18 * height) / 300), ((75 * width) / 1000), ((27 * height) / 1000));
            lessons_add_lessonNumber_txtbx.SetBounds(((215 * width) / 1000), ((18 * height) / 300), ((110 * width) / 1000), ((27 * height) / 1000));
            lessons_add_lessonGroupNumber_lbl.SetBounds(((315 * width) / 1000), ((33 * height) / 300), ((75 * width) / 1000), ((27 * height) / 1000));
            lessons_add_lessonGroupNumber_txtbx.SetBounds(((215 * width) / 1000), ((33 * height) / 300), ((110 * width) / 1000), ((27 * height) / 1000));
            lessons_add_lessonName_lbl.SetBounds(((315 * width) / 1000), ((48 * height) / 300), ((75 * width) / 1000), ((27 * height) / 1000));
            lessons_add_lessonName_txtbx.SetBounds(((215 * width) / 1000), ((48 * height) / 300), ((110 * width) / 1000), ((27 * height) / 1000));
            lessons_add_deleteTeacher_btn.SetBounds(((305 * width) / 1000), ((62 * height) / 300), ((85 * width) / 1000), ((30 * height) / 1000));
            lessons_add_addTeacher_btn.SetBounds(((215 * width) / 1000), ((62 * height) / 300), ((85 * width) / 1000), ((30 * height) / 1000));
            lessons_add_registerTeacher_btn.SetBounds(((5 * width) / 1000), ((75 * height) / 300), ((200 * width) / 1000), ((33 * height) / 1000));
            lessons_add_clear_btn.SetBounds(((215 * width) / 1000), ((75 * height) / 300), ((176 * width) / 1000), ((33 * height) / 1000));

            //***edit
            lessons_edit_lessonNumber_lbl.SetBounds(((134 * width) / 1000), ((10 * height) / 300), ((75 * width) / 1000), ((27 * height) / 1000));
            lessons_edit_lessonNumber_txtbx.SetBounds(((9 * width) / 1000), ((10 * height) / 300), ((110 * width) / 1000), ((27 * height) / 1000));
            lessons_edit_lessonGroupNumber_lbl.SetBounds(((134 * width) / 1000), ((22 * height) / 300), ((75 * width) / 1000), ((27 * height) / 1000));
            lessons_edit_lessonGroupNumber_txtbx.SetBounds(((9 * width) / 1000), ((22 * height) / 300), ((110 * width) / 1000), ((27 * height) / 1000));
            lessons_edit_lessonName_lbl.SetBounds(((134 * width) / 1000), ((34 * height) / 300), ((75 * width) / 1000), ((27 * height) / 1000));
            lessons_edit_lessonName_txtbx.SetBounds(((9 * width) / 1000), ((34 * height) / 300), ((110 * width) / 1000), ((27 * height) / 1000));
            lessons_edit_teacherNumber_lbl.SetBounds(((134 * width) / 1000), ((46 * height) / 300), ((75 * width) / 1000), ((27 * height) / 1000));
            lessons_edit_teacherNumber_txtbx.SetBounds(((9 * width) / 1000), ((46 * height) / 300), ((110 * width) / 1000), ((27 * height) / 1000));
            lessons_edit_editLesson_btn.SetBounds(((9 * width) / 1000), ((62 * height) / 300), ((95 * width) / 1000), ((30 * height) / 1000));
            lessons_edit_clear_btn.SetBounds(((114 * width) / 1000), ((62 * height) / 300), ((95 * width) / 1000), ((30 * height) / 1000));
            lessons_edit_deleteLesson_btn.SetBounds(((9 * width) / 1000), ((75 * height) / 300), ((200 * width) / 1000), ((33 * height) / 1000));

            //***delete
            lessons_delete_lessonNumber_lbl.SetBounds(((145 * width) / 1000), ((10 * height) / 300), ((75 * width) / 1000), ((27 * height) / 1000));
            lessons_delete_lessonNumber_text_lbl.SetBounds(((9 * width) / 1000), ((10 * height) / 300), ((110 * width) / 1000), ((27 * height) / 1000));
            lessons_delete_lessonGroupNumber_lbl.SetBounds(((145 * width) / 1000), ((22 * height) / 300), ((75 * width) / 1000), ((27 * height) / 1000));
            lessons_delete_lessonGroupNumber_text_lbl.SetBounds(((9 * width) / 1000), ((22 * height) / 300), ((110 * width) / 1000), ((27 * height) / 1000));
            lessons_delete_lessonName_lbl.SetBounds(((145 * width) / 1000), ((34 * height) / 300), ((75 * width) / 1000), ((27 * height) / 1000));
            lessons_delete_lessonName_text_lbl.SetBounds(((9 * width) / 1000), ((34 * height) / 300), ((110 * width) / 1000), ((27 * height) / 1000));
            lessons_delete_teacherNumber_lbl.SetBounds(((145 * width) / 1000), ((46 * height) / 300), ((75 * width) / 1000), ((27 * height) / 1000));
            lessons_delete_teacherNumber_text_lbl.SetBounds(((9 * width) / 1000), ((46 * height) / 300), ((110 * width) / 1000), ((27 * height) / 1000));
            lessons_delete_deleteTeacher_btn.SetBounds(((9 * width) / 1000), ((75 * height) / 300), ((211 * width) / 1000), ((33 * height) / 1000));

            //***groupBoxes
            lessons_addLesson_gpb.SetBounds(((537 * width) / 1000), ((1 * height) / 300), ((395 * width) / 1000), ((290 * height) / 1000));
            lessons_editLesson_gpb.SetBounds(((294 * width) / 1000), ((1 * height) / 300), ((215 * width) / 1000), ((290 * height) / 1000));
            lessons_deleteTeacher_gpb.SetBounds(((30 * width) / 1000), ((1 * height) / 300), ((235 * width) / 1000), ((290 * height) / 1000));


            /// <summary>
            /// Multiple teacher
            /// </summary>
            lessons_add_teachers_panel.CreateControl();

            teacher_lbl_List.Add(new Label());
            teacher_lbl_List[numberOfTeachers].Font = new Font("B Yekan+", 9, FontStyle.Regular);
            teacher_lbl_List[numberOfTeachers].SetBounds(((100 * width) / 1000), ((5 * height) / 300), ((75 * width) / 1000), (27 * height) / 1000);
            teacher_lbl_List[numberOfTeachers].Text = "شماره استاد " + (numberOfTeachers + 1);

            teacher_txtbx_List.Add(new TextBox());
            teacher_txtbx_List[numberOfTeachers].Font = new Font("B Yekan+", 9, FontStyle.Regular);
            teacher_txtbx_List[numberOfTeachers].SetBounds(((15 * width) / 1000), ((5 * height) / 300), ((115 * width) / 1000), (27 * height) / 1000);

            lessons_add_teachers_panel.Controls.Add(teacher_txtbx_List[numberOfTeachers]);
            lessons_add_teachers_panel.Controls.Add(teacher_lbl_List[numberOfTeachers]);

            numberOfTeachers++;
            /// <summary>
            /// Multiple teacher
            /// </summary>

            /****************************************************lessons tab design**********************************************************/






            /***************************************************messagingTab***************************************************************/

            messaging_inbox_panel.SetBounds(((10 * width) / 800), ((2 * height) / 100), ((45 * width) / 100), ((67 * height) / 100));
            messaging_inbox_gpb.SetBounds(((10 * width) / 800), ((2 * height) / 100), ((42 * width) / 100), ((62 * height) / 100));
            dataGridView6.SetBounds(((8 * width) / 800), ((15 * height) / 100), ((40 * width) / 100), ((25 * height) / 100));
            messaging_inbox_messageShow_txtbx.SetBounds(((8 * width) / 800), ((42 * height) / 100), ((40 * width) / 100), ((18 * height) / 100));
            messaging_inbox_select_btn.SetBounds(((130 * width) / 800), ((83 * height) / 800), ((64 * width) / 800), ((23 * height) / 800));
            messaging_inbox_selectLessonGroupNumber_cb.SetBounds(((200 * width) / 800), ((84 * height) / 800), ((64 * width) / 800), ((25 * height) / 800));
            messaging_inbox_selectLessonNumber_cb.SetBounds(((270 * width) / 800), ((84 * height) / 800), ((64 * width) / 800), ((25 * height) / 800));
            messaging_inbox_lessonGroupNumber_lbl.SetBounds(((220 * width) / 800), ((55 * height) / 800), ((64 * width) / 800), ((25 * height) / 800));
            messaging_inbox_lessonNumber_lbl.SetBounds(((300 * width) / 800), ((55 * height) / 800), ((64 * width) / 800), ((25 * height) / 800));

            messaging_send_panel.SetBounds(((400 * width) / 800), ((49 * height) / 100), ((189 * width) / 400), ((20 * height) / 100));
            messaging_send_rtxt.SetBounds(((8 * width) / 800), ((8 * height) / 100), ((160 * width) / 400), ((10 * height) / 100));
            messaging_send_lbl.SetBounds(((332 * width) / 800), ((8 * height) / 100), ((20 * width) / 400), ((10 * height) / 100));
            messaging_send_selectGroupLessonNumber_cb.SetBounds(((193 * width) / 800), ((27 * height) / 800), ((64 * width) / 800), ((25 * height) / 800));
            messaging_send_selectLessonNumber_cb.SetBounds(((263 * width) / 800), ((27 * height) / 800), ((64 * width) / 800), ((25 * height) / 800));
            messaging_send_lessonGroupNumber_lbl.SetBounds(((213 * width) / 800), ((5 * height) / 800), ((64 * width) / 800), ((25 * height) / 800));
            messaging_send_lessonNumber_lbl.SetBounds(((293 * width) / 800), ((5 * height) / 800), ((64 * width) / 800), ((25 * height) / 800));

            messaging_outbox_panel.SetBounds(((400 * width) / 800), ((2 * height) / 100), ((189 * width) / 400), ((45 * height) / 100));
            messaging_outbox_gpb.SetBounds(((10 * width) / 800), ((2 * height) / 100), ((178 * width) / 400), ((41 * height) / 100));
            dataGridView7.SetBounds(((8 * width) / 800), ((4 * height) / 100), ((170 * width) / 400), ((20 * height) / 100));
            messaging_outbox_messageShow_txtbx.SetBounds(((8 * width) / 800), ((26 * height) / 100), ((170 * width) / 400), ((9 * height) / 100));
            messaging_outbox_delete_btn.SetBounds(((8 * width) / 800), ((365 * height) / 1000), ((30 * width) / 400), ((30 * height) / 1000));
            messaging_outbox_delete_btn.Enabled = false;
            /***************************************************messagingTab***************************************************************/






            /****************************************************attendance tab design**********************************************************/
            attendance_lessonInfo_panel.SetBounds(((5 * width) / 400), ((2 * height) / 100), ((96 * width) / 100), ((12 * height) / 100));
            attendance_lessonInfo_gpb.SetBounds(((30 * width) / 1000), ((1 * height) / 300), ((903 * width) / 1000), ((10 * height) / 100));

            attendance_lessonNumber_lbl.SetBounds(((810 * width) / 1000), ((13 * height) / 300), ((75 * width) / 1000), ((27 * height) / 1000));
            attendance_lessonNumber_cb.SetBounds(((760 * width) / 1000), ((13 * height) / 300), ((75 * width) / 1000), ((27 * height) / 1000));

            attendance_lessonGroupNumber_lbl.SetBounds(((670 * width) / 1000), ((13 * height) / 300), ((75 * width) / 1000), ((27 * height) / 1000));
            attendance_lessonGroupNumber_cb.SetBounds(((600 * width) / 1000), ((13 * height) / 300), ((75 * width) / 1000), ((27 * height) / 1000));

            attendance_showLesson_btn.SetBounds(((530 * width) / 1000), ((13 * height) / 300), ((55 * width) / 1000), ((27 * height) / 1000));

            attendance_minute_lbl.SetBounds(((180 * width) / 1000), ((13 * height) / 300), ((75 * width) / 1000), ((27 * height) / 1000));
            attendance_minute_cb.SetBounds(((150 * width) / 1000), ((13 * height) / 300), ((75 * width) / 1000), ((27 * height) / 1000));

            attendance_hour_lbl.SetBounds(((300 * width) / 1000), ((13 * height) / 300), ((75 * width) / 1000), ((27 * height) / 1000));
            attendance_hour_cb.SetBounds(((270 * width) / 1000), ((13 * height) / 300), ((75 * width) / 1000), ((27 * height) / 1000));

            attendance_date_lbl.SetBounds(((420 * width) / 1000), ((13 * height) / 300), ((75 * width) / 1000), ((27 * height) / 1000));
            attendance_date_dp.SetBounds(((390 * width) / 1000), ((13 * height) / 300), ((75 * width) / 1000), ((27 * height) / 1000));




            attendance_clear_btn.SetBounds(((80 * width) / 1000), ((13 * height) / 300), ((55 * width) / 1000), ((27 * height) / 1000));
            attendance_attend_btn.SetBounds(((15 * width) / 1000), ((13 * height) / 300), ((55 * width) / 1000), ((27 * height) / 1000));


            Attendance_dataGridView_panel.SetBounds(((5 * width) / 400), ((50 * height) / 300), ((960 * width) / 1000), ((572 * height) / 1000));
            dataGridView8.SetBounds(((5 * width) / 400), ((5 * height) / 300), ((932 * width) / 1000), ((480 * height) / 1000));
            attendance_attendClear_btn.SetBounds(((500 * width) / 1000), ((510 * height) / 1000), ((75 * width) / 1000), ((27 * height) / 1000));
            attendance_register_btn.SetBounds(((400 * width) / 1000), ((510 * height) / 1000), ((75 * width) / 1000), ((27 * height) / 1000));

            attendance_date_dp.UsePersianFormat = true;

            ///////////////////////////////////////////////////

            for (int i = 0; i < attendance_lessonNumber_cb.Items.Count; i++)
            {
                attendance_lessonNumber_cb.Items.RemoveAt(i);
            }


            SqlConnection conn8 = new SqlConnection();
            conn8.ConnectionString =
            "Data Source= 185.159.152.5;" +
                "Initial Catalog=youshita_Test;" +
                "User id=youshita_co; " +
                "Password=P@hn1395;";

            SqlCommand sc8 = new SqlCommand();
            SqlDataReader reader8;
            sc8.Connection = conn8;
            conn8.Open();

            sc8.CommandText = "SELECT DISTINCT lessonName FROM lessonTable where lessonTeacher# = " + currentUserName + "";


            sc8.CommandType = CommandType.Text;
            reader8 = sc8.ExecuteReader();
            while (reader8.Read())
            {
                string name = reader8.GetString(0);
                attendance_lessonNumber_cb.Items.Add(name);
                //.Insert(" " + reader2.GetString(0) + " " + reader2.GetInt32(1).ToString() + " ");
            }

            conn8.Close();


            /****************************************************attendance tab design**********************************************************/





            /****************************************************settings tab design**********************************************************/
            try
            {
                if (managerUsername != -2)
                {
                    //***datagridview initialization
                    SqlConnection conn2 = new SqlConnection();
                    conn2.ConnectionString =
                          "Data Source= 185.159.152.5;" +
                            "Initial Catalog=youshita_Test;" +
                            "User id=youshita_co; " +
                            "Password=P@hn1395;";

                    SqlCommand sc = new SqlCommand();
                    SqlDataReader reader;
                    sc.CommandText = "SELECT COUNT(*) AS NumberOfLogs FROM logTable ";
                    sc.CommandType = CommandType.Text;
                    sc.Connection = conn2;
                    conn2.Open();
                    reader = sc.ExecuteReader();

                    reader.Read();
                    totalRecords = int.Parse((reader["NumberOfLogs"].ToString()));
                    conn2.Close();



                    s = new string[totalRecords, 5];


                    SqlConnection conn = new SqlConnection();
                    conn.ConnectionString =
                        "Data Source= 185.159.152.5;" +
                        "Initial Catalog=youshita_Test;" +
                        "User id=youshita_co; " +
                        "Password=P@hn1395;";


                    SqlCommand sc1 = new SqlCommand();

                    SqlDataReader rdr = null;
                    sc1.CommandText = "SELECT * FROM logTable ORDER BY logDate DESC";
                    sc1.Connection = conn;
                    conn.Open();
                    rdr = sc1.ExecuteReader();
                    for (int x = 0; x < totalRecords; x++)
                    {

                        rdr.Read();


                        s[x, 0] = rdr.GetString(0);
                        s[x, 1] = rdr.GetString(1);
                        s[x, 2] = rdr.GetString(2);
                        s[x, 3] = (rdr.GetInt64(3)).ToString();
                        s[x, 4] = rdr.GetString(4);

                    }


                    bindingNavigator1.BindingSource = bindingSource5;
                    bindingSource5.CurrentChanged += new System.EventHandler(bindingSource5_CurrentChanged);
                    bindingSource5.DataSource = new PageOffsetList();

                    dataGridView5.RowHeadersWidth = (width / 30);

                    dataGridView5.Columns[0].HeaderText = "عنوان گزارش ";
                    dataGridView5.Columns[1].HeaderText = "متن گزارش";
                    dataGridView5.Columns[2].HeaderText = "تاریخ گزارش";
                    dataGridView5.Columns[3].HeaderText = " کاربر";
                    dataGridView5.Columns[4].Visible = false;


                    //***change info components filling
                    SqlConnection conn4 = new SqlConnection();
                    conn4.ConnectionString =
                          "Data Source= 185.159.152.5;" +
                            "Initial Catalog=youshita_Test;" +
                            "User id=youshita_co; " +
                            "Password=P@hn1395;";

                    SqlCommand sc4 = new SqlCommand();
                    SqlDataReader reader4;
                    sc4.CommandText = "SELECT * FROM managerTable WHERE manager# =" + managerUsername + "";
                    sc4.CommandType = CommandType.Text;
                    sc4.Connection = conn4;
                    conn4.Open();
                    reader4 = sc4.ExecuteReader();

                    reader4.Read();
                    setting_changeInfo_managerName_txtbx.Text = reader4.GetString(1);
                    setting_changeInfo_managerFamily_txtbx.Text = reader4.GetString(2);
                    setting_changeInfo_managerPass_txtbx.Text = "";
                    setting_changeInfo_managerNewPass_txtbx.Text = "";
                    conn4.Close();
                }

                else if (userType == 3)
                {
                    dataGridView5.Visible = false;
                    bindingNavigator1.Visible = false;
                    SqlConnection conn6 = new SqlConnection();
                    conn6.ConnectionString =
                    "Data Source= 185.159.152.5;" +
                            "Initial Catalog=youshita_Test;" +
                            "User id=youshita_co; " +
                            "Password=P@hn1395;";
                    SqlCommand sc6 = new SqlCommand();
                    sc6.CommandType = CommandType.Text;
                    sc6.Connection = conn6;
                    SqlDataReader reader5;

                    sc6.CommandText = " SELECT teacherFName , teacherLName FROM teacherTable WHERE teacher# = '" + currentUserName + "'";
                    conn6.Open();
                    reader5 = sc6.ExecuteReader();
                    reader5.Read();
                    string FName = reader5.GetString(0);
                    string LName = reader5.GetString(1);
                    conn6.Close();
                    setting_changeInfo_managerName_txtbx.Text = FName;
                    setting_changeInfo_managerFamily_txtbx.Text = LName;
                }



                setting_panel.SetBounds(((5 * width) / 400), ((2 * height) / 100), ((96 * width) / 100), ((31 * height) / 100));

                dataGridView5.SetBounds(((5 * width) / 400), (38 * height) / 100, ((96 * width) / 100), ((36 * height) / 100));
                bindingNavigator1.SetBounds(((5 * width) / 400), (135 * height) / 400, ((96 * width) / 100), ((4 * height) / 100));
                setting_changeInfo_gpb.SetBounds(((65 * width) / 100), ((1 * height) / 300), ((282 * width) / 1000), ((290 * height) / 1000));
                setting_changeTheme_gpb.SetBounds(((34 * width) / 100), ((1 * height) / 300), ((282 * width) / 1000), ((290 * height) / 1000));
                setting_aboutUs_gpb.SetBounds(((3 * width) / 100), ((1 * height) / 300), ((282 * width) / 1000), ((290 * height) / 1000));


                ////change pass
                setting_changeInfo_managerName_lbl.SetBounds(((17 * width) / 100), ((8 * height) / 300), ((83 * width) / 1000), ((27 * height) / 1000));
                setting_changeInfo_managerFamily_lbl.SetBounds(((17 * width) / 100), ((20 * height) / 300), ((83 * width) / 1000), ((27 * height) / 1000));
                setting_changeInfo_managerPass_lbl.SetBounds(((17 * width) / 100), ((32 * height) / 300), ((83 * width) / 1000), ((27 * height) / 1000));
                setting_changeInfo_managerNewPass_lbl.SetBounds(((17 * width) / 100), ((44 * height) / 300), ((83 * width) / 1000), ((27 * height) / 1000));
                setting_changeInfo_managerName_txtbx.SetBounds(((4 * width) / 100), ((8 * height) / 300), ((110 * width) / 1000), ((27 * height) / 1000));
                setting_changeInfo_managerFamily_txtbx.SetBounds(((4 * width) / 100), ((20 * height) / 300), ((110 * width) / 1000), ((27 * height) / 1000));
                setting_changeInfo_managerPass_txtbx.SetBounds(((4 * width) / 100), ((32 * height) / 300), ((110 * width) / 1000), ((27 * height) / 1000));
                setting_changeInfo_managerNewPass_txtbx.SetBounds(((4 * width) / 100), ((44 * height) / 300), ((110 * width) / 1000), ((27 * height) / 1000));
                setting_changeInfo_change_btn.SetBounds(((4 * width) / 100), ((73 * height) / 300), ((10 * width) / 100), ((30 * height) / 1000));
                setting_changeInfo_clear_btn.SetBounds(((30 * width) / 200), ((73 * height) / 300), ((10 * width) / 100), ((30 * height) / 1000));
                setting_changeInfo_showPass_pic.SetBounds(((8 * width) / 400), ((87 * height) / 800), ((15 * width) / 1000), ((27 * height) / 1000));
                setting_changeInfo_showNewPass_pic.SetBounds(((8 * width) / 400), ((45 * height) / 300), ((15 * width) / 1000), ((27 * height) / 1000));
                //////About Us
                settings_abotUs_pictureBox.SetBounds(((60* width) / 1000), ((25 * height) / 1000), ((160* width) / 1000), ((185 * height) / 1000));
                setting_aboutUs_lbl.SetBounds(((4 * width) / 400), ((54* height) / 300), ((260 * width) / 1000), ((98 * height) / 1000));
                setting_aboutUs_lbl.Text = "شرکت نرم افزاری رایان پردازش نوین آریا\nتلفن تماس: 061335534050\nآدرس ایمیل :RayanProcessCompany@gmail.com\nوب سایت:";
            }
            catch(SqlException)
            {
                DialogForm dialog = new DialogForm("اشکال در برقراری ارتباط با سرور", "خطای سرور", "error", this);
            }
            catch (InvalidOperationException)
            {
                DialogForm dialog = new DialogForm("اشکال در برقراری ارتباط با سرور", "خطای سرور", "error", this);
            }
            /****************************************************setting tab design**********************************************************/




            /****************************************************determining access level****************************************************/
            if (userType == 3)
            {
                manager_main_tc.TabPages.Remove(teachers);
                manager_main_tc.TabPages.Remove(students);
                manager_main_tc.TabPages.Remove(lessons);
            }
            /****************************************************determining access level****************************************************/
            /// <summary>
            /// MultiResolution
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
                studentObj.addStudent(long.Parse(students_add_lessonNumber_txtbx.Text), int.Parse(students_add_lessonGroupNumber_txtbx.Text), true);
            }
            catch (FormatException)
            {
                DialogForm dialog = new DialogForm("فرمت اطلاعات ورودی اشتباه است.", "خطا", "error", this);
            }

            catch (ArgumentNullException)
            {
                DialogForm dialog = new DialogForm("اطلاعات ورودی ناقص هستند.", "خطا", "error", this);
            }

            catch (SqlException e1)
            {
                if (e1.Message.Contains("server"))
                {
                    DialogForm dialog = new DialogForm("ارتباط با سرور برقرار نشد.", "خطای سرور", "error", this);
                }
                else
                {
                    DialogForm dialog = new DialogForm("اطلاعات ورودی تکراری یا اشتباه است.", "خطا", "error", this);
                }
            }

            catch (Exception e1)
            {
                if (e1.Message == "success")
                {
                    DialogForm dialog = new DialogForm("اطلاعات ورودی با موفقیت ثبت شدند.", "ثبت موفقیت آمیز", "success", this);
                    lessonsDataGridViewUpdate_2();

                    //***clear textBoxes
                    students_add_studentNumber_txtbx.Clear();
                    students_add_studentName_txtbx.Clear();
                    students_add_studentFamily_txtbx.Clear();
                }
            }
        }

        private void manager_lesson_add_bt_Click(object sender, EventArgs e)
        {
            isWrong = false;
            try
            {
                for (int counter = 0; counter < numberOfTeachers; counter++)
                {
                    if (teacher_txtbx_List[counter].Text.Any(char.IsLetter) || teacher_txtbx_List[counter].Text.Any(char.IsSymbol) ||
                       teacher_txtbx_List[counter].Text.Any(char.IsPunctuation) || teacher_txtbx_List[counter].Text.Any(char.IsWhiteSpace))
                    {
                        isWrong = true;
                        throw new FormatException();
                    }
                }

                for (int i = 0; i < numberOfTeachers; i++)
                {
                    for (int j = 0; j < numberOfTeachers; j++)
                    {
                        if (i != j)
                        {
                            if (teacher_txtbx_List[i].Text == teacher_txtbx_List[j].Text)
                            {
                                isWrong = false;
                                throw new Exception("duplicateTeacher");
                            }
                        }

                    }
                }

                if (isWrong == false)
                {
                    currentLessonNumber = lessons_add_lessonNumber_txtbx.Text;
                    currentLessonGroupNumber = lessons_add_lessonGroupNumber_txtbx.Text;

                    LessonModel lessonObj = new LessonModel();
                    lessonObj.setLessonNumber(long.Parse(lessons_add_lessonNumber_txtbx.Text));
                    lessonObj.setLessonGroupNumber(int.Parse(lessons_add_lessonGroupNumber_txtbx.Text));
                    lessonObj.setLessonName(lessons_add_lessonName_txtbx.Text);
                    lessonObj.setLessonTeacherNumber(-1);
                    lessonObj.addLesson();
                    for (int counter = 0; counter < numberOfTeachers; counter++)
                    {
                        lessonObj.setLessonTeacherNumber(long.Parse(teacher_txtbx_List[counter].Text));
                        lessonObj.addLesson();
                        //isAdded = true;
                    }
                    lessonObj.createLessonTable();

                    //***Reset Components
                    lessons_add_lessonNumber_txtbx.Clear();
                    lessons_add_lessonGroupNumber_txtbx.Clear();
                    lessons_add_lessonName_txtbx.Clear();

                    for (int i = numberOfTeachers - 1; i > 0; i--)
                    {
                        lessons_add_teachers_panel.Controls.Remove(teacher_txtbx_List[i]);
                        lessons_add_teachers_panel.Controls.Remove(teacher_lbl_List[i]);

                        teacher_txtbx_List.RemoveAt(i);
                        teacher_lbl_List.RemoveAt(i);
                    }

                    numberOfTeachers = 1;

                    //***disable deleteTeacher Button
                    lessons_add_deleteTeacher_btn.Enabled = false;

                    //***clear first teacher textBox
                    teacher_txtbx_List[0].Clear();

                    //***successful
                    throw new Exception("success");
                }
            }


            catch (FormatException)
            {
                DialogForm dialog = new DialogForm("فرمت اطلاعات ورودی اشتباه است.", "خطا", "error", this);
            }

            catch (ArgumentNullException)
            {
                DialogForm dialog = new DialogForm("اطلاعات ورودی ناقص هستند.", "خطا", "error", this);
            }

            catch (SqlException e1)
            {
                if (e1.Message.Contains("server"))
                {
                    DialogForm dialog = new DialogForm("ارتباط با سرور برقرار نشد.", "خطای سرور", "error", this);
                }
                else
                {
                    DialogForm dialog = new DialogForm("اطلاعات ورودی تکراری یا اشتباه است.", "خطا", "error", this);
                }
            }

            catch (Exception e1)
            {
                if (e1.Message == "success")
                {
                    DialogForm dialog = new DialogForm("اطلاعات ورودی با موفقیت ثبت شدند.", "ثبت موفقیت آمیز", "success", this);
                    lessonsDataGridViewUpdate_2();
                    lessons_return_btn.Enabled = true;
                }

                else if (e1.Message == "duplicateTeacher")
                {
                    DialogForm dialog = new DialogForm("شماره اساتید تکراری هستند.", "خطا", "error", this);
                }
            }
        }





        private void add_lesson_teacher_bt_Click(object sender, EventArgs e)
        {
            lessons_add_deleteTeacher_btn.Enabled = true;

            if (numberOfTeachers == 9)
            {
                lessons_add_addTeacher_btn.Enabled = false;
            }

            teacher_lbl_List.Add(new Label());
            teacher_lbl_List[numberOfTeachers].Font = new Font("B Yekan+", 9, FontStyle.Regular);
            teacher_lbl_List[numberOfTeachers].SetBounds(((100 * width) / 1000), ((35 * height) / 1000) + teacher_lbl_List[numberOfTeachers - 1].Bounds.Y, ((75 * width) / 1000), ((27 * height) / 1000));
            teacher_lbl_List[numberOfTeachers].BringToFront();
            teacher_lbl_List[numberOfTeachers].Text = "شماره استاد " + (numberOfTeachers + 1);

            teacher_txtbx_List.Add(new TextBox());
            teacher_txtbx_List[numberOfTeachers].Font = new Font("B Yekan+", 9, FontStyle.Regular);
            teacher_txtbx_List[numberOfTeachers].SetBounds(((15 * width) / 1000), ((35 * height) / 1000) + teacher_txtbx_List[numberOfTeachers - 1].Bounds.Y, ((115 * width) / 1000), ((27 * height) / 1000));
            teacher_txtbx_List[numberOfTeachers].BringToFront();

            lessons_add_teachers_panel.Controls.Add(teacher_txtbx_List[numberOfTeachers]);
            lessons_add_teachers_panel.Controls.Add(teacher_lbl_List[numberOfTeachers]);

            lessons_add_teachers_panel.VerticalScroll.Value = lessons_add_teachers_panel.VerticalScroll.Maximum;

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
                TeacherModel teacherObj = new TeacherModel();

                teacherObj.setTeacherNumber(long.Parse(teachers_add_teacherNumber_txtbx.Text));
                teacherObj.setTeacherFName(teachers_add_teacherName_txtbx.Text);
                teacherObj.setTeacherLName(teachers_add_teacherFamily_txtbx.Text);
                teacherObj.setTeacherPassword(hashPass(teachers_add_teacher_password_txtbx.Text));
                teacherObj.setTeacherURL("");
                teacherObj.addTeacher();
            }

            catch (FormatException)
            {
                DialogForm dialog = new DialogForm("فرمت اطلاعات ورودی اشتباه است.", "خطا", "error", this);
            }

            catch (ArgumentNullException)
            {
                DialogForm dialog = new DialogForm("اطلاعات ورودی ناقص هستند.", "خطا", "error", this);
            }

            catch (SqlException e1)
            {
                if (e1.Message.Contains("server"))
                {
                    DialogForm dialog = new DialogForm("ارتباط با سرور برقرار نشد.", "خطای سرور", "error", this);
                }
                else
                {
                    DialogForm dialog = new DialogForm("اطلاعات ورودی تکراری یا اشتباه است.", "خطا", "error", this);
                }
            }

            catch (Exception e1)
            {
                if (e1.Message == "success")
                {
                    DialogForm dialog = new DialogForm("اطلاعات ورودی با موفقیت ثبت شدند.", "ثبت موفقیت آمیز", "success", this);
                    teachersDataGridViewUpdate_1();
                    addTeacher_resetComponents();
                }
            }
        }

        private void teachers_delete_clear_btn_Click(object sender, EventArgs e)
        {
            teachers_delete_teacherNumber_text_lbl.Text = "";
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
                if (teachers_password_txtbx.Text == currentPassword)
                {
                    TeacherModel teacherObj = new TeacherModel();
                    teacherObj.setTeacherNewNumber(Int64.Parse(teachers_edit_teacherNumber_txtbx.Text));
                    teacherObj.setTeacherNumber(Int64.Parse(currentNumber));
                    teacherObj.setTeacherFName(teachers_edit_teacherName_txtbx.Text);
                    teacherObj.setTeacherLName(teachers_edit_teacherFamily_txtbx.Text);
                    teacherObj.setTeacherPassword(hashPass(teachers_edit_teacher_password_txtbx.Text));
                    teacherObj.setTeacherURL("");
                    teacherObj.updateTeacher();
                }
                else
                {
                    DialogForm dialog = new DialogForm("رمز عبور اشتباه است.", "خطا", "error", this);
                }
            }

            catch (FormatException)
            {
                DialogForm dialog = new DialogForm("فرمت اطلاعات ورودی اشتباه است.", "خطا", "error", this);
            }

            catch (ArgumentNullException)
            {
                DialogForm dialog = new DialogForm("اطلاعات ورودی ناقص هستند.", "خطا", "error", this);
            }

            catch (SqlException e1)
            {
                if (e1.Message.Contains("server"))
                {
                    DialogForm dialog = new DialogForm("ارتباط با سرور برقرار نشد.", "خطای سرور", "error", this);
                }
                else
                {
                    DialogForm dialog = new DialogForm("اطلاعات ورودی تکراری یا اشتباه است.", "خطا", "error", this);
                }
            }

            catch (Exception e1)
            {
                if (e1.Message == "success")
                {
                    teachers_cancel_btn.PerformClick();
                    DialogForm dialog = new DialogForm("اطلاعات ورودی با موفقیت تغییر یافتند.", "تغییر موفقیت آمیز", "success", this);
                    edit_Delete_Teacher_resetComponents();
                    teachersDataGridViewUpdate_1();
                }
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
                teachers_delete_teacherNumber_text_lbl.Enabled = true;
                teachers_deleteTeacher_btn.Enabled = true;
                //***enable password components
                teachers_showPassword_pictureBox.Visible = true;
                teachers_password_txtbx.Visible = true;
                teachers_password_lbl.Visible = true;
                teachers_passwordInfo_lbl.Visible = true;

                currentNumber = dataGridView1.Rows[e.RowIndex].Cells["teacher#"].Value.ToString();

                teachers_delete_teacherNumber_text_lbl.Text = dataGridView1.Rows[e.RowIndex].Cells["teacher#"].Value.ToString();
                teachers_edit_teacherNumber_txtbx.Text = dataGridView1.Rows[e.RowIndex].Cells["teacher#"].Value.ToString();
                teachers_edit_teacherName_txtbx.Text = dataGridView1.Rows[e.RowIndex].Cells["teacherFName"].Value.ToString();
                teachers_edit_teacherFamily_txtbx.Text = dataGridView1.Rows[e.RowIndex].Cells["teacherLName"].Value.ToString();
                teachers_edit_teacher_password_txtbx.Text = dataGridView1.Rows[e.RowIndex].Cells["teacherPassword"].Value.ToString();
            }
            catch (System.ArgumentOutOfRangeException)
            {

            }
        }

        private void teachers_deleteTeacher_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (teachers_password_txtbx.Text == currentPassword)
                {
                    TeacherModel teacherObj = new TeacherModel();
                    teacherObj.setTeacherNumber(Int64.Parse(teachers_delete_teacherNumber_text_lbl.Text));
                    teacherObj.deleteTeacher();
                }
                else
                {
                    DialogForm dialog = new DialogForm("رمز عبور اشتباه است.", "خطا", "error", this);
                }
            }
            catch (FormatException)
            {
                DialogForm dialog = new DialogForm("فرمت اطلاعات ورودی اشتباه است.", "خطا", "error", this);
            }

            catch (ArgumentNullException)
            {
                DialogForm dialog = new DialogForm("اطلاعات ورودی ناقص هستند.", "خطا", "error", this);
            }

            catch (SqlException e1)
            {
                if (e1.Message.Contains("server"))
                {
                    DialogForm dialog = new DialogForm("ارتباط با سرور برقرار نشد.", "خطای سرور", "error", this);
                }
                else
                {
                    DialogForm dialog = new DialogForm("اطلاعات ورودی تکراری یا اشتباه است.", "خطا", "error", this);
                }
            }

            catch (Exception e1)
            {
                if (e1.Message == "success")
                {
                    teachers_cancel_btn.PerformClick();
                    DialogForm dialog = new DialogForm("اطلاعات با موفقیت حذف شدند.", "حذف موفقیت آمیز", "success", this);
                    edit_Delete_Teacher_resetComponents();
                    teachersDataGridViewUpdate_1();
                }
            }
        }

        private void students_return_btn_Click(object sender, EventArgs e)
        {
            studentsDataGridViewUpdate_1();

            //***disable cancel & export button
            students_cancel_btn.Enabled = false;
            students_export_excel_btn.Enabled = false;
            //***disable add components
            students_add_studentNumber_lbl.Enabled = false;
            students_add_studentName_lbl.Enabled = false;
            students_add_studentFamily_lbl.Enabled = false;
            students_add_lessonNumber_lbl.Enabled = false;
            students_add_lessonGroupNumber_lbl.Enabled = false;
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
            students_delete_studentNumber_text_lbl.Enabled = false;
            students_delete_lessonNumber_lbl.Enabled = false;
            students_delete_lessonNumber_text_lbl.Enabled = false;
            students_delete_lessonGroupNumber_lbl.Enabled = false;
            students_delete_lessonGroupNumber_text_lbl.Enabled = false;
            students_delete_deleteStudent_btn.Enabled = false;
            //***Clear add & edit & delete textBoxes
            students_add_studentNumber_txtbx.Clear();
            students_add_studentName_txtbx.Clear();
            students_add_studentFamily_txtbx.Clear();
            students_add_lessonNumber_txtbx.Clear();
            students_add_lessonGroupNumber_txtbx.Clear();
            students_edit_studentNumber_txtbx.Clear();
            students_edit_studentName_txtbx.Clear();
            students_edit_studentFamily_txtbx.Clear();
            students_delete_studentNumber_text_lbl.Text = "";
            students_delete_lessonNumber_text_lbl.Text = "";
            students_delete_lessonGroupNumber_text_lbl.Text = "";
            //***Disable return button
            students_return_btn.Enabled = false;
            //***Disable password components
            students_showPassword_pictureBox.Visible = false;
            students_password_txtbx.Clear();
            students_password_txtbx.Visible = false;
            students_password_lbl.Visible = false;
            students_passwordInfo_lbl.Visible = false;
        }

        private void manager_main_tc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (manager_main_tc.SelectedTab == manager_main_tc.TabPages["teachers"])
            {
                teachers_cancel_btn.PerformClick();
                teachers_add_clear_btn.PerformClick();
                teachersDataGridViewUpdate_1();
            }

            else if (manager_main_tc.SelectedTab == manager_main_tc.TabPages["students"])
            {
                studentsDataGridViewUpdate_1();
                students_return_btn.PerformClick();
            }

            else if (manager_main_tc.SelectedTab == manager_main_tc.TabPages["lessons"])
            {
                lessonsDataGridViewUpdate_1();
                lessons_return_btn.PerformClick();
            }


            else if (manager_main_tc.SelectedTab == manager_main_tc.TabPages["messaging"])
            {
                int lessonLimit = messaging_send_selectLessonNumber_cb.Items.Count;
                int lessonGroupLimit = messaging_inbox_selectLessonNumber_cb.Items.Count;

                for (int i = 0; i < lessonLimit; i++)
                {
                    messaging_send_selectLessonNumber_cb.Items.RemoveAt(0);
                }

                for (int i = 0; i < lessonGroupLimit ; i++)
                {
                    messaging_inbox_selectLessonNumber_cb.Items.RemoveAt(0);
                }


                //////////////////////outbox/////////////////////////

                MessageModel obj = new MessageModel();

                dataGridView7.DataSource = bindingSource7;

                GetData7("SELECT * FROM  messageTable where senderTeacher# = " + currentUserName + " ORDER BY messageDate DESC ");

                dataGridView7.RowHeadersWidth = (width / 25);
                dataGridView7.Columns[0].Visible = false;
                dataGridView7.Columns[1].Visible = false;
                dataGridView7.Columns[2].HeaderText = "متن پیام";
                dataGridView7.Columns[3].HeaderText = "شماره درس";
                dataGridView7.Columns[4].Visible = false;
                dataGridView7.Columns[5].HeaderText = "شماره گروه درس";
                dataGridView7.Columns[6].Visible = false;
                dataGridView7.Columns[7].HeaderText = "تاریخ";
                //dataGridView7.Columns[2].Width = (width / 3);


                foreach (DataGridViewColumn col in dataGridView7.Columns)
                {
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }

                foreach (DataGridViewRow row in dataGridView7.Rows)
                {
                    //row.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView7.Rows[row.Index].HeaderCell.Value = (row.Index + 1).ToString();
                    //row.HeaderCell.Value = String.Format("{0}", row.Index + 1);
                }

                /////////////////////////inbox/////////////////////////////////


                



                SqlConnection conn = new SqlConnection();
                conn.ConnectionString =
                "Data Source= 185.159.152.5;" +
                    "Initial Catalog=youshita_Test;" +
                    "User id=youshita_co; " +
                    "Password=P@hn1395;";

                SqlCommand sc1 = new SqlCommand();
                SqlDataReader reader2;
                sc1.Connection = conn;
                conn.Open();

                sc1.CommandText = "SELECT DISTINCT lessonName FROM lessonTable where lessonTeacher# = " + currentUserName + "";


                sc1.CommandType = CommandType.Text;
                reader2 = sc1.ExecuteReader();
                while (reader2.Read())
                {
                    string name = reader2.GetString(0);
                    messaging_send_selectLessonNumber_cb.Items.Add(name);
                    //.Insert(" " + reader2.GetString(0) + " " + reader2.GetInt32(1).ToString() + " ");
                }

                conn.Close();


                ////////////////////////////////cobo2 send//////////////////////////////////////

                

                SqlConnection conn2 = new SqlConnection();
                conn2.ConnectionString =
                "Data Source= 185.159.152.5;" +
                    "Initial Catalog=youshita_Test;" +
                    "User id=youshita_co; " +
                    "Password=P@hn1395;";

                SqlCommand sc2 = new SqlCommand();
                SqlDataReader reader1;
                sc2.Connection = conn2;
                conn2.Open();

                sc2.CommandText = "SELECT DISTINCT lessonName FROM lessonTable where lessonTeacher# = " + currentUserName + "";


                sc2.CommandType = CommandType.Text;
                reader1 = sc2.ExecuteReader();
                while (reader1.Read())
                {
                    string name = reader1.GetString(0);
                    messaging_inbox_selectLessonNumber_cb.Items.Add(name);
                    //.Insert(" " + reader2.GetString(0) + " " + reader2.GetInt32(1).ToString() + " ");
                }

                conn2.Close();

                /////////////////////////////cobo2 inbox////////////////////////////////////////*/

            }

            else if (manager_main_tc.SelectedTab == manager_main_tc.TabPages["settings"])
            {
                if(userType != 3)
                {
                    //***datagridview initialization
                    SqlConnection conn2 = new SqlConnection();
                    conn2.ConnectionString =
                          "Data Source= 185.159.152.5;" +
                            "Initial Catalog=youshita_Test;" +
                            "User id=youshita_co; " +
                            "Password=P@hn1395;";

                    SqlCommand sc = new SqlCommand();
                    SqlDataReader reader;
                    sc.CommandText = "SELECT COUNT(*) AS NumberOfLogs FROM logTable ";
                    sc.CommandType = CommandType.Text;
                    sc.Connection = conn2;
                    conn2.Open();
                    reader = sc.ExecuteReader();

                    reader.Read();
                    totalRecords = int.Parse((reader["NumberOfLogs"].ToString()));
                    conn2.Close();



                    s = new string[totalRecords, 5];


                    SqlConnection conn = new SqlConnection();
                    conn.ConnectionString =
                        "Data Source= 185.159.152.5;" +
                        "Initial Catalog=youshita_Test;" +
                        "User id=youshita_co; " +
                        "Password=P@hn1395;";


                    SqlCommand sc1 = new SqlCommand();

                    SqlDataReader rdr = null;
                    sc1.CommandText = "SELECT * FROM logTable ORDER BY logDate DESC";
                    sc1.Connection = conn;
                    conn.Open();
                    rdr = sc1.ExecuteReader();
                    for (int x = 0; x < totalRecords; x++)
                    {

                        rdr.Read();


                        s[x, 0] = rdr.GetString(0);
                        s[x, 1] = rdr.GetString(1);
                        s[x, 2] = rdr.GetString(2);
                        s[x, 3] = (rdr.GetInt64(3)).ToString();
                        s[x, 4] = rdr.GetString(4);

                    }


                    bindingNavigator1.BindingSource = bindingSource5;
                    bindingSource5.CurrentChanged += new System.EventHandler(bindingSource5_CurrentChanged);
                    bindingSource5.DataSource = new PageOffsetList();

                    dataGridView5.RowHeadersWidth = (width / 30);

                    dataGridView5.Columns[0].HeaderText = "عنوان گزارش ";
                    dataGridView5.Columns[1].HeaderText = "متن گزارش";
                    dataGridView5.Columns[2].HeaderText = "تاریخ گزارش";
                    dataGridView5.Columns[3].HeaderText = " کاربر";
                    dataGridView5.Columns[4].Visible = false;
                }
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
            students_delete_studentNumber_text_lbl.Text = "";
            students_delete_lessonNumber_text_lbl.Text = "";
            students_delete_lessonGroupNumber_text_lbl.Text = "";
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
            students_delete_studentNumber_text_lbl.Enabled = false;
            students_delete_lessonNumber_lbl.Enabled = false;
            students_delete_lessonNumber_text_lbl.Enabled = false;
            students_delete_lessonGroupNumber_lbl.Enabled = false;
            students_delete_lessonGroupNumber_text_lbl.Enabled = false;
            students_delete_deleteStudent_btn.Enabled = false;
            //***Clear edit & delete textBoxes
            students_edit_studentNumber_txtbx.Clear();
            students_edit_studentName_txtbx.Clear();
            students_edit_studentFamily_txtbx.Clear();
            students_delete_studentNumber_text_lbl.Text = "";
            students_delete_lessonNumber_text_lbl.Text = "";
            students_delete_lessonGroupNumber_text_lbl.Text = "";
            //***Disable Cancel Button
            students_cancel_btn.Enabled = false;
            //***enable password components
            students_showPassword_pictureBox.Visible = false;
            students_password_txtbx.Clear();
            students_password_txtbx.Visible = false;
            students_password_lbl.Visible = false;
            students_passwordInfo_lbl.Visible = false;
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
            teachers_delete_teacherNumber_text_lbl.Enabled = false;
            teachers_deleteTeacher_btn.Enabled = false;
            //***clear textBoxes
            teachers_delete_teacherNumber_text_lbl.Text = "";
            teachers_edit_teacherNumber_txtbx.Clear();
            teachers_edit_teacherName_txtbx.Clear();
            teachers_edit_teacherFamily_txtbx.Clear();
            teachers_edit_teacher_password_txtbx.Clear();
            //***disable password components
            teachers_password_txtbx.Clear();
            teachers_showPassword_pictureBox.Visible = false;
            teachers_password_txtbx.Visible = false;
            teachers_password_lbl.Visible = false;
            teachers_passwordInfo_lbl.Visible = false;
        }

        private void students_edit_addStudent_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (students_password_txtbx.Text == currentPassword)
                {
                    StudentModel studentObj = new StudentModel();
                    studentObj.setStudentNumber(Int64.Parse(currentNumber));
                    studentObj.setStudentNewNumber(Int64.Parse(students_edit_studentNumber_txtbx.Text));
                    studentObj.setStudentFName(students_edit_studentName_txtbx.Text);
                    studentObj.setStudentLName(students_edit_studentFamily_txtbx.Text);
                    studentObj.setStudentURL("");
                    studentObj.updateStudent(Int64.Parse(currentLessonNumber), Int32.Parse(currentLessonGroupNumber));
                }
                else
                {
                    DialogForm dialog = new DialogForm("رمز عبور اشتباه است.", "خطا", "error", this);
                }
            }
            catch (FormatException)
            {
                DialogForm dialog = new DialogForm("فرمت اطلاعات ورودی اشتباه است.", "خطا", "error", this);
            }

            catch (ArgumentNullException)
            {
                DialogForm dialog = new DialogForm("اطلاعات ورودی ناقص هستند.", "خطا", "error", this);
            }

            catch (SqlException e1)
            {
                if (e1.Message.Contains("server"))
                {
                    DialogForm dialog = new DialogForm("ارتباط با سرور برقرار نشد.", "خطای سرور", "error", this);
                }
                else
                {
                    DialogForm dialog = new DialogForm("اطلاعات ورودی تکراری یا اشتباه است.", "خطا", "error", this);
                }
            }

            catch (Exception e1)
            {
                if (e1.Message == "success")
                {
                    students_cancel_btn.PerformClick();
                    DialogForm dialog = new DialogForm("اطلاعات ورودی با موفقیت تغییر یافتند.", "تغییر موفقیت آمیز", "success", this);
                    students_Edit_Delete_ResetComponents();
                    studentsDataGridViewUpdate_2();
                }
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
                students_add_lessonNumber_lbl.Enabled = true;
                students_add_lessonGroupNumber_lbl.Enabled = true;

                try
                {
                    currentLessonNumber = dataGridView2.Rows[e.RowIndex].Cells["lesson#"].Value.ToString();
                    currentLessonGroupNumber = dataGridView2.Rows[e.RowIndex].Cells["lessonGroup#"].Value.ToString();

                    students_add_lessonNumber_txtbx.Text = currentLessonNumber;
                    students_add_lessonGroupNumber_txtbx.Text = currentLessonGroupNumber;

                    studentsDataGridViewUpdate_2();
                }
                catch (System.ArgumentOutOfRangeException)
                {

                }
                catch (ArgumentException)
                {
                    DialogForm dialog = new DialogForm("ارتباط با سرور یا پایگاه داده برقرار نشد.", "خطا", "error", this);
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
                    students_delete_studentNumber_text_lbl.Enabled = true;
                    students_delete_lessonNumber_lbl.Enabled = true;
                    students_delete_lessonNumber_text_lbl.Enabled = true;
                    students_delete_lessonGroupNumber_lbl.Enabled = true;
                    students_delete_lessonGroupNumber_text_lbl.Enabled = true;
                    students_delete_deleteStudent_btn.Enabled = true;
                    //***enable password components
                    students_showPassword_pictureBox.Visible = true;
                    students_password_txtbx.Visible = true;
                    students_password_lbl.Visible = true;
                    students_passwordInfo_lbl.Visible = true;

                    //***Fill edit & delete textBoxes
                    currentNumber = dataGridView2.Rows[e.RowIndex].Cells["student#"].Value.ToString();

                    students_edit_studentNumber_txtbx.Text = dataGridView2.Rows[e.RowIndex].Cells["student#"].Value.ToString();
                    students_edit_studentName_txtbx.Text = dataGridView2.Rows[e.RowIndex].Cells["studentFName"].Value.ToString();
                    students_edit_studentFamily_txtbx.Text = dataGridView2.Rows[e.RowIndex].Cells["studentLName"].Value.ToString();

                    students_delete_studentNumber_text_lbl.Text = dataGridView2.Rows[e.RowIndex].Cells["student#"].Value.ToString();
                    students_delete_lessonNumber_text_lbl.Text = currentLessonNumber;
                    students_delete_lessonGroupNumber_text_lbl.Text = currentLessonGroupNumber;
                }
                catch (System.ArgumentOutOfRangeException)
                {

                }
                catch (ArgumentException)
                {
                    DialogForm dialog = new DialogForm("ارتباط با سرور یا پایگاه داده برقرار نشد.", "خطا", "error", this);
                }
            }
        }

        private void del_lesson_teacher_bt_Click(object sender, EventArgs e)
        {
            if (numberOfTeachers == 2)
            {
                lessons_add_deleteTeacher_btn.Enabled = false;
            }

            lessons_add_addTeacher_btn.Enabled = true;

            lessons_add_teachers_panel.Controls.Remove(teacher_txtbx_List[numberOfTeachers - 1]);
            lessons_add_teachers_panel.Controls.Remove(teacher_lbl_List[numberOfTeachers - 1]);

            teacher_txtbx_List.RemoveAt(numberOfTeachers - 1);
            teacher_lbl_List.RemoveAt(numberOfTeachers - 1);

            numberOfTeachers--;
        }

        private void students_delete_deleteStudent_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (students_password_txtbx.Text == currentPassword)
                {
                    StudentModel studentObj = new StudentModel();
                    studentObj.setStudentNumber(Int64.Parse(students_delete_studentNumber_text_lbl.Text));
                    studentObj.deleteStudent(long.Parse(students_delete_lessonNumber_text_lbl.Text), int.Parse(students_delete_lessonGroupNumber_text_lbl.Text));
                }
                else
                {
                    DialogForm dialog = new DialogForm("رمز عبور اشتباه است.", "خطا", "error", this);
                }
            }
            catch (FormatException)
            {
                DialogForm dialog = new DialogForm("فرمت اطلاعات ورودی اشتباه است.", "خطا", "error", this);
            }

            catch (ArgumentNullException)
            {
                DialogForm dialog = new DialogForm("اطلاعات ورودی ناقص هستند.", "خطا", "error", this);
            }

            catch (SqlException e1)
            {
                if (e1.Message.Contains("server"))
                {
                    DialogForm dialog = new DialogForm("ارتباط با سرور برقرار نشد.", "خطای سرور", "error", this);
                }
                else
                {
                    DialogForm dialog = new DialogForm("اطلاعات ورودی تکراری یا اشتباه است.", "خطا", "error", this);
                }
            }
            catch (Exception e1)
            {
                if (e1.Message == "success")
                {
                    students_cancel_btn.PerformClick();
                    studentsDataGridViewUpdate_2();
                    DialogForm dialog = new DialogForm("اطلاعات با موفقیت حذف شدند.", "حذف موفقیت آمیز", "success", this);
                }
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

        private void lessons_add_clear_btn_Click(object sender, EventArgs e)
        {
            lessons_add_lessonNumber_txtbx.Clear();
            lessons_add_lessonGroupNumber_txtbx.Clear();
            lessons_add_lessonName_txtbx.Clear();

            for (int i = numberOfTeachers - 1; i > 0; i--)
            {
                lessons_add_teachers_panel.Controls.Remove(teacher_txtbx_List[i]);
                lessons_add_teachers_panel.Controls.Remove(teacher_lbl_List[i]);

                teacher_txtbx_List.RemoveAt(i);
                teacher_lbl_List.RemoveAt(i);
            }

            numberOfTeachers = 1;

            //***disable deleteTeacher Button
            lessons_add_deleteTeacher_btn.Enabled = false;

            //***clear first teacher textBox
            teacher_txtbx_List[0].Clear();
        }

        private void students_Edit_Delete_ResetComponents()
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
            students_delete_studentNumber_text_lbl.Enabled = false;
            students_delete_lessonNumber_lbl.Enabled = false;
            students_delete_lessonNumber_text_lbl.Enabled = false;
            students_delete_lessonGroupNumber_lbl.Enabled = false;
            students_delete_lessonGroupNumber_text_lbl.Enabled = false;
            students_delete_deleteStudent_btn.Enabled = false;
            //***Clear edit & delete textBoxes
            students_edit_studentNumber_txtbx.Clear();
            students_edit_studentName_txtbx.Clear();
            students_edit_studentFamily_txtbx.Clear();
            students_delete_studentNumber_text_lbl.Text = "";
            students_delete_lessonNumber_text_lbl.Text = "";
            students_delete_lessonGroupNumber_text_lbl.Text = "";
        }

        /// <summary>
        /// newsAgancys
        /// </summary>
        private void isnaNews()
        {
            List<xmlReaderClass> my = new List<xmlReaderClass>();
            var doc = System.Xml.Linq.XDocument.Load("http://isna.ir/rss/tp/38");
            var rssFeed = from el in doc.Elements("rss").Elements("channel").Elements("item")
                          select new xmlReaderClass()
                          {
                              url = el.Element("link").Value,
                              title = el.Element("title").Value,
                              description = el.Element("description").Value,

                          };

            foreach (var i in rssFeed)
            {


                my.Add(i);
            }
            dataGridView4.DataSource = my;
            dataGridView4.Columns[1].Visible = false;
            dataGridView4.Columns[2].Visible = false;
            dataGridView4.Columns[0].HeaderText = "عنوان";
        }

        private void mehrNews()
        {
            List<xmlReaderClass> my = new List<xmlReaderClass>();
            var doc = System.Xml.Linq.XDocument.Load("http://www.mehrnews.com/rss/tp/550");
            var rssFeed = from el in doc.Elements("rss").Elements("channel").Elements("item")
                          select new xmlReaderClass()
                          {
                              url = el.Element("link").Value,
                              title = el.Element("title").Value,
                              description = el.Element("description").Value,

                          };

            foreach (var i in rssFeed)
            {


                my.Add(i);
            }
            dataGridView4.DataSource = my;
            dataGridView4.Columns[1].Visible = false;
            dataGridView4.Columns[2].Visible = false;
            dataGridView4.Columns[0].Name = "عنوان";
        }


        private void yjcNews()
        {
            List<xmlReaderClass> my = new List<xmlReaderClass>();
            var doc = System.Xml.Linq.XDocument.Load(" http://www.yjc.ir/fa/rss/7/57");
            var rssFeed = from el in doc.Elements("rss").Elements("channel").Elements("item")
                          select new xmlReaderClass()
                          {
                              url = el.Element("link").Value,
                              title = el.Element("title").Value,
                              description = el.Element("description").Value,

                          };

            foreach (var i in rssFeed)
            {


                my.Add(i);
            }
            dataGridView4.DataSource = my;
            dataGridView4.Columns[1].Visible = false;
            dataGridView4.Columns[2].Visible = false;
            dataGridView4.Columns[0].Name = "عنوان";
        }

        /********************************************messsaging tab codes*******************/

        private void messaging_outbox_delete_btn_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn2 = new SqlConnection();
                conn2.ConnectionString =
                      "Data Source= 185.159.152.5;" +
                        "Initial Catalog=youshita_Test;" +
                        "User id=youshita_co; " +
                        "Password=P@hn1395;";

                SqlCommand sc = new SqlCommand();
                SqlDataReader reader;
                sc.CommandText = "DELETE FROM messageTable WHERE message# =" + currentNumber + " ";
                sc.CommandType = CommandType.Text;
                sc.Connection = conn2;
                conn2.Open();
                reader = sc.ExecuteReader();
                conn2.Close();
                DialogForm dialog = new DialogForm("پیام با موفقیت حذف شد.", "حذف موفقیت آمیز", "success", this);
                messaging_outbox_delete_btn.Enabled = false;

                ///////////////update Table
                dataGridView7.DataSource = bindingSource7;

                GetData7("SELECT * FROM  messageTable where senderTeacher# = " + currentUserName + " ORDER BY messageDate DESC ");


                dataGridView7.Columns[0].Visible = false;
                dataGridView7.Columns[1].Visible = false;
                dataGridView7.Columns[2].HeaderText = "متن پیام";
                dataGridView7.Columns[3].HeaderText = "شماره درس";
                dataGridView7.Columns[4].Visible = false;
                dataGridView7.Columns[5].HeaderText = "شماره گروه درس";
                dataGridView7.Columns[6].Visible = false;
                dataGridView7.Columns[7].HeaderText = "تاریخ";



                foreach (DataGridViewColumn col in dataGridView7.Columns)
                {
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }

                foreach (DataGridViewRow row in dataGridView7.Rows)
                {
                    //row.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView7.Rows[row.Index].HeaderCell.Value = (row.Index + 1).ToString();
                    //row.HeaderCell.Value = String.Format("{0}", row.Index + 1);
                }

                messaging_outbox_messageShow_txtbx.Text = "";
            }
            catch(SqlException)
            {
                DialogForm dialog = new DialogForm("اشکال در برقراری ارتباط با سرور", "خطا", "error", this);
            }
        }


        private void GetData7(string selectCommand)
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
                DataTable table7 = new DataTable();
                table7.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table7);
                bindingSource7.DataSource = table7;


                // Resize the DataGridView columns to fit the newly loaded content.
                /*   dataGridView7.AutoResizeColumns(
                       DataGridViewAutoSizeColumnsMode.AllCells);
                   dataGridView7.AutoResizeRows(
                      DataGridViewAutoSizeRowsMode.AllCells);*/

            }
            catch (SqlException)
            {
                DialogForm dialog = new DialogForm("اشکال در برقراری ارتباط با سرور", "خطا", "error", this);
            }
        }



        private void GetData6(string selectCommand)
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
                DataTable table6 = new DataTable();
                table6.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table6);
                bindingSource6.DataSource = table6;


                // Resize the DataGridView columns to fit the newly loaded content.
                dataGridView6.AutoResizeColumns(
                    DataGridViewAutoSizeColumnsMode.AllCells);
                dataGridView6.AutoResizeRows(
                   DataGridViewAutoSizeRowsMode.AllCells);

            }
            catch (SqlException)
            {
                DialogForm dialog = new DialogForm("اشکال در برقراری ارتباط با سرور", "خطا", "error", this);
            }
        }

        private void messaging_send_selectLessonNumber_cb_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int lessonGroupLimit = messaging_send_selectGroupLessonNumber_cb.Items.Count;
            messaging_send_selectGroupLessonNumber_cb.Text = "";
            for (int i = 0; i < lessonGroupLimit; i++)
            {
                messaging_send_selectGroupLessonNumber_cb.Items.RemoveAt(0);
            }


            string lessonName = messaging_send_selectLessonNumber_cb.Items[messaging_send_selectLessonNumber_cb.SelectedIndex].ToString();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString =
            "Data Source= 185.159.152.5;" +
                "Initial Catalog=youshita_Test;" +
                "User id=youshita_co; " +
                "Password=P@hn1395;";

            SqlCommand sc1 = new SqlCommand();
            SqlDataReader reader2;
            sc1.Connection = conn;
            conn.Open();

            sc1.CommandText = "SELECT DISTINCT lessonGroup# FROM lessonTable where lessonName = '" + lessonName+ "' AND lessonTeacher# = " + currentUserName + "";


            sc1.CommandType = CommandType.Text;
            reader2 = sc1.ExecuteReader();
            while (reader2.Read())
            {
                //
                Int16 name = reader2.GetInt16(0);

                messaging_send_selectGroupLessonNumber_cb.Items.Add(name);
                //.Insert(" " + reader2.GetString(0) + " " + reader2.GetInt32(1).ToString() + " ");
            }
        }

        private void messaging_inbox_select_btn_Click(object sender, EventArgs e)
        {
            messaging_inbox_messageShow_txtbx.Clear();
            long inbox_lessonNumber = 0;
            SqlConnection conn2 = new SqlConnection();
            conn2.ConnectionString =
                  "Data Source= 185.159.152.5;" +
                    "Initial Catalog=youshita_Test;" +
                    "User id=youshita_co; " +
                    "Password=P@hn1395;";

            SqlCommand sc = new SqlCommand();
            SqlDataReader reader;
            sc.CommandText = "SELECT lesson# FROM lessonTable WHERE lessonName = '" + messaging_inbox_selectLessonNumber_cb.Text + "'";
            sc.CommandType = CommandType.Text;
            sc.Connection = conn2;
            conn2.Open();
            reader = sc.ExecuteReader();
            reader.Read();
            inbox_lessonNumber = reader.GetInt64(0);
            conn2.Close();


            inbox_lessonGroupNumber = messaging_inbox_selectLessonGroupNumber_cb.Text;


            dataGridView6.DataSource = bindingSource6;
            GetData6("select *  from messageTable where messageLesson# = " + inbox_lessonNumber + "AND messageLessonGroup# = " + inbox_lessonGroupNumber + "  ORDER BY messageDate DESC");

            dataGridView6.RowHeadersWidth = (width / 25);
            dataGridView6.Columns[0].Visible = false;
            dataGridView6.Columns[1].HeaderText = "فرستنده";
            dataGridView6.Columns[2].HeaderText = "متن پیام";
            dataGridView6.Columns[3].HeaderText = "شماره درس";
            dataGridView6.Columns[4].Visible = false;
            dataGridView6.Columns[5].HeaderText = "شماره گروه درس";
            dataGridView6.Columns[6].Visible = false;
            dataGridView6.Columns[7].HeaderText = "تاریخ";

            dataGridView6.Columns[2].Width = (width / 5);


            foreach (DataGridViewColumn col in dataGridView6.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }

            foreach (DataGridViewRow roww in dataGridView6.Rows)
            {
                //row.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView6.Rows[roww.Index].HeaderCell.Value = (roww.Index + 1).ToString();
                //row.HeaderCell.Value = String.Format("{0}", row.Index + 1);
            }
        }

        private void dataGridView7_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                messaging_outbox_messageShow_txtbx.Text = dataGridView7.Rows[e.RowIndex].Cells["messageMain"].Value.ToString();
            }
            catch (System.ArgumentOutOfRangeException)
            {
                MessageBox.Show("!بر روی رکورد کلیک کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            currentNumber = dataGridView7.Rows[e.RowIndex].Cells["message#"].Value.ToString();
            messaging_outbox_delete_btn.Enabled = true;
        }


        private void dataGridView6_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                messaging_inbox_messageShow_txtbx.Text = dataGridView6.Rows[e.RowIndex].Cells["messageMain"].Value.ToString();
            }
            catch (System.ArgumentOutOfRangeException)
            {
                MessageBox.Show("!بر روی رکورد کلیک کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void messaging_send_lbl_MouseDown(object sender, MouseEventArgs e)
        {
            messaging_send_lbl.BorderStyle = BorderStyle.Fixed3D;
        }

        private void messaging_send_lbl_MouseUp(object sender, MouseEventArgs e)
        {
            messaging_send_lbl.BorderStyle = BorderStyle.FixedSingle;
        }

        private void messaging_inbox_selectLessonNumber_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            int lessonGroupLimit = messaging_inbox_selectLessonGroupNumber_cb.Items.Count;
            messaging_inbox_selectLessonGroupNumber_cb.Text = "";
            for (int i = 0; i < lessonGroupLimit; i++)
            {
                messaging_inbox_selectLessonGroupNumber_cb.Items.RemoveAt(0);
            }
            

            string lessonName = messaging_inbox_selectLessonNumber_cb.Items[messaging_inbox_selectLessonNumber_cb.SelectedIndex].ToString();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString =
            "Data Source= 185.159.152.5;" +
                "Initial Catalog=youshita_Test;" +
                "User id=youshita_co; " +
                "Password=P@hn1395;";

            SqlCommand sc1 = new SqlCommand();
            SqlDataReader reader2;
            sc1.Connection = conn;
            conn.Open();

            sc1.CommandText = "SELECT DISTINCT lessonGroup# FROM lessonTable where lessonName = '" + lessonName + "' AND lessonTeacher# = " + currentUserName + "";


            sc1.CommandType = CommandType.Text;
            reader2 = sc1.ExecuteReader();
            while (reader2.Read())
            {

                Int16 name = reader2.GetInt16(0);

                messaging_inbox_selectLessonGroupNumber_cb.Items.Add(name);

            }
        }

        private void messaging_send_lbl_Click(object sender, EventArgs e)
        {
            if (messaging_send_rtxt.Text == "")
            {
                DialogForm dialog = new DialogForm("متن پیام را وارد نمایید.", "خطا", "error", this);
            }
            else if (messaging_send_selectLessonNumber_cb.Text == "select" || messaging_send_selectGroupLessonNumber_cb.Text == "")
            {
                DialogForm dialog = new DialogForm("شماره درس یا شماره گروه درس انتخاب نشده است.", "خطا", "error", this);
            }
            else
            {
                try
                {
                    long send_lessonNum = 0;
                    SqlConnection conn2 = new SqlConnection();
                    conn2.ConnectionString =
                          "Data Source= 185.159.152.5;" +
                            "Initial Catalog=youshita_Test;" +
                            "User id=youshita_co; " +
                            "Password=P@hn1395;";

                    SqlCommand sc = new SqlCommand();
                    SqlDataReader reader;
                    sc.CommandText = "SELECT lesson# FROM lessonTable WHERE lessonName = '" + messaging_send_selectLessonNumber_cb.Text + "'";
                    sc.CommandType = CommandType.Text;
                    sc.Connection = conn2;
                    conn2.Open();
                    reader = sc.ExecuteReader();
                    reader.Read();
                    send_lessonNum = reader.GetInt64(0);
                    conn2.Close();


                    MessageModel messageObj = new MessageModel();
                    messageObj.setMessageMain(messaging_send_rtxt.Text);
                    messageObj.setMessageLessonNumber(send_lessonNum);
                    messageObj.setMessageLessonGroupNumber(Int16.Parse(messaging_send_selectGroupLessonNumber_cb.Text));
                    // messageObj.setSenderTeacherNumber(Int16.Parse(senderTeacherNumber));
                    messageObj.setSenderTeacherNumber(currentUserName);
                    messageObj.setMessageRead(0);
                    messageObj.setMessageDate("");
                    messageObj.setMessageNumber(0);
                    messageObj.setMessageTitle("");

                    messageObj.sendMessage();
                    DialogForm dialog = new DialogForm("پیام شما با موفقیت ارسال شد.", "ارسال موفقیت آمیز", "success", this);

                    ///////////////update Table
                    dataGridView7.DataSource = bindingSource7;

                    GetData7("SELECT * FROM  messageTable where senderTeacher# = " + currentUserName + " ORDER BY messageDate DESC ");


                    dataGridView7.Columns[0].Visible = false;
                    dataGridView7.Columns[1].Visible = false;
                    dataGridView7.Columns[2].HeaderText = "متن پیام";
                    dataGridView7.Columns[3].HeaderText = "شماره درس";
                    dataGridView7.Columns[4].Visible = false;
                    dataGridView7.Columns[5].HeaderText = "شماره گروه درس";
                    dataGridView7.Columns[6].Visible = false;
                    dataGridView7.Columns[7].HeaderText = "تاریخ";

                    /*  dataGridView7.Columns[2].Width = (width / 3);
                      dataGridView7.Columns[3].Width = (width /20);
                      dataGridView7.Columns[5].Width = (width / 20);
                      dataGridView7.Columns[7].Width = (width / 10);*/

                    foreach (DataGridViewColumn col in dataGridView7.Columns)
                    {
                        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    }

                    foreach (DataGridViewRow row in dataGridView7.Rows)
                    {
                        //row.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView7.Rows[row.Index].HeaderCell.Value = (row.Index + 1).ToString();
                        //row.HeaderCell.Value = String.Format("{0}", row.Index + 1);
                    }

                    ///////////////////clear////////////

                    messaging_send_rtxt.Clear();
                }
                catch (SqlException)
                {
                    DialogForm dialog = new DialogForm("اشکال در برقراری ارتباط با سرور", "خطا", "error", this);
                }
            }
        }
        /********************************************messsaging tab codes*******************/

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (dashboard_news_cob.SelectedIndex == 0)
                {
                    isnaNews();
                    dataGridView4.Columns[0].HeaderText = "عنوان";
                }
                if (dashboard_news_cob.SelectedIndex == 1)
                {
                    mehrNews();
                    dataGridView4.Columns[0].HeaderText = "عنوان";
                }
                if (dashboard_news_cob.SelectedIndex == 2)
                {
                    yjcNews();
                    dataGridView4.Columns[0].HeaderText = "عنوان";
                }
            }
            catch (System.Net.WebException)
            {
                DialogForm dialog = new DialogForm("اشکال در برقراری ارتباط با سرور", "خطا", "error", this);
            }
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dashboard_news_descriptions_lbl.Text = dataGridView4.Rows[e.RowIndex].Cells["description"].Value.ToString();
                dataGridView4.Columns[0].HeaderText = "عنوان";
            }
            catch (ArgumentOutOfRangeException)
            {

            }
        }

        private void dataGridView4_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ProcessStartInfo sInfo = new ProcessStartInfo(dataGridView4.Rows[e.RowIndex].Cells["url"].Value.ToString());
                Process.Start(sInfo);
            }
            catch (ArgumentOutOfRangeException)
            {

            }
        }

        private void lessons_edit_teacherNumber_lbl_Click(object sender, EventArgs e)
        {
            lessons_edit_teacherNumber_lbl.Font = new Font("B Yekan+", 9, FontStyle.Regular);
            lessons_edit_teacherNumber_lbl.Text = "شماره استاد";
            lessons_edit_teacherNumber_txtbx.Visible = true;
            lessons_edit_teacherNumber_lbl.ForeColor = Color.Black;
        }

        private void lessons_edit_teacherNumber_lbl_MouseEnter(object sender, EventArgs e)
        {
            if (lessons_edit_teacherNumber_lbl.Text.Contains("+"))
            {
                lessons_edit_teacherNumber_lbl.ForeColor = Color.Blue;
                lessons_edit_teacherNumber_lbl.Font = new Font("B Yekan+", 10, FontStyle.Regular);
            }
        }

        private void lessons_edit_teacherNumber_lbl_MouseLeave(object sender, EventArgs e)
        {
            if (lessons_edit_teacherNumber_lbl.Text.Contains("+"))
            {
                lessons_edit_teacherNumber_lbl.ForeColor = Color.Black;
                lessons_edit_teacherNumber_lbl.Font = new Font("B Yekan+", 9, FontStyle.Regular);
            }
        }

        private void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //***This "if" statement determines the dataGridView's dataSource then decides what should happen there.
            if (dataGridView3.Columns[0].HeaderText == "شماره درس" && dataGridView3.ColumnCount != 4)
            {
                //***enable return button
                lessons_return_btn.Enabled = true;

                //***disable add components
                lessons_addLesson_gpb.Enabled = false;

                //***enable edit components
                lessons_editLesson_gpb.Enabled = true;

                //***enable password components
                lessons_showPassword_pictureBox.Visible = true;
                lessons_password_txtbx.Visible = true;
                lessons_password_lbl.Enabled = true;
                lessons_passwordInfo_lbl.Visible = true;

                try
                {
                    currentLessonNumber = dataGridView3.Rows[e.RowIndex].Cells["lesson#"].Value.ToString();
                    currentLessonGroupNumber = dataGridView3.Rows[e.RowIndex].Cells["lessonGroup#"].Value.ToString();


                    //***fill edit textBoxes
                    lessons_edit_lessonNumber_txtbx.Text = currentLessonNumber;
                    lessons_edit_lessonGroupNumber_txtbx.Text = currentLessonGroupNumber;
                    lessons_edit_lessonName_txtbx.Text = dataGridView3.Rows[e.RowIndex].Cells["lessonName"].Value.ToString();

                    //***enable delete lesson button
                    lessons_edit_deleteLesson_btn.Enabled = true;

                    lessonsDataGridViewUpdate_2();
                }
                catch (System.ArgumentOutOfRangeException)
                {

                }
            }

            else if (dataGridView3.ColumnCount == 4)
            {
                //***enable edit & delete components
                lessonsTab_enable_edit_delete_components();

                //***enable cancel button
                lessons_cancel_btn.Enabled = true;

                //***enable password components
                lessons_showPassword_pictureBox.Visible = true;
                lessons_password_txtbx.Visible = true;
                lessons_password_lbl.Enabled = true;
                lessons_passwordInfo_lbl.Visible = true;

                try
                {
                    currentNumber = dataGridView3.Rows[e.RowIndex].Cells["lessonTeacher#"].Value.ToString();
                    currentLessonNumber = dataGridView3.Rows[e.RowIndex].Cells["lesson#"].Value.ToString();
                    currentLessonGroupNumber = dataGridView3.Rows[e.RowIndex].Cells["lessonGroup#"].Value.ToString();

                    //***fill delete textBoxes
                    lessons_edit_lessonNumber_txtbx.Text = currentLessonNumber;
                    lessons_edit_lessonGroupNumber_txtbx.Text = currentLessonGroupNumber;
                    lessons_edit_lessonName_txtbx.Text = dataGridView3.Rows[e.RowIndex].Cells["lessonName"].Value.ToString();
                    lessons_delete_lessonNumber_text_lbl.Text = currentLessonNumber;
                    lessons_delete_lessonGroupNumber_text_lbl.Text = currentLessonGroupNumber;
                    lessons_delete_lessonName_text_lbl.Text = dataGridView3.Rows[e.RowIndex].Cells["lessonName"].Value.ToString();
                    lessons_delete_teacherNumber_text_lbl.Text = dataGridView3.Rows[e.RowIndex].Cells["lessonTeacher#"].Value.ToString();
                }
                catch (System.ArgumentOutOfRangeException)
                {

                }
            }
        }

        private void lessons_return_btn_Click(object sender, EventArgs e)
        {
            //***enable add components
            lessonsTab_enable_add_components();

            //***disable edit & delete component
            lessonsTab_disable_edit_delete_components();

            //***disable return & cancel Buttons
            lessons_return_btn.Enabled = false;
            lessons_cancel_btn.Enabled = false;

            //***disable password components
            lessons_showPassword_pictureBox.Visible = false;
            lessons_password_txtbx.Clear();
            lessons_password_txtbx.Visible = false;
            lessons_password_lbl.Enabled = false;
            lessons_passwordInfo_lbl.Visible = false;

            lessonsDataGridViewUpdate_1();
        }

        private void lessons_cancel_btn_Click(object sender, EventArgs e)
        {
            lessonsTab_disable_edit_delete_components();
            lessons_cancel_btn.Enabled = false;

            //***disable password components
            lessons_showPassword_pictureBox.Visible = false;
            lessons_password_txtbx.Clear();
            lessons_password_txtbx.Visible = false;
            lessons_password_lbl.Enabled = false;
            lessons_passwordInfo_lbl.Visible = false;
        }

        private void lessons_edit_deleteLesson_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (lessons_password_txtbx.Text == currentPassword)
                {
                    LessonModel lessonObj = new LessonModel();
                    lessonObj.setLessonNumber(long.Parse(currentLessonNumber));
                    lessonObj.setLessonGroupNumber(int.Parse(currentLessonGroupNumber));
                    lessonObj.deleteLesson();
                }
                else
                {
                    DialogForm dialog = new DialogForm("رمز عبور اشتباه است.", "خطا", "error", this);
                }
            }
            catch (FormatException)
            {
                DialogForm dialog = new DialogForm("فرمت اطلاعات ورودی اشتباه است.", "خطا", "error", this);
            }

            catch (ArgumentNullException)
            {
                DialogForm dialog = new DialogForm("اطلاعات ورودی ناقص هستند.", "خطا", "error", this);
            }

            catch (SqlException e1)
            {
                if (e1.Message.Contains("server"))
                {
                    DialogForm dialog = new DialogForm("ارتباط با سرور برقرار نشد.", "خطای سرور", "error", this);
                }
                else
                {
                    DialogForm dialog = new DialogForm("اطلاعات ورودی تکراری یا اشتباه است.", "خطا", "error", this);
                }
            }
            catch (Exception e1)
            {
                if (e1.Message == "success")
                {
                    students_return_btn.PerformClick();
                    DialogForm dialog = new DialogForm("اطلاعات با موفقیت حذف شدند.", "حذف موفقیت آمیز", "success", this);
                }
            }
        }

        private void lessons_edit_editLesson_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (lessons_password_txtbx.Text == currentPassword)
                {
                    LessonModel lessonObj = new LessonModel();
                    lessonObj.setLessonNumber(long.Parse(currentLessonNumber));
                    lessonObj.setLessonGroupNumber(int.Parse(currentLessonGroupNumber));
                    lessonObj.setNewLessonNumber(long.Parse(lessons_edit_lessonNumber_txtbx.Text));
                    lessonObj.setNewLessonGroupNumber(int.Parse(lessons_edit_lessonGroupNumber_txtbx.Text));
                    lessonObj.setLessonName(lessons_edit_lessonName_txtbx.Text);
                    currentLessonNumber = lessons_edit_lessonNumber_txtbx.Text;
                    currentLessonGroupNumber = lessons_edit_lessonGroupNumber_txtbx.Text;
                    if (lessons_edit_teacherNumber_txtbx.Text != "")
                    {
                        lessonObj.setLessonTeacherNumber(long.Parse(lessons_edit_teacherNumber_txtbx.Text));
                        lessonObj.addLesson();
                    }
                    lessonObj.updateLesson();
                }
                else
                {
                    DialogForm dialog = new DialogForm("رمز عبور اشتباه است.", "خطا", "error", this);
                }

            }
            catch (FormatException)
            {
                DialogForm dialog = new DialogForm("فرمت اطلاعات ورودی اشتباه است.", "خطا", "error", this);
            }

            catch (ArgumentNullException)
            {
                DialogForm dialog = new DialogForm("اطلاعات ورودی ناقص هستند.", "خطا", "error", this);
            }

            catch (SqlException e1)
            {
                if (e1.Message.Contains("server"))
                {
                    DialogForm dialog = new DialogForm("ارتباط با سرور برقرار نشد.", "خطای سرور", "error", this);
                }
                else
                {
                    DialogForm dialog = new DialogForm("اطلاعات ورودی تکراری یا اشتباه است.", "خطا", "error", this);
                }
            }

            catch (Exception e1)
            {
                if (e1.Message == "success")
                {
                    lessons_return_btn.PerformClick();
                    lessonsDataGridViewUpdate_2();
                    lessons_return_btn.Enabled = true;
                    DialogForm dialog = new DialogForm("اطلاعات ورودی با موفقیت ثبت شدند.", "ثبت موفقیت آمیز", "success", this);
                }
            }
        }

        private void lessons_edit_clear_btn_Click(object sender, EventArgs e)
        {
            lessons_edit_lessonNumber_txtbx.Clear();
            lessons_edit_lessonGroupNumber_txtbx.Clear();
            lessons_edit_lessonName_txtbx.Clear();
            lessons_edit_teacherNumber_lbl.Text = "+افزودن استاد";
            lessons_edit_teacherNumber_txtbx.Clear();
            lessons_edit_teacherNumber_txtbx.Visible = false;
        }


        private void lessonsTab_disableAddComponents()
        {
            lessons_addLesson_gpb.Enabled = false;

            lessons_add_lessonNumber_txtbx.Clear();
            lessons_add_lessonGroupNumber_txtbx.Clear();
            lessons_add_lessonName_txtbx.Clear();

            for (int i = numberOfTeachers - 1; i > 0; i--)
            {
                lessons_add_teachers_panel.Controls.Remove(teacher_txtbx_List[i]);
                lessons_add_teachers_panel.Controls.Remove(teacher_lbl_List[i]);

                teacher_txtbx_List.RemoveAt(i);
                teacher_lbl_List.RemoveAt(i);
            }

            numberOfTeachers = 1;

            //***disable deleteTeacher Button
            lessons_add_deleteTeacher_btn.Enabled = false;

            //***clear first teacher textBox
            teacher_txtbx_List[0].Clear();
        }

        private void lessonsTab_disable_edit_delete_components()
        {
            //***disable edit
            lessons_editLesson_gpb.Enabled = false;

            lessons_edit_lessonNumber_txtbx.Clear();
            lessons_edit_lessonGroupNumber_txtbx.Clear();
            lessons_edit_lessonName_txtbx.Clear();
            lessons_edit_teacherNumber_lbl.Text = "+افزودن استاد";
            lessons_edit_teacherNumber_txtbx.Clear();
            lessons_edit_teacherNumber_txtbx.Visible = false;

            //***disable delete
            lessons_deleteTeacher_gpb.Enabled = false;
            lessons_delete_lessonName_text_lbl.Text = "";
            lessons_delete_lessonGroupNumber_text_lbl.Text = "";
            lessons_delete_lessonNumber_text_lbl.Text = "";
            lessons_delete_teacherNumber_text_lbl.Text = "";
        }

        private void lessonsTab_enable_edit_delete_components()
        {
            lessons_editLesson_gpb.Enabled = true;
            lessons_deleteTeacher_gpb.Enabled = true;
        }

        private void lessonsTab_enable_add_components()
        {
            lessons_addLesson_gpb.Enabled = true;
        }

        private void lessons_delete_deleteTeacher_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (lessons_password_txtbx.Text == currentPassword)
                {
                    LessonModel lessonObj = new LessonModel();
                    lessonObj.setLessonNumber(long.Parse(currentLessonNumber));
                    lessonObj.setLessonGroupNumber(int.Parse(currentLessonGroupNumber));
                    lessonObj.setLessonTeacherNumber(long.Parse(currentNumber));
                    lessonObj.deleteLessonTeacher();
                }
                else
                {
                    DialogForm dialog = new DialogForm("رمز عبور اشتباه است.", "خطا", "error", this);
                }
            }
            catch (FormatException)
            {
                DialogForm dialog = new DialogForm("فرمت اطلاعات ورودی اشتباه است.", "خطا", "error", this);
            }

            catch (ArgumentNullException)
            {
                DialogForm dialog = new DialogForm("اطلاعات ورودی ناقص هستند.", "خطا", "error", this);
            }

            catch (SqlException e1)
            {
                if (e1.Message.Contains("server"))
                {
                    DialogForm dialog = new DialogForm("ارتباط با سرور برقرار نشد.", "خطای سرور", "error", this);
                }
                else
                {
                    DialogForm dialog = new DialogForm("اطلاعات ورودی تکراری یا اشتباه است.", "خطا", "error", this);
                }
            }
            catch (Exception e1)
            {
                if (e1.Message == "success")
                {
                    lessons_cancel_btn.PerformClick();
                    lessonsDataGridViewUpdate_2();
                    DialogForm dialog = new DialogForm("اطلاعات با موفقیت حذف شدند.", "حذف موفقیت آمیز", "success", this);
                }
            }
        }

        private void lessons_edit_lessonNumber_txtbx_TextChanged(object sender, EventArgs e)
        {
            lessons_edit_deleteLesson_btn.Enabled = false;
        }

        private void lessons_edit_lessonGroupNumber_txtbx_TextChanged(object sender, EventArgs e)
        {
            lessons_edit_deleteLesson_btn.Enabled = false;
        }

        private void lessons_edit_lessonName_txtbx_TextChanged(object sender, EventArgs e)
        {
            lessons_edit_deleteLesson_btn.Enabled = false;
        }

        private void bindingSource5_CurrentChanged(object sender, EventArgs e)
        {

            // The desired page has changed, so fetch the page of records using the "Current" offset 
            int offset = (int)bindingSource5.Current;
            var records = new List<logModel>();
            for (int i = offset; i < offset + pageSize && i < totalRecords; i++)
                records.Add(new logModel { logTitle = s[i, 0], logMain = s[i, 1], logDate = s[i, 2], logMode = s[i, 4], logUser = long.Parse(s[i, 3]) });
            dataGridView5.DataSource = records;

        }

        private void setting_changeInfo_clear_btn_Click(object sender, EventArgs e)
        {
            setting_changeInfo_managerName_txtbx.Clear();
            setting_changeInfo_managerFamily_txtbx.Clear();
            setting_changeInfo_managerPass_txtbx.Clear();
            setting_changeInfo_managerNewPass_txtbx.Clear();
        }


        private void setting_changeInfo_change_btn_Click(object sender, EventArgs e)
        {
            if (setting_changeInfo_managerName_txtbx.Text != "" && setting_changeInfo_managerFamily_txtbx.Text != "" && setting_changeInfo_managerPass_txtbx.Text != "" && setting_changeInfo_managerNewPass_txtbx.Text != "")
            {
                if(setting_changeInfo_managerName_txtbx.Text.Any(char.IsDigit) || setting_changeInfo_managerFamily_txtbx.Text.Any(char.IsDigit) ||
                   setting_changeInfo_managerName_txtbx.Text.Any(char.IsPunctuation) || setting_changeInfo_managerFamily_txtbx.Text.Any(char.IsPunctuation) ||
                   setting_changeInfo_managerName_txtbx.Text.Any(char.IsSymbol) || setting_changeInfo_managerFamily_txtbx.Text.Any(char.IsSymbol) )
                {
                       DialogForm dialog = new DialogForm("فرمت اطلاعات ورودی اشتباه است.", "خطا", "error", this);
                }

                else if(currentPassword.Equals(setting_changeInfo_managerPass_txtbx.Text))
                {
                    try
                    {
                        if(managerUsername != -2)
                        {
                            SqlConnection conn2 = new SqlConnection();
                            conn2.ConnectionString =
                                  "Data Source= 185.159.152.5;" +
                                    "Initial Catalog=youshita_Test;" +
                                    "User id=youshita_co; " +
                                    "Password=P@hn1395;";

                            SqlCommand sc = new SqlCommand();
                            SqlDataReader reader;
                            sc.CommandText = "UPDATE managerTable SET  managerFName='" + setting_changeInfo_managerName_txtbx.Text + "', " +
                                                                      "managerLName='" + setting_changeInfo_managerFamily_txtbx.Text + "'," +
                                                                      "managerPassword='" + hashPass(setting_changeInfo_managerNewPass_txtbx.Text) + "'  WHERE manager# = " + managerUsername + "";
                            sc.CommandType = CommandType.Text;
                            sc.Connection = conn2;
                            conn2.Open();
                            reader = sc.ExecuteReader();
                            conn2.Close();
                        }
                        

                        SqlConnection conn = new SqlConnection();
                        conn.ConnectionString =
                              "Data Source= 185.159.152.5;" +
                                "Initial Catalog=youshita_Test;" +
                                "User id=youshita_co; " +
                                "Password=P@hn1395;";

                        SqlCommand sc1 = new SqlCommand();
                        SqlDataReader reader1;
                        sc1.CommandText = "UPDATE teacherTable SET  teacherFName='" + setting_changeInfo_managerName_txtbx.Text + "', " +
                                                                  "teacherLName='" + setting_changeInfo_managerFamily_txtbx.Text + "'," +
                                                                  "teacherPassword='" + hashPass(setting_changeInfo_managerNewPass_txtbx.Text) + "'  WHERE teacher# = " + currentUserName + "";
                        sc1.CommandType = CommandType.Text;
                        sc1.Connection = conn;
                        conn.Open();
                        reader1 = sc1.ExecuteReader();
                        conn.Close();

                        currentPassword = setting_changeInfo_managerNewPass_txtbx.Text;
                        setting_changeInfo_managerPass_txtbx.Clear();
                        setting_changeInfo_managerNewPass_txtbx.Clear();
                        DialogForm dialog = new DialogForm("گذر واژه شما با موفقیت تغییر یافت.", "تغییر موفقیت آمیز", "success", this);
                    }

                    catch (FormatException)
                    {
                        DialogForm dialog = new DialogForm("فرمت اطلاعات ورودی اشتباه است.", "خطا", "error", this);
                    }

                    catch (ArgumentNullException)
                    {
                        DialogForm dialog = new DialogForm("اطلاعات ورودی ناقص هستند.", "خطا", "error", this);
                    }

                    catch (SqlException e1)
                    {
                        if (e1.Message.Contains("server"))
                        {
                            DialogForm dialog = new DialogForm("ارتباط با سرور برقرار نشد.", "خطای سرور", "error", this);
                        }
                        else
                        {
                            DialogForm dialog = new DialogForm("اطلاعات ورودی تکراری یا اشتباه است.", "خطا", "error", this);
                        }
                    }
                }
                else
                {
                    DialogForm dialog = new DialogForm("گذرواژه اشتباه است.", "خطا", "error", this);
                }
            }
            else
            {
                DialogForm dialog = new DialogForm("اطلاعات ورودی کامل نیست.", "خطا", "error", this);
            }
        }

        private void setting_changeInfo_showPass_pic_MouseDown(object sender, MouseEventArgs e)
        {
            setting_changeInfo_managerPass_txtbx.PasswordChar = '\0';
            setting_changeInfo_showPass_pic.BorderStyle = BorderStyle.FixedSingle;
        }

        private void setting_changeInfo_showPass_pic_MouseUp(object sender, MouseEventArgs e)
        {
            setting_changeInfo_managerPass_txtbx.PasswordChar = '●';
            setting_changeInfo_showPass_pic.BorderStyle = BorderStyle.None;
        }

        private void setting_changeInfo_showNewPass_pic_MouseDown(object sender, MouseEventArgs e)
        {
            setting_changeInfo_managerNewPass_txtbx.PasswordChar = '\0';
            setting_changeInfo_showNewPass_pic.BorderStyle = BorderStyle.FixedSingle;
        }

        private void setting_changeInfo_showNewPass_pic_MouseUp(object sender, MouseEventArgs e)
        {
            setting_changeInfo_managerNewPass_txtbx.PasswordChar = '●';
            setting_changeInfo_showNewPass_pic.BorderStyle = BorderStyle.None;
        }

        private void teachersDataGridViewUpdate_1()
        {
            try
            {
                /// <summary>
                /// datagridview reintialization
                /// </summary>
                dataGridView1.DataSource = bindingSource1;
                GetData("SELECT * FROM teacherTable");

                //***change mode of columns to Fill
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.RowHeadersWidth = (width / 25);
                dataGridView1.Columns[0].HeaderText = "شماره استاد";
                dataGridView1.Columns[1].HeaderText = "نام استاد";
                dataGridView1.Columns[2].HeaderText = "نام خانوادگی استاد";
                dataGridView1.Columns[3].HeaderText = "رمز عبور";
                dataGridView1.Columns[4].HeaderText = "آدرس اینترنتی";
                dataGridView1.Columns[4].Width = (width / 5);

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value.ToString() == "-1")
                    {
                        dataGridView1.Rows.Remove(row);
                    }
                }

                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    dataGridView1.Rows[row.Index].HeaderCell.Value = (row.Index + 1).ToString();
                }
                /// <summary>
                /// datagridview reintialization
                /// </summary>
            }
            catch (ArgumentOutOfRangeException)
            {
                //DialogForm dialog = new DialogForm("اشکال در ارتباط با پایگاه داده", "خطا", "error", this);
            }
        }

        private void studentsDataGridViewUpdate_1()
        {
            try
            {
                /// <summary>
                /// datagridview intialization
                /// </summary>
                dataGridView2.DataSource = bindingSource2;
                GetData2("SELECT DISTINCT lesson# , lessonGroup# ,lessonName FROM lessonTable");

                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView2.RowHeadersWidth = (width / 25);
                dataGridView2.Columns[0].HeaderText = "شماره درس";
                dataGridView2.Columns[1].HeaderText = "شماره گروه ";
                dataGridView2.Columns[2].HeaderText = "عنوان درس";
                dataGridView2.Columns[2].Width = (width / 3);

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
            }
            catch (ArgumentOutOfRangeException)
            {
                
            }
        }



        private void studentsDataGridViewUpdate_2()
        {
            try
            {
                /// <summary>
                /// Reset dataGridView to the desired class
                /// </summary>
                GetData2("SELECT * FROM [dbo].[" + currentLessonNumber + "-" + currentLessonGroupNumber + "_Table]");

                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView2.RowHeadersWidth = (width / 25);
                dataGridView2.Columns[0].HeaderText = "شماره دانشجویی";
                dataGridView2.Columns[1].HeaderText = "نام دانشجو";
                dataGridView2.Columns[2].HeaderText = "نام خانوادگی دانشجو";
                dataGridView2.Columns[2].Width = (width / 3);

                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    foreach (DataGridViewColumn col in dataGridView2.Columns)
                    {
                        if (row.Cells[col.Index].Value.ToString() == "1")
                        {
                            if (col.Index > 2)
                            {
                                row.Cells[col.Index].Value = "✓";
                                row.Cells[col.Index].Style.ForeColor = Color.Blue;
                            }
                        }
                        else if (row.Cells[col.Index].Value.ToString() == "0")
                        {
                            if (col.Index > 2)
                            {
                                row.Cells[col.Index].Value = "×";
                                row.Cells[col.Index].Style.ForeColor = Color.Red;
                            }
                        }
                    }
                }

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
                students_export_excel_btn.Enabled = true;
            }
            catch (ArgumentOutOfRangeException)
            {
                //DialogForm dialog = new DialogForm("اشکال در ارتباط با پایگاه داده", "خطا", "error", this);
            }
        }

        private void lessonsDataGridViewUpdate_1()
        {
            try
            {
                /// <summary>
                /// datagridview intialization
                /// </summary>
                dataGridView3.DataSource = bindingSource3;
                GetData3("SELECT DISTINCT lesson# , lessonGroup# ,lessonName FROM lessonTable");

                dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView3.RowHeadersWidth = (width / 25);
                dataGridView3.Columns[0].HeaderText = "شماره درس";
                dataGridView3.Columns[1].HeaderText = "شماره گروه";
                dataGridView3.Columns[2].HeaderText = "عنوان درس";
                dataGridView3.Columns[2].Width = (width / 3);


                foreach (DataGridViewColumn col in dataGridView3.Columns)
                {
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }

                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    dataGridView3.Rows[row.Index].HeaderCell.Value = (row.Index + 1).ToString();
                }
                /// <summary>
                /// datagridview intialization
                /// </summary>
            }
            catch (ArgumentOutOfRangeException)
            {
                //DialogForm dialog = new DialogForm("اشکال در ارتباط با پایگاه داده", "خطا", "error", this);
            }
        }

        private void lessonsDataGridViewUpdate_2()
        {
            try
            {
                /// <summary>
                /// Reset dataGridView to the desired class
                /// </summary>
                GetData3("SELECT * FROM lessonTable WHERE lesson# = " + currentLessonNumber + "AND lessonGroup# = " + currentLessonGroupNumber);

                //***change mode of columns to Fill
                dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView3.Columns[0].HeaderText = "شماره درس";
                dataGridView3.Columns[2].HeaderText = "شماره گروه";
                dataGridView3.Columns[1].HeaderText = "نام درس";
                dataGridView3.Columns[3].HeaderText = "شماره استاد";
                dataGridView3.Columns[3].Width = (width / 3);

                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    if (row.Cells[3].Value.ToString() == "-1")
                    {
                        dataGridView3.Rows.Remove(row);
                    }
                }
                foreach (DataGridViewColumn col in dataGridView3.Columns)
                {
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    dataGridView3.Rows[row.Index].HeaderCell.Value = (row.Index + 1).ToString();
                }
                /// <summary>
                /// Reset dataGridView to the desired class
                /// </summary>
            }
            catch (ArgumentOutOfRangeException)
            {
                //DialogForm dialog = new DialogForm("اشکال در ارتباط با پایگاه داده", "خطا", "error", this);
            }
        }

        private void addTeacher_resetComponents()
        {
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
        }

        private void edit_Delete_Teacher_resetComponents()
        {
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
            teachers_delete_teacherNumber_text_lbl.Enabled = false;
            teachers_deleteTeacher_btn.Enabled = false;
            //***clear textBoxes
            teachers_edit_teacherNumber_txtbx.Clear();
            teachers_edit_teacherName_txtbx.Clear();
            teachers_edit_teacherFamily_txtbx.Clear();
            teachers_edit_teacher_password_txtbx.Clear();
            teachers_delete_teacherNumber_text_lbl.Text = "";
            /// <summary>
            /// Reset GroupBoxes and their components
            /// </summary>
        }

        private void ManagerForm1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void lessons_showPassword_pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            lessons_password_txtbx.PasswordChar = '\0';
            lessons_showPassword_pictureBox.BorderStyle = BorderStyle.FixedSingle;
        }

        private void lessons_showPassword_pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            lessons_password_txtbx.PasswordChar = '●';
            lessons_showPassword_pictureBox.BorderStyle = BorderStyle.None;
        }

        private void students_showPassword_pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            students_password_txtbx.PasswordChar = '\0';
            students_showPassword_pictureBox.BorderStyle = BorderStyle.FixedSingle;
        }

        private void students_showPassword_pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            students_password_txtbx.PasswordChar = '●';
            students_showPassword_pictureBox.BorderStyle = BorderStyle.None;
        }

        private void teachers_showPassword_pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            teachers_password_txtbx.PasswordChar = '\0';
            teachers_showPassword_pictureBox.BorderStyle = BorderStyle.FixedSingle;
        }

        private void teachers_showPassword_pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            teachers_password_txtbx.PasswordChar = '●';
            teachers_showPassword_pictureBox.BorderStyle = BorderStyle.None;
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
                DialogForm dialog = new DialogForm("مشکل در ارتباط با سرور یا پایگاه داده", "خطا", "error", this);
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
                DialogForm dialog = new DialogForm("مشکل در ارتباط با سرور یا پایگاه داده", "خطا", "error", this);
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
                DataTable table3 = new DataTable();
                table3.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table3);
                bindingSource3.DataSource = table3;


                // Resize the DataGridView columns to fit the newly loaded content.
                dataGridView3.AutoResizeColumns(
                    DataGridViewAutoSizeColumnsMode.AllCells);
                dataGridView3.AutoResizeRows(
                   DataGridViewAutoSizeRowsMode.AllCells);

            }
            catch (SqlException)
            {
                DialogForm dialog = new DialogForm("مشکل در ارتباط با سرور یا پایگاه داده", "خطا", "error", this);
            }
        }

        public string hashPass(string password2)
        {
            string password = password2;

            // byte array representation of that string
            byte[] encodedPassword = new UTF8Encoding().GetBytes(password);

            // need MD5 to calculate the hash
            byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);

            // string representation (similar to UNIX format)
            string encoded = BitConverter.ToString(hash)
               // without dashes
               .Replace("0", string.Empty).Replace("-", string.Empty)
               // make lowercase
               .ToLower();

            return encoded;
        }

        class xmlReaderClass
        {
            public string title { get; set; }
            public string url { get; set; }
            public string description { get; set; }
        }

        class logModel
        {
            public string logTitle { get; set; }
            public string logMain { get; set; }
            public string logDate { get; set; }
            public long logUser { get; set; }
            public string logMode { get; set; }

        }

        class PageOffsetList : System.ComponentModel.IListSource
        {
            public bool ContainsListCollection { get; protected set; }
            private int totalRecords;
            public System.Collections.IList GetList()
            {

                SqlConnection conn2 = new SqlConnection();
                conn2.ConnectionString =
                      "Data Source= 185.159.152.5;" +
                        "Initial Catalog=youshita_Test;" +
                        "User id=youshita_co; " +
                        "Password=P@hn1395;";

                SqlCommand sc = new SqlCommand();
                SqlDataReader reader;
                sc.CommandText = "SELECT COUNT(*) AS NumberOfLogs FROM logTable ";
                sc.CommandType = CommandType.Text;
                sc.Connection = conn2;
                conn2.Open();
                reader = sc.ExecuteReader();

                reader.Read();
                totalRecords = int.Parse((reader["NumberOfLogs"].ToString()));
                conn2.Close();


                // Return a list of page offsets based on "totalRecords" and "pageSize"
                var pageOffsets = new List<int>();
                for (int offset = 0; offset < totalRecords; offset += pageSize)
                    pageOffsets.Add(offset);
                return pageOffsets;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // creating Excel Application
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();

                // creating new WorkBook within Excel application
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);

                // see the excel sheet behind the program
                app.Visible = true;

                // creating new Excelsheet in workbook
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

                // get the reference of first sheet. By default its name is Sheet1.
                // store its reference to worksheet
                worksheet = workbook.Sheets["Sheet1"];
                worksheet = workbook.ActiveSheet;
                worksheet.DisplayRightToLeft = true;

                // changing the name of active sheet
                worksheet.Name = currentLessonNumber + "-" + currentLessonGroupNumber;

                // storing header part in Excel
                for (int i = 1; i < dataGridView2.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = dataGridView2.Columns[i - 1].HeaderText;
                }

                // storing Each row and column value to excel sheet
                for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dataGridView2.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dataGridView2.Rows[i].Cells[j].Value.ToString();
                        //worksheet.Cells[i + 2, j + 1].w
                    }
                }
                
                // save the application
                workbook.SaveAs("d:\\123.xlsx", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                // Exit from the application
                app.Quit();
            }
            catch(System.Runtime.InteropServices.COMException)
            {
                DialogForm dialog = new DialogForm("اشکال در باز کردن فایل ورودی", "خطا", "error", this);
            }
        }

        private void attendance_register_btn_Click(object sender, EventArgs e)
        {
            StudentModel studentObj = new StudentModel();
            Attendance attendanceObj = new Attendance();
            attendanceObj.setLessonNumber(10);
            attendanceObj.setLessonGroupNumber(1);

            foreach (DataGridViewRow row in dataGridView8.Rows)
            {
                string stNum = row.Cells[0].Value.ToString();



                attendanceObj.attend(attendance_date_dp.Text + "\n" + attendance_hour_cb.Text + ":" + attendance_minute_cb.Text + "", row.Cells[3].Value.ToString(), long.Parse(stNum));
            }


        }

        private void attendance_attend_btn_Click(object sender, EventArgs e)
        {
            Attendance attendanceObj = new Attendance();

            long inbox_lessonNumber = 0;
            SqlConnection conn2 = new SqlConnection();
            conn2.ConnectionString =
                  "Data Source= 185.159.152.5;" +
                    "Initial Catalog=youshita_Test;" +
                    "User id=youshita_co; " +
                    "Password=P@hn1395;";

            SqlCommand sc = new SqlCommand();
            SqlDataReader reader;
            sc.CommandText = "SELECT lesson# FROM lessonTable WHERE lessonName = '" + attendance_lessonNumber_cb.Text + "'";
            sc.CommandType = CommandType.Text;
            sc.Connection = conn2;
            conn2.Open();
            reader = sc.ExecuteReader();
            reader.Read();
            attendanceObj.setLessonNumber(reader.GetInt64(0));
            conn2.Close();

            DataGridViewCheckBoxColumn myCheckedColumn = new DataGridViewCheckBoxColumn()
            {
                Name = attendance_date_dp.Text + "\n" + attendance_hour_cb.Text + ":" + attendance_minute_cb.Text + "",
                FalseValue = "0",
                TrueValue = "1",
                Visible = true
            };


            attendanceObj.setLessonGroupNumber(short.Parse(attendance_lessonGroupNumber_cb.Text));
            attendanceObj.attendanceLesson(myCheckedColumn.Name, currentUserName);
            dataGridView8.Columns.Insert(3, myCheckedColumn); ///catch invalid operation
            foreach (DataGridViewRow row in dataGridView8.Rows)
            {
                row.Cells[myCheckedColumn.Name].Value = "0";
            }
            dataGridView8.Columns[3].Frozen = true;


        }




        private void attendance_lessonNumber_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < attendance_lessonGroupNumber_cb.Items.Count; i++)
            {
                attendance_lessonGroupNumber_cb.Items.RemoveAt(i);
            }
            string lessonNum = attendance_lessonNumber_cb.Items[attendance_lessonNumber_cb.SelectedIndex].ToString();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString =
            "Data Source= 185.159.152.5;" +
                "Initial Catalog=youshita_Test;" +
                "User id=youshita_co; " +
                "Password=P@hn1395;";

            SqlCommand sc1 = new SqlCommand();
            SqlDataReader reader2;
            sc1.Connection = conn;
            conn.Open();

            sc1.CommandText = "SELECT DISTINCT lessonGroup# FROM lessonTable where lessonName = '" + lessonNum + "' AND lessonTeacher# = " + currentUserName + "";


            sc1.CommandType = CommandType.Text;
            reader2 = sc1.ExecuteReader();
            while (reader2.Read())
            {
                //
                Int16 name = reader2.GetInt16(0);

                attendance_lessonGroupNumber_cb.Items.Add(name);

                //.Insert(" " + reader2.GetString(0) + " " + reader2.GetInt32(1).ToString() + " ");
            }
        }

        private void attendance_showLesson_btn_Click(object sender, EventArgs e)
        {
            long inbox_lessonNumber = 0;
            SqlConnection conn2 = new SqlConnection();
            conn2.ConnectionString =
                  "Data Source= 185.159.152.5;" +
                    "Initial Catalog=youshita_Test;" +
                    "User id=youshita_co; " +
                    "Password=P@hn1395;";

            SqlCommand sc = new SqlCommand();
            SqlDataReader reader;
            sc.CommandText = "SELECT lesson# FROM lessonTable WHERE lessonName = '" + attendance_lessonNumber_cb.Text + "'";
            sc.CommandType = CommandType.Text;
            sc.Connection = conn2;
            conn2.Open();
            reader = sc.ExecuteReader();
            reader.Read();
            inbox_lessonNumber = reader.GetInt64(0);
            conn2.Close();

            dataGridView8.DataSource = bindingSource8;

            GetData8("select *  from [dbo].[" + inbox_lessonNumber + "-" + attendance_lessonGroupNumber_cb.Text + "_Table]");

            // dataGridView6.RowHeadersWidth = (width / 28);

            dataGridView8.Columns[0].HeaderText = "شماره دانشجویی";
            dataGridView8.Columns[1].HeaderText = "نام دانشجو";
            dataGridView8.Columns[2].HeaderText = "نام خانوادگی";
            dataGridView8.Columns[0].Frozen = true;
            dataGridView8.Columns[1].Frozen = true;
            dataGridView8.Columns[2].Frozen = true;


            foreach (DataGridViewColumn col in dataGridView8.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }

            foreach (DataGridViewRow roww in dataGridView6.Rows)
            {
                //row.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView8.Rows[roww.Index].HeaderCell.Value = (roww.Index + 1).ToString();
                //row.HeaderCell.Value = String.Format("{0}", row.Index + 1);
            }
        }

        private void GetData8(string selectCommand)
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
                DataTable table8 = new DataTable();
                table8.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table8);
                bindingSource8.DataSource = table8;


                // Resize the DataGridView columns to fit the newly loaded content.
                dataGridView8.AutoResizeColumns(
                    DataGridViewAutoSizeColumnsMode.AllCells);
                dataGridView8.AutoResizeRows(
                   DataGridViewAutoSizeRowsMode.AllCells);


            }
            catch (SqlException)
            {
                DialogForm dialog = new DialogForm("مشکل در ارتباط با سرور یا پایگاه داده", "خطا", "error", this);
            }
        }
    }
}
    
