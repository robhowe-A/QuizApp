using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections;
using System.Text.Json.Serialization;

namespace QuizApp.Models
{
    public class QuizData
    {
        [JsonPropertyName("quizzes")]
        public System.Collections.Generic.List<Quiz> Quizzes { get; set; } = new System.Collections.Generic.List<Quiz>();
    }

    public class Quiz
    {
        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;
        
        [JsonPropertyName("icon")]
        public string IconPath { get; set; } = string.Empty;
        
        [JsonPropertyName("questions")]
        public System.Collections.Generic.List<Question> Questions { get; set; } = new System.Collections.Generic.List<Question>();
    }

    public class Question
    {
        [JsonPropertyName("question")]
        public string QuestionStr { get; set; } = string.Empty;
        
        [JsonPropertyName("options")]
        public System.Collections.Generic.List<string> Options { get; set; } = new List<string>();
        
        [JsonPropertyName("answer")]
        public string AnswerStr { get; set; } = string.Empty;
    }

    public class QuestionSelection
    {
        public string? qName { get; set; }
        public string? qAnswer { get; set; }
        public string? id { get; set; }
    }

    public class QuizOverview
    {
        public string Title { get; set; } = string.Empty;
        public string IconPath { get; set; } = string.Empty;

        public QuizOverview(Quiz quiz)
        {
            Title = quiz.Title;
            IconPath = quiz.IconPath;
        }
    }

    public static class QuizOperations
    {
        public static QuizData GetQuizData()
        {
            FileStream quizFileData = File.Open("./assets/data.json", FileMode.Open, FileAccess.Read, FileShare.None);
            QuizData Data = System.Text.Json.JsonSerializer.Deserialize<QuizData>
            (quizFileData)!;
            quizFileData.Close();

            return Data;
        }

        public static List<string> GetQuizNames()
        {
            List<string> Names = new List<string>();

            var Data = GetQuizData();
            foreach (var name in Data.Quizzes)
            {
                Names.Add(name.Title);
            }

            return Names;
        }

        public static Quiz GetQuiz(string match)
        {
            //Find and return the quiz model
            QuizData Data = QuizOperations.GetQuizData();
            var QuizChoice = Data.Quizzes.Find(name => name.Title.Equals(match));
            return QuizChoice;
        }

        public static QuizOverview GetQuiz(Quiz quiz)
        {
            //Find and return the quiz model
            QuizData Data = QuizOperations.GetQuizData();
            var QuizChoice = Data.Quizzes.Find(name => name.Title.Equals(quiz));
            QuizOverview qOverview= new QuizOverview(QuizChoice);
            return qOverview;
        }
    }
}
