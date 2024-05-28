using Praktos5.View;
using MVVMHelperLibrary;
using System.Windows;

namespace Praktos5.ViewModel
{
    class MainViewModel : BindingHelper
    {
        #region Свойства
        Window window;
        string WordToEnter = "1";
        public string WordToEntertbx { get; set; }

        private Visibility _elementVisibility;
        public Visibility ElementVisibility
        {
            get { return _elementVisibility; }
            set
            {
                _elementVisibility = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region Команды
        public BindableCommand TakeTheTestCommand { get; set; }
        public BindableCommand EditTestCommand { get; set; }
        #endregion

        public MainViewModel(Window window)
        {
            this.window = window;
            TakeTheTestCommand = new BindableCommand(_ => TakeTheTest());
            EditTestCommand = new BindableCommand(_ => EditTest());
            ElementVisibility = Visibility.Hidden;
        }

        private void TakeTheTest()
        {
            Test test = new Test(Visibility.Collapsed);
            test.Show();
            window.Close();
        }

        private void EditTest()
        {
            ElementVisibility = Visibility.Visible;
            if (WordToEnter == WordToEntertbx)
            {
                Test test = new Test(Visibility.Visible);
                test.Show();
                window.Close();
            }
        }
    }
}
