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
            this.SetBounds(((300 * width) / 800), ((25 * height) / 100), ((20 * width) / 100), ((35 * height) / 100));
            login_panel.SetBounds(((0 * width) / 800), ((0 * height) / 100), ((20 * width) / 100), ((35 * height) / 100));
            login_exit_lbl.SetBounds(((137 * width) / 800), ((9 * height) / 200), ((3 * width) / 200), ((2 * height) / 100));
            login_username_txtbx.SetBounds(((40 * width) / 800), ((61 * height) / 400), ((21 * width) / 200), ((5 * height) / 100));
            login_password_txtbx.SetBounds(((40 * width) / 800), ((160 * height) / 800), ((21 * width) / 200), ((5 * height) / 100));
            login_enter_lbl.SetBounds(((38 * width) / 800), ((200 * height) / 800), ((25 * width) / 200), ((7 * height) / 200));
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

    }
}
