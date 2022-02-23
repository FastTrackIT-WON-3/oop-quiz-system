namespace QuizSystem.Library
{
    public class Quiz
    {
        public Quiz(Question[] questions)
        {
            Questions = questions;
        }

        public Question[] Questions { get; }
    }
}
