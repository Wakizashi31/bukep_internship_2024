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

            if (char.IsDigit(Convert.ToChar(buttonInput)) || "+-x÷^,()".Contains(Convert.ToChar(buttonInput)))
            {
                displayText = inputHandler.GetUpdatedInput(displayText, Convert.ToChar(buttonInput));
            }

            if (buttonInput == "C")
            {
                displayText = null;
            }

            if (buttonInput == "⌫")
            {
                if (displayText.Length > 0)
                {
                    displayText = displayText.Remove(displayText.Length - 1, 1);
                }
            }

            if (buttonInput == "=")
            {
                displayText = _mathCalculator.Calculate(inputHandler.ConvertToMathExpression(displayText)).ToString();
            }

            if (buttonInput == "M")
            {
                _resultService.Save(Convert.ToDouble(displayText));
            }

            if (buttonInput == "MC")
            {
                //_resultService.Clear();

                displayText = "MC";
            }

            if (buttonInput == "<S")
            {
                displayText = "<S";
            }

            if (buttonInput == "S>")
            {
                displayText = "S>";
            }

            return RedirectToAction("Index", new { display = displayText });
        }

    }
}