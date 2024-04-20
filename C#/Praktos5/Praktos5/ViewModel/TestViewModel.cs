using Praktos5.Model;
using Praktos5.View.Pages;
using Praktos5.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Praktos5.ViewModel
{
    class TestViewModel : BindingHelper
    {
        #region Свойства
        Window window;
        List<TestModel> tests = new List<TestModel>();
        public Visibility _buttonVisibility { get; set; }

        private Page _pageFrame;
        public Page PageFrame
        {
            get { return _pageFrame; }
            set
            {
                if (_pageFrame != value)
                {
                    _pageFrame = value;
                    OnPropertyChanged(nameof(PageFrame));
                }
            }
        }
        #endregion

        #region Команды
        public BindableCommand ExitCommand { get; set; }
        public BindableCommand TakeCommand { get; set; }
        public BindableCommand EditCommand { get; set; }
        #endregion
        public TestViewModel(Visibility visibility, Window window)
        {
            this.window = window;
            _buttonVisibility = visibility;
            ExitCommand = new BindableCommand(_ => Exit());
            TakeCommand = new BindableCommand(_ => Take());
            EditCommand = new BindableCommand(_ => Edit());
        }

        private void Exit()
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            window.Close();
        }

        private void Take()
        {
            tests = JsonConvertModel.JsonDeserialize<List<TestModel>>();
            if (tests == null || tests.Count <= 0)
            {
                PageFrame = new NoTestPage();
            }
            else
            {
                PageFrame = new PassingTheTestPage();
            }
        }

        private void Edit()
        {
            PageFrame = new EditTestPage();
        }
    }
}
