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

namespace BankApp
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

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
           
            decimal endingBalance;
            int numChecksWritten;

            try
            {
                endingBalance = decimal.Parse(txtBalance.Text);
                numChecksWritten = int.Parse(txtChecks.Text);
            }
            catch (FormatException)
            {
               
                MessageBox.Show("Please enter valid numbers for balance and checks.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Create BankCharges object
            BankCharges charges = new BankCharges(endingBalance, numChecksWritten);

            // Calculate service charges
            decimal totalCharges = charges.CalculateServiceCharges();
            decimal newBalance = endingBalance - totalCharges;

            //Printing to textBox
            string result = $"Account Balance: {endingBalance:F2}\n" +
                     $"Check Fees: {charges.CalculateCheckFees():F2}\n" +
                     $"Total Service Charges: {totalCharges:F2}\n" +
                     $"New Balance: {newBalance:F2}";

            txtResult.Text = result;
        }


    }
}