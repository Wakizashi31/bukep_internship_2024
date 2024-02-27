using System;
using System.Collections.Generic;
using System.Text;

namespace BUKEP.Student.Calculator.Data
{  
    /// <summary>
    /// Результат вычислений
    /// </summary>
    public class CalculationResult
    {  
        /// <summary>
        /// Идентификатор
        /// </summary>      
        public int Id {  get; set; }

        /// <summary>
        /// Значение
        /// </summary>
        public double Value { get; set; }
    }
}
