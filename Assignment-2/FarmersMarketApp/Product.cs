using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmersMarketApp
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Amount { get; set; }
        public decimal PricePerKg { get; set; }
        public decimal PurchaseAmount { get; set; }
    }
}
