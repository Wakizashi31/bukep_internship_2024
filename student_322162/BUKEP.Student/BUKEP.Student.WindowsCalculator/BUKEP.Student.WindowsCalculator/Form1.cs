using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUKEP.Student.Calculator;

namespace BUKEP.Student.WindowsCalculator
{
    public partial class Form1 : Form
    {
        private InputHandler InputHandler = new InputHandler();
        
        private MathCalculator calculator = new MathCalculator();

        public Form1()
        {
            InitializeComponent();
        }

        private void ButtonInput_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            char newChar = button.Text[0]; 
            textBox1.Text = InputHandler.GetUpdatedInput(textBox1.Text, newChar);
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void ButtonDeleteChar_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
            }
        }

        private void ButtonResult_Click(object sender, EventArgs e)
        {
            try
            {
                bool symbolEqual = textBox1.Text.Contains('=');

                if (!symbolEqual)
                {
                    textBox1.Text += " = " + calculator.Calculate(textBox1.Text);
                }
                else
                {
                    MessageBox.Show("Результат выражения уже получен.");
                }
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("Деление на ноль.");
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Математическое выражение не удалось преобразовать.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex);
            }
        }
    }
}
