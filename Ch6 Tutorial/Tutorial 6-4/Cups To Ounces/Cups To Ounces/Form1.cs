using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cups_To_Ounces
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // The CupsToOunces method accepts a number
        // of cups as an argument and returns the
        // equivalent number of fluid ounces.


        private void CupsToOunces(double cups, out double ounces)
        {
            ounces =  cups * 8.0;
        }
     

        private void convertButton_Click(object sender, EventArgs e)
        {
            double cups, ounces;

            if(double.TryParse(cupsTextBox.Text, out cups))
            {
                CupsToOunces(cups, out ounces);
                ouncesLabel.Text = ounces.ToString("nl");
            }
            else
            {
                MessageBox.Show("Enter a valid number.");
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }
    }
}
