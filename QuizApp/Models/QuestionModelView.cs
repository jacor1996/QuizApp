using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizApp.Entities;

namespace QuizApp.Models
{
    public class QuestionModelView
    {
        public Question Question { get; set; }

        public List<Answer> Answers { get; set; }

    }
}