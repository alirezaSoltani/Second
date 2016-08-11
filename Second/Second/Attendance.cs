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

        public Attendance()
        {
            lessonNumber = 0;
            lessonGroupNumber = 0;
        }

        public void attendanceLesson(string date)
        {

            try
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

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }


        public void attend(String date,bool state)
        {
            Attendance attendanceObj = new Attendance();
            StudentModel studentObj = new StudentModel();
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
