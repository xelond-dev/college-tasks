using Praktos5.Model;
using MVVMHelperLibrary;
using System.Collections.ObjectModel;

namespace Praktos5.ViewModel
{
    class EditTestPageModel : BindingHelper
    {
        #region Свойства
        List<TestModel> tests = new List<TestModel>();
        public BindableCommand SaveChangesCommand { get; set; }
        private ObservableCollection<TestModel> _editTestDG;
        public ObservableCollection<TestModel> EditTestDG
        {
            get { return _editTestDG; }
            set
            {
                if (_editTestDG != value)
                {
                    _editTestDG = value;
                    OnPropertyChanged(nameof(EditTestDG));
                }
            }
        }
        #endregion
        public EditTestPageModel()
        {
            tests = JsonLibrary.JsonConvertModel.JsonDeserialize<List<TestModel>>();
            if (tests == null)
            {
                tests = new List<TestModel>();
            }
            EditTestDG = new ObservableCollection<TestModel>(tests);
            SaveChangesCommand = new BindableCommand(_ => SaveChanges());
        }
        private void SaveChanges()
        {
            List<TestModel> editedTests = new List<TestModel>();
            foreach (var model in _editTestDG)
            {
                if (model != null && model is TestModel testModel)
                {
                    editedTests.Add(testModel);
                }
            }
            JsonLibrary.JsonConvertModel.JsonSerialize(editedTests);
        }
    }
}
