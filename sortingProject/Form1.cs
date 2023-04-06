using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sortingProject
{
    public partial class FormSort : Form
    {
        static int[] ParseTextToIntArr(string txt)
        {
            int[] numbers = new int[10];

            int num = 0;
            int position = 0;
            for (int i = 0; i < txt.Length; i++)
            {
                if (txt[i] >= '0' && txt[i] <= '9')
                {
                    num *= 10;
                    num += txt[i] - '0';
                }
                else if (txt[i] == ',')
                {
                    numbers[position] = num;
                    ++position;
                    num = 0;
                }
            }
            numbers[numbers.Length - 1] = num;
            return numbers;
        }

        public void PauseExecution(double seconds, string speed)
        {
            if (speed == "Super Fast")
            {
                seconds -= seconds * 110 / 100;
            }
            else if (speed == "Slow")
            {
                seconds += (seconds<0.1)?seconds * 10000 / 100:seconds*500/100;
            }
            var t = DateTime.Now;
            DateTime t1;
            do
            {
                t1 = DateTime.Now;
            }
            while ((double)(t1 - t).Seconds <= seconds);
        }

        public void ChangeTextBoxColor(int textBoxIndex, Color color)
        {
            switch (textBoxIndex)
            {
                case 0:
                    textBox0.BackColor = color;
                    break;
                case 1:
                    textBox1.BackColor = color;
                    break;
                case 2:
                    textBox2.BackColor = color;
                    break;
                case 3:
                    textBox3.BackColor = color;
                    break;
                case 4:
                    textBox4.BackColor = color;
                    break;
                case 5:
                    textBox5.BackColor = color;
                    break;
                case 6:
                    textBox6.BackColor = color;
                    break;
                case 7:
                    textBox7.BackColor = color;
                    break;
                case 8:
                    textBox8.BackColor = color;
                    break;
                case 9:
                    textBox9.BackColor = color;
                    break;
            }
            panelSorting.Refresh();
        }

        public Color CheckTextBoxColor(int textBoxIndex)
        {
            Color color = Color.Gold;
            switch (textBoxIndex)
            {
                case 0:
                    color = textBox0.BackColor;
                    break;
                case 1:
                    color = textBox1.BackColor;
                    break;
                case 2:
                    color = textBox2.BackColor;
                    break;
                case 3:
                    color = textBox3.BackColor;
                    break;
                case 4:
                    color = textBox4.BackColor;
                    break;
                case 5:
                    color = textBox5.BackColor;
                    break;
                case 6:
                    color = textBox6.BackColor;
                    break;
                case 7:
                    color = textBox7.BackColor;
                    break;
                case 8:
                    color = textBox8.BackColor;
                    break;
                case 9:
                    color = textBox9.BackColor;
                    break;
            }
            return color;
        }

        public void CleanSortingBoard()
        {
            textBox1.BackColor = Color.White;
            textBox2.BackColor = Color.White;
            textBox3.BackColor = Color.White;
            textBox4.BackColor = Color.White;
            textBox5.BackColor = Color.White;
            textBox6.BackColor = Color.White;
            textBox7.BackColor = Color.White;
            textBox8.BackColor = Color.White;
            textBox0.BackColor = Color.White;
        }

        public void FillTextBoxes(int[] numbers)
        {
            textBox0.Text = numbers[0].ToString();
            textBox1.Text = numbers[1].ToString();
            textBox2.Text = numbers[2].ToString();
            textBox3.Text = numbers[3].ToString();
            textBox4.Text = numbers[4].ToString();
            textBox5.Text = numbers[5].ToString();
            textBox6.Text = numbers[6].ToString();
            textBox7.Text = numbers[7].ToString();
            textBox8.Text = numbers[8].ToString();
            textBox9.Text = numbers[9].ToString();
        }

        public FormSort()
        {
            InitializeComponent();
        }
        
        private void buttonStart_Click(object sender, EventArgs e)
        {
            string speed = comboBoxSpeed.SelectedItem.ToString();
            CleanSortingBoard();
            string text = textBoxInput.Text;
            int[] arr = ParseTextToIntArr(text);
            FillTextBoxes(arr);
            //start
            for (int i = arr.Length - 1; i > 0; i--)
            {
                for (int k = 0; k <= 9; k++)
                {
                    if (CheckTextBoxColor(k) == Color.Red)
                    {
                        ChangeTextBoxColor(k, Color.White);
                    }
                }
                ChangeTextBoxColor(arr.Length - 1, Color.Green);
                int maxIndex = i;
                ChangeTextBoxColor(maxIndex, Color.Blue);
                for (int j = i - 1; j >= 0; j--)
                {
                    ChangeTextBoxColor(j, Color.Yellow);
                    PauseExecution(0.01, speed);
                    if (arr[j] > arr[maxIndex])
                    {
                        if (maxIndex != i)
                            ChangeTextBoxColor(maxIndex, Color.White);
                        maxIndex = j;
                        ChangeTextBoxColor(j, Color.Red);
                        PauseExecution(0.01, speed);
                    }
                    if (CheckTextBoxColor(j) == Color.Yellow)
                        ChangeTextBoxColor(j, Color.White);
                }
                int temp = arr[maxIndex];
                arr[maxIndex] = arr[i];
                arr[i] = temp;
                ChangeTextBoxColor(i, Color.Green);
                FillTextBoxes(arr);
                panelSorting.Refresh();
                PauseExecution(0.5, speed);
            }
            //end
        }
    }
}
