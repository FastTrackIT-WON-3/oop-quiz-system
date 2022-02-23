

namespace QuizSystem.Library
{
    public abstract class QuestionRenderer
    {
        public abstract bool CanRenderQuestion(Question question);

        public abstract void RenderQuestion(int questionNo, Question question);
    }
}
