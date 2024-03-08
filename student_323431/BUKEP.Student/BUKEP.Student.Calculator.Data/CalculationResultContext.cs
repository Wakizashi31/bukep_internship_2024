using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace BUKEP.Student.Calculator.Data
{   /// <summary>
    /// Контекст базы данных.
    /// </summary>
    public class CalculationResultContext: DbContext
    {
       
        public DbSet<CalculationResult> CalculationResults { get; set; }

        /// <summary>
        /// Инициализация экземпляра класса с строкой подключения к БД
        /// </summary>
        /// <param name="connectionString">Строка подлючения к базе данных</param>

        public CalculationResultContext(string connectionString) : base(connectionString)
        {
            
        }

        /// <summary>
        /// Настройки для модели сущности
        /// </summary>
        /// <param name="modelBuilder">>Модель для сопоставления с БД</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CalculationResultEntityMap());
        }
       

    }
}
