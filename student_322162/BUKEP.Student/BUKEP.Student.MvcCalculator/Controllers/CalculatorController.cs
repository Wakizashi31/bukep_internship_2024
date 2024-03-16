using BUKEP.Student.Calculator.Data;
using BUKEP.Student.Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BUKEP.Student.MvcCalculator.Controllers
{
    public class CalculatorController : Controller
    {
        private InputHandler inputHandler = new InputHandler();

        private readonly ICalculationResultService _resultService;

        private readonly MathCalculator _mathCalculator;

        private int currentPosition = 0;

        public CalculatorController(ICalculationResultService resultService, MathCalculator mathCalculator)
        {
            _resultService = resultService;
            _mathCalculator = mathCalculator;
        }


        public ActionResult Index(string display)
        {
            ViewBag.DisplayText = display;
            return View();
        }

        [HttpPost]
        public ActionResult Calculate(string displayText, string buttonInput)
        {
            if (buttonInput.Length == 1)
            {
                displayText = inputHandler.GetUpdatedInput(displayText, Convert.ToChar(buttonInput));
            }

            if (buttonInput == "ButtonClear")
            {
                displayText = null;
            }

            if (buttonInput == "ButtonDeleteChar")
            {
                if (displayText.Length > 0)
                {
                    displayText = displayText.Remove(displayText.Length - 1, 1);
                }
            }

           if (buttonInput == "ButtonResult")
           {
               try
               {
                    displayText = _mathCalculator.Calculate(inputHandler.ConvertToMathExpression(displayText)).ToString();
               }
               catch (DivideByZeroException)
               {
                   displayText = "Деление на ноль!";
               }
               catch (ArgumentException)
               {
                   displayText = "Неверное выражение!!";
               }
           }
           
            if (buttonInput == "ButtonSave")
            {
                try
                {
                    _resultService.Save(Convert.ToDouble(displayText));
                }
                catch (Exception)
                {
                    displayText = "Ошибка сохранения!";
                }
            }

            if (buttonInput == "ButtonClearAll")
            {
                _resultService.Clear();
            }

            if (buttonInput == "ButtonNextResult")
            {
                if (Session["CurrentPosition"] != null)
                {
                    currentPosition = Convert.ToInt32(Session["CurrentPosition"]);
                }

                MoveToResult(-1);
                List<CalculationResult> value = _resultService.GetAll();

                if (currentPosition >= 0 && currentPosition < value.Count)
                {
                    displayText = value[currentPosition].Value.ToString();
                }
            }

            if (buttonInput == "ButtonPreviousResult")
            {
                if (Session["CurrentPosition"] != null)
                {
                    currentPosition = Convert.ToInt32(Session["CurrentPosition"]);
                }

                MoveToResult(1);
                List<CalculationResult> value = _resultService.GetAll();

                if (currentPosition >= 0 && currentPosition < value.Count)
                {
                    displayText = value[currentPosition].Value.ToString();
                }
            }

            return RedirectToAction("Index", new { display = displayText });
        }

        private void MoveToResult(int step)
        {
            List<CalculationResult> value = _resultService.GetAll();

            if (value.Count == 0)
            {
                return;
            }

            currentPosition += step;

            if (currentPosition < 0)
            {
                currentPosition = 0;
            }
            else if (currentPosition >= value.Count)
            {
                currentPosition = value.Count - 1;
            }

            Session["CurrentPosition"] = currentPosition;
        }

    }
}