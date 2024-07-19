using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace FarmersMarketApp
{
    public class ApiClient
    {
        private readonly HttpClient _client;
        private readonly string _baseUrl = "https://localhost:7184/api/products/";

        public ApiClient()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri(_baseUrl)
            };
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<Response> GetFullListAsync()
        {
            try
            {
                return await _client.GetFromJsonAsync<Response>("GetFullList");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting full list: {ex.Message}");
            }
        }

        public async Task<Response> AddProductAsync(Product product)
        {
            try
            {
                var response = await _client.PostAsJsonAsync("AddInfo", product);
                return await response.Content.ReadFromJsonAsync<Response>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding product: {ex.Message}");
            }
        }

        public async Task<Response> UpdateProductAsync(int id, Product product)
        {
            try
            {
                var response = await _client.PostAsJsonAsync($"UpdateById/{id}", product);
                return await response.Content.ReadFromJsonAsync<Response>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating product: {ex.Message}");
            }
        }

        public async Task<Response> DeleteProductAsync(int id)
        {
            try
            {
                var response = await _client.PostAsync($"DeleteById/{id}", null);
                return await response.Content.ReadFromJsonAsync<Response>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting product: {ex.Message}");
            }
        }
        public async Task<Response> ProcessSaleAsync(List<SaleItem> saleItems)
        {
            try
            {
                var response = await _client.PostAsJsonAsync("ProcessSale", saleItems);
                return await response.Content.ReadFromJsonAsync<Response>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error processing sale: {ex.Message}");
            }
        }
    }
}
