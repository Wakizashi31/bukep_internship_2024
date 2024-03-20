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
        private readonly ICalculationResultService _resultService;

        private readonly MathCalculator _mathCalculator;

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

        [HttpPost]
        public JsonResult SaveResult(string display)
        {
            try
            {
                _resultService.Save(Convert.ToDouble(display));
                return Json(display);
            }
            catch
            {
                return Json("Ошибка сохранения!");
            }
        }

        [HttpPost]
        public JsonResult ClearDB(string display)
        {
            try
            {
                _resultService.Clear();
                return Json(display);
            }
            catch
            {
                return Json("Ошибка очистки!");
            }
        }

        [HttpPost]
        public JsonResult GetAllResults()
        {
            try
            {
                List<CalculationResult> results = _resultService.GetAll();
                return Json(results);
            }
            catch
            {
                return Json("Ошибка при получении результатов!");
            }
        }

        [HttpPost]
        public JsonResult CalculateResult(string display)
        {
            try
            {
                string result = _mathCalculator.Calculate(ConvertToMathExpression(display)).ToString();
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

        public string ConvertToMathExpression(string input)
        {
            input = input.Replace('÷', '/');
            input = input.Replace(',', '.');
            input = input.Replace('x', '*');

            return input;
        }
    }
}