using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FarmersMarketApp
{
    /// <summary>
    /// Interaction logic for SalesWindow.xaml
    /// </summary>
    public partial class SalesWindow : Window
    {
        private readonly ApiClient apiClient;
        private List<Product> products;

        public SalesWindow()
        {
            InitializeComponent();
            apiClient = new ApiClient();
            LoadProducts();
        }

        private async void LoadProducts()
        {
            try
            {
                var response = await apiClient.GetFullListAsync();
                if (response.StatusCode == 200 && response.ProductsList != null)
                {
                    products = response.ProductsList;
                    dgProducts.ItemsSource = products;
                }
                else
                {
                    MessageBox.Show($"Error loading products: {response.StatusMessage}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}");
            }
        }

        private void CalculateTotal_Click(object sender, RoutedEventArgs e)
        {
            decimal total = products.Sum(p => p.PurchaseAmount * p.PricePerKg);
            txtTotal.Text = $"${total:F2}";
        }

        private async void CompleteSale_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<SaleItem> saleItems = new List<SaleItem>();
                foreach (var product in products)
                {
                    if (product.PurchaseAmount > 0)
                    {
                        if (product.PurchaseAmount <= product.Amount)
                        {
                            saleItems.Add(new SaleItem
                            {
                                ProductID = product.ProductID,
                                Quantity = product.PurchaseAmount
                            });
                        }
                        else
                        {
                            MessageBox.Show($"Not enough stock for {product.ProductName}. Available: {product.Amount}kg");
                            return;
                        }
                    }
                }

                if (saleItems.Count > 0)
                {
                    var response = await apiClient.ProcessSaleAsync(saleItems);
                    if (response.StatusCode == 200)
                    {
                        MessageBox.Show("Sale completed successfully!");
                        LoadProducts();
                        CalculateTotal_Click(null, null);
                    }
                    else
                    {
                        MessageBox.Show($"Error processing sale: {response.StatusMessage}");
                    }
                }
                else
                {
                    MessageBox.Show("No items selected for sale.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error completing sale: {ex.Message}");
            }
        }
    }

    public class SaleItem
    {
        public int ProductID { get; set; }
        public decimal Quantity { get; set; }
    }

}
