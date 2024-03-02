using System;
using System.Collections.Generic;
using System.Text;

namespace BUKEP.Student.Calculator.Data
{
    /// <summary>
    /// Интерфейс сервиса результатов вычисления. 
    /// </summary>
    public interface ICalculationResultService
    {
        /// <summary>
        /// Сохранить результат.
        /// </summary>
        /// <param name="value">Содержит результат вычисления, который будет сохранён.</param>
        void Save(double value);

        /// <summary>
        /// Получить все результаты вычислений. 
        /// </summary>
        /// <returns>Возвращает список объектов CalculationResult</returns>
        List<CalculationResult> GetAll();

        /// <summary>
        /// Очистить результаты вычислений.
        /// </summary>
        void Clear();
    }
}
