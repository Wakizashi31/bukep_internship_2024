using BUKEP.Student.Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BUKEP.Student.Calculator.Data;
using System.Web.Configuration;

namespace BUKEP.Student.WebFormsCalculator
{
    public partial class Default : System.Web.UI.Page
    {
        private MathCalculator calculator = new MathCalculator();

        private InputHandler inputHandler = new InputHandler();

        private readonly static string connectionString = WebConfigurationManager.ConnectionStrings["DBCalculator"].ConnectionString;

        private readonly CalculationResultContext context = new CalculationResultContext(connectionString);

        private ICalculationResultService calculationResultService;

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
            calculationResultService = new EfCalculationResultService(context);
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                double result = Convert.ToDouble(DisplayText.Text.Replace('=', ' '));
                var calculationResult = new CalculationResult() { Value = result };
                calculationResultService.Save(result);
            }
            catch (Exception)
            {
                DisplayText.Text = "Ошибка при сохранении: ";
            }
        }

        protected void ButtonNextResult_Click(object sender, EventArgs e)
        {
            MoveToResult(-1);
        }

        protected void ButtonPreviousResult_Click(object sender, EventArgs e)
        {
            MoveToResult(1);
        }

        private void MoveToResult(int step)
        {
            List<CalculationResult> value = calculationResultService.GetAll();

            if (value.Count == 0)
            {
                DisplayText.Text = "Нет результатов";
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

            DisplayText.Text = value[CurrentPosition].Value.ToString();
        }

        protected void ButtonClearAll_Click(object sender, EventArgs e)
        {
            try
            {
                calculationResultService.Clear();
                DisplayText.Text = "0";
            }
            catch (Exception)
            {
                DisplayText.Text = "Ошибка при очистке: ";
            }
        }

        protected void ButtonInput_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            char newChar = button.Text[0];
            
            if (DisplayText.Text.Contains('='))
            {
                DisplayText.Text = DisplayText.Text.Replace('=', ' '); 
            }

            if (char.IsLetter(DisplayText.Text[0]))
            {
                DisplayText.Text = "0";
            }

            DisplayText.Text = inputHandler.GetUpdatedInput(DisplayText.Text, newChar);
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
                DisplayText.Text = "=" + calculator.Calculate(inputHandler.ConvertToMathExpression(DisplayText.Text));
            }
            catch (DivideByZeroException)
            {
                DisplayText.Text = "деление на ноль!";
            }
            catch (ArgumentException)
            {
                DisplayText.Text = "неверное выражение!";
            }
            catch (Exception ex)
            {
                DisplayText.Text = "Ошибка:" + ex.ToString();
            }
        }
    }

}