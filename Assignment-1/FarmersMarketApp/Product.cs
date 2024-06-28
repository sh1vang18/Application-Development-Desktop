using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmersMarketApp
{
    public class Product : INotifyPropertyChanged
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Amount { get; set; }
        public decimal PricePerKg { get; set; }

        private decimal _purchaseAmount;
        public decimal PurchaseAmount
        {
            get { return _purchaseAmount; }
            set
            {
                if (_purchaseAmount != value)
                {
                    _purchaseAmount = value;
                    OnPropertyChanged(nameof(PurchaseAmount));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
