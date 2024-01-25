using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUKEP.Student.WindowsCalculator
{
    public partial class Form1 : Form
    {
        public bool flag;
        public string tempParametr;
        public string act;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            Button numButton = (Button)sender;
            int tempNumber;
            bool isNum = int.TryParse(numButton.Text, out tempNumber);
            if (flag)
            {
                flag = false;
                TextBox.Text = "0";
            }
            if (TextBox.Text == "0" && isNum)
            {
                TextBox.Text = numButton.Text;
            }
            else
            {
                if (!numButton.Text.Contains(",") && numButton.Text == ",")
                {
                    TextBox.Text = TextBox.Text + numButton.Text;
                }
                else
                {
                    TextBox.Text = TextBox.Text + numButton.Text;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextBox.Text = "0";
        }


        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (char.IsDigit(number))
            {
                e.Handled = true;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Button buttonAct = (Button)sender;
            act = buttonAct.Text;
            tempParametr = TextBox.Text;
            flag = true;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            double firstVar, secondVar, result = 0;
            Double.TryParse(tempParametr, out firstVar);
            Double.TryParse(TextBox.Text, out secondVar);
            switch (act)
            {
                case "+":
                    result = firstVar + secondVar;
                    break;
                case "-":
                    result = firstVar - secondVar;
                    break;
                case "×":
                    result = firstVar * secondVar;
                    break;
                case "÷":
                    result = firstVar / secondVar;
                    break;
            }
            TextBox.Text = result.ToString();
            flag = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (TextBox.Text != "0")
            {
                TextBox.Text = TextBox.Text.Substring(0, TextBox.Text.Length - 1);
            }
            else
            {
                TextBox.Text = "0";
            }
        }
    }
}

