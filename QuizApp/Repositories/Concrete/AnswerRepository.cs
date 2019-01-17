using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizApp.Entities;
using QuizApp.Repositories.Abstract;

namespace QuizApp.Repositories.Concrete
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly QuizAppDbContext _context;

        public AnswerRepository(QuizAppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Answer> GetAll()
        {
            return _context.Answers;
        }

        public Answer Get(int id)
        {
            return _context.Answers.FirstOrDefault(x => x.Id == id);
        }

        public int Insert(Answer answer)
        {
            if (answer == null)
                throw new ArgumentNullException();

            if (Get(answer.Id) == null)
            {
                _context.Answers.Add(answer);
                _context.SaveChanges();
            }

            return answer.Id;
        }

        public void Edit(Answer answer)
        {
            if (answer == null)
                throw new ArgumentNullException();

            Answer answerToEdit = Get(answer.Id);

            if (answerToEdit != null)
            {
                answerToEdit.Text = answer.Text;
                _context.SaveChanges();
            }
        }

        public void Remove(int id)
        {
            Answer answer = Get(id);

            if (answer != null)
            {
                _context.Answers.Remove(answer);
                _context.SaveChanges();
            }
        }
    }
}