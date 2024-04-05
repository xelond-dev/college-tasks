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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Praktosik_4.Pages
{
    public partial class PassingTheTestPage : Page
    {
        List<TestModel> tests = new List<TestModel>();
        int currentTestIndex = 0;
        int correctAnswers = 0;
        int wrongAnswers = 0;

        public class TestModel
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public string FirstAnswer { get; set; }
            public string SecondAnswer { get; set; }
            public string ThirdAnswer { get; set; }
            public CorrectAnswer CorrectAnswer { get; set; }
        }

        private void LoadTest()
        {
            if (currentTestIndex < tests.Count)
            {
                RightOrWrong.Content = "";
                TitleLabel.Content = tests[currentTestIndex].Title;
                DescriptionLabel.Content = tests[currentTestIndex].Description;
                FirstAnswerButton.Content = tests[currentTestIndex].FirstAnswer;
                SecondAnswerButton.Content = tests[currentTestIndex].SecondAnswer;
                ThirdAnswerButton.Content = tests[currentTestIndex].ThirdAnswer;
            }
        }

        public enum CorrectAnswer
        {
            FirstAnswerCorrect,
            SecondAnswerCorrect,
            ThirdAnswerCorrect
        }

        public PassingTheTestPage()
        {
            InitializeComponent();
            tests = JsonConvert.JsonDeserialize<List<TestModel>>();
            LoadTest();
        }

        private async void ShowNextTest()
        {
            if (currentTestIndex < tests.Count - 1)
            {
                currentTestIndex++;
                await Task.Delay(500);
                LoadTest();
            }
            else if (currentTestIndex == tests.Count - 1)
            {
                await Task.Delay(500);
                TitleLabel.Content = $"Тест пройден. Правильных ответов - {correctAnswers}, неправильных - {wrongAnswers}";
                RightOrWrong.Visibility = Visibility.Hidden;
                DescriptionLabel.Visibility = Visibility.Hidden;
                FirstAnswerButton.Visibility = Visibility.Hidden;
                SecondAnswerButton.Visibility = Visibility.Hidden;
                ThirdAnswerButton.Visibility = Visibility.Hidden;
            }
        }

        private void FirstAnswerButton_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(tests[0].CorrectAnswer) == 0)
            {
                RightOrWrong.Content = "Правильно!";
                correctAnswers++;
            }
            else
            {
                RightOrWrong.Content = "Ответ неверный";
                wrongAnswers++;
            }
            ShowNextTest();
        }

        private void SecondAnswerButton_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(tests[0].CorrectAnswer) == 1)
            {
                RightOrWrong.Content = "Правильно!";
                correctAnswers++;
            }
            else
            {
                RightOrWrong.Content = "Ответ неверный";
                wrongAnswers++;
            }
            ShowNextTest();
        }

        private void ThirdAnswerButton_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(tests[0].CorrectAnswer) == 2)
            {
                RightOrWrong.Content = "Правильно!";
                correctAnswers++;
            }
            else
            {
                RightOrWrong.Content = "Ответ неверный";
                wrongAnswers++;
            }
            ShowNextTest();
        }
    }
}
