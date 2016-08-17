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
        public long studentNewNumber;

        public StudentModel()
        {
            studentNumber = 0;
            studentFName = "";
            studentLName = "";
            studentURL = "";


        }
        public void addStudent(long lessonNumber , int lessonGroupNumber)
        {
            
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString =
            "Data Source= 185.159.152.5;" +
                    "Initial Catalog=youshita_Test;" +
                    "User id=youshita_co; " +
                    "Password=P@hn1395;";

            SqlCommand sc = new SqlCommand();
            SqlDataReader reader;
            sc.CommandText = "INSERT INTO [dbo].["+lessonNumber+"-"+lessonGroupNumber+"_Table] (student#,studentFName,studentLName) VALUES ( '" + getStudentNumber()
                                                                                                            + "','" + getStudentFName()
                                                                                                            + "','" + getStudentLName() + "')";
            sc.CommandType = CommandType.Text;
            sc.Connection = conn;
            conn.Open();
            reader = sc.ExecuteReader();
            conn.Close();



        }

        public void updateStudent(long lessonNumber, int lessonGroupNumber)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString =
            "Data Source= 185.159.152.5;" +
                    "Initial Catalog=youshita_Test;" +
                    "User id=youshita_co; " +
                    "Password=P@hn1395;";

            SqlCommand sc = new SqlCommand();
            SqlDataReader reader;
            sc.CommandText = "UPDATE [dbo].[" + lessonNumber + "-" + lessonGroupNumber + "_Table] SET student# = '" + getStudentNewNumber()
                                                                + "', studentFName ='" + getStudentFName()
                                                                + "', studentLName ='" + getStudentLName()  + "') WHERE student# = "+getStudentNumber()+"";

            sc.CommandType = CommandType.Text;
            sc.Connection = conn;
            conn.Open();
            reader = sc.ExecuteReader();
            conn.Close();


        }
        public void deleteStudent(long lessonNumber, int lessonGroupNumber)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString =
            "Data Source= 185.159.152.5;" +
                    "Initial Catalog=youshita_Test;" +
                    "User id=youshita_co; " +
                    "Password=P@hn1395;";

            SqlCommand sc = new SqlCommand();
            SqlDataReader reader;
            sc.CommandText = " DELETE FROM [dbo].[" + lessonNumber + "-" + lessonGroupNumber + "_Table] WHERE student# = " + getStudentNumber() + " ";

            sc.CommandType = CommandType.Text;
            sc.Connection = conn;
            conn.Open();
            reader = sc.ExecuteReader();
            conn.Close();



        }
        public  List<StudentModel> getAllStudent()
        {
            List<StudentModel> list = new List<StudentModel>();
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

            sc.CommandText = " SELECT * FROM studentTable";
            try
            {
                conn.Open();
                rdr = sc.ExecuteReader();
                while (rdr.Read())
                {
                    StudentModel studentObject = new StudentModel();
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





        public void setStudentNumber(long StudentNumber)
        {
            this.studentNumber= StudentNumber;
        }


        public long getStudentNumber()
        {
            return studentNumber;
        }
        public void setStudentFName(String StudentFName)
        {
            this.studentFName = StudentFName;
        }


        public String getStudentFName()
        {
            return studentFName;
        }
        public void setStudentLName(String StudentLName)
        {
            this.studentLName = StudentLName;
        }


        public String getStudentLName()
        {
            return studentLName;
        }
        public void setStudentURL(String StudentURL)
        {
            this.studentURL = StudentURL;
        }


        public String getStudentURL()
        {
            return studentURL;
        }


        public void setStudentNewNumber(long StudentNewNumber)
        {
            this.studentNewNumber = StudentNewNumber;
        }


        public long getStudentNewNumber()
        {
            return studentNewNumber;
        }
    }
}
