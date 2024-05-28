using Praktos5.ViewModel;
using System.Windows;

namespace Praktos5
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel(this);
        }
    }
}