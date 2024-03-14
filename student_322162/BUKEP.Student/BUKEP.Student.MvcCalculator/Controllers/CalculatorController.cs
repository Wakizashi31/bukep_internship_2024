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
                displayText = _mathCalculator.Calculate(inputHandler.ConvertToMathExpression(displayText)).ToString();
            }

            if (buttonInput == "ButtonSave")
            {
                _resultService.Save(Convert.ToDouble(displayText));
            }

            if (buttonInput == "ButtonClearAll")
            {
                _resultService.Clear();
            }

            if (buttonInput == "ButtonNextResult")
            {
                displayText = "<S";
            }

            if (buttonInput == "ButtonPreviousResult")
            {
                displayText = "S>";
            }

            return RedirectToAction("Index", new { display = displayText });
        }

    }
}