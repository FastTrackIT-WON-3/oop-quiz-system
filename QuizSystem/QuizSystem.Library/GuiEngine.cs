using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Library
{
    public abstract class GuiEngine
    {
        public GuiEngine(QuestionRenderer[] renderers)
        {
            Renderers = renderers;
        }

        public QuestionRenderer[] Renderers { get; }

        public abstract void GoToNextQuestion();

        public abstract string GetQuestionReply();

        public QuestionRenderer GetRendererForQuestion(Question question)
        {
            foreach (QuestionRenderer renderer in Renderers)
            {
                if (renderer.CanRenderQuestion(question))
                {
                    return renderer;
                }
            }

            throw new NotSupportedException($"There is no renderer for question type {question.GetType()}");
        }
    }
}
