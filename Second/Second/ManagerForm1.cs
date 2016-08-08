using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using Test;

namespace Second
{
    public partial class ManagerForm1 : Form
    {
        private object openFD;
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        public ManagerForm1()
        {
            InitializeComponent();
        }

        private void ManagerForm1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projectDataSet.teacherTable' table. You can move, or remove it, as needed.
            // this.teacherTableTableAdapter.Fill(this.projectDataSet.teacherTable);
            dataGridView1.DataSource = bindingSource1;
            GetData("SELECT * FROM teacherTable");

            dataGridView3.DataSource = bindingSource2;
            GetData3("SELECT DISTINCT lesson# , lessonGroup# ,lessonName FROM lessonTable");

        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void manager_teacherAdd_bt_Click(object sender, EventArgs e)
        {
            //this.Enabled=false;

            TeacherModel teacherObj = new TeacherModel();
           
            teacherObj.setTeacherNumber(long.Parse(manager_teacherNumber_add_txt.Text));
            teacherObj.setTeacherFName(manager_teacherFName_add_txt.Text);
            teacherObj.setTeacherLName(manager_teacherLName_add_txt.Text);
            teacherObj.setTeacherPassword(manager_techerPassword_add_txt.Text);
            teacherObj.setTeacherURL("");

            teacherObj.addTeacher();
            MessageBox.Show("استاد مورد نظر افزوده شد ");
            manager_teacherNumber_add_txt.Text="";
            manager_teacherFName_add_txt.Text="";
            manager_teacherLName_add_txt.Text="";
            manager_techerPassword_add_txt.Text = "";


            /*Manager_techer_change k = new Manager_techer_change();
            k.Show();*/
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

            LessonModel lessonObj = new LessonModel();
            //lessonObj.lessonNumber



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

       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void GetData(string selectCommand)
        {
            try
            {
                // Specify a connection string. Replace the given value with a 
                // valid connection string for a Northwind SQL Server sample
                // database accessible to your system.
                String connectionString = "Data Source= 185.159.152.5;" +
                    "Initial Catalog=youshita_Test;" +
                    "User id=youshita_co; " +
                    "Password=P@hn1395;";

                // Create a new data adapter based on the specified query.
                dataAdapter = new SqlDataAdapter(selectCommand, connectionString);

                // Create a command builder to generate SQL update, insert, and
                // delete commands based on selectCommand. These are used to
                // update the database.

                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                // Populate a new data table and bind it to the BindingSource.
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table);
                bindingSource1.DataSource = table;
               

                // Resize the DataGridView columns to fit the newly loaded content.
                dataGridView1.AutoResizeColumns(
                    DataGridViewAutoSizeColumnsMode.AllCells);
                dataGridView1.AutoResizeRows(
                   DataGridViewAutoSizeRowsMode.AllCells);

              

            }
            catch (SqlException)
            {
                MessageBox.Show("To run this example, replace the value of the " +
                    "connectionString variable with a connection string that is " +
                    "valid for your system.");
            }
        }
        private void GetData3(string selectCommand)
        {
            try
            {
                // Specify a connection string. Replace the given value with a 
                // valid connection string for a Northwind SQL Server sample
                // database accessible to your system.
                String connectionString = "Data Source= 185.159.152.5;" +
                    "Initial Catalog=youshita_Test;" +
                    "User id=youshita_co; " +
                    "Password=P@hn1395;";

                // Create a new data adapter based on the specified query.
                dataAdapter = new SqlDataAdapter(selectCommand, connectionString);

                // Create a command builder to generate SQL update, insert, and
                // delete commands based on selectCommand. These are used to
                // update the database.

                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                // Populate a new data table and bind it to the BindingSource.
                DataTable table2 = new DataTable();
                table2.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table2);
                bindingSource2.DataSource = table2;


                // Resize the DataGridView columns to fit the newly loaded content.
                dataGridView3.AutoResizeColumns(
                    DataGridViewAutoSizeColumnsMode.AllCells);
                dataGridView3.AutoResizeRows(
                   DataGridViewAutoSizeRowsMode.AllCells);



            }
            catch (SqlException)
            {
                MessageBox.Show("To run this example, replace the value of the " +
                    "connectionString variable with a connection string that is " +
                    "valid for your system.");
            }
        }
    }
}
