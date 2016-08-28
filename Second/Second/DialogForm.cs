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
    public partial class DialogForm : Form
    {
        private Form callerForm;
        private int width; //Width of system resolution
        private int height;  //Height of system resolution
        private string iconName;// Error/informationIcon

        public DialogForm(String context, string title, string icon, Form managerFormObject)
        {
            InitializeComponent();

            callerForm = managerFormObject;
            callerForm.Enabled = false;

            titleBar_lbl.Text = title;
            context_lbl.Text = context;
            iconName = icon;

            this.Show();
        }


        private void Error_Load(object sender, EventArgs e)
        {
            //*********************************************Design************************************************\\
            width = SystemInformation.PrimaryMonitorSize.Width;
            height = SystemInformation.PrimaryMonitorSize.Height;
            this.SetBounds(((340 * width) / 1000), ((300 * height) / 1000), ((300 * width) / 1000), ((300 * height) / 1000));
            error_panel.SetBounds(((5 * width) / 1000), ((50 * height) / 1000), ((290 * width) / 1000), ((240 * height) / 1000));
            titleBar_lbl.SetBounds(0, 0, ((300 * width) / 1000), ((45 * height) / 1000));
            icon_lbl.SetBounds(((237 * width) / 1000), ((35 * height) / 1000), ((65 * height) / 1000), ((65 * height) / 1000));
            context_lbl.SetBounds(((15 * width) / 1000), ((40 * height) / 1000), ((220 * width) / 1000), ((160 * height) / 1000));
            ok_btn.SetBounds(((15 * width) / 1000), ((195 * height) / 1000), ((80 * width) / 1000), ((37 * height) / 1000));

            if(iconName == "error")
            {
                icon_lbl.BackgroundImage = Second.Properties.Resources.error_icon;
            }

            else if (iconName == "information")
            {
                icon_lbl.BackgroundImage = Second.Properties.Resources.info_icon;
            }

            else if (iconName == "success")
            {
                icon_lbl.BackgroundImage = Second.Properties.Resources.success_icon;
            }
        }


        private void ok_btn_Click(object sender, EventArgs e)
        {
            this.Close();
            callerForm.Enabled = true;
            callerForm.TopLevel = true;
        }
    }
}
