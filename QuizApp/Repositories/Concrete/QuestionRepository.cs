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
        private readonly QuizAppDbContext _context;

        public QuestionRepository(QuizAppDbContext context)
        {
            _context = context;
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
            return _context.Questions.Where(q => q.Id == id)
                .Include(q => q.Answers)
                .Include(q => q.CorrectAnswer)
                .FirstOrDefault();
        }

        public void Insert(Question question)
        {
            if (question == null)
                throw new ArgumentNullException();

            if (Get(question.Id) == null)
            {
                _context.Questions.Add(question);
                _context.SaveChanges();
            }
        }

        public void Edit(Question question)
        {
            if (question == null)
                throw new ArgumentException();

            Question questionToEdit = Get(question.Id);

            if (questionToEdit != null)
            {
                questionToEdit.Text = question.Text;
                questionToEdit.CorrectAnswer = question.CorrectAnswer;
                questionToEdit.Answers = question.Answers;

                _context.SaveChanges();
            }
        }

        public void Remove(int id)
        {
            Question question = Get(id);

            if (question != null)
            {
                _context.Questions.Remove(question);
                _context.SaveChanges();
            }
        }
    }
}