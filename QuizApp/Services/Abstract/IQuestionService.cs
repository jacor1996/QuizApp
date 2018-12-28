using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizApp.Entities;

namespace QuizApp.Services.Abstract
{
    public interface IQuestionService
    {
        bool ContainsCorrectAnswer(Question question);
    }
}
