using Newtonsoft.Json;
using QuizApp.Models;
using System;
using System.Diagnostics;

namespace ArticleJsonFetch.Models
{
    internal class QuizJsonSerializer
    {
        public Object obj = new();
        public bool isJson = false;

        public QuizJsonSerializer()
        {
        }

        public void DeserializeToJson(ref string str)
        {
            if (string.IsNullOrWhiteSpace(str)) { return; }

            try
            {
                obj = System.Text.Json.JsonSerializer.Deserialize<object>(str)!;
                if (obj != null)
                {
                    isJson = true;
                }
            }
            catch (ArgumentNullException ex)
            {
                WriteExceptionToConsole(ex);
            }
            catch (System.Text.Json.JsonException ex)
            {
                WriteExceptionToConsole(ex);
            }
            catch (Exception ex)
            {
                WriteExceptionToConsole(ex);
            }
        }

        public void DeserializeToJson(ref FileStream stream)
        {
            if (FileStream.Equals(stream, null)) { return; }

            try
            {
                obj = System.Text.Json.JsonSerializer.Deserialize<object>(stream)!;
                if (obj != null)
                {
                    isJson = true;
                }
            }
            catch (ArgumentNullException ex)
            {
                WriteExceptionToConsole(ex);
            }
            catch (System.Text.Json.JsonException ex)
            {
                WriteExceptionToConsole(ex);
            }
            catch (Exception ex)
            {
                WriteExceptionToConsole(ex);
            }
        }

        public void DeserializeQuizDataToJson(ref FileStream stream)
        {
            if (FileStream.Equals(stream, null)) { return; }

            try
            {
                obj = System.Text.Json.JsonSerializer.Deserialize<QuizData>(stream)!;
                if (obj != null)
                {
                    isJson = true;
                }
            }
            catch (ArgumentNullException ex)
            {
                WriteExceptionToConsole(ex);
            }
            catch (System.Text.Json.JsonException ex)
            {
                WriteExceptionToConsole(ex);
            }
            catch (Exception ex)
            {
                WriteExceptionToConsole(ex);
            }
        }


        private void WriteExceptionToConsole(Exception e)
        {
            if (e.InnerException == null)
                Console.WriteLine("Exception: {0}\n{1}", e.ToString(), e.StackTrace);
            else
                Console.WriteLine("Exception: {0}\n{1}\n{2}", e.ToString(), e.StackTrace, e.InnerException);
        }
    }
}
