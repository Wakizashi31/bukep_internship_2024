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

        [HttpGet]
        public ActionResult Index(string display)
        {
            ViewBag.DisplayText = display;
            return View();
        }

        public ActionResult CalculateResult(string display)
        {
            string result = _mathCalculator.Calculate(display).ToString();
            return RedirectToAction("Index", new { display = result });
            //return View();
        }
    }
}