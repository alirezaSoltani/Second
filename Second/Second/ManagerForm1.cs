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
    public partial class ManagerForm1 : Form
    {
        public ManagerForm1()
        {
            InitializeComponent();
        }

        private void ManagerForm1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projectDataSet.teacherTable' table. You can move, or remove it, as needed.
            this.teacherTableTableAdapter.Fill(this.projectDataSet.teacherTable);

        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void manager_teacherAdd_bt_Click(object sender, EventArgs e)
        {
            //this.Enabled=false;
            Manager_techer_change k = new Manager_techer_change();
            k.Show();
        }
    }
}
