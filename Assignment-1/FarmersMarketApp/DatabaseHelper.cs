using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmersMarketApp
{
    public class DatabaseHelper
    {
        private readonly string connectionString;

        public DatabaseHelper()
        {
            connectionString = "Data Source=shivang;Initial Catalog=FarmersMarketDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        }

        public async Task<List<Product>> SelectAllProductsAsync()
        {
            List<Product> products = new List<Product>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT * FROM Products";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            products.Add(new Product
                            {
                                ProductID = reader.GetInt32(reader.GetOrdinal("ProductID")),
                                ProductName = reader.GetString(reader.GetOrdinal("ProductName")),
                                Amount = reader.GetDecimal(reader.GetOrdinal("Amount")),
                                PricePerKg = reader.GetDecimal(reader.GetOrdinal("PricePerKg")),
                                PurchaseAmount = 0
                            });
                        }
                    }
                }
            }
            return products;
        }

        public async Task InsertProductAsync(int productId, string productName, decimal amount, decimal pricePerKg)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string query = "INSERT INTO Products (ProductID, ProductName, Amount, PricePerKg) VALUES (@ProductID, @ProductName, @Amount, @PricePerKg)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductID", productId);
                    command.Parameters.AddWithValue("@ProductName", productName);
                    command.Parameters.AddWithValue("@Amount", amount);
                    command.Parameters.AddWithValue("@PricePerKg", pricePerKg);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateProductAsync(int productId, string productName, decimal amount, decimal pricePerKg)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string query = "UPDATE Products SET ProductName = @ProductName, Amount = @Amount, PricePerKg = @PricePerKg WHERE ProductID = @ProductID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductID", productId);
                    command.Parameters.AddWithValue("@ProductName", productName);
                    command.Parameters.AddWithValue("@Amount", amount);
                    command.Parameters.AddWithValue("@PricePerKg", pricePerKg);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteProductAsync(int productId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string query = "DELETE FROM Products WHERE ProductID = @ProductID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductID", productId);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
