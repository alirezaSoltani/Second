﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Second
{
    public partial class Manager_lesson_change : Form
    {
        public Manager_lesson_change()
        {
         //   InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void manager_lesson_update_bt_Click(object sender, EventArgs e)
        {
            PasswordRequest k = new PasswordRequest();
            k.Show();
        }

        private void manager_lesson_delet_bt_Click(object sender, EventArgs e)
        {
            PasswordRequest k = new PasswordRequest();
            k.Show();
        }
    }
}
