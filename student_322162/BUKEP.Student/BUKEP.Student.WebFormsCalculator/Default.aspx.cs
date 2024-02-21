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
        public MathCalculator calculator = new MathCalculator();

        public InputHandler inputHandler = new InputHandler();

        private readonly string connectionString = WebConfigurationManager.ConnectionStrings["DBCalculator"].ConnectionString;

        private readonly CalculationResultStorage storage;

        public Default()
        {
            storage = new CalculationResultStorage(connectionString);
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                double result = Convert.ToDouble(DisplayResult.Text.Replace('=', ' '));
                var calculationResult = new CalculationResult() { Value = result };
                storage.Save(calculationResult);

                DisplayResult.Text += " - Сохранено";
            }
            catch (Exception ex)
            {
                DisplayResult.Text = "Ошибка при сохранении: " + ex.Message;
            }
        }

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
            List<CalculationResult> value = storage.GetAll();

            if (value.Count == 0)
            {
                DisplayResult.Text = "Нет результатов";
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

            DisplayResult.Text = value[CurrentPosition].Value.ToString();
        }

        protected void ButtonClearAll_Click(object sender, EventArgs e)
        {
            try
            {
                storage.Clear();
                DisplayMathExpression.Text = "0";
                DisplayResult.Text = "0";
            }
            catch (Exception)
            {
                DisplayMathExpression.Text = "Ошибка при очистке: ";
            }
        }

        protected void ButtonInput_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            char newChar = button.Text[0];
            DisplayMathExpression.Text = inputHandler.GetUpdatedInput(DisplayMathExpression.Text, newChar);

            try
            {
                DisplayResult.Text = "=" + calculator.Calculate(inputHandler.ConvertToMathExpression(DisplayMathExpression.Text));
            }
            catch (DivideByZeroException)
            {
                DisplayResult.Text = "деление на ноль!";
            }
            catch (ArgumentException)
            {
                DisplayResult.Text = "неверное выражение!";
            }
            catch (Exception ex)
            {
                DisplayResult.Text = "Ошибка:" + ex.ToString();
            }

        }

        protected void ButtonClear_Click(object sender, EventArgs e)
        {
            DisplayMathExpression.Text = "0";
            DisplayResult.Text = "0";
        }

        protected void ButtonDeleteChar_Click(object sender, EventArgs e)
        {
            if (DisplayMathExpression.Text.Length > 1)
            {
                DisplayMathExpression.Text = DisplayMathExpression.Text.Remove(DisplayMathExpression.Text.Length - 1, 1);
            }
            else
            {
                DisplayMathExpression.Text = "0";
            }
        }

        protected void ButtonResult_Click(object sender, EventArgs e)
        {
            DisplayMathExpression.Text = DisplayResult.Text.Replace('=', ' ');
        }
    }

}