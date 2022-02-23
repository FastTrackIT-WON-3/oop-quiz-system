namespace QuizSystem.Library
{
    public class QuizReply
    {
        public QuizReply(User user, Quiz quiz)
        {
            User = user;
            Quiz = quiz;
        }

        public User User { get; }

        public Quiz Quiz { get; }

        public decimal Score { get; private set; } = 0M;

        public void Solve(GuiEngine guiEngine)
        {
            // rezolvarea chestionarului
            // pentru fiecare intrebare din chestionar
            
            for (int i = 0; i < Quiz.Questions.Length; i++)
            {
                guiEngine.GoToNextQuestion();

                //    1) afisez intrebarea
                Question question = Quiz.Questions[i];
                QuestionRenderer questionRenderer = guiEngine.GetRendererForQuestion(question);
                questionRenderer.RenderQuestion(i + 1, question);

                //    2) astept raspuns de la utilizator
                string userAnswer = guiEngine.GetQuestionReply();

                //    3) interpretez raspuns si updatez scor
                decimal questionScore = question.GetScoreForAnswer(userAnswer);
                Score += questionScore;
            }
        }
    }
}
