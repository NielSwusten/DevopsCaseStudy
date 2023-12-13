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

        private readonly string userName;


        public MainWindow(string userName)
        {
            InitializeComponent();
            this.userName = userName;
            UpdateWelcomeLabel();

        }

        private void UpdateWelcomeLabel()
        {
            // Set the welcome label text including the user's name
            welcomeLabel.Content = $"Welcome, {userName}!";
        }



        private void Button_ClickGuess(object sender, RoutedEventArgs e)
        {
            GuessGame GuessGame = new GuessGame(userName);
            GuessGame.Show();
            Close();


        }

        private void Button_ClickMath(object sender, RoutedEventArgs e)
        {
            MathGame MathGame = new MathGame(userName);
            MathGame.Show();
            Close();



 
        }

        private void Button_ClickReaction(object sender, RoutedEventArgs e)
        {
            ReactionGame ReactionGame = new ReactionGame(userName);
            ReactionGame.Show();
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

