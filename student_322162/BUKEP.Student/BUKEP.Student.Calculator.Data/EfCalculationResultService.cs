using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BUKEP.Student.Calculator.Data
{
    /// <inheritdoc />
    public class EfCalculationResultService : ICalculationResultService
    {
        private readonly CalculationResultContext _context;

        public EfCalculationResultService(CalculationResultContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public void Save(double value)
        {
            var result = new CalculationResult { Value = value };
            _context.calculationResult.Add(result);
            _context.SaveChanges();
        }

        /// <inheritdoc />
        public List<CalculationResult> GetAll()
        {
            return _context.calculationResult.ToList();
        }

        /// <inheritdoc />
        public void Clear()
        {
            _context.calculationResult.RemoveRange(_context.calculationResult);
            _context.SaveChanges();
        }

    }
}
