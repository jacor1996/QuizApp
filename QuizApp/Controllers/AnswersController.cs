using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuizApp.Entities;
using QuizApp.Repositories.Abstract;

namespace QuizApp.Controllers
{
    public class AnswersController : Controller
    {
        private readonly IAnswerRepository _repository;

        public AnswersController(IAnswerRepository repository)
        {
            _repository = repository;
        }

        // GET: Answers
        public ActionResult Index()
        {
            var answers = _repository.GetAll();
            return View(answers);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Answer answer)
        {
            if (ModelState.IsValid)
            {
                _repository.Insert(answer);
                return RedirectToAction("Index");
            }

            return View(answer);
        }

        public ActionResult Edit(int id)
        {
            Answer answer = _repository.Get(id);

            if (answer == null)
            {
                return HttpNotFound("Answer with specified id does not exist.");
            }

            return View(answer);
        }

        [HttpPost]
        public ActionResult Edit(Answer answer)
        {
            if (ModelState.IsValid)
            {
                _repository.Edit(answer);
                return RedirectToAction("Index");
            }

            return View(answer);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            Answer answer = _repository.Get(id);

            if (answer != null)
            {
                _repository.Remove(id);
                return RedirectToAction("Index");
            }

            return HttpNotFound("Answer with specified id does not exist.");
        }
    }
}