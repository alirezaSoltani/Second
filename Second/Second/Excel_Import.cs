using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test;

namespace Second
{
    public partial class Excel_Import : Form
    {
        /// <summary>
        /// MultiResolution Attributes
        /// </summary>
            private int width; //Width of system resolution
            private int height;  //Height of system resolution
        /// <summary>
        /// MultiResolution Attributes
        /// </summary>
        /// 


        /// <summary>
        /// Data gridview attributes
        /// </summary>
            private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        /// <summary>
        /// Data gridview attributes
        /// </summary>
        /// 


        /// <summary>
        /// Project temp attributes
        /// </summary>
            private bool hasError = false;
            private bool hasRegister = false;
            private bool hasRepeat = false;
            private string repeats = "";
            private string currentLessonNumber = "50";
            private string currentLessonGroupNumber = "10";
        /// <summary>
        /// Project temp attributes
        /// </summary>
        /// 

        public Excel_Import(string lessonNumber, string lessonGroupNumber)
        {
            InitializeComponent();

            currentLessonNumber = lessonNumber;
            currentLessonGroupNumber = lessonGroupNumber;
        }
        
        private void Excel_Import_Load(object sender, EventArgs e)
        {
            width = SystemInformation.PrimaryMonitorSize.Width;
            height = SystemInformation.PrimaryMonitorSize.Height;



            //*** MultiResolution
            this.SetBounds(((1 * width) / 5), ((1 * height) / 5), ((3 * width) / 5), ((3 * height) / 5));
            dataGridView_panel.SetBounds(((5 * width) / 500), ((8 * height) / 500), ((171 * width) / 300), ((47 * height) / 100));
            dataGridView1.SetBounds(((5 * width) / 500), ((5 * height) / 500), ((165 * width) / 300), ((45 * height) / 100));
            Options_panel.SetBounds(((5 * width) / 500), ((250 * height) / 500), ((171 * width) / 300), ((5 * height) / 100));

            finalRegister_btn.SetBounds(((5 * width) / 400), ((2 * height) / 200), ((80 * width) / 1000), ((32 * height) / 1000));
            cancel_btn.SetBounds(((40 * width) / 400), ((2 * height) / 200), ((80 * width) / 1000), ((32 * height) / 1000));
            information_lbl.SetBounds(((80 * width) / 400), ((1 * height) / 200), ((360 * width) / 1000), ((32 * height) / 1000));
            information_lbl.Text = " * برای افزودن اطلاعات فوق به درس شماره " + currentLessonNumber + " با شماره گروه " + currentLessonGroupNumber + "برروی دکمه ثبت نهایی اطلاعات کلیک کنید.";
            //*** MultiResolution



            //***dataGridView init
            dataGridView1.RowHeadersWidth = (width / 25);
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "افزودن فایل اکسل";
            fileDialog.Filter = "All Excel Files|*.xlsx;*.xls";
            fileDialog.InitialDirectory = @"D:\temp";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileDirectory = fileDialog.FileName;
                //MessageBox.Show(fileDirectory);

                //***Importing excel to gridview
                System.Data.OleDb.OleDbConnection MyConnection;
                System.Data.DataSet DtSet;
                System.Data.OleDb.OleDbDataAdapter MyCommand;
                MyConnection = new System.Data.OleDb.OleDbConnection(@"provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + fileDirectory + "';Extended Properties=Excel 8.0;");
                MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", MyConnection);
                MyCommand.TableMappings.Add("Table", "Net-informations.com");
                DtSet = new System.Data.DataSet();
                MyCommand.Fill(DtSet);
                dataGridView1.DataSource = DtSet.Tables[0];
                MyConnection.Close();
                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    dataGridView1.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
                }

                //***enable Final Register Button
                finalRegister_btn.Enabled = true;
            }
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
                dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);

            }
            catch (SqlException)
            {
                MessageBox.Show("1- To run this example, replace the value of the " +
                    "connectionString variable with a connection string that is " +
                    "valid for your system.");
            }
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void finalRegister_btn_Click(object sender, EventArgs e)
        {
            ///////////////////////////////////////////////////ADD Group/////////////////////////////////////////////////////
            StudentModel studentObj = new StudentModel();

            if (MessageBox.Show("آیا از ثبت نهایی اطلاعات مطمئن هستید؟", "ثبت نهایی", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    try
                    {
                        studentObj.setStudentNumber(long.Parse(dataGridView1.Rows[r.Index].Cells[0].Value.ToString()));
                        studentObj.setStudentFName(dataGridView1.Rows[r.Index].Cells[1].Value.ToString());
                        studentObj.setStudentLName(dataGridView1.Rows[r.Index].Cells[2].Value.ToString());
                        studentObj.addStudent(long.Parse(currentLessonNumber), int.Parse(currentLessonGroupNumber));
                        hasRegister = true;
                    }
                    catch (SqlException ee)
                    {
                        if (ee.Message.Contains("PRIMARY"))
                        {
                            hasRepeat = true;
                            repeats = repeats + studentObj.getStudentNumber()+ "، ";
                        }
                    }
                    catch(FormatException ee)
                    {
                        hasError = true;
                        MessageBox.Show("!خطای فایل ورودی", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                }

                if (hasRegister && !hasError)
                {
                    MessageBox.Show("اطلاعات (غیرتکراری) در لیست کلاس افزوده شدند.");
                }
                else if (!hasError)
                {
                    MessageBox.Show(".تمامی اطلاعات تکراری هستند");
                }

                if (hasRepeat && hasRegister && !hasError)
                {
                    repeats = "شماره های دانشجویی " + repeats + "تکراری بوده و ثبت نشدند.";
                    MessageBox.Show(repeats);
                }
            }
            this.Close();
        }
    }
}
