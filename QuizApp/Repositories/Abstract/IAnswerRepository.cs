using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizApp.Entities;

namespace QuizApp.Repositories.Abstract
{
    public interface IAnswerRepository
    {
        IEnumerable<Answer> GetAll();
        Answer Get(int id);
        void Insert(Answer answer);
        void Edit(Answer answer);
        void Remove(int id);
    }
}
