using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizApp.Entities;

namespace QuizApp.Repositories.Abstract
{
    public interface IQuestionRepository
    {
        IEnumerable<Question> GetAll();
        Question Get(int id);
        void Insert(Question question);
        void Edit(Question question);
        void Remove(int id);
    }
}
