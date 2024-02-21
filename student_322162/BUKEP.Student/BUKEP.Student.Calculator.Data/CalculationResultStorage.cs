using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace BUKEP.Student.Calculator.Data
{
    public class CalculationResultStorage
    {
        private readonly string _connectionString;

        public CalculationResultStorage(string connectionString)
        {
            _connectionString = connectionString;
        }

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
