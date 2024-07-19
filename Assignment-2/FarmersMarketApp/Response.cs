using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmersMarketApp
{
    public class Response
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public Product ProductInfo { get; set; }
        public List<Product> ProductsList { get; set; }
    }
}
