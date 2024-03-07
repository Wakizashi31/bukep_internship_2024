using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BUKEP.Student.Calculator.Data
{   /// <summary>
    /// Сервис результатов вычисления
    /// </summary>
    public class EFCalculationResultService : ICalculationResultService
    {
        private readonly CalculationResultContext _context;
        private string connectionString;

        public EFCalculationResultService(CalculationResultContext connectionString)
        {
            _context = connectionString;
        }

        public EFCalculationResultService(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Сохранение результата
        /// </summary>
        /// <param name="value">результат вычисления,который будет сохранен</param>
        public void Save(double value)
        {
            var results = new CalculationResult {Value = value};
            _context.CalculationResults.Add(results);
            _context.SaveChanges();
        }

        /// <summary>
        /// Получает результаты вычислений
        /// </summary>
        /// <returns>Возвращает список объектов</returns>
        public List<CalculationResult> GetAll()
        {
            return _context.CalculationResults.ToList();
        }

        /// <summary>
        /// Очищает хранилище с результами вычислений
        /// </summary>
        public  void ClearData()
        {
            _context.CalculationResults.RemoveRange(_context.CalculationResults);
            _context.SaveChanges();
        }
    }
}
