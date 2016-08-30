using Second;
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
    public class TeacherModel
    {
        private  long teacherNumber;
        private  String teacherFName;
        private  String teacherLName;
        private  String teacherPassword;
        private  String teacherURL;
        private long teacherNewNumber;

        

        public TeacherModel()
        {
            teacherNumber = 0;
            teacherFName = "";
            teacherLName = "";
            teacherPassword = "";
            teacherURL = "";
        }

     

        public void addTeacher()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString =
              "Data Source= 185.159.152.5;" +
                    "Initial Catalog=youshita_Test;" +
                    "User id=youshita_co; " +
                    "Password=P@hn1395;";
            SqlCommand sc = new SqlCommand();
            SqlDataReader reader;

            if(getTeacherFName() == "" || getTeacherLName() == "" || getTeacherPassword() == "")
            {
                throw new System.ArgumentNullException();
            }
            
            else if(getTeacherFName().Any(char.IsNumber) || getTeacherLName().Any(char.IsNumber) || getTeacherPassword().Any(char.IsWhiteSpace) )
            {
                throw new System.FormatException();
            }

            else
            {
                sc.CommandText = "INSERT INTO teacherTable (teacher#,teacherFName,teacherLName,teacherPassword,teacherURL) VALUES ( '" + getTeacherNumber()
                                                                                                            + "','" + getTeacherFName()
                                                                                                            + "','" + getTeacherLName()
                                                                                                            + "','" + getTeacherPassword()
                                                                                                            + "','" + getTeacherURL() + "')";
                sc.CommandType = CommandType.Text;
                sc.Connection = conn;
                conn.Open();
                reader = sc.ExecuteReader();
                conn.Close();
                throw new Exception("success");
            }
        }

       

        public void updateTeacher()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString =
             "Data Source= 185.159.152.5;" +
                    "Initial Catalog=youshita_Test;" +
                    "User id=youshita_co; " +
                    "Password=P@hn1395;";

            SqlCommand sc = new SqlCommand();
            SqlDataReader reader;

            if (getTeacherFName() == "" || getTeacherLName() == "" || getTeacherPassword() == "")
            {
                throw new System.ArgumentNullException();
            }

            else if (getTeacherFName().Any(char.IsNumber) || getTeacherLName().Any(char.IsNumber) || getTeacherPassword().Any(char.IsWhiteSpace))
            {
                throw new System.FormatException();
            }

            else
            {

                sc.CommandText = "UPDATE teacherTable SET teacher# = '" + getTeacherNewNumber()
                                                                    + "', teacherFName ='" + getTeacherFName()
                                                                    + "', teacherLName ='" + getTeacherLName()
                                                                    + "', teacherPassword ='" + getTeacherPassword()
                                                                    + "', teacherURL ='" + getTeacherURL() + "' WHERE teacher# =" + getTeacherNumber() + "";

                sc.CommandType = CommandType.Text;
                sc.Connection = conn;
                conn.Open();
                reader = sc.ExecuteReader();
                conn.Close();
                throw new Exception("success");
            }
        }




        public  void deleteTeacher()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString =
            "Data Source= 185.159.152.5;" +
                        "Initial Catalog=youshita_Test;" +
                        "User id=youshita_co; " +
                        "Password=P@hn1395;";

            SqlCommand sc = new SqlCommand();
            SqlDataReader reader;
            sc.CommandText = " DELETE FROM teacherTable WHERE teacher# = " + getTeacherNumber() + "";

            sc.CommandType = CommandType.Text;
            sc.Connection = conn;
            conn.Open();
            reader = sc.ExecuteReader();
            conn.Close();
            throw new Exception("success");
        }

        public string getTeacherFullName(long username)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString =
            "Data Source= 185.159.152.5;" +
                    "Initial Catalog=youshita_Test;" +
                    "User id=youshita_co; " +
                    "Password=P@hn1395;";
            SqlCommand sc = new SqlCommand();
            sc.CommandType = CommandType.Text;
            sc.Connection = conn;
            SqlDataReader reader;

            sc.CommandText = " SELECT teacherFName , teacherLName FROM teacherTable WHERE teacher# = '" + username + "'";
            conn.Open();
            reader = sc.ExecuteReader();
            reader.Read();
            string FName = reader.GetString(0);
            string LName = reader.GetString(1);
            string fullName = FName + " " + LName;
            conn.Close();

            return fullName;
        }
        public  List<TeacherModel> getAllTeacher()
        {
            List<TeacherModel> list = new List<TeacherModel>();
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

            sc.CommandText = " SELECT * FROM teacherTable";
            try
            {
                conn.Open();
                rdr = sc.ExecuteReader();
                while (rdr.Read())
                {
                    TeacherModel teacherObj = new TeacherModel();
                    teacherNumber = (long)rdr["teacher#"];
                    teacherFName = (String)rdr["teacherFName"];
                    teacherLName = (String)rdr["teacherLName"];
                    teacherPassword = (String)rdr["teacherPassword"];
                    teacherURL = (String)rdr["teacherURL"];
                    list.Add(teacherObj);
                }
            }
            finally { if (rdr != null) { rdr.Close(); } if (conn != null) { conn.Close(); } }


            return list;
       


        }
        public int Authenticator(long username, String password)
        {
            int Authenticate = 0;
            if(username == 99 && password == "1")
            {
                Authenticate = 1;
            }

            if (username != 99)
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString =
                    "Data Source= 185.159.152.5;" +
                    "Initial Catalog=youshita_Test;" +
                    "User id=youshita_co; " +
                    "Password=P@hn1395;";


                SqlCommand sc = new SqlCommand();
                SqlDataReader reader;
                sc.CommandText = "SELECT manager# , managerPassword FROM managerTable ";

                sc.CommandType = CommandType.Text;
                sc.Connection = conn;
                conn.Open();
                reader = sc.ExecuteReader();

                while (reader.Read())
                {
                    if (reader.GetInt64(0) == username &&
                            reader.GetString(1) == password)
                    {
                        Authenticate = 2;
                    }
                }
                conn.Close();
            }

            if (Authenticate == 0)
            {
                SqlConnection conn1 = new SqlConnection();
                conn1.ConnectionString =
                    "Data Source= 185.159.152.5;" +
                    "Initial Catalog=youshita_Test;" +
                    "User id=youshita_co; " +
                    "Password=P@hn1395;";


                SqlCommand sc1 = new SqlCommand();
                SqlDataReader reader1;
                sc1.CommandText = "SELECT teacher# , teacherPassword FROM teacherTable ";

                sc1.CommandType = CommandType.Text;
                sc1.Connection = conn1;
                conn1.Open();
                reader1 = sc1.ExecuteReader();

                while (reader1.Read())
                {
                    if (reader1.GetInt64(0) == username &&
                            reader1.GetString(1) == password)
                    {
                        Authenticate = 3;
                    }
                }
                conn1.Close();
            } 
            return Authenticate;
        }

        /// <summary>
        /// end of set and get
        /// </summary>

        public void setTeacherNumber(long teacherNumber)
        {
            this.teacherNumber = teacherNumber;
        }


        public long getTeacherNumber()
        {
            return teacherNumber;
        }

        public void setTeacherFName(string teacherFName)
        {
            this.teacherFName = teacherFName;
        }


        public string getTeacherFName()
        {
            return teacherFName;
        }
        public void setTeacherLName(string teacherLName)
        {
            this.teacherLName = teacherLName;
        }


        public string getTeacherLName()
        {
            return teacherLName;
        }

        public void setTeacherPassword(string teacherPassword)
        {
            this.teacherPassword = teacherPassword;
        }


        public string getTeacherPassword()
        {
            return teacherPassword;
        }
        public void setTeacherURL(string teacherURL)
        {
            this.teacherURL = teacherURL;
        }


        public string getTeacherURL()
        {
            return teacherURL;
        }

        public void setTeacherNewNumber(long teacherNewNumber)
        {
            this.teacherNewNumber = teacherNewNumber;
        }


        public long getTeacherNewNumber()
        {
            return teacherNewNumber;
        }

        /// <summary>
        /// end of set and gets
        /// </summary>



    }
}
