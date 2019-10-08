using System;
using System.IO;

namespace PrincessBrideTrivia
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string filePath = GetFilePath();
            Question[] questions = LoadQuestions(filePath);
            
            // Extra Credit - Randomize Answers
            foreach (var q in questions)
                RandomizeAnswers(q);
            
            int numberCorrect = 0;
            for (int i = 0; i < questions.Length; i++)
            {
                bool result = AskQuestion(questions[i]);
                if (result)
                {
                    numberCorrect++;
                }
            }
            Console.WriteLine("You got " + GetPercentCorrect(numberCorrect, questions.Length) + " correct");
        }

        public static string GetPercentCorrect(int numberCorrectAnswers, int numberOfQuestions)
        {
            //issue2-fixed!!!
            return (numberCorrectAnswers * 1.0 / numberOfQuestions * 100) + "%";
        }

        public static bool AskQuestion(Question question)
        {
            DisplayQuestion(question);

            string userGuess = GetGuessFromUser();
            return DisplayResult(userGuess, question);
        }

        public static string GetGuessFromUser()
        {
            return Console.ReadLine();
        }

        public static bool DisplayResult(string userGuess, Question question)
        {
            if (userGuess == question.CorrectAnswerIndex)
            {
                Console.WriteLine("Correct");
                return true;
            }

            Console.WriteLine("Incorrect");
            return false;
        }

        public static void DisplayQuestion(Question question)
        {
            Console.WriteLine("Question: " + question.Text);
            for (int i = 0; i < question.Answers.Length; i++)
            {
                Console.WriteLine((i + 1) + ": " + question.Answers[i]);
            }
        }

        public static string GetFilePath()
        {
            return "Trivia.txt";
        }

        public static Question[] LoadQuestions(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);

            Question[] questions = new Question[lines.Length / 5];
            for (int i = 0; i < questions.Length; i++)
            {
                int lineIndex = i * 5;
                string questionText = lines[lineIndex];

                string answer1 = lines[lineIndex + 1];
                string answer2 = lines[lineIndex + 2];
                string answer3 = lines[lineIndex + 3];

                string correctAnswerIndex = lines[lineIndex + 4];

                Question question = new Question();
                question.Text = questionText;
                question.Answers = new string[3];
                question.Answers[0] = answer1;
                question.Answers[1] = answer2;
                question.Answers[2] = answer3;
                question.CorrectAnswerIndex = correctAnswerIndex;
                
                // FIX - issue1!!! 
                questions[i] = question;
            }
            return questions;
        }
        
                static Random rand = new Random(Environment.TickCount);

        /// <summary>
        /// Randomizes the order of questions and updates correct answer index
        /// </summary>
        /// <param name="Q"></param>
        public static void RandomizeAnswers(Question Q)
        {
            int curIndex = Convert.ToInt32(Q.CorrectAnswerIndex) - 1;

            var answer = Q.Answers[curIndex];

            var list = new List<int>();
            var newOrder = new List<int>();

            for (int i = 0; i < Q.Answers.Length; i++)
                list.Add(i);

            while(list.Count > 1)
            {
                var val = rand.Next(0, list.Count - 1);

                newOrder.Add(list[val]);

                list.RemoveAt(val);
            }

            newOrder.Add(list[0]);

            string[] randomList = new string[Q.Answers.Length];

            for(int idx = 0; idx < randomList.Length; idx++)
            {
                int newIdx = newOrder[idx];

                randomList[newIdx] = Q.Answers[idx];

                if (randomList[newIdx] == answer)
                    Q.CorrectAnswerIndex = (newOrder[idx] + 1).ToString();
            }

            Q.Answers = randomList;
        }
    }
}
