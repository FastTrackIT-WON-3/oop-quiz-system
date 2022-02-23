using QuizSystem.Library;
using System;

namespace QuizSystem.Terminal
{
    public class ConsoleGuiEngine : GuiEngine
    {
        public ConsoleGuiEngine(QuestionRenderer[] renderers)
            : base(renderers)
        {

        }

        public override string GetQuestionReply()
        {
            return Console.ReadLine();
        }

        public override void GoToNextQuestion()
        {
            Console.WriteLine();
        }
    }
}
