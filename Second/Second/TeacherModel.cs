using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class TeacherModel
    {
        public long teacherNumber;
        public String teacherFName;
        public String teacherLName;
        public String teacherUsername;
        public String teacherPassword;
        public String teacherURL;

        public TeacherModel()
        {
            teacherNumber = 0;
            teacherFName = "";
            teacherLName = "";
            teacherUsername = "";
            teacherPassword = "";
            teacherURL = "";


        }
        public static void addTeacher(TeacherModel teacherObject)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString =
            "Data Source=(local);" +
            "Initial Catalog=Project;" +
            "Integrated Security=True";

            SqlCommand sc = new SqlCommand();
            SqlDataReader reader;
            sc.CommandText = "INSERT INTO teacherTable (teacher#,teacherFName,teacherLName,teacherUsername,teacherPassword,teacherURL) VALUES ( '" + teacherObject.teacherNumber
                                                                                                            + "','" + teacherObject.teacherFName
                                                                                                            + "','" + teacherObject.teacherLName
                                                                                                            + "','" + teacherObject.teacherUsername
                                                                                                            + "','" + teacherObject.teacherPassword
                                                                                                            + "','" + teacherObject.teacherURL + "')";
            sc.CommandType = CommandType.Text;
            sc.Connection = conn;
            conn.Open();
            reader = sc.ExecuteReader();
            conn.Close();



        }

        public static void updateTeacher(TeacherModel teacherObject)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString =
            "Data Source=(local);" +
            "Initial Catalog=Project;" +
            "Integrated Security=True";

            SqlCommand sc = new SqlCommand();
            SqlDataReader reader;
            sc.CommandText = "UPDATE taecherTable SET teacher# = '" + teacherObject.teacherNumber
                                                                + "', studentFName ='" + teacherObject.teacherFName
                                                                + "', studentLName ='" + teacherObject.teacherLName
                                                                + "', teacherUsername ='" + teacherObject.teacherUsername
                                                                + "', teacherPassword ='" + teacherObject.teacherPassword
                                                                + "', teacherURL ='" + teacherObject.teacherURL + "')";

            sc.CommandType = CommandType.Text;
            sc.Connection = conn;
            conn.Open();
            reader = sc.ExecuteReader();
            conn.Close();


        }
        public static void deleteTeacher(TeacherModel teacherObject)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString =
            "Data Source=(local);" +
            "Initial Catalog=Project;" +
            "Integrated Security=True";

            SqlCommand sc = new SqlCommand();
            SqlDataReader reader;
            sc.CommandText = " DELETE FROM teacherTable WHERE teacher# = " + teacherObject.teacherNumber + " ";

            sc.CommandType = CommandType.Text;
            sc.Connection = conn;
            conn.Open();
            reader = sc.ExecuteReader();
            conn.Close();



        }
        public static List<TeacherModel> getAllTeacher(TeacherModel teacherObject)
        {
            List<TeacherModel> list = new List<TeacherModel>();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString =
            "Data Source=(local);" +
            "Initial Catalog=Project;" +
            "Integrated Security=True";
            SqlCommand sc = new SqlCommand();
            sc.CommandType = CommandType.Text;
            sc.Connection = conn;
            SqlDataReader rdr = null;

            sc.CommandText = " SELECT * FROM teacherTable";
            try
            {
                conn.Open();
                rdr = sc.ExecuteReader();
                while (rdr.Read())
                {
                    StudentModel person = new StudentModel();
                    teacherObject.teacherNumber = (long)rdr["teacher#"];
                    teacherObject.teacherFName = (String)rdr["teacherFName"];
                    teacherObject.teacherLName = (String)rdr["teacherLName"];
                    teacherObject.teacherUsername = (String)rdr["teacherUsername"];
                    teacherObject.teacherPassword = (String)rdr["teacherPassword"];
                    teacherObject.teacherURL = (String)rdr["teacherURL"];
                    list.Add(teacherObject);
                }


            }
            finally { if (rdr != null) { rdr.Close(); } if (conn != null) { conn.Close(); } }


            return list;


        }
    }
}
