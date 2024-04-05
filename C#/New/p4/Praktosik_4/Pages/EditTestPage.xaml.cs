using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
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
using System.IO;
namespace Praktosik_4.Pages
{
    public partial class EditTestPage : Page
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

        public EditTestPage()
        {
            InitializeComponent();
            tests = JsonConvert.JsonDeserialize<List<TestModel>>();
            if (tests == null)
            {
                tests = new List<TestModel>();
            }
            EditTestDG.ItemsSource = tests;
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            List<TestModel> editedTests = new List<TestModel>();
            foreach (var model in EditTestDG.Items)
            {
                if (model != null && model is TestModel testModel)
                {
                    editedTests.Add(testModel);
                }
            }
            JsonConvert.JsonSerialize(editedTests);
        }
    }
}
