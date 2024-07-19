using System.Data.SqlClient;

namespace FarmersMartketAppAPI.Models
{
    public class DatabaseHelper
    {
        public Response GetFullList(SqlConnection con)
        {
            Response response = new Response();
            List<Product> productList = new List<Product>();

            try
            {
                string query = "SELECT * FROM Products";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Product product = new Product
                    {
                        ProductID = Convert.ToInt32(reader["ProductID"]),
                        ProductName = reader["ProductName"].ToString(),
                        Amount = Convert.ToDecimal(reader["Amount"]),
                        PricePerKg = Convert.ToDecimal(reader["PricePerKg"])
                    };
                    productList.Add(product);
                }

                response.StatusCode = 200;
                response.StatusMessage = "Data retrieved successfully";
                response.ProductsList = productList;
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.StatusMessage = "An error occurred: " + ex.Message;
            }
            finally
            {
                con.Close();
            }

            return response;
        }

        public Response AddInfo(SqlConnection con, Product product)
        {
            Response response = new Response();

            try
            {
                string query = "INSERT INTO Products (ProductID, ProductName, Amount, PricePerKg) VALUES (@ProductID, @ProductName, @Amount, @PricePerKg)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ProductID", product.ProductID);
                cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("@Amount", product.Amount);
                cmd.Parameters.AddWithValue("@PricePerKg", product.PricePerKg);

                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "Product added successfully";
                }
                else
                {
                    response.StatusCode = 400;
                    response.StatusMessage = "Error adding product";
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.StatusMessage = "An error occurred: " + ex.Message;
            }
            finally
            {
                con.Close();
            }

            return response;
        }

        public Response DeleteInfo(SqlConnection con, int productId)
        {
            Response response = new Response();

            try
            {
                string query = "DELETE FROM Products WHERE ProductID = @ProductID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ProductID", productId);

                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "Product deleted successfully";
                }
                else
                {
                    response.StatusCode = 404;
                    response.StatusMessage = "Product not found";
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.StatusMessage = "An error occurred: " + ex.Message;
            }
            finally
            {
                con.Close();
            }

            return response;
        }

        public Response UpdateInfo(SqlConnection con, int productId, Product updatedInfo)
        {
            Response response = new Response();

            try
            {
                string query = "UPDATE Products SET ProductName = @ProductName, Amount = @Amount, PricePerKg = @PricePerKg WHERE ProductID = @ProductID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ProductID", productId);
                cmd.Parameters.AddWithValue("@ProductName", updatedInfo.ProductName);
                cmd.Parameters.AddWithValue("@Amount", updatedInfo.Amount);
                cmd.Parameters.AddWithValue("@PricePerKg", updatedInfo.PricePerKg);

                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "Product updated successfully";
                }
                else
                {
                    response.StatusCode = 404;
                    response.StatusMessage = "Product not found";
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.StatusMessage = "An error occurred: " + ex.Message;
            }
            finally
            {
                con.Close();
            }

            return response;
        }
    }
}

