using System;

namespace QuizSystem.Library
{
    public class MultipleSelectionQuestion : Question
    {
        public MultipleSelectionQuestion(
            int id,
            string text,
            string[] options,
            int[] correctOptionsIndex)
            : base(id, text)
        {
            Options = options;
            CorrectOptionsIndex = correctOptionsIndex;
        }

        public string[] Options { get; }

        public int[] CorrectOptionsIndex { get; }

        public override decimal GetScoreForAnswer(string answer)
        {
            if (string.IsNullOrWhiteSpace(answer))
            {
                return 0M;
            }

            // transform user input into an array of indices
            string[] options = answer.Split(',', StringSplitOptions.RemoveEmptyEntries);
            int[] optionsIndices = new int[options.Length];
            for (int i = 0; i < options.Length; i++)
            {
                if (!int.TryParse(options[i], out int optionIndex))
                {
                    return 0M;
                }

                optionsIndices[i] = optionIndex;
            }

            // correct answer must be of the same size as user input
            if (CorrectOptionsIndex.Length != optionsIndices.Length)
            {
                return 0M;
            }

            // all correct options must be among user input options
            foreach (int correctOptionIndex in CorrectOptionsIndex)
            {
                bool foundInUserReply = false;
                foreach (int userOptionIndex in optionsIndices)
                {
                    if (correctOptionIndex == userOptionIndex)
                    {
                        foundInUserReply = true;
                        break;
                    }
                }

                if (!foundInUserReply)
                {
                    return 0M;
                }
            }

            return 1M;
        }
    }
}
