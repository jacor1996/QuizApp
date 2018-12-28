using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using QuizApp.Entities;
using QuizApp.Repositories.Abstract;

namespace QuizApp.Repositories.Concrete
{
    public class QuestionRepository : IQuestionRepository
    {
        private QuizAppDbContext _context;

        public QuestionRepository()
        {
            _context = new QuizAppDbContext();    
        }

        public IEnumerable<Question> GetAll()
        {
            return _context.Questions
                .Include(q => q.CorrectAnswer)
                .Include(q => q.Answers)
                .ToList();
        }

        public Question Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Question question)
        {
            throw new NotImplementedException();
        }

        public void Edit(Question question)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}