using System;

namespace QuizSystem.Library
{
    public class SingleSelectionQuestion : Question
    {
        public SingleSelectionQuestion(
            int id,
            string text,
            string[] options,
            int correctOptionIndex)
            : base(id, text)
        {
            Options = options;
            CorrectOptionIndex = correctOptionIndex;
        }

        public string[] Options { get; }

        public int CorrectOptionIndex { get; }

        public override decimal GetScoreForAnswer(string answer)
        {
            if (string.IsNullOrWhiteSpace(answer))
            {
                return 0;
            }

            if (!int.TryParse(answer, out int resultIndex))
            {
                return 0;
            }

            return (resultIndex == CorrectOptionIndex)
                ? 1M
                : 0M;
        }

        public override void Render(int questionNo)
        {
            Console.WriteLine($"{questionNo}) {Text}");
            for (int i = 0; i < Options.Length; i++)
            {
                Console.WriteLine($"    {i}: {Options[i]}");
            }

            Console.Write("Please choose a single option index=");
        }
    }
}
