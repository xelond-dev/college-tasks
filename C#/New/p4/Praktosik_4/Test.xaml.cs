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

namespace Praktosik_4
{
    public partial class Test : Window
    {
        List<TestModel> tests = new List<TestModel>();

        public class TestModel
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public string FirstAnswer { get; set; }
            public string SecondAnswer { get; set; }
            public string ThirdAnswer { get; set; }
            public CorrectAnswer CorrectAnswer { get; set; }
        }

        public enum CorrectAnswer
        {
            FirstAnswerCorrect,
            SecondAnswerCorrect,
            ThirdAnswerCorrect
        }

        public Test()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void EditTheTest_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Pages.EditTestPage();
        }

        private void TakeTheTest_Click(object sender, RoutedEventArgs e)
        {
            tests = JsonConvert.JsonDeserialize<List<TestModel>>();
            if (tests == null || tests.Count <= 0)
            {
                PageFrame.Content = new Pages.NoTestPage();
            }
            else
            {
                PageFrame.Content = new Pages.PassingTheTestPage();
            }
        }
    }
}
