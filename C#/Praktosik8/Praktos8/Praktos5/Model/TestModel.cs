namespace Praktos5.Model
{
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
}
