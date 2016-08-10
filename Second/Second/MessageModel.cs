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
        private bool messageRead;

        public MessageModel()
        {
            messageNumber = 0;
            messageTitle = "";
            messageMain = "";
            messageLessonNumber = 0;
            senderTeacherNumber = 0;
            messageRead = false;
            messageLessonGroupNumber = 0;

        }
        public void sendMessage()
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
                sc.CommandText = "INSERT INTO messageTable (message#,messageTitle,messageMain,messageDate,messageLesson#,senderTeacher#,messageLessonGroup#,messageRead) VALUES ( '" + getMessageNumber()
                                                                                                                + "','" + getMessageTtile()
                                                                                                                + "','" + getMessageMain()
                                                                                                                + "','" + getMessageDate()
                                                                                                                + "','" + getMessageLessonNumber()
                                                                                                                + "','" + getSenderTeacherNumber()
                                                                                                                + "','" + getMessageLessonGroupNumber()
                                                                                                                + "','" + getMessageRead() + "')";

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

        public void deleteMessage()
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
                sc.CommandText = " DELETE FROM messageTable WHERE message# = " + getMessageNumber() + " ";
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

        public void setMessageRead(bool MessageRead)
        {
            this.messageRead = MessageRead;
        }


        public bool getMessageRead()
        {
            return messageRead;

        }
    }
}
