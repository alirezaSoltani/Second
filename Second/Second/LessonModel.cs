using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LessonModel
{
    class LessonModel
    {
        public long lessonNumber;
        public String lessonName;
        public String lessonTime;
        public int lessonGroupNumber;
        public long lessonTeacherNumber;
        public long newLessonNumber;
        public int newLessonGroupNumber;
        public LessonModel()
        {
            lessonNumber = 0;
            lessonName = "";
            lessonTime = "";
            lessonGroupNumber = 0;
            lessonTeacherNumber = 0;
            newLessonNumber = 0;
            newLessonGroupNumber = 0;

        }
        public static void addLesson(LessonModel lessonObject)
        {
            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString =
                "Data Source=(local);" +
                "Initial Catalog=Project;" +
                "Integrated Security=True";

                SqlCommand sc = new SqlCommand();
                SqlDataReader reader;
                sc.CommandText = "INSERT INTO lessonTable (lesson#,lessonName,lessonTime,lessonGroup#,lessonTeacher#) VALUES ( '" + lessonObject.lessonNumber
                                                                                                                + "','" + lessonObject.lessonName
                                                                                                                + "','" + lessonObject.lessonGroupNumber
                                                                                                                + "','" + lessonObject.lessonTeacherNumber + "')";

                sc.CommandType = CommandType.Text;
                sc.Connection = conn;
                conn.Open();
                reader = sc.ExecuteReader();


                using (SqlCommand cmd = new SqlCommand("CREATE TABLE [dbo].[" + lessonObject.lessonNumber + "-" + lessonObject.lessonGroupNumber + "_Table" + "]("
                                 + "[student#] [bigint] NOT NULL ,"
                                 + "[studentFName] [text] NOT NULL,"
                                 + "[studentLName] [text] NOT NULL,"
                                 + "CONSTRAINT ['pk_" + lessonObject.lessonNumber + "-" + lessonObject.lessonGroupNumber + "_Table" + "'] PRIMARY KEY CLUSTERED "
                                 + "("
                                 + "[student#] ASC"
                                 + ")WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]"
                                 + ") ON [PRIMARY]", new SqlConnection(conn.ConnectionString)))
                {
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }

                conn.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }



        }

        public static void updateLesson(LessonModel lessonObject)
        {
            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString =
                "Data Source=(local);" +
                "Initial Catalog=Project;" +
                "Integrated Security=True";

                SqlCommand sc = new SqlCommand();
                SqlDataReader reader;
                sc.CommandText = "UPDATE lessonTable SET lesson# = '" + lessonObject.lessonNumber
                                                                    + "', lessonName ='" + lessonObject.lessonName
                                                                    + "', lessonTime ='" + lessonObject.lessonTime
                                                                    + "', lessonGroup# ='" + lessonObject.lessonGroupNumber
                                                                    + "', lessonTeacher# ='" + lessonObject.lessonTeacherNumber + "')";

                sc.CommandType = CommandType.Text;
                sc.Connection = conn;
                conn.Open();
                reader = sc.ExecuteReader();
                conn.Close();

                /*

                using (SqlCommand cmd = new SqlCommand("CREATE TABLE [dbo].[" + lessonObject.newLessonNumber + "-" + lessonObject.newLessonGroupNumber + "_Table" + "]("
                            + "[student#] [bigint] NOT NULL ,"
                            + "[studentFName] [text] NOT NULL,"
                            + "[studentLName] [text] NOT NULL,"
                            + "CONSTRAINT ['pk_" + lessonObject.newLessonNumber + "-" + lessonObject.newLessonGroupNumber + "_Table" + "'] PRIMARY KEY CLUSTERED "
                            + "("
                            + "[student#] ASC"
                            + ")WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]"
                            + ") ON [PRIMARY]", new SqlConnection(conn.ConnectionString)))
                {
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }

                */


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public static void deleteLesson(LessonModel lessonObject)
        {
            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString =
                "Data Source=(local);" +
                "Initial Catalog=Project;" +
                "Integrated Security=True";

                SqlCommand sc = new SqlCommand();
                SqlDataReader reader;
                sc.CommandText = " DELETE FROM lessonTable WHERE lesson# = " + lessonObject.lessonNumber + "AND lessonGroup# = " + lessonObject.lessonGroupNumber + " ";


                SqlCommand sc1 = new SqlCommand();
                SqlDataReader reader2;
                sc1.CommandText = " DROP TABLE [dbo].[" + lessonObject.lessonNumber + "-" + lessonObject.lessonGroupNumber + "_Table]";
                sc1.CommandType = CommandType.Text;

                sc.CommandType = CommandType.Text;
                sc.Connection = conn;
                sc1.Connection = conn;
                conn.Open();
                reader = sc.ExecuteReader();
                reader2 = sc.ExecuteReader();
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
        public static List<LessonModel> getAllLesson(LessonModel lessonObject)
        {
            List<LessonModel> list = new List<LessonModel>();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString =
            "Data Source=(local);" +
            "Initial Catalog=Project;" +
            "Integrated Security=True";
            SqlCommand sc = new SqlCommand();
            sc.CommandType = CommandType.Text;
            sc.Connection = conn;
            SqlDataReader rdr = null;

            sc.CommandText = " SELECT * FROM lessonTable";
            try
            {
                conn.Open();
                rdr = sc.ExecuteReader();
                while (rdr.Read())
                {
                    
                    lessonObject.lessonNumber = (long)rdr["lesson#"];
                    lessonObject.lessonName = (String)rdr["lessonName"];
                    lessonObject.lessonTime = (String)rdr["lessonDate"];
                    lessonObject.lessonGroupNumber = (Int16)rdr["lessonGroup#"];
                    lessonObject.lessonTeacherNumber = (Int64)rdr["lessonTeacher#"];
                    list.Add(lessonObject);
                }


            }
            finally { if (rdr != null) { rdr.Close(); } if (conn != null) { conn.Close(); } }


            return list;


        }


    }
}
