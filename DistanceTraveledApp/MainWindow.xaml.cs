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

namespace DistanceTraveledApp
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
            double speed;
            double time;
            try
            {
                speed = double.Parse(txtSpeed.Text);
                time = double.Parse(txtTime.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numbers for speed and time.");
                return;
            }

            DistanceTraveled distanceTraveled = new DistanceTraveled(speed,time);

           
            StringBuilder result = new StringBuilder();


            for (int hour = 1; hour <= time; hour++)
            {
                double distance = distanceTraveled.GetDistance(hour);
               result.AppendLine($"Distance traveled after {hour} hour(s): {distance} miles\n");

              
            }
              resultText.Text = result.ToString();

        }
    }
}