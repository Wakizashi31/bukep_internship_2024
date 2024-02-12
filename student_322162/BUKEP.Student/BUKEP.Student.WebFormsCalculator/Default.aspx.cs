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

        protected void ButtonInput_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (!DisplayText.Text.Contains('='))
            {
                char newChar = button.Text[0];
                DisplayText.Text = inputHandler.GetUpdatedInput(DisplayText.Text, newChar);
            }
        }

        protected void ButtonClear_Click(object sender, EventArgs e)
        {
            DisplayText.Text = "0";
        }

        protected void ButtonDeleteChar_Click(object sender, EventArgs e)
        {
            if (DisplayText.Text.Length > 1)
            {
                DisplayText.Text = DisplayText.Text.Remove(DisplayText.Text.Length - 1, 1);
            }
            else
            {
                DisplayText.Text = "0";
            }
        }

        protected void ButtonResult_Click(object sender, EventArgs e)
        {
            try
            {
                if (!DisplayText.Text.Contains('='))
                {
                    DisplayText.Text += " = " + calculator.Calculate(inputHandler.ConvertToMathExpression(DisplayText.Text));
                }
            }
            catch (DivideByZeroException)
            {
                DisplayText.Text += " = " + "деление на ноль!";
            }
            catch (ArgumentException)
            {
                DisplayText.Text += " = " + "математическое выржение не удалось преобразовать!";
            }
            catch (Exception ex)
            {
                DisplayText.Text = "Ошибка:" + ex.ToString();
            }
        }
    }
}