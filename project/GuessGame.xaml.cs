using System;
using System.Collections.Generic;
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

namespace project
{
    /// <summary>
    /// Interaction logic for GuessGame.xaml
    /// </summary>
    public partial class GuessGame : Window
    {
        private int secretNumber;
        private string username;
        public GuessGame(string username)
        {
            InitializeComponent();
            this.username = username; // Store the username for later use
            InitializeGame();
        }

        private void InitializeGame()
        {
            // Generate a random number between 1 and 100
            Random rand = new Random();
            secretNumber = rand.Next(1, 101);

            // Clear previous results
            resultLabel.Content = "";
            guessTextBox.Text = "";
        }

        private async void SubmitGuess_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Get user's guess
                int userGuess = int.Parse(guessTextBox.Text);

                // Check if the guess is correct
                if (userGuess == secretNumber)
                {
                    resultLabel.Content = "Congratulations! You guessed the correct number.";
                    await Task.Delay(3000);

                    InitializeGame(); // Start a new game
                }
                else
                {
                    resultLabel.Content = userGuess < secretNumber
                        ? "Try a higher number."
                        : "Try a lower number.";
                }
            }
            catch (FormatException)
            {
                resultLabel.Content = "Please enter a valid number.";
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow MainWindow = new MainWindow(username);
            MainWindow.Show();
            Close();


        }
    }
}