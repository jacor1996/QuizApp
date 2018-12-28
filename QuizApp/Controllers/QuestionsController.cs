using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuizApp.Repositories.Abstract;

namespace QuizApp.Controllers
{
    public class QuestionsController : Controller
    {
        private IQuestionRepository _questionRepository;

        public QuestionsController(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        // GET: Questions
        public ActionResult Index()
        {
            var data = _questionRepository.GetAll();
            return View(data);
        }
    }
}