using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BUKEP.Student.Calculator.Data
{
    /// <summary>
    /// Сервис результатов вычисления Entity Framework.
    /// </summary>
    public class EfCalculationResultService : ICalculationResultService
    {
        private readonly CalculationResultContext _context;

        public EfCalculationResultService(CalculationResultContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Сохранить результат.
        /// </summary>
        /// <param name="value">Содержит результат вычисления, который будет сохранён.</param>
        public void Save(double value)
        {
            var result = new CalculationResult { Value = value };
            _context.calculationResult.Add(result);
            _context.SaveChanges();
        }

        /// <summary>
        /// Получить все результаты вычислений. 
        /// </summary>
        /// <returns>Возвращает список объектов CalculationResult</returns>
        public List<CalculationResult> GetAll()
        {
            return _context.calculationResult.ToList();
        }

        /// <summary>
        /// Очистить результаты вычислений.
        /// </summary>
        public void Clear()
        {
            _context.calculationResult.RemoveRange(_context.calculationResult);
            _context.SaveChanges();
        }

    }
}
