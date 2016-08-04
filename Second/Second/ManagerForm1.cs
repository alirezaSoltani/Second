using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace Second
{
    public partial class ManagerForm1 : Form
    {
        private object openFD;

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

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void copyCtrlCToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void manager_studentAdd_bt_Click(object sender, EventArgs e)
        {
            Manager_student_change k = new Manager_student_change();
            k.Show();
        }

        private void manager_lesson_add_bt_Click(object sender, EventArgs e)
        {
            Manager_lesson_change k = new Manager_lesson_change();
            k.Show();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*OpenFileDialog dlg = new OpenFileDialog();
            dlg.ShowDialog();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string fileName;
                fileName = dlg.FileName;
                MessageBox.Show(fileName);
            }
            */

          /* int size = -1;
           DialogResult result = openFileDialog2.ShowDialog(); // Show the dialog.
           if (result == DialogResult.OK) // Test result.
           {
               string file = openFileDialog2.FileName;
               try
               {
                   string text = File.ReadAllText(file);
                   size = text.Length;
               }
               catch (IOException)
               {
               }
           }
           Console.WriteLine(size); // <-- Shows file size in debugging mode.
           Console.WriteLine(result); // <-- For debugging use.*/

            
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
