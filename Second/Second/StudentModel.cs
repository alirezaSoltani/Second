using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class StudentModel
    {
        public long studentNumber;
        public String studentFName;
        public String studentLName;
        public String studentURL;

        public StudentModel()
        {
            studentNumber = 0;
            studentFName = "";
            studentLName = "";
            studentURL = "";


        }
        public static void addStudent(StudentModel studentObject)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString =
            "Data Source=(local);" +
            "Initial Catalog=Project;" +
            "Integrated Security=True";

            SqlCommand sc = new SqlCommand();
            SqlDataReader reader;
            sc.CommandText = "INSERT INTO studentTable (student#,studentFName,studentLName,studetURL) VALUES ( '" + studentObject.studentNumber
                                                                                                            + "','" + studentObject.studentFName
                                                                                                            + "','" + studentObject.studentLName
                                                                                                            + "','" + studentObject.studentURL + "')";
            sc.CommandType = CommandType.Text;
            sc.Connection = conn;
            conn.Open();
            reader = sc.ExecuteReader();
            conn.Close();



        }

        public static void updateStudent(StudentModel studentObject)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString =
            "Data Source=(local);" +
            "Initial Catalog=Project;" +
            "Integrated Security=True";

            SqlCommand sc = new SqlCommand();
            SqlDataReader reader;
            sc.CommandText = "UPDATE studentTable SET student# = '" + studentObject.studentNumber
                                                                + "', studentFName ='" + studentObject.studentFName
                                                                + "', studentLName ='" + studentObject.studentLName
                                                                + "', studetURL ='" + studentObject.studentURL + "')";

            sc.CommandType = CommandType.Text;
            sc.Connection = conn;
            conn.Open();
            reader = sc.ExecuteReader();
            conn.Close();


        }
        public static void deleteStudent(StudentModel studentObject)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString =
            "Data Source=(local);" +
            "Initial Catalog=Project;" +
            "Integrated Security=True";

            SqlCommand sc = new SqlCommand();
            SqlDataReader reader;
            sc.CommandText = " DELETE FROM studentTable WHERE student# = " + studentObject.studentNumber + " ";

            sc.CommandType = CommandType.Text;
            sc.Connection = conn;
            conn.Open();
            reader = sc.ExecuteReader();
            conn.Close();



        }
        public static List<StudentModel> getAllStudent(StudentModel studentObject)
        {
            List<StudentModel> list = new List<StudentModel>();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString =
            "Data Source=(local);" +
            "Initial Catalog=Project;" +
            "Integrated Security=True";
            SqlCommand sc = new SqlCommand();
            sc.CommandType = CommandType.Text;
            sc.Connection = conn;
            SqlDataReader rdr = null;

            sc.CommandText = " SELECT * FROM studentTable";
            try
            {
                conn.Open();
                rdr = sc.ExecuteReader();
                while (rdr.Read())
                {
                    StudentModel person = new StudentModel();
                    studentObject.studentNumber = (long)rdr["student#"];
                    studentObject.studentFName = (String)rdr["studentFName"];
                    studentObject.studentLName = (String)rdr["studentLName"];
                    studentObject.studentURL = (String)rdr["studentURL"];
                    list.Add(studentObject);
                }


            }
            finally { if (rdr != null) { rdr.Close(); } if (conn != null) { conn.Close(); } }


            return list;


        }
    }
}
