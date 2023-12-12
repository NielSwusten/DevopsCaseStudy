using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for ReactionGame.xaml
    /// </summary>
    public partial class ReactionGame : Window
    {
        private Random random = new Random();
        private Stopwatch stopwatch = new Stopwatch();
        public ReactionGame()
        {
            InitializeComponent();
            reactionButton.Visibility = Visibility.Hidden;

            StartGame();
        }

        private async void StartGame()
        {
            int countdownTime = random.Next(2000, 5000);

            await Task.Delay(countdownTime);

            MoveButtonRandomly();
            reactionButton.Visibility = Visibility.Visible;
            reactiontext.Visibility = Visibility.Hidden;

            stopwatch.Restart();
        }

        private void MoveButtonRandomly()
        {
            double maxX = ActualWidth - reactionButton.Width;
            double maxY = ActualHeight - reactionButton.Height;

            double minX = -800;


            double newX = random.NextDouble() * (maxX + 300 / 2 - minX) + minX;

            double newY = random.NextDouble() * maxY;

            reactionButton.Margin = new Thickness(newX, newY, 0, 0);
        }

        private async void ReactionButton_Click(object sender, RoutedEventArgs e)
        {
            if (stopwatch.IsRunning)
            {
                stopwatch.Stop();
                MessageBox.Show($"Your reaction time: {stopwatch.ElapsedMilliseconds} milliseconds", "Game Over");

                reactionButton.Visibility = Visibility.Hidden;
                reactiontext.Visibility = Visibility.Visible;
                await Task.Delay(500);
                StartGame();
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow MainWindow = new MainWindow();
            MainWindow.Show();
            Close();
        }
    }
}

