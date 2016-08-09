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
    public partial class Error : Form
    {
        public String k;
        public Error()
        {
            k = "hi";
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
      /*  private void lable4 (object sender , EventArgs e)
        {
            label4.Text = k;
            
        }*/

        private void button1_Click(object sender, EventArgs e)
        {
            label4.Text = "";
            label4.Text = k;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
