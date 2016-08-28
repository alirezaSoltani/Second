using Second.pharmalogyWebService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test;
namespace Second
{
    class Attendance
    {
        public long lessonNumber;
        public short lessonGroupNumber;
        PharmalogyWebService pharmaObj = new PharmalogyWebService();

        public Attendance()
        {
            lessonNumber = 0;
            lessonGroupNumber = 0;
        }

        public void attendanceLesson(string date , long username)
        {
           
           
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString =
                  "Data Source= 185.159.152.5;" +
                    "Initial Catalog=youshita_Test;" +
                    "User id=youshita_co; " +
                    "Password=P@hn1395;";

                using (SqlCommand cmd = new SqlCommand("ALTER TABLE [dbo].[" + getLessonNumber() + "-" + getLessonGroupNumber() + "_Table" + "]"
                           + "ADD [" + date + "] [INT]", new SqlConnection(conn.ConnectionString)))
                {
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }

                ///////log
                SqlCommand sc1 = new SqlCommand();
                SqlDataReader reader2;
                sc1.Connection = conn;
                conn.Open();
                sc1.CommandText = "INSERT INTO logTable VALUES ( 'Attendance' , 'Attendance with username : " + username + " for this class number " + getLessonNumber() + " and this class group number " + getLessonGroupNumber() + " at " + date + "' , '" + pharmaObj.getDateTime() + "' , '" + username + "','at')";
                sc1.CommandType = CommandType.Text;
                reader2 = sc1.ExecuteReader();
                conn.Close();
                ////////log

          

          

        }


        public void attend(String date,bool state)
        {
            Attendance attendanceObj = new Attendance();
            Test.StudentModel studentObj = new Test.StudentModel();
            try
            {

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString =
                  "Data Source= 185.159.152.5;" +
                    "Initial Catalog=youshita_Test;" +
                    "User id=youshita_co; " +
                    "Password=P@hn1395;";

                SqlCommand sc = new SqlCommand();
                SqlDataReader reader;
                sc.CommandText = "UPDATE [dbo].[" + getLessonNumber() + "-" + getLessonGroupNumber() + "_Table" + "] SET [" + date + "] = '" + state + "' WHERE student# = " + studentObj.getStudentNumber() + "";
               

                sc.CommandType = CommandType.Text;
                sc.Connection = conn;
                conn.Open();
                reader = sc.ExecuteReader();
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void setLessonNumber(long LessonNumber)
        {
            this.lessonNumber = LessonNumber;
        }


        public long getLessonNumber()
        {
            return lessonNumber;

        }

        public void setLessonGroupNumber(Int16 LessonGroupNumber)
        {
            this.lessonGroupNumber = LessonGroupNumber;
        }


        public Int16 getLessonGroupNumber()
        {
            return lessonGroupNumber;

        }
    }
}
