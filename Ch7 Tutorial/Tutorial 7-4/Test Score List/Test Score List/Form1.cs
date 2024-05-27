using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Test_Score_List
{
    public partial class Form1 : Form
    {
        List<int> scoresList = new List<int>();
        public Form1()
        {
            InitializeComponent();
        }


        private void getScoresButton_Click(object sender, EventArgs e)
        {
           double average;
           int numAboveAverage;
           int numBelowAverage;
            GetScoresFromFile(scoresList);

            foreach (int value in scoresList)
            {
                testScoresListBox.Items.Add(value);
            }

            average = Average(scoresList);
            averageLabel.Text = average.ToString("n1");

            numAboveAverage = AboveAverage(scoresList,average);
            aboveAverageLabel.Text = numAboveAverage.ToString();

            numBelowAverage = BelowAverage(scoresList,average);
            belowAverageLabel.Text = numBelowAverage.ToString();
        }

        private int BelowAverage(List<int> scoresList, double average)
        {
            //double average = Average(scoresList);
            int numBelow = 0;
            foreach (int value in scoresList)
            {
                if (value < average)
                {
                    numBelow++;
                }
            }
            return numBelow;
        }

        private int AboveAverage(List<int> scoresList,double average)
        {
            //double average = Average(scoresList);
            int numAbove = 0;
            foreach (int value in scoresList)
            {
                if(value > average)
                {
                    numAbove++;
                }
            }
            return numAbove;
        }

        private double Average(List<int> scoresList)
        {
            int sum = 0;
            //for (int i = 0; i < scores.Length; i++)
            //{
                //sum += scores[i]; //sum = sum + scores[i]

            //}
            foreach (int value in scoresList)
            {
                sum += value;
            }
            //MessageBox.Show("SUM = " + sum);
            return (double)sum / scoresList.Count; //casting
        }

        private void GetScoresFromFile(List<int> scoresList)
        {
            StreamReader inputFile = null;
            int index = 0;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                inputFile = File.OpenText(openFile.FileName);

                while (!inputFile.EndOfStream)
                {
                    scoresList.Add(int.Parse(inputFile.ReadLine()));
                }
            }
            else
            {
                MessageBox.Show("已取消");
            }
            inputFile.Close();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }

        private void delButton_Click(object sender, EventArgs e)
        {
            int pos = int.Parse(indexTextBox.Text);
            if (pos >= 0 && pos < scoresList.Count)
            {
                scoresList.RemoveAt(pos);
                testScoresListBox.Items.Clear();
                foreach (int value in scoresList)
                {
                    testScoresListBox.Items.Add(value);
                }
            }
        }
    }
}
