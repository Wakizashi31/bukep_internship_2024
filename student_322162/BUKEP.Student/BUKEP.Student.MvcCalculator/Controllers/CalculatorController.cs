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

            return RedirectToAction("Index", new { display = displayText });
        }

    }
}