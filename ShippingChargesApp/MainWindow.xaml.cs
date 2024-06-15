using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShippingChargesApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonCalculate_Click(object sender, RoutedEventArgs e)
        {
            decimal weight = decimal.Parse(txtWeight.Text);
            int distance = int.Parse(txtDistance.Text);

            ShippingCharges charges = new ShippingCharges(weight,distance);

            decimal totalCharge = charges.CalculateCharges();

            txtResult.Text = $"Shipping Charge $: {totalCharge} ";

        }
    }
}