namespace QuizSystem.Library
{
    public abstract class Question
    {
        public Question(int id, string text)
        {
            Id = id;
            Text = text;
        }

        public int Id { get; }

        public string Text { get; }

        public abstract decimal GetScoreForAnswer(string answer);

        public abstract void Render(int questionNo);
    }
}
