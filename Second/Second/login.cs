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
        int width = SystemInformation.PrimaryMonitorSize.Width;
        int height = SystemInformation.PrimaryMonitorSize.Height;

        public login1()
        {
            InitializeComponent();
            this.BackColor = Color.LightBlue;
            this.TransparencyKey = Color.LightBlue;
        }
       
        private void login1_Load(object sender, EventArgs e)
        {
            this.SetBounds(((390 * width) / 1000), ((150* width) / 1000), ((205 * width) / 1000), ((205 * width) / 1000));
            login_panel.SetBounds(((0 * width) / 800), ((0 * height) / 100), ((205 * width) / 1000), ((205 * width) / 1000));
            //login_exit_lbl.SetBounds(((137 * width) / 800), ((9 * height) / 200), ((3 * width) / 200), ((2 * height) / 100));
            logo_pictureBox.SetBounds(((33 * width) / 800), ((40 * height) / 800), ((30 * width) / 200), ((12 * height) / 200));
            login_username_txtbx.SetBounds(((23 * width) / 800), ((150 * height) / 1000), ((26 * width) / 200), ((35 * height) / 1000));
            login_password_txtbx.SetBounds(((23 * width) / 800), ((205 * height) / 1000), ((26 * width) / 200), ((35 * height) / 1000));
            login_enter_lbl.SetBounds(((21 * width) / 800), ((210 * height) / 800), ((30 * width) / 200), ((8 * height) / 200));
            exit_pictureBox.SetBounds(((142 * width) / 800), ((25 * height) / 800), ((5 * height) / 200), ((5 * height) / 200));
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            bool Checker = false;
            if (login_username_txtbx.Text != "" && login_password_txtbx.Text != "")
            {
                TeacherModel teacher = new TeacherModel();
                Checker = teacher.Authenticator(Int64.Parse(login_username_txtbx.Text), login_password_txtbx.Text);
                if (Checker == true)
                {
                    setModeratorUsername(long.Parse(login_username_txtbx.Text));
                    this.Hide();
                    ManagerForm1 Form2 = new ManagerForm1();
                    Form2.Show();
                }
                else
                {
                    /*Error errorObj = new Error(".نام کاربری یا رمز عبور صحیح نمی باشد");
                    errorObj.Show();*/

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

        private void exit_pictureBox_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void exit_pictureBox_MouseEnter(object sender, EventArgs e)
        {
            exit_pictureBox.BackgroundImage = Second.Properties.Resources.exit_3;
        }

        private void exit_pictureBox_MouseLeave(object sender, EventArgs e)
        {
            exit_pictureBox.BackgroundImage = Second.Properties.Resources.exit_1;
        }
    }
}
