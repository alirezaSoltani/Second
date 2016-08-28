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
            this.SetBounds( ((310 * width) / 1000), ((300 * height) / 1000), ((300 * width) / 1000), ((250 * height) / 1000) );
            toolbar_lbl.SetBounds(0, 0, ((300 * width) / 1000), ((45 * height) / 1000));
            icon_lbl.SetBounds((480 * (width / 1000)), (80 * (height / 1000)), (75 * (height / 1000)), (75 * (height / 1000)));
            context_lbl.SetBounds((60 * (width / 1000)), (85 * (height / 1000)), (400 * (width / 1000)), (170 * (height / 1000)));

            
        }
    }
}
