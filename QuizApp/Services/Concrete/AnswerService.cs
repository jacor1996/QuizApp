using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuizApp.Entities;
using QuizApp.Repositories.Abstract;
using QuizApp.Services.Abstract;

namespace QuizApp.Services.Concrete
{
    public class AnswerService : IAnswerService
    {
        private readonly IAnswerRepository _repository;

        public AnswerService(IAnswerRepository repository)
        {
            _repository = repository;
        }

        public SelectList GetAnswersSelectList()
        {
            SelectList selectList = new SelectList(_repository.GetAll(), "Id", "Text", 1);

            return selectList;
        }
    }
}