using BUKEP.Student.Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BUKEP.Student.WebFormsCalculator
{
    public partial class Default : System.Web.UI.Page
    {
        public MathCalculator calculator = new MathCalculator();

        public InputHandler inputHandler = new InputHandler();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonInput_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            char newChar = button.Text[0];
            TextBox1.Text = inputHandler.GetUpdatedInput(TextBox1.Text, newChar);
        }

        protected void ButtonClear_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "0";
        }

        protected void ButtonDeleteChar_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text.Length > 1)
            {
                TextBox1.Text = TextBox1.Text.Remove(TextBox1.Text.Length - 1, 1);
            }
            else
            {
                TextBox1.Text = "0";
            }
        }

        protected void ButtonResult_Click(object sender, EventArgs e)
        {
            try
            {
                bool symbolEqual = TextBox1.Text.Contains('=');

                if (!symbolEqual)
                {
                    TextBox1.Text += " = " + calculator.Calculate(MathExpressionFormat(TextBox1.Text));
                }
            }
            catch (DivideByZeroException)
            {
                TextBox1.Text += " = " + "деление на ноль!";
            }
            catch (ArgumentException)
            {
                TextBox1.Text += " = " + "математическое выржение не удалось преобразовать!";
            }
            catch (Exception ex)
            {
                TextBox1.Text = "Ошибка:" + ex.ToString();
            }
        }

        public string MathExpressionFormat(string input)
        {
            input = input.Replace('÷','/');
            input = input.Replace(',', '.');
            input = input.Replace('x', '*');
            
            return input;
        }
    }
}