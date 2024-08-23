using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StajEmployeeManProje
{
    public partial class MainF : Form
    {
        
        public MainF()
        {
            InitializeComponent();
            controlDash1.Visible = false;
            controllAdd1.Visible = false;
            controlSalary1.Visible = false;
            welcomeThing.Text ="Merhaba " +Form1.Instence.loginUserName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            controllAdd1.Visible = true;
            controlDash1.Visible = false;
            controlSalary1.Visible = false;    
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dashButton_Click(object sender, EventArgs e)
        {
            controlDash1.Visible = true;
            controllAdd1.Visible = false;
            controlSalary1.Visible = false; 
        }

        private void salaryButton_Click(object sender, EventArgs e)
        {
            controlDash1.Visible = false;
            controllAdd1.Visible = false;
            controlSalary1.Visible = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
