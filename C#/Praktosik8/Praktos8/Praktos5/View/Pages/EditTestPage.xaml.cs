using Praktos5.ViewModel;
using System.Windows.Controls;

namespace Praktos5.View.Pages
{
    public partial class EditTestPage : Page
    {
        public EditTestPage()
        {
            InitializeComponent();
            DataContext = new EditTestPageModel();
        }
    }
}
