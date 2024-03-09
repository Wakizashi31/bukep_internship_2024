using System;
using System.Collections.Generic;
using System.Text;

namespace BUKEP.Student.Calculator.Data
{
    /// <summary>
    /// Интерфейс сервиса результатов вычесления.
    /// </summary>
    public interface ICalculationResultService
    {   
        /// <summary>
        /// Сохранить результат
        /// </summary>
        /// <param name="value">Результат вычисления</param>
        void Save(double value);

        /// <summary>
        /// Получать все результаты вычисления.
        /// </summary>
        /// <returns>Возвращает все результаты вычисления</returns>
        List<CalculationResult> GetAll();
        
        /// <summary>
        /// Очистить результаты вычисления 
        /// </summary>
        void ClearData();
    }
}
