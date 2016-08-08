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
    public partial class PasswordRequest : Form
    {

        private bool Checker = false;
        public PasswordRequest()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void botton1_Click(object sender, EventArgs e)
        {
         

        }

        private void authenticatePassword_Click(object sender, EventArgs e)
        {
            Checker = false;
            if (textBox1.Text != "")
            {

                TeacherModel teacherObj = new TeacherModel();
                login1 loginObj = new login1();


                Checker = teacherObj.Authenticator(loginObj.getModeratorUsername(), textBox1.Text);
                if (Checker == true)
                {

                    this.Hide();
                   
                }
                else
                {
                    MessageBox.Show(".رمز عبور صحیح نمیباشد. در صورت منصرف شدن روی دکمه ی بستن کلیک کنید");
                   
                }
            }
            else
            {
                MessageBox.Show(".رمز عبور وارد نشده است . لطفا پس از اطمینان مجدداً تلاش کنید");
                
            }
        }
        public bool authenPass()
        {
            if(Checker == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
