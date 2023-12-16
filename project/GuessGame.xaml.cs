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

    public partial class GuessGame : Window
    {
        private int secretNumber;
        private string username;

        public GuessGame(string username)
        {
            InitializeComponent();
            this.username = username; 
            InitializeGame();
        }

        private void InitializeGame()
        {
            Random rand = new Random();
            secretNumber = rand.Next(1, 101);

            resultLabel.Content = "";
            guessTextBox.Text = "";
        }

        private async void SubmitGuess_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int userGuess = int.Parse(guessTextBox.Text);

                if (userGuess == secretNumber)
                {
                    resultLabel.Content = "Congratulations! You guessed the correct number.";
                    await Task.Delay(2500);

                    InitializeGame(); 
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