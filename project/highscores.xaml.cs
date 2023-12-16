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
    /// Interaction logic for highscores.xaml
    /// </summary>
    public partial class highscores : Window
    {
        private string username;

        public highscores(string username)
        {
            InitializeComponent();
            LoadFastestTimes();
            this.username = username;

        }

        private void LoadFastestTimes()
        {
            using (var context = new UserDataContext())
            {
                var fastestTime = context.FastestTime.OrderBy(ft => ft.Time).FirstOrDefault();
                if (fastestTime != null)
                {
                    fastestTimesDataGrid.ItemsSource = new List<FastestTime> { fastestTime };
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
