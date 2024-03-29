using BUKEP.Student.Calculator;
using BUKEP.Student.Calculator.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
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

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CalculateResult(string expression)
        {
            try
            {
                double result = _mathCalculator.ResultCalculate(expression);
                return Json(result);
            }
            catch (DivideByZeroException) 
            {
                return Json("Деление на ноль!");
            }
            catch(InvalidOperationException)
            {
                return Json("Неверное выражение");
            }
        }

        [HttpPost]
        public void SaveResult(string expression)
        {
            _resultService.Save(Convert.ToDouble(expression));
        }

        [HttpPost]
        public void ClearCalcDb()
        {
            _resultService.ClearData();
        }

        [HttpPost]
        public JsonResult ShowAllResults()
        {
           List<CalculationResult> results = _resultService.GetAll();
           return Json(results);
        }
    }   

}