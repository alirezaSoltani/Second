﻿using System;
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
    public partial class Manager_techer_change : Form
    {
        public Manager_techer_change()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManagerForm1 l = new ManagerForm1();

        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void teacher_update_bt_Click(object sender, EventArgs e)
        {
            if (teacher_teacherNumber_update_txt.Text != "" && teacher_FName_update_txt.Text != "" && teacher_LName_update_txt.Text != "" && teacher_password_update_txt.Text != "")
            {

                PasswordRequest k = new PasswordRequest();
                k.Show();


                if (k.authenPass() == true)
                {
                    TeacherModel teacherObj = new TeacherModel();
                    teacherObj.setTeacherFName(teacher_FName_update_txt.Text);
                    teacherObj.setTeacherLName(teacher_LName_update_txt.Text);
                    teacherObj.setTeacherNumber(Int64.Parse(teacher_teacherNumber_update_txt.Text));
                    teacherObj.setTeacherPassword(teacher_password_update_txt.Text);
                    teacherObj.setTeacherURL("");

                    teacherObj.updateTeacher();

                }
            }
            else
            {
                MessageBox.Show("اطلاعات را به طور کامل وارد کنید");
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void teacher_FName_update_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void techer_username_update_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void closeAltF4ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void copyCtrlCToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pastCtrlVToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void teacher_delet_bt_Click(object sender, EventArgs e)
        {
            if (teacherTeacherNumber_delet_txt.Text != "")
            {


                PasswordRequest k = new PasswordRequest();
                k.Show();


                if (k.authenPass() == true)
                {
                    TeacherModel teacherObj = new TeacherModel();

                    teacherObj.setTeacherNumber(Int64.Parse(teacher_teacherNumber_update_txt.Text));


                    teacherObj.deleteTeacher();

                }
            }
            else
            {
                MessageBox.Show("شماره استاد را وارد کنید");
            }

        }
   
        

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void teacherTeacherNumber_delet_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void teacher_teacherNumber_update_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void techer_password_update_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void teacher_LName_update_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
