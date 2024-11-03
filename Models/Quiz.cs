using System.Text.Json.Serialization;

namespace QuizApp.Models
{
    public class QuizData : IDisposable
    {
        [JsonPropertyName("quizzes")]
        public System.Collections.Generic.List<Quiz> Quizzes { get; set; } = new System.Collections.Generic.List<Quiz>();

        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Quizzes.Clear();
                    Quizzes.TrimExcess();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        ~QuizData() {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: false);
            Console.WriteLine("Destructor called."); 
        }

    }

    public class Quiz : IDisposable
    {
        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;
        
        [JsonPropertyName("icon")]
        public string IconPath { get; set; } = string.Empty;
        
        [JsonPropertyName("questions")]
        public System.Collections.Generic.List<Question> Questions { get; set; } = new System.Collections.Generic.List<Question>();

        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Questions.Clear();
                    Questions.TrimExcess();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        ~Quiz()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: false);
        }

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

    public class QuizzesOverview
    {
        public List<QuizOverview> Quizzes { get; set; } = new List<QuizOverview>();

        public QuizzesOverview(List<QuizOverview>? quizzes)
        {
            Quizzes = quizzes;
        }

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
}
