using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test;

namespace Second
{
    public partial class login1 : Form
    {
        private int width = SystemInformation.PrimaryMonitorSize.Width;
        private int height = SystemInformation.PrimaryMonitorSize.Height;

        private int userType = 0;
        private long username = -256;
        private string password = "";

        public login1()
        {
            InitializeComponent();
            this.BackColor = Color.Gainsboro;
            this.TransparencyKey = Color.Gainsboro;
        }
       
        private void login1_Load(object sender, EventArgs e)
        {
            this.SetBounds(((390 * width) / 1000), ((150* width) / 1000), ((205 * width) / 1000), ((205 * width) / 1000));
            login_panel.SetBounds(((0 * width) / 800), ((0 * height) / 100), ((205 * width) / 1000), ((205 * width) / 1000));
            logo_pictureBox.SetBounds(((33 * width) / 800), ((40 * height) / 800), ((30 * width) / 200), ((12 * height) / 200));
            login_username_txtbx.SetBounds(((23 * width) / 800), ((153 * height) / 1000), ((26 * width) / 200), ((35 * height) / 1000));
            login_password_txtbx.SetBounds(((23 * width) / 800), ((208 * height) / 1000), ((26 * width) / 200), ((35 * height) / 1000));
            login_enter_lbl.SetBounds(((21 * width) / 800), ((210 * height) / 800), ((30 * width) / 200), ((8 * height) / 200));
            exit_pictureBox.SetBounds(((142 * width) / 800), ((25 * height) / 800), ((5 * height) / 200), ((5 * height) / 200));
            showPassword_pictureBox.SetBounds(((130 * width) / 800), ((208 * height) / 1000), ((25 * height) / 1000), ((25 * height) / 1000));
        }
        
        private void label1_Click(object sender, EventArgs e)
        {
            try
            {
                login_Authenticator();
            }
            catch (SqlException)
            {
                DialogForm dialog = new DialogForm("اشکال در برقراری ارتباط با سرور", "خطا", "error", this);
            }
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

        private void showPassword_pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            showPassword_pictureBox.Visible = false;
            login_password_txtbx.PasswordChar = '\0';
        }

        private void showPassword_pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            showPassword_pictureBox.Visible = true;
            login_password_txtbx.PasswordChar = '●';
        }

        private void login_enter_lbl_MouseEnter(object sender, EventArgs e)
        {
            login_enter_lbl.ForeColor = Color.LightSkyBlue;
        }

        private void login_enter_lbl_MouseLeave(object sender, EventArgs e)
        {
            login_enter_lbl.ForeColor = Color.White;
        }

        private void login_username_txtbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13)
                {
                    login_Authenticator();
                }
            }
            catch (SqlException)
            {
                DialogForm dialog = new DialogForm("اشکال در برقراری ارتباط با سرور", "خطا", "error", this);
            }
        }

        private void login_password_txtbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13)
                {
                    login_Authenticator();
                }
            }
            catch (SqlException)
            {
                DialogForm dialog = new DialogForm("اشکال در برقراری ارتباط با سرور", "خطا", "error", this);
            }
        }

        private void login_Authenticator()
        {
            userType = 0;
            if (login_username_txtbx.Text != "" && login_password_txtbx.Text != "")
            {
                TeacherModel teacher = new TeacherModel();
                try
                {
                    username = long.Parse(login_username_txtbx.Text);
                    password = login_password_txtbx.Text;
                    userType = teacher.Authenticator(username, password);
                }
                catch (FormatException)
                {
                    userType = -1;
                    DialogForm dialog = new DialogForm("نام کاربری اشتباه است.", "خطا", "error", this);
                }

                if (userType == 1)
                {
                    this.Hide();
                    ManagerForm1 form = new ManagerForm1(-1, password, userType, username);
                    form.Show();
                }
                else if (userType == 2)
                {
                    this.Hide();
                    ManagerForm1 form = new ManagerForm1(-1, password, userType, username);
                    form.Show();
                }
                else if (userType == 3)
                {
                    this.Hide();
                    ManagerForm1 form = new ManagerForm1(username, password, userType, -2);
                    form.Show();
                }
                else if (userType == 0)
                {
                    DialogForm dialog = new DialogForm("نام کاربری یا رمز عبور اشتباه است.", "خطا", "error", this);
                }
            }
            else
            {
                DialogForm dialog = new DialogForm("نام کاربری و رمز عبور را وارد کنید.", "خطا", "error", this);
            }
        }
    }
}
