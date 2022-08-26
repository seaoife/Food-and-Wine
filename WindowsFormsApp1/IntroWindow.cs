using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class IntroWindow : Form
    {
        public IntroWindow()
        {
            InitializeComponent();

           
                  
            textBox1IntoMessage.Text = "RECIPES FOR YOU\r\n\r\nUsing ingredients of your choice find the perfect food and wine for your meal.\r\n\r\nJust press on the Button below";

        }

        private void Button1ToPage2_Click(object sender, EventArgs e)
        {
            
                F_W newF_W = new F_W();
                newF_W.Show();
                this.Hide();
            

        }
    }
}
