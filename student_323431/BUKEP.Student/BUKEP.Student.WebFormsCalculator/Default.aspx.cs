using BUKEP.Student.Calculator;
using System.Linq;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BUKEP.Student.WebFormsCalculator
{
    public partial class Default : System.Web.UI.Page
    {
        MathCalculator calculator = new MathCalculator();

        protected void ButtonAddNumber(object sender, EventArgs e)
        {
            Button numButton = (Button)sender;

            if (displayText.Text == "0" && numButton.Text != ",")
            {
                displayText.Text = "";
            }

            if (numButton.Text == ",")
            {
                string[] numbers = displayText.Text.Split('+', '-', '*', '/');
                string currentNumber = numbers[numbers.Length - 1];

                if (!currentNumber.Contains(","))
                {
                    displayText.Text += numButton.Text;
                }
            }           
            else
            {
                displayText.Text += numButton.Text;
            }
        }

        protected void DeleteAll(object sender, EventArgs e)
        {
            displayText.Text = "0";
        }

        protected void DeleteSymbol(object sender, EventArgs e)
        {
            if (displayText.Text.Length > 1)
            {
                displayText.Text = displayText.Text.Substring(0, displayText.Text.Length - 1);
            }
            else
            {
                displayText.Text = "0";
            }
        }

        protected void ButtonResult(object sender, EventArgs e)
        {
            try
            {              
                
                    displayText.Text = displayText.Text.Replace(',', '.');
                    displayText.Text = calculator.ResultCalculate(displayText.Text).ToString();
                
            }
            catch (DivideByZeroException)
            {
                displayText.Text = "Ошибка: деление на ноль!";

            }
            catch (InvalidOperationException)
            {
                displayText.Text = "Неизвестная операция";
            }
            catch (Exception)
            {
                displayText.Text = "Неизвестная ошибка";
            }
        }
    }
}