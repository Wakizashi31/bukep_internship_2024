using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace BUKEP.Student.Calculator.Data
{
    public class CalculationResultContext: DbContext
    {
        /// <summary>
        /// Контекст базы данных
        /// </summary>
        public DbSet<CalculationResult> calculationResults { get; set; }

        /// <summary>
        /// Инициализация экземпляра класса с строкой подключения к БД
        /// </summary>
        /// <param name="connectionString"></param>

        public CalculationResultContext(string connectionString) : base(connectionString)
        {
            calculationResults = Set<CalculationResult>();
        }

        /// <summary>
        /// Настройки для модели сущности
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CalculationResultEntityMap());
        }
       

    }
}
