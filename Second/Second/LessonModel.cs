﻿using System;
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
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString =
                    "Data Source= 185.159.152.5;" +
                    "Initial Catalog=youshita_Test;" +
                    "User id=youshita_co; " +
                    "Password=P@hn1395;";


            SqlCommand sc = new SqlCommand();
            SqlDataReader reader;

            if (getLessonName() == "")
            {
                throw new System.ArgumentNullException();
            }

            else
            {
                sc.CommandText = "INSERT INTO lessonTable (lesson#,lessonName,lessonGroup#,lessonTeacher#) VALUES ( '" + getLessonNumber()
                                                                                                                + "','" + getLessonName()
                                                                                                                + "','" + getLessonGroupNumber()
                                                                                                                + "','" + getLessonTeacherNumber() + "')";

                sc.CommandType = CommandType.Text;
                sc.Connection = conn;
                conn.Open();
                reader = sc.ExecuteReader();
                conn.Close();
                //throw new Exception("success");
            }
        }

        public void createLessonTable()
        {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString =
                         "Data Source= 185.159.152.5;" +
                         "Initial Catalog=youshita_Test;" +
                         "User id=youshita_co; " +
                         "Password=P@hn1395;";

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
        }

        public void updateLesson()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString =
            "Data Source= 185.159.152.5;" +
                "Initial Catalog=youshita_Test;" +
                "User id=youshita_co; " +
                "Password=P@hn1395;";

            SqlCommand sc = new SqlCommand();
            SqlDataReader reader;

            if (getLessonName() == "")
            {
                throw new System.ArgumentNullException();
            }
            
            else
            {
                sc.CommandText = "UPDATE lessonTable SET lesson# = '" + getNewLessonNumber()
                                                                + "', lessonName ='" + getLessonName()
                                                                + "', lessonGroup# ='" + getNewLessonGroupNumber() + "' WHERE lesson# =" + getLessonNumber() + "AND lessonGroup#= " + getLessonGroupNumber() + "";

                sc.CommandType = CommandType.Text;
                sc.Connection = conn;
                conn.Open();
                reader = sc.ExecuteReader();
                conn.Close();
                //throw new Exception("success");
            }



            SqlConnection conn2 = new SqlConnection();
            conn2.ConnectionString =
                "Data Source= 185.159.152.5;" +
                "Initial Catalog=youshita_Test;" +
                "User id=youshita_co; " +
                "Password=P@hn1395;";


            if (getLessonName() == "")
            {
                throw new System.ArgumentNullException();
            }

            else
            {
                SqlCommand sc2 = new SqlCommand();
                SqlDataReader reader2;
                sc2.Connection = conn2;
                conn2.Open();
                sc2.CommandText = "EXEC sp_rename '" + getLessonNumber() + "-" + getLessonGroupNumber() + "_Table', '" + getNewLessonNumber() + "-" + getNewLessonGroupNumber() + "_Table'";
                sc2.CommandType = CommandType.Text;
                reader2 = sc2.ExecuteReader();
                conn2.Close();
                throw new Exception("success");
            }
        }
        public void deleteLesson()
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
                sc.CommandType = CommandType.Text;
                sc.Connection = conn;
                conn.Open();
                reader = sc.ExecuteReader();
                conn.Close();


                SqlConnection conn2 = new SqlConnection();
                 conn2.ConnectionString =
                    "Data Source= 185.159.152.5;" +
                    "Initial Catalog=youshita_Test;" +
                    "User id=youshita_co; " +
                    "Password=P@hn1395;";


                SqlCommand sc1 = new SqlCommand();
                SqlDataReader reader2;

                sc1.CommandText = "DROP TABLE [dbo].["+ getLessonNumber() + "-" + getLessonGroupNumber() + "_Table]";
                sc1.CommandType = CommandType.Text;
                sc1.Connection = conn2;
                conn2.Open();
                reader2 = sc1.ExecuteReader();
                conn2.Close();
                throw new Exception("success");
        }

        public void deleteLessonTeacher ()
        {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString =
                "Data Source= 185.159.152.5;" +
                    "Initial Catalog=youshita_Test;" +
                    "User id=youshita_co; " +
                    "Password=P@hn1395;";


                SqlCommand sc1 = new SqlCommand();
                SqlDataReader reader1;
                sc1.CommandText = " SELECT COUNT(*) FROM lessonTable WHERE lesson# = " + getLessonNumber() + "AND lessonGroup# = " + getLessonGroupNumber() + "  ";
                sc1.CommandType = CommandType.Text;
                sc1.Connection = conn;
                conn.Open();
                reader1 = sc1.ExecuteReader();
                reader1.Read();
                int teacherCount = reader1.GetInt32(0);
                conn.Close();

                if (teacherCount > 1)
                {

                    SqlCommand sc = new SqlCommand();
                    SqlDataReader reader;
                    sc.CommandText = " DELETE FROM lessonTable WHERE lesson# = " + getLessonNumber() + "AND lessonGroup# = " + getLessonGroupNumber() + " AND lessonTeacher#= " + getLessonTeacherNumber() + " ";
                    sc.CommandType = CommandType.Text;
                    sc.Connection = conn;
                    conn.Open();
                    reader= sc.ExecuteReader();
                    conn.Close();
                    throw new Exception("success");
                }
                else
                {
                    MessageBox.Show("به دلیل وجود فقط یک استاد در این درس، نمی توان استاد مورد نظر را حذف کرد.");
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
