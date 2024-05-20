using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lottery_Numbers
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            int[] lotterNumbers = new int[5];
            Random rand = new Random();
            Label[] labelsArray = {firstLabel, secondLabel, thirdLabel, fourthLabel, fifthLabel};

            for(int i =0; i < lotterNumbers.Length; i++) //陣列巡行
            {
                lotterNumbers[i] = rand.Next(42) + 1;
            }

            //firstLabel.Text = lotterNumbers[0].ToString();
            //secondLabel.Text = lotterNumbers[1].ToString();
            //thirdLabel.Text = lotterNumbers[2].ToString();
            //fourthLabel.Text = lotterNumbers[3].ToString();
            //fifthLabel.Text = lotterNumbers[4].ToString();

            for(int i = 0; i < labelsArray.Length; i++)
            {
                labelsArray[i].Text = lotterNumbers[i].ToString();
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }
    }
}
