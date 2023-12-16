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
        private string username;
        private double fastestTime = 9999990;

        public ReactionGame()
        {
            InitializeComponent();
            reactionButton.Visibility = Visibility.Hidden;
            this.username = "Obama";
            StartGame();
        }

        public ReactionGame(string username)
        {
            InitializeComponent();
            reactionButton.Visibility = Visibility.Hidden;
            this.username = username;
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

                if (stopwatch.ElapsedMilliseconds < fastestTime)
                {
                    fastestTime = stopwatch.ElapsedMilliseconds;

                    // Save the fastest time to the database
                    using (var context = new UserDataContext())
                    {
                        var fastestTimeEntry = new FastestTime
                        {
                            Id = 1,
                            Name = username,
                            Time = fastestTime
                        };

                        context.FastestTime.Add(fastestTimeEntry);
                        context.SaveChanges();
                    }

                    // Update the FastestTime property in the Users table
                    UpdateUserFastestTime(username, fastestTime);
                }

                MessageBox.Show($"fastest: {fastestTime} milliseconds");


                reactionButton.Visibility = Visibility.Hidden;
                reactiontext.Visibility = Visibility.Visible;
                await Task.Delay(500);
                StartGame();
            }
        }


        private void UpdateUserFastestTime(string username, double fastestTime)
        {
            using (var context = new UserDataContext())
            {
                // Retrieve the user from the Users table
                var user = context.Users.FirstOrDefault(u => u.Name == username);

                if (user != null && fastestTime < user.FastestTime)
                {
                    // Update the FastestTime property
                    user.FastestTime = fastestTime;

                    // Save the changes to the database
                    context.SaveChanges();
                }
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

