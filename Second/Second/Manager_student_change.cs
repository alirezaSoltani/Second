using System;
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
    public partial class Manager_student_change : Form
    {
        public Manager_student_change()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void manager_student_update_bt_Click(object sender, EventArgs e)
        {
            PasswordRequest k = new PasswordRequest();
            k.Show();
        }

        private void manager_studentDelet_bt_Click(object sender, EventArgs e)
        {
            PasswordRequest k = new PasswordRequest();
            k.Show();
        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
