using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace BUKEP.Student.Calculator.Data
{
    public class CalculatorResult
    {
        private readonly string _connectionString;
        public CalculatorResult(string connectionString)
        {
            _connectionString = connectionString;
        }
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

        public List<CalculatorStorage> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = new List<CalculatorStorage>();
                var query = "SELECT Id, Value FROM CalculatorResult";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var value = new CalculatorStorage
                            {
                                id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Value = reader.GetDouble(reader.GetOrdinal("Value"))
                            };

                            result.Add(value);
                        }
                    }
                }
                return result;
            }
        }   

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