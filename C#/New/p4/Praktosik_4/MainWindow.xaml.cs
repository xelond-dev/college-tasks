using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Praktosik_4
{
    public partial class MainWindow : Window
    {
        string WordToEnter = "1";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TakeTheTest_Click(object sender, RoutedEventArgs e)
        {
            Test test = new Test();
            test.Show();
            test.EditTheTest.Visibility = Visibility.Collapsed;
            this.Close();
        }

        private void EditTheTest_Click(object sender, RoutedEventArgs e)
        {
            CodeWord.Visibility = Visibility.Visible;
            if (CodeWord.Text == WordToEnter)
            {
                Test test = new Test();
                test.Show();
                this.Close();
            }
        }
    }
}