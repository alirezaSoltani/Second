using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class LessonModel
    {
        public long lessonNumber;
        public String lessonName;
        public String lessonTime;
        public int lessonGroupNumber;
        public LessonModel()
        {
            lessonNumber = 0;
            lessonName = "";
            lessonGroupNumber = 0;

        }
        public static void addLesson(LessonModel lessonObject)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString =
            "Data Source=(local);" +
            "Initial Catalog=Project;" +
            "Integrated Security=True";

            SqlCommand sc = new SqlCommand();
            SqlDataReader reader;
            sc.CommandText = "INSERT INTO lessonTable (lesson#,lessonName,lessonTime,lessonGroup#) VALUES ( '" + lessonObject.lessonNumber
                                                                                                            + "','" + lessonObject.lessonName
                                                                                                            + "','" + lessonObject.lessonTime
                                                                                                            + "','" + lessonObject.lessonGroupNumber + "')";
            sc.CommandType = CommandType.Text;
            sc.Connection = conn;
            conn.Open();
            reader = sc.ExecuteReader();
            conn.Close();

            //////////Create Table Querry

        }

        public static void updateLesson(LessonModel lessonObject)
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
                                                                + "', lessonGroup# ='" + lessonObject.lessonGroupNumber + "')";

            sc.CommandType = CommandType.Text;
            sc.Connection = conn;
            conn.Open();
            reader = sc.ExecuteReader();
            conn.Close();

            ///////Update Table querry
        }
        public static void deleteLesson(LessonModel lessonObject)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString =
            "Data Source=(local);" +
            "Initial Catalog=Project;" +
            "Integrated Security=True";

            SqlCommand sc = new SqlCommand();
            SqlDataReader reader;
            sc.CommandText = " DELETE FROM lessonTable WHERE lesson# = " + lessonObject.lessonNumber + " ";

            sc.CommandType = CommandType.Text;
            sc.Connection = conn;
            conn.Open();
            reader = sc.ExecuteReader();
            conn.Close();


            //////Delete Table Querry
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
                    LessonModel person = new LessonModel();
                    lessonObject.lessonNumber = (long)rdr["lesson#"];
                    lessonObject.lessonName = (String)rdr["lessonName"];
                    lessonObject.lessonTime = (String)rdr["lessonDate"];
                    lessonObject.lessonGroupNumber = (Int16)rdr["lessonGroup#"];
                    list.Add(lessonObject);
                }


            }
            finally { if (rdr != null) { rdr.Close(); } if (conn != null) { conn.Close(); } }


            return list;


        }
    }
}
