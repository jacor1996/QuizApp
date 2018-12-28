using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizApp.Entities
{
    public class Question : BaseModel
    {
        public string Text { get; set; }
        public string CorrectAnswer { get; set; }
        public IList<string> Answers { get; set; }
    }
}