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

namespace project
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


        private void Button_ClickGuess(object sender, RoutedEventArgs e)
        {
            GuessGame GuessGame = new GuessGame();
            GuessGame.Show();
            Close();


        }

        private void Button_ClickMath(object sender, RoutedEventArgs e)
        {
            MathGame MathGame = new MathGame();
            MathGame.Show();
            Close();


        }

        private void highscores(object sender, RoutedEventArgs e)
        {

            highscores highscores = new highscores();
            highscores.Show();
            Close();

        }
    }



          
}

