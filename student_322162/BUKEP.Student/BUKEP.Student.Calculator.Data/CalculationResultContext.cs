using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace BUKEP.Student.Calculator.Data
{
    /// <summary>
    /// Контекст базы данных.
    /// </summary>
    public class CalculationResultContext : DbContext
    {
        public DbSet<CalculationResult> calculationResult { get; set; }

        /// <summary>
        /// Инициализация экземпляра класса с строкой подключения к БД.
        /// </summary>
        /// <param name="connectionString">Строка подключения к БД.</param>
        public CalculationResultContext(string connectionString) : base(connectionString)
        {
            calculationResult = Set<CalculationResult>();
        }

        /// <summary>
        /// Настройки для модели сущности.
        /// </summary>
        /// <param name="modelBuilder">Модель для сопоставления с базой данных.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CalculationResultEntityMap());
        }
    }
}
