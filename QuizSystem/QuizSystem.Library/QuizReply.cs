using System;

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

        public void Solve()
        {
            // rezolvarea chestionarului
            // pentru fiecare intrebare din chestionar
            
            for (int i = 0; i < Quiz.Questions.Length; i++)
            {
                Console.WriteLine();

                //    1) afisez intrebarea
                Question question = Quiz.Questions[i];
                question.Render(i + 1);

                //    2) astept raspuns de la utilizator
                string userAnswer = Console.ReadLine();

                //    3) interpretez raspuns si updatez scor
                decimal questionScore = question.GetScoreForAnswer(userAnswer);
                Score += questionScore;
            }
        }
    }
}
