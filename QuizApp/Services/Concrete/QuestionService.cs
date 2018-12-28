using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizApp.Entities;
using QuizApp.Services.Abstract;

namespace QuizApp.Services.Concrete
{
    public class QuestionService : IQuestionService
    {
        public bool ContainsCorrectAnswer(Question question)
        {
            if (question == null)
            {
                throw new ArgumentNullException(nameof(question), "Question is null!");
            }

            foreach (var q in question.Answers)
            {
                if (string.Equals(q, question.CorrectAnswer, StringComparison.CurrentCultureIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }
    }
}