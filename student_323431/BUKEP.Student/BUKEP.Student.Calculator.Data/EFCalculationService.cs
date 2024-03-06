using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BUKEP.Student.Calculator.Data
{   
    public class EFCalculationService : ICalculationResultService
    {
        private readonly CalculationResultContext _context;
        
        public EFCalculationService(CalculationResultContext context)
        {
            _context = context;
        }

        public void Save(double value)
        {
            var results = new CalculationResult {Value = value};
            _context.calculationResults.Add(results);
            _context.SaveChanges();
        }
        
        public List<CalculationResult> GetAll()
        {
            return _context.calculationResults.ToList();
        }
        public  void ClearData()
        {
            _context.calculationResults.RemoveRange(_context.calculationResults);
            _context.SaveChanges();
        }
    }
}
