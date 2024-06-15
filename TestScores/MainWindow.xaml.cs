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

namespace TestScores
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

       

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            int score1 = int.Parse(txtTestScore1.Text);
            int score2 = int.Parse(txtTestScore2.Text);
            int score3 = int.Parse(txtTestScore3.Text);

            TestScoresClass scores = new TestScoresClass(score1, score2, score3);

            double averageScore = scores.GetAverageScore();
            char letterGrade = scores.GetLetterGrade();

            string result = $"Average Score: {averageScore:F2}\nLetter Grade: {letterGrade}";
            txtResult.Text = result;

        }
    }
}