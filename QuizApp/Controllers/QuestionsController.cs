using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuizApp.Entities;
using QuizApp.Models;
using QuizApp.Repositories.Abstract;
using QuizApp.Services.Abstract;

namespace QuizApp.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IAnswerRepository _answerRepository;
        private readonly IAnswerService _answerService;

        public QuestionsController(IQuestionRepository questionRepository, IAnswerRepository answerRepository, IAnswerService answerService)
        {
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;
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
            QuestionModelView modelView = new QuestionModelView
            {
                Answers = new List<Answer>(4) {new Answer(), new Answer(), new Answer(), new Answer()},
                Question = new Question()
            };

            return View(modelView);
        }

        [HttpPost]
        public ActionResult Create(QuestionModelView modelView)
        {
            ViewBag.AnswersSelectList = _answerService.GetAnswersSelectList();

            modelView.Question.Answers = modelView.Answers;
            modelView.Question.CorrectAnswerId = modelView.Answers[0].Id;

            if (ModelState.IsValid)
            {
                Question question = new Question();

                question.Text = modelView.Question.Text;
                question.Answers = modelView.Answers;

                int index = -1;
                for (int i = 0; i < question.Answers.Count; i++)
                {
                    Answer answer = question.Answers.ElementAt(i);
                    if (i == 0)
                    {
                        index = _answerRepository.Insert(question.Answers.ElementAt(i));
                    }
                    else
                        _answerRepository.Insert(answer);
                }

                question.CorrectAnswerId = index;

                _questionRepository.Insert(question);

                return RedirectToAction("Index");
            }

            return View(modelView);
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