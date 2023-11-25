﻿using System;
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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }




        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var Username = textbox1.Text;
            var Password = textbox2.Text;

            using (UserDataContext context = new UserDataContext()) 
            {

                bool userfound = context.Users.Any(user => user.Name == Username && user.Password == Password);

                if (userfound)
                {
                    GrantAccess();
                    Close();
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password");
                }

            }

        }


        public void GrantAccess()
        {
            MainWindow main = new MainWindow();
            main.Show();
        }
    }
}

