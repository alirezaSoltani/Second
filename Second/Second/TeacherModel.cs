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

            MessageBox.Show("اطلاعات مورد نظر با موفقیت ثبت شد.");
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
            sc.CommandText = "UPDATE teacherTable SET teacher# = '" + getTeacherNewNumber()
                                                                + "', teacherFName ='" +getTeacherFName()
                                                                + "', teacherLName ='" + getTeacherLName()                       
                                                                + "', teacherPassword ='" + getTeacherPassword()
                                                                + "', teacherURL ='" + getTeacherURL()+"' WHERE teacher# ="+getTeacherNumber()+ "";

            sc.CommandType = CommandType.Text;
            sc.Connection = conn;
            conn.Open();
            reader = sc.ExecuteReader();
            conn.Close();

            MessageBox.Show("اطلاعات مورد با موفقیت تغییر یافت.");
        }




        public  void deleteTeacher()
        {
            try {
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
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }

            MessageBox.Show("اطلاعات مورد نظر با موفقیت حذف شد.");
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
        public bool Authenticator(long username, String password)
        {
            bool Authenticate = false;
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
                sc.CommandText = "SELECT teacher# , teacherPassword FROM teacherTable ";

                sc.CommandType = CommandType.Text;
                sc.Connection = conn;
                conn.Open();
                reader = sc.ExecuteReader();

                while (reader.Read())
                {
                    if (reader.GetInt64(0) == username &&
                            reader.GetString(1) == password)

                    {
                        Authenticate = true;
                    }
                }
                conn.Close();



            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return Authenticate;

        }

        /// <summary>
        /// end of set and get
        /// </summary>
        /// <param name="teacherNumber"></param>

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
