using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test;

namespace Second
{
    public partial class login1 : Form
    {
        private  long moderatorUsername;

        public login1()
        {
            InitializeComponent();
            this.BackColor = Color.LightBlue;
            this.TransparencyKey = Color.LightBlue;

           

             

        }
       
        private void login1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            bool Checker = false;
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                TeacherModel teacher = new TeacherModel();
                Checker = teacher.Authenticator(Int64.Parse(textBox1.Text), textBox2.Text);
                if (Checker == true)
                {
                    setModeratorUsername(long.Parse(textBox1.Text));
                    this.Hide();
                    ManagerForm1 Form2 = new ManagerForm1();
                    Form2.Show();
                }
                else
                {
                    Error errorObj = new Error(".نام کاربری یا رمز عبور صحیح نمی باشد");
                    errorObj.Show();

                }
            }
            else
            {
                MessageBox.Show(".نام کاربری یا رمز عبور وارد نشده است . لطفا پس از اطمینان مجدداً تلاش کنید");
            }
        }
        public void setModeratorUsername(long moderatorUsername2)
        {
            this.moderatorUsername = moderatorUsername2;
        }


        public long getModeratorUsername()
        {
            return moderatorUsername;
        }

    }
}
