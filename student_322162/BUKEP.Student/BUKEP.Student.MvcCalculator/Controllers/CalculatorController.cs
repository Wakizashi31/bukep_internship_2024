using BUKEP.Student.Calculator.Data;
using BUKEP.Student.Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Runtime.CompilerServices;

namespace BUKEP.Student.MvcCalculator.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly ICalculationResultService _resultService;

        private readonly MathCalculator _mathCalculator;

        public CalculatorController(ICalculationResultService resultService, MathCalculator mathCalculator)
        {
            _resultService = resultService;
            _mathCalculator = mathCalculator;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public void SaveResult(string expression)
        {
            _resultService.Save(Convert.ToDouble(expression));
        }

        [HttpPost]
        public void ClearDB()
        {
            _resultService.Clear();
        }

        [HttpPost]
        public JsonResult GetAllResults()
        {
            List<CalculationResult> results = _resultService.GetAll();
            return Json(results);
        }

        [HttpPost]
        public JsonResult CalculateResult(string expression)
        {
            try
            {
                string result = _mathCalculator.Calculate(ConvertToMathExpression(expression)).ToString();
                return Json(result);
            }
            catch (DivideByZeroException)
            {
                return Json("Деление на ноль!");
            }
            catch (ArgumentException)
            {
                return Json("Неверное выражение!");
            }
        }

        private string ConvertToMathExpression(string input)
        {
            input = input.Replace('÷', '/');
            input = input.Replace(',', '.');
            input = input.Replace('x', '*');

            return input;
        }
    }
}