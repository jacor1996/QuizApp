using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using QuizApp.Entities;
using QuizApp.Services.Abstract;
using QuizApp.Services.Concrete;

namespace QuizAppTests
{
    [TestFixture]
    public class QuestionServiceTest
    {
        private IQuestionService _questionService;

        [SetUp]
        public void Initialize()
        {
            _questionService = new QuestionService();
        }

        [Test]
        public void ContainsCorrectAnswer_ContainsCorrectAnswer_ReturnsTrue()
        {
            Question question = new Question
            {
                Id = 1,
                Text = "How many fingers do people have?",
                CorrectAnswer = "Twenty",
                Answers = new List<string>()
                {
                    "One",
                    "Five",
                    "Twenty",
                    "Eleven"
                }
            };

            bool result = _questionService.ContainsCorrectAnswer(question);

            Assert.AreEqual(true, result);
        }

        [Test]
        public void ContainsCorrectAnswer_DoesNotContainCorrectAnswer_ReturnsFalse()
        {
            Question question = new Question
            {
                Id = 1,
                Text = "How many fingers do people have?",
                CorrectAnswer = "Twenty",
                Answers = new List<string>
                {
                    "One",
                    "Five",
                    "Six",
                    "Eleven"
                }
            };

            bool result = _questionService.ContainsCorrectAnswer(question);

            Assert.AreEqual(false, result);
        }

        [Test]
        public void ContainsCorrectAnswer_Null_ThrowsArgumentNullException()
        {
            Question question = null;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _questionService.ContainsCorrectAnswer(question)
            );

            Assert.AreEqual(typeof(ArgumentNullException), ex.GetType());
        }
    }
}
