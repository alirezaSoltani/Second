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
        private int width; //Width of system resolution
        private int height;  //Height of system resolution


        public Error(String s)
        {
            InitializeComponent();
            context_lbl.Text = s;
        }


        private void Error_Load(object sender, EventArgs e)
        {
            //*********************************************Design************************************************\\
            width = SystemInformation.PrimaryMonitorSize.Width;
            height = SystemInformation.PrimaryMonitorSize.Height;
            this.SetBounds(((310 * width) / 1000), ((300 * height) / 1000), ((300 * width) / 1000), ((250 * height) / 1000));
            error_panel.SetBounds(((5 * width) / 1000), ((50 * height) / 1000), ((290 * width) / 1000), ((190 * height) / 1000));
            toolbar_lbl.SetBounds(0, 0, ((300 * width) / 1000), ((45 * height) / 1000));
            icon_lbl.SetBounds(((240 * width) / 1000), ((35 * height) / 1000), ((65 * height) / 1000), ((65 * height) / 1000));
            context_lbl.SetBounds(((15 * width) / 1000), ((40 * height) / 1000), ((220 * width) / 1000), ((110 * height) / 1000));
            ok_btn.SetBounds(((15 * width) / 1000), ((145 * height) / 1000), ((70 * width) / 1000), ((32 * height) / 1000));

        }


        private void ok_btn_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
    }
}
