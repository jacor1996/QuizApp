using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuizApp.Entities;
using QuizApp.Repositories.Abstract;
using QuizApp.Services.Abstract;

namespace QuizApp.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IAnswerService _answerService;

        public QuestionsController(IQuestionRepository questionRepository, IAnswerService answerService)
        {
            _questionRepository = questionRepository;
            _answerService = answerService;
        }

        // GET: Questions
        public ActionResult Index()
        {
            var data = _questionRepository.GetAll();
            return View(data);
        }

        public ActionResult Create()
        {
            ViewBag.AnswersSelectList = _answerService.GetAnswersSelectList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Question question)
        {
            ViewBag.AnswersSelectList = _answerService.GetAnswersSelectList();

            if (ModelState.IsValid)
            {
                _questionRepository.Insert(question);
                return RedirectToAction("Index");
            }

            return View(question);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            if (_questionRepository.Get(id) != null)
            {
                _questionRepository.Remove(id);
                return RedirectToAction("Index");
            }

            return HttpNotFound("Question with specified id does not exist!");
        }
    }
}