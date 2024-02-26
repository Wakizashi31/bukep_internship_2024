using BUKEP.Student.Calculator;
using System.Linq;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Web.Services.Description;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using BUKEP.Student.Calculator.Data;
using System.Collections.Generic;


namespace BUKEP.Student.WebFormsCalculator
{
    public partial class Default : System.Web.UI.Page
    {
        private readonly string connectionString = WebConfigurationManager.ConnectionStrings["CalculatorDB"].ConnectionString;
        private readonly  CalculatorResult storage;
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
        public Default()
        {
            storage = new CalculatorResult(connectionString);
        }

        protected void ButtonAddElement(object sender, EventArgs e)
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
        private void MoveToResult(int step)
        {
            List<CalculatorStorage> value = storage.GetAll();

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
        protected void DbClearResults(object sender, EventArgs e)
        {
            try
            {
                storage.ClearData();
                displayText.Text = "0";
            }
            catch (Exception)
            {
                displayText.Text = "Ошибка при очистке: ";
            }
        }

        protected void ButtonBeforeResult(object sender, EventArgs e)
        {
            MoveToResult(1);
        }

        protected void ButtonNextResult(object sender, EventArgs e)
        {
            MoveToResult(-1);
        }

        protected void ButtonSaveResult(object sender, EventArgs e)
        {
            try
            {
                double result = Convert.ToDouble(displayText.Text.Replace('=', ' '));
                var CalcResult = new CalculatorStorage() { Value = result };
                storage.Save(result);
            }
            catch (Exception)
            {
                displayText.Text = "Ошибка при сохранении: ";
            }
        }
    }
}