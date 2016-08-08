using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    class LessonModel
    {
        private long lessonNumber;
        private String lessonName;
        private int lessonGroupNumber;
        private long lessonTeacherNumber;
        private long newLessonNumber;
        private int newLessonGroupNumber;

        public LessonModel()
        {
            lessonNumber = 0;
            lessonName = "";

            lessonGroupNumber = 0;
            lessonTeacherNumber = 0;
            newLessonNumber = 0;
            newLessonGroupNumber = 0;



        }
        public void addLesson()
        {
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
                sc.CommandText = "INSERT INTO lessonTable (lesson#,lessonName,lessonGroup#,lessonTeacher#) VALUES ( '" + getLessonNumber()
                                                                                                                + "','" + getLessonName()
                                                                                                                + "','" + getLessonGroupNumber()
                                                                                                                + "','" + getLessonTeacherNumber() + "')";

                sc.CommandType = CommandType.Text;
                sc.Connection = conn;
                conn.Open();
                reader = sc.ExecuteReader();


                using (SqlCommand cmd = new SqlCommand("CREATE TABLE [dbo].[" + getLessonNumber() + "-" + getLessonGroupNumber() + "_Table" + "]("
                                 + "[student#] [bigint] NOT NULL ,"
                                 + "[studentFName] [text] NOT NULL,"
                                 + "[studentLName] [text] NOT NULL,"
                                 + "CONSTRAINT ['pk_" + getLessonNumber() + "-" + getLessonGroupNumber() + "_Table" + "'] PRIMARY KEY CLUSTERED "
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

        public void updateLesson()
        {
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
                sc.CommandText = "UPDATE lessonTable SET lesson# = '" + getNewLessonNumber()
                                                                    + "', lessonName ='" + getLessonName()
                                                                    + "', lessonGroup# ='" + getNewLessonGroupNumber()
                                                                    + "', lessonTeacher# ='" + getLessonTeacherNumber() + "')";

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
        public void deleteLesson()
        {
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
                sc.CommandText = " DELETE FROM lessonTable WHERE lesson# = " + getLessonNumber() + "AND lessonGroup# = " + getLessonGroupNumber() + " ";


                SqlCommand sc1 = new SqlCommand();
                SqlDataReader reader2;
                sc1.CommandText = " DROP TABLE [dbo].[" + getLessonNumber() + "-" + getLessonGroupNumber() + "_Table]";
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
        public List<LessonModel> getAllLesson()
        {
            List<LessonModel> list = new List<LessonModel>();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString =
            "Data Source= 185.159.152.5;" +
                    "Initial Catalog=youshita_Test;" +
                    "User id=youshita_co; " +
                    "Password=P@hn1395;";
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
                    LessonModel lessonObj = new LessonModel();
                    setLessonNumber((long)rdr["lesson#"]);
                    setLessonName((String)rdr["lessonName"]);
                    setLessonGroupNumber((Int16)rdr["lessonGroup#"]);
                    setLessonTeacherNumber((Int64)rdr["lessonTeacher#"]);
                    list.Add(lessonObj);
                }


            }
            finally { if (rdr != null) { rdr.Close(); } if (conn != null) { conn.Close(); } }


            return list;


        }

        public void setLessonNumber(long LessonNumber)
        {
            this.lessonNumber = LessonNumber;
        }


        public long getLessonNumber()
        {
            return lessonNumber;
        }

        public void setLessonName(string LessonName)
        {
            this.lessonName = LessonName;
        }


        public string getLessonName()
        {
            return lessonName;
        }
        public void setLessonGroupNumber(int LessonGroupNumber)
        {
            this.lessonGroupNumber = LessonGroupNumber;
        }


        public int getLessonGroupNumber()
        {
            return lessonGroupNumber;
        }

        public void setLessonTeacherNumber(long LessonTeacherNumber)
        {
            this.lessonTeacherNumber = LessonTeacherNumber;
        }


        public long getLessonTeacherNumber()
        {
            return lessonTeacherNumber;
        }

        public void renameLessonTable(String newName, String lastName)
        {

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
                sc.CommandText = "EXEC sp_rename '" + lastName + "', '" + newName + "'";

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

        public void setNewLessonNumber(long NewLessonNumber)
        {
            this.newLessonNumber = NewLessonNumber;
        }


        public long getNewLessonNumber()
        {
            return newLessonNumber;
        }
        public void setNewLessonGroupNumber(int NewLessonGroupNum)
        {
            newLessonGroupNumber = NewLessonGroupNum;
        }


        public long getNewLessonGroupNumber()
        {
            return newLessonGroupNumber;
        }

    }
}
