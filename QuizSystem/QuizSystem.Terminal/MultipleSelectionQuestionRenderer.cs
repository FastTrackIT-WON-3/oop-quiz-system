using QuizSystem.Library;
using System;


namespace QuizSystem.Terminal
{
    public class MultipleSelectionQuestionRenderer : QuestionRenderer
    {
        public override bool CanRenderQuestion(Question question)
        {
            return question is MultipleSelectionQuestion;
        }

        public override void RenderQuestion(int questionNo, Question question)
        {
            if (question is MultipleSelectionQuestion multipleSelectionQuestion)
            {
                // randeaza multiple selection question
                Console.WriteLine($"{questionNo}) {multipleSelectionQuestion.Text}");
                for (int i = 0; i < multipleSelectionQuestion.Options.Length; i++)
                {
                    Console.WriteLine($"    {i}: {multipleSelectionQuestion.Options[i]}");
                }

                Console.Write("Please choose one or more option indices (comma separated)=");
            }
            else
            {
                throw new NotSupportedException();
            }
        }
    }
}
