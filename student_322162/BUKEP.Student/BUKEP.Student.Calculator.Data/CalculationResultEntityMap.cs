using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace BUKEP.Student.Calculator.Data
{
    /// <summary>
    /// Сопоставление свойств сущности с таблицей БД. 
    /// </summary>
    internal class CalculationResultEntityMap : EntityTypeConfiguration<CalculationResult>
    {
        /// <summary>
        /// Конструктор для сопоставлниея свойств сущности с таблицей БД.
        /// </summary>
        public CalculationResultEntityMap()
        {
            ToTable("CalculationResult", "dbo");

            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id");
            Property(x => x.Value).HasColumnName("Value");
        }
    }
}
