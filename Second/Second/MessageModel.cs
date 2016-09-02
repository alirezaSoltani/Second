using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Second
{

     
    class MessageModel
    {
        private long messageNumber;
        private string messageTitle;
        private string messageMain;
        private String messageDate;
        private long messageLessonNumber;
        private long senderTeacherNumber;
        private Int16 messageLessonGroupNumber;
        private int messageRead;

        pharmalogyWebService.PharmalogyWebService pharmaObj = new pharmalogyWebService.PharmalogyWebService();

        public MessageModel()
        {
            messageNumber = 0;
            messageTitle = "";
            messageMain = "";
            messageLessonNumber = 0;
            senderTeacherNumber = 0;
            messageRead = 0;
            messageLessonGroupNumber = 0;


        }
        public void sendMessage()
        {
           string dateAndTime = pharmaObj.getDateTime();
            try
            {

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString =
                "Data Source= 185.159.152.5;" +
                    "Initial Catalog=youshita_Test;" +
                    "User id=youshita_co; " +
                    "Password=P@hn1395;";

                long teacherNumber = getSenderTeacherNumber();

                SqlCommand sc1 = new SqlCommand();
                SqlDataReader reader2;
                sc1.Connection = conn;
                conn.Open();

                sc1.CommandText = "SELECT teacherFName , teacherLName FROM teacherTable WHERE teacher# = " + teacherNumber + "";


                sc1.CommandType = CommandType.Text;
                reader2 = sc1.ExecuteReader();
                reader2.Read();
                setMessageTitle( " " + reader2.GetString(0) + " " + reader2.GetString(1) + " ");


                conn.Close();




                SqlCommand sc = new SqlCommand();
                SqlDataReader reader;
                sc.CommandText = "INSERT INTO messageTable (messageTitle,messageMain,messageDate,messageLesson#,senderTeacher#,messageLessonGroup#,messageRead) VALUES ( '" + getMessageTtile()
                                                                                                                + "','" + getMessageMain()
                                                                                                                + "','" + dateAndTime
                                                                                                                + "','" + getMessageLessonNumber()
                                                                                                                + "','" + getSenderTeacherNumber()
                                                                                                                + "','" + getMessageLessonGroupNumber()
                                                                                                                + "','" + 0 + "')";

                sc.CommandType = CommandType.Text;
                sc.Connection = conn;
                conn.Open();
                reader = sc.ExecuteReader();
                conn.Close();


                ///////log
                SqlCommand sc2 = new SqlCommand();
                SqlDataReader reader3;
                sc2.Connection = conn;
                conn.Open();
                sc2.CommandText = "INSERT INTO logTable VALUES ( 'Send Message' , 'sending message with " + getSenderTeacherNumber() + " ' , '" + dateAndTime  + "' , '" + getSenderTeacherNumber() + "','s m')";
                sc2.CommandType = CommandType.Text;
                reader3 = sc2.ExecuteReader();
                conn.Close();
                ////////log

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        public void deleteMessage(String username)
        {
            string dateAndTime = pharmaObj.getDateTime();
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
                sc.CommandText = " DELETE FROM messageTable WHERE message# = " + getMessageNumber() + " ";
                sc.CommandType = CommandType.Text;
                sc.Connection = conn;
                conn.Open();
                reader = sc.ExecuteReader();
                conn.Close();

                /////log
                SqlCommand sc1 = new SqlCommand();
                SqlDataReader reader2;
                sc1.Connection = conn;
                conn.Open();
                sc1.CommandText = "INSERT INTO logTable VALUES ( 'Delete Message' , 'deleting message # " +getMessageNumber() + " with " + username + " ' , '" + dateAndTime + "' , '" + username + "','d m')";
                sc1.CommandType = CommandType.Text;
                reader2 = sc1.ExecuteReader();
                conn.Close();
                //////log
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
            


        public void setMessageNumber(long MessageNumber)
        {
            this.messageNumber = MessageNumber;
        }


        public long getMessageNumber()
        {
            return messageNumber;
        }

        public void setMessageTitle(string MessageTitle)
        {
            this.messageTitle = MessageTitle;
        }


        public string getMessageTtile()
        {
            return messageTitle;
        }
        public void setMessageMain(string MessageMain)
        {
            this.messageMain = MessageMain;
        }


        public string getMessageMain()
        {
            return messageMain;
        }

        public void setMessageDate(string MessageDate)
        {
            this.messageDate = MessageDate;
        }
        public string getMessageDate()
        {
            return messageDate;
        }


        public void setMessageLessonNumber(long MessageLessonNumber)
        {
            this.messageLessonNumber = MessageLessonNumber;
        }
        public long getMessageLessonNumber()
        {
            return messageLessonNumber;
        }



        public void setSenderTeacherNumber(long SenderTeacherNumber)
        {
            this.senderTeacherNumber = SenderTeacherNumber;
        }


        public long getSenderTeacherNumber()
        {
            return senderTeacherNumber;
            
        }


        public void setMessageLessonGroupNumber(Int16 MessageLessonGroupNumber)
        {
            this.messageLessonGroupNumber = MessageLessonGroupNumber;
        }


        public Int16 getMessageLessonGroupNumber()
        {
            return messageLessonGroupNumber;

        }

        public void setMessageRead(int MessageRead)
        {
            this.messageRead = MessageRead;
        }


        public int getMessageRead()
        {
            return messageRead;

        }
    }
}
