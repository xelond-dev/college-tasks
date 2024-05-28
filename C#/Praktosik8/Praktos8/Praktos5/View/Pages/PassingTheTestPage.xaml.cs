using Praktos5.ViewModel;
using System.Windows.Controls;

namespace Praktos5.View.Pages
{
    public partial class PassingTheTestPage : Page
    {
        public PassingTheTestPage()
        {
            InitializeComponent();
            DataContext = new PassingTheTestPageViewModel();
        }
    }
}
