using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for MathGame.xaml
    /// </summary>
    public partial class MathGame : Window, INotifyPropertyChanged
    {
        private Random random = new Random();
        private int operand1;
        private int operand2;
        private string operatorString;
        private string mathProblem;

        public string MathProblem
        {
            get { return mathProblem; }
            set
            {
                if (mathProblem != value)
                {
                    mathProblem = value;
                    OnPropertyChanged(nameof(MathProblem));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MathGame()
        {
            InitializeComponent();
            DataContext = this; // Set the DataContext to the current instance of MainWindow
            GenerateMathProblem();
        }

        private void GenerateMathProblem()
        {
            operand1 = random.Next(1, 11);
            operand2 = random.Next(1, 11);

            switch (random.Next(1, 5))
            {
                case 1:
                    operatorString = "+";
                    break;
                case 2:
                    operatorString = "-";
                    break;
                case 3:
                    operatorString = "*";
                    break;
                case 4:
                    operatorString = "/";
                    break;
            }

            resultLabel.Content = "";
            answerTextBox.Text = "";

            // Update the MathProblem property
            MathProblem = $"{operand1} {operatorString} {operand2} = ?";
        }

        private async void SubmitAnswer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int userAnswer = int.Parse(answerTextBox.Text);
                int correctAnswer = CalculateCorrectAnswer();

                if (userAnswer == correctAnswer)
                {
                    resultLabel.Content = "Correct!";
                }
                else
                {
                    resultLabel.Content = $"Incorrect. The correct answer is {correctAnswer}.";
                }
                await Task.Delay(2000);


                // Generate a new math problem
                GenerateMathProblem();
            }
            catch (FormatException)
            {
                resultLabel.Content = "Please enter a valid number.";
            }
        }

        private int CalculateCorrectAnswer()
        {
            switch (operatorString)
            {
                case "+":
                    return operand1 + operand2;
                case "-":
                    return operand1 - operand2;
                case "*":
                    return operand1 * operand2;
                case "/":
                    return operand1 / operand2;
                default:
                    throw new InvalidOperationException("Invalid operator");
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