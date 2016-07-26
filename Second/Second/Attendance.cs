using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second
{
    class Attendance
    {
        public long lessonNumber;
        public short lessonGroupNumber;

        public Attendance()
        {
            lessonNumber = 0;
            lessonGroupNumber = 0;
        }

        public static void attencanceLesson(Attendance attendanceObject)
        {

            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString =
                "Data Source=(local);" +
                "Initial Catalog=Project;" +
                "Integrated Security=True";

                using (SqlCommand cmd = new SqlCommand("ALTER TABLE [dbo].[" + attendanceObject.lessonNumber + "-" + attendanceObject.lessonGroupNumber + "_Table" + "]"
                           + "ADD [" + "/*currentDate*/" + "] [INT]", new SqlConnection(conn.ConnectionString)))
                {
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
