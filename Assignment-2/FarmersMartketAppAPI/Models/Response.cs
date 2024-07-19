namespace FarmersMartketAppAPI.Models
{
    public class Response
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public Product ProductInfo { get; set; }
        public List<Product> ProductsList { get; set; }
    }
}
