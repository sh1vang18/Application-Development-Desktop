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
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private readonly DatabaseHelper dbHelper;
        private List<Product> products;

        public AdminWindow()
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
                dgProducts.ItemsSource = null;
                dgProducts.ItemsSource = products;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}");
            }
        }

        private async void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (int.TryParse(txtProductId.Text, out int productId) &&
                    decimal.TryParse(txtAmount.Text, out decimal amount) &&
                    decimal.TryParse(txtPrice.Text, out decimal price))
                {
                    string productName = txtProductName.Text;
                    await dbHelper.InsertProductAsync(productId, productName, amount, price);
                    LoadProducts();
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show("Please enter valid values for Product ID, Amount, and Price.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding product: {ex.Message}");
            }
        }

        private async void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (int.TryParse(txtProductId.Text, out int productId) &&
                    decimal.TryParse(txtAmount.Text, out decimal amount) &&
                    decimal.TryParse(txtPrice.Text, out decimal price))
                {
                    string productName = txtProductName.Text;
                    await dbHelper.UpdateProductAsync(productId, productName, amount, price);
                    LoadProducts();
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show("Please enter valid values for Product ID, Amount, and Price.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating product: {ex.Message}");
            }
        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (int.TryParse(txtProductId.Text, out int productId))
                {
                    await dbHelper.DeleteProductAsync(productId);
                    LoadProducts();
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show("Please enter a valid Product ID.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting product: {ex.Message}");
            }
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            LoadProducts();
        }

        private void ClearInputs()
        {
            txtProductId.Clear();
            txtProductName.Clear();
            txtAmount.Clear();
            txtPrice.Clear();
        }

        private void DgProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgProducts.SelectedItem is Product selectedProduct)
            {
                txtProductId.Text = selectedProduct.ProductID.ToString();
                txtProductName.Text = selectedProduct.ProductName;
                txtAmount.Text = selectedProduct.Amount.ToString();
                txtPrice.Text = selectedProduct.PricePerKg.ToString();
            }
        }
    }
}
