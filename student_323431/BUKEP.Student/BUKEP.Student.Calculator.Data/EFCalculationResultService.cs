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
        private string connectionString;

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
            CalculationResultContext context = new CalculationResultContext(connectionString);
            CalculationResult results = new CalculationResult {Value = value};
            context.CalculationResults.Add(results);
            context.SaveChanges();
        }

        /// <summary>
        /// Получает результаты вычислений
        /// </summary>
        /// <returns>Возвращает список объектов</returns>
        public List<CalculationResult> GetAll()
        {
            CalculationResultContext context = new CalculationResultContext(connectionString);
            return context.CalculationResults.ToList();
        }

        /// <summary>
        /// Очищает хранилище с результами вычислений
        /// </summary>
        public  void ClearData()
        {
            CalculationResultContext context = new CalculationResultContext(connectionString);
            context.CalculationResults.RemoveRange(context.CalculationResults);
            context.SaveChanges();
        }
    }
}
