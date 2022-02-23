using QuizSystem.Library;
using System;

namespace QuizSystem.Terminal
{
    class Program
    {
        static void Main(string[] args)
        {
            SetupDatabase();

            // 1) obtin un quiz si userul care il completeaza
            Console.Write("Your email addess=");
            string email = Console.ReadLine();

            Quiz quiz = QuestionsDatabase.Create(2);
            User user = new User(email);

            // 2) User fills in the quiz
            QuizReply userReply = new QuizReply(user, quiz);
            ConsoleGuiEngine guiEngine = new ConsoleGuiEngine(
                new QuestionRenderer[]
                {
                    new SingleSelectionQuestionRenderer(),
                    new MultipleSelectionQuestionRenderer()
                });

            userReply.Solve(guiEngine);

            // 3) Display score
            Console.WriteLine();
            Console.Write($"Congrats, you achieved {userReply.Score} points!!!");
        }

        private static void SetupDatabase()
        {
            int id = 1;
            QuestionsDatabase.PopulateDatabase(
                new Question[]
                {
                    new SingleSelectionQuestion(
                        id++,
                        "Choose your preffered fruit:",
                        new []
                        {
                            "Apples", "Oranges", "Bananas"
                        },
                        1),

                    new MultipleSelectionQuestion(
                        id++,
                        "What is the best smartphone brand:",
                        new []
                        {
                            "Apple", "Samsung", "LG"
                        },
                        new[] { 0, 1 }),

                    new SingleSelectionQuestion(
                        id++,
                        "Which is the best operating system:",
                        new []
                        {
                            "Windows", "MacOS", "Ubuntu"
                        },
                        2),

                    new MultipleSelectionQuestion(
                        id++,
                        "Who builds the best electric cars",
                        new []
                        {
                            "Tesla", "Renault", "Dacia"
                        },
                        new[] { 0, 2 })
                });
        }
    }
}
