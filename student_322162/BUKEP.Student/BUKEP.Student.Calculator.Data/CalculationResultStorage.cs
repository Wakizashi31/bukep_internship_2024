using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace BUKEP.Student.Calculator.Data
{
    /// <summary>
    /// Класс для управления результатами вычисления в базе данных.
    /// </summary>
    public class CalculationResultStorage
    {
        private readonly string _connectionString;

        public CalculationResultStorage(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Метод для сохранения результатов в базу данных. 
        /// </summary>
        /// <param name="value">Содержит результат вычисления, который будет сохранён.</param>
        public void Save(CalculationResult value)
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            using (connection)
            {
                connection.Open();

                string query = "INSERT INTO CalculationResult (Value) VALUES (@Value)";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Value", value.Value);
                    command.ExecuteNonQuery();
                }

            }
        }

        /// <summary>
        /// Метод для получение всех результатов хранимых в базе данных. 
        /// </summary>
        /// <returns> Возвращает список объектов CalculationResult.</returns>
        public List<CalculationResult> GetAll()
        {
            var results = new List<CalculationResult>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var query = "SELECT Id, Value FROM CalculationResult";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var value = new CalculationResult
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Value = reader.GetDouble(reader.GetOrdinal("Value"))
                            };

                            results.Add(value);
                        }
                    }
                }
            }
            return results;
        }

        /// <summary>
        /// Метод для очистка базы данных. 
        /// </summary>
        public void Clear()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var query = "DELETE FROM CalculationResult";
                using (var command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }

}
