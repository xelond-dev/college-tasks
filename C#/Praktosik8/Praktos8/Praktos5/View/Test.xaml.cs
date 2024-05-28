using Praktos5.ViewModel;
using System.Windows;

namespace Praktos5.View
{
    public partial class Test : Window
    {
        public Test(Visibility visibility)
        {
            InitializeComponent();
            DataContext = new TestViewModel(visibility, this);
        }
    }
}
