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
    /// Interaction logic for CustomButton.xaml
    /// </summary>
    public class CustomButton : Button
    {
        // Additional property specific to CustomButton
        public string CustomText
        {
            get { return (string)GetValue(CustomTextProperty); }
            set { SetValue(CustomTextProperty, value); }
        }

        public static readonly DependencyProperty CustomTextProperty =
            DependencyProperty.Register("CustomText", typeof(string), typeof(CustomButton), new PropertyMetadata(string.Empty));

        // Constructor
        public CustomButton()
        {
            // Apply the default style
            DefaultStyleKey = typeof(CustomButton);
        }
    }
}
