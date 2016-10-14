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
        public void addStudent(long lessonNumber, int lessonGroupNumber, bool isSingle)
        {

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString =
            "Data Source= 185.159.152.5;" +
                    "Initial Catalog=youshita_Test;" +
                    "User id=youshita_co; " +
                    "Password=P@hn1395;";

            SqlCommand sc = new SqlCommand();
            SqlDataReader reader;

            if (getStudentFName() == "" || getStudentLName() == "")
            {
                throw new System.ArgumentNullException();
            }

            else if (getStudentFName().Any(char.IsNumber) || getStudentLName().Any(char.IsNumber) ||
                     getStudentFName().Any(char.IsSymbol) || getStudentLName().Any(char.IsSymbol) ||
                     getStudentFName().Any(char.IsPunctuation) || getStudentLName().Any(char.IsPunctuation))
            {
                throw new System.FormatException();
            }

            else
            {
                SqlConnection conn1 = new SqlConnection();
                conn1.ConnectionString =
                "Data Source= 185.159.152.5;" +
                        "Initial Catalog=youshita_Test;" +
                        "User id=youshita_co; " +
                        "Password=P@hn1395;";

                SqlCommand sc1 = new SqlCommand();
                SqlDataReader reader1;

                sc1.CommandText = "  SELECT COUNT(COLUMN_NAME)" +
                                   " FROM INFORMATION_SCHEMA.COLUMNS" +
                                  "  WHERE TABLE_CATALOG = 'youshita_Test' AND TABLE_SCHEMA = 'dbo'" +
                                  "  AND TABLE_NAME = '" + lessonNumber + "-" + lessonGroupNumber + "_Table'  ";

                sc1.CommandType = CommandType.Text;
                sc1.Connection = conn1;
                conn1.Open();
                reader1 = sc1.ExecuteReader();
                reader1.Read();
                int numberOfColumnsClass = reader1.GetInt32(0);
                conn1.Close();




                sc.CommandText = "INSERT INTO [dbo].[" + lessonNumber + "-" + lessonGroupNumber + "_Table] (student#,studentFName,studentLName) VALUES ( '" + getStudentNumber()
                                                                                                            + "','" + getStudentFName()
                                                                                                            + "','" + getStudentLName() + "')";
                sc.CommandType = CommandType.Text;
                sc.Connection = conn;
                conn.Open();
                reader = sc.ExecuteReader();
                conn.Close();
              
                if (numberOfColumnsClass > 3)
                {
                    SqlConnection conn2 = new SqlConnection();
                    conn2.ConnectionString =
                    "Data Source= 185.159.152.5;" +
                            "Initial Catalog=youshita_Test;" +
                            "User id=youshita_co; " +
                            "Password=P@hn1395;";

                    SqlCommand sc2 = new SqlCommand();
                    SqlDataReader reader2;
                    sc2.CommandText = "select Column_name  from Information_schema.columns where Table_name like '" + lessonNumber + "-" + lessonGroupNumber + "_Table'";
                    sc2.CommandType = CommandType.Text;
                    sc2.Connection = conn2;
                    conn2.Open();
                    reader2 = sc2.ExecuteReader();
                    for (int i = 0; i < 3; i++)
                    {
                        reader2.Read();
                    }

                    SqlConnection conn3 = new SqlConnection();
                    conn3.ConnectionString =
                    "Data Source= 185.159.152.5;" +
                            "Initial Catalog=youshita_Test;" +
                            "User id=youshita_co; " +
                            "Password=P@hn1395;";

                  
                     while (reader2.Read())
                     {
                        SqlCommand sc3 = new SqlCommand();
                        conn3.Open();
                        sc3.Connection = conn3;
                        SqlDataReader reader3;
                        sc3.CommandText = "UPDATE [dbo].[" + lessonNumber + "-" + lessonGroupNumber + "_Table] SET [" + reader2.GetString(0) + "] = '0' WHERE student# = " + getStudentNumber() + "" ;
                        sc3.CommandType = CommandType.Text;
                        reader3 = sc3.ExecuteReader();
                        conn3.Close();
                    }
           

                    conn2.Close();
                    }

                    if (isSingle)
                    {
                        throw new Exception("success");
                    }


                    }
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

            if (getStudentFName() == "" || getStudentLName() == "")
            {
                throw new System.ArgumentNullException();
            }

            else if (getStudentFName().Any(char.IsNumber) || getStudentLName().Any(char.IsNumber) ||
                     getStudentFName().Any(char.IsSymbol) || getStudentLName().Any(char.IsSymbol) ||
                     getStudentFName().Any(char.IsPunctuation) || getStudentLName().Any(char.IsPunctuation))
            {
                throw new System.FormatException();
            }

            else
            {
                sc.CommandText = "UPDATE [dbo].[" + lessonNumber + "-" + lessonGroupNumber + "_Table] SET student# = '" + getStudentNewNumber()
                                                                + "', studentFName ='" + getStudentFName()
                                                                + "', studentLName ='" + getStudentLName() + "' WHERE student# = " + getStudentNumber() + "";

                sc.CommandType = CommandType.Text;
                sc.Connection = conn;
                conn.Open();
                reader = sc.ExecuteReader();
                conn.Close();
                throw new Exception("success");
            }


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
            throw new Exception("success");
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
