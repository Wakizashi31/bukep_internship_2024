using BUKEP.Student.Calculator;
using BUKEP.Student.Calculator.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web.Configuration;
using System.Web.UI.WebControls;
using System.Xml.Linq;


namespace BUKEP.Student.WebFormsCalculator
{
    public partial class Default : System.Web.UI.Page
    {
        private readonly static string connectionString = WebConfigurationManager.ConnectionStrings["CalculatorDB"].ConnectionString;
      
        private ICalculationResultService calculationResultService = new EFCalculationResultService(connectionString);

        private int CurrentPosition
        {
            get
            {
                if (ViewState["CurrentPosition"] != null)
                    return (int)ViewState["CurrentPosition"];
                return 0;
            }
            set
            {
                ViewState["CurrentPosition"] = value;
            }
        }

        protected void bElement_click(object sender, EventArgs e)
        {
            Button numButton = (Button)sender;

            if (displayText.Text == "0" && numButton.Text != ",")
            {
                displayText.Text = "";
            }          
            if (numButton.Text == ",")
            {
                string[] numbers = displayText.Text.Split('+', '-', '*', '/', '^');
                string currentNumber = numbers[numbers.Length - 1];

                if (!currentNumber.Contains(","))
                {
                    displayText.Text += numButton.Text;
                }
            }
            else if (displayText.Text.Length > 0 && "+-*/^".Contains(numButton.Text) && "+-*/^".Contains(displayText.Text.Last()))
            {
                displayText.Text = displayText.Text.Replace(numButton.Text, numButton.Text);
            }
            else
            {
                displayText.Text += numButton.Text;
            }
        }

        protected void bDeleteAll_click(object sender, EventArgs e)
        {
            displayText.Text = "0";
        }

        protected void bDeleteSymbol_click(object sender, EventArgs e)
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
        
        protected void bResult_click(object sender, EventArgs e)
        {
            MathCalculator calculator = new MathCalculator();

            try
            {
                displayText.Text = displayText.Text.Replace(',', '.');
                displayText.Text = calculator.ResultCalculate(displayText.Text).ToString();
            }
            catch (DivideByZeroException)
            {
                displayText.Text = "Деление на ноль!";
                

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

        /// <summary>
        /// Перейти к результату
        /// </summary>
        private void MoveToResult(int step)
        {
            List<CalculationResult> value = calculationResultService.GetAll();

            if (value.Count == 0)
            {
                displayText.Text = "Нет результатов";
                return;
            }

            CurrentPosition += step;

            if (CurrentPosition < 0)
            {
                CurrentPosition = 0;
            }
            else if (CurrentPosition >= value.Count)
            {
                CurrentPosition = value.Count - 1;
            }

            displayText.Text = value[CurrentPosition].Value.ToString();
        }

        protected void bDbClearResults_click(object sender, EventArgs e)
        {
            try
            {
                calculationResultService.ClearData();
                displayText.Text = "0";
            }
            catch (Exception)
            {
                displayText.Text = "Ошибка при очистке: ";
            }
        }

        protected void bBeforeResult_click(object sender, EventArgs e)
        {
            MoveToResult(-1);
        }

        protected void bNextResult_click(object sender, EventArgs e)
        {
            MoveToResult(1);
        }

        protected void bSaveResult_click(object sender, EventArgs e)
        {
            try
            {
                double result = Convert.ToDouble(displayText.Text);
                calculationResultService.Save(result);
            }
            catch (Exception)
            {
                displayText.Text = "Ошибка при сохранении: ";
            }
        }
    }
}