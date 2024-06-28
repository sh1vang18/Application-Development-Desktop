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
        private readonly DatabaseHelper dbHelper;
        private List<Product> products;

        public SalesWindow()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            LoadProducts();
        }

        private async void LoadProducts()
        {
            try
            {
                products = await dbHelper.SelectAllProductsAsync();
                dgProducts.ItemsSource = products;
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
                foreach (var product in products)
                {
                    if (product.PurchaseAmount > 0)
                    {
                        if (product.PurchaseAmount <= product.Amount)
                        {
                            decimal newAmount = product.Amount - product.PurchaseAmount;
                            await dbHelper.UpdateProductAsync(product.ProductID, product.ProductName, newAmount, product.PricePerKg);
                        }
                        else
                        {
                            MessageBox.Show($"Not enough stock for {product.ProductName}. Available: {product.Amount}kg");
                            return;
                        }
                    }
                }

                MessageBox.Show("Sale completed successfully!");
                LoadProducts();
                CalculateTotal_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error completing sale: {ex.Message}");
            }
        }
    
   
    }
}
