using Praktos5.Model;
using Praktos5.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Praktos5.ViewModel
{
    class PassingTheTestPageViewModel : BindingHelper
    {
        #region Свойства&Команды
        List<TestModel> tests = new List<TestModel>();
        int currentTestIndex = 0;
        int correctAnswers = 0;
        int wrongAnswers = 0;
        private Visibility _visibility;
        private string _titleLabel;
        private string _descriptionLabel;
        private string _rightOrWrong;
        private string _firstButtonContent;
        private string _secondButtonContent;
        private string _thirdButtonContent;
        public Visibility Visibility
        {
            get { return _visibility; }
            set
            {
                if (_visibility != value)
                {
                    _visibility = value;
                    OnPropertyChanged(nameof(Visibility));
                }
            }
        }

        public string TitleLabel
        {
            get { return _titleLabel; }
            set
            {
                if (_titleLabel != value)
                {
                    _titleLabel = value;
                    OnPropertyChanged(nameof(TitleLabel));
                }
            }
        }

        public string DescriptionLabel
        {
            get { return _descriptionLabel; }
            set
            {
                if (_descriptionLabel != value)
                {
                    _descriptionLabel = value;
                    OnPropertyChanged(nameof(DescriptionLabel));
                }
            }
        }

        public string RightOrWrong
        {
            get { return _rightOrWrong; }
            set
            {
                if (_rightOrWrong != value)
                {
                    _rightOrWrong = value;
                    OnPropertyChanged(nameof(RightOrWrong));
                }
            }
        }

        public string FirstButtonContent
        {
            get { return _firstButtonContent; }
            set
            {
                if (_firstButtonContent != value)
                {
                    _firstButtonContent = value;
                    OnPropertyChanged(nameof(FirstButtonContent));
                }
            }
        }

        public string SecondButtonContent
        {
            get { return _secondButtonContent; }
            set
            {
                if (_secondButtonContent != value)
                {
                    _secondButtonContent = value;
                    OnPropertyChanged(nameof(SecondButtonContent));
                }
            }
        }

        public string ThirdButtonContent
        {
            get { return _thirdButtonContent; }
            set
            {
                if (_thirdButtonContent != value)
                {
                    _thirdButtonContent = value;
                    OnPropertyChanged(nameof(ThirdButtonContent));
                }
            }
        }
        public BindableCommand FirstAnswerButton { get; set; }
        public BindableCommand SecondAnswerButton { get; set; }
        public BindableCommand ThirdAnswerButton { get; set; }
        #endregion

        public PassingTheTestPageViewModel()
        {
            tests = JsonConvertModel.JsonDeserialize<List<TestModel>>();
            LoadTest();
            FirstAnswerButton = new BindableCommand(_ => FirstAnswerButton_Click());
            SecondAnswerButton = new BindableCommand(_ => SecondAnswerButton_Click());
            ThirdAnswerButton = new BindableCommand(_ => ThirdAnswerButton_Click());
        }

        private void LoadTest()
        {
            if (currentTestIndex < tests.Count)
            {
                RightOrWrong = "";
                TitleLabel = tests[currentTestIndex].Title;
                DescriptionLabel = tests[currentTestIndex].Description;
                FirstButtonContent = tests[currentTestIndex].FirstAnswer;
                SecondButtonContent = tests[currentTestIndex].SecondAnswer;
                ThirdButtonContent = tests[currentTestIndex].ThirdAnswer;
            }
        }

        private async void ShowNextTest()
        {
            if (currentTestIndex < tests.Count - 1)
            {
                currentTestIndex++;
                await Task.Delay(500);
                LoadTest();
            }
            else if (currentTestIndex == tests.Count - 1)
            {
                await Task.Delay(500);
                TitleLabel = $"Тест пройден. Правильных ответов - {correctAnswers}, неправильных - {wrongAnswers}";
                ChangeVisibility(false);
            }
        }

        private void FirstAnswerButton_Click()
        {
            if (Convert.ToInt32(tests[0].CorrectAnswer) == 0)
            {
                RightOrWrong = "Правильно!";
                correctAnswers++;
            }
            else
            {
                RightOrWrong = "Ответ неверный";
                wrongAnswers++;
            }
            ShowNextTest();
        }

        private void SecondAnswerButton_Click()
        {
            if (Convert.ToInt32(tests[0].CorrectAnswer) == 1)
            {
                RightOrWrong = "Правильно!";
                correctAnswers++;
            }
            else
            {
                RightOrWrong = "Ответ неверный";
                wrongAnswers++;
            }
            ShowNextTest();
        }

        private void ThirdAnswerButton_Click()
        {
            if (Convert.ToInt32(tests[0].CorrectAnswer) == 2)
            {
                RightOrWrong = "Правильно!";
                correctAnswers++;
            }
            else
            {
                RightOrWrong = "Ответ неверный";
                wrongAnswers++;
            }
            ShowNextTest();
        }

        public void ChangeVisibility(bool isVisible)
        {
            Visibility = isVisible ? Visibility.Visible : Visibility.Hidden;
        }
    }
}
