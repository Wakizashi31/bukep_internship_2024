using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace BUKEP.Student.Calculator.Data
{
    /// <inheritdoc />
    public class CalculationResultService : ICalculationResultService
    {
        private readonly string _connectionString;

        public CalculationResultService(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <inheritdoc />
        public void Save(double value)
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            using (connection)
            {
                connection.Open();

                string query = "INSERT INTO CalculationResult (Value) VALUES (@Value)";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Value", value);
                    command.ExecuteNonQuery();
                }

            }
        }

        /// <inheritdoc />
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

        /// <inheritdoc />
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
