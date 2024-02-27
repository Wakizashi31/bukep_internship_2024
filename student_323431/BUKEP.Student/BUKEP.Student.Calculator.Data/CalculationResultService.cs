using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace BUKEP.Student.Calculator.Data
{   /// <summary>
    /// Сервис результатов вычисления
    /// </summary>
    public class CalculationResultService
    {
        private readonly string _connectionString;
        public CalculationResultService(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Сохранение результата
        /// </summary>
        /// <param name="value">результат вычисления,который будет сохранен</param>
        public void Save (double value)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            using (connection)
            {
                connection.Open();

                string query = "INSERT INTO CalculatorResult (Value) VALUES (@Value)";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Value", value);
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Получает результаты вычислений
        /// </summary>
        /// <returns>Возвращает список объектов</returns>
        public List<CalculationResult> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var results = new List<CalculationResult>();
                var query = "SELECT Id, Value FROM CalculatorResult";
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
                return results;
            }
        }   

        /// <summary>
        /// очищает хранилище с результатами 
        /// </summary>
        public void ClearData()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var query = "DELETE FROM CalculatorResult";
                using (var command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}