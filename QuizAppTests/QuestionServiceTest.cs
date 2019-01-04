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
        public void ShouldReturnTrueWhenQuestionContainsCorrectAnswer()
        {
            Question question = new Question
            {
                Id = 1,
                Text = "How many fingers do people have?",
                CorrectAnswer = new Answer { Text = "Twenty" },
                Answers = new List<Answer>
                {
                    new Answer { Text = "One" },
                    new Answer { Text = "Five" },
                    new Answer { Text = "Twenty" },
                    new Answer { Text = "Eleven" }
                }
            };

            bool result = _questionService.ContainsCorrectAnswer(question);

            Assert.AreEqual(true, result);
        }

        [Test]
        public void ShouldReturnFalseWhenQuestionDoesNotContainCorrectAnswer()
        {
            Question question = new Question
            {
                Id = 1,
                Text = "How many fingers do people have?",
                CorrectAnswer = new Answer { Text = "Twenty" },
                Answers = new List<Answer>
                {
                    new Answer { Text = "One" },
                    new Answer { Text = "Five" },
                    new Answer { Text = "Six" },
                    new Answer { Text = "Eleven" }
                }
            };

            bool result = _questionService.ContainsCorrectAnswer(question);

            Assert.AreEqual(false, result);
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWhenQuestionIsNull()
        {
            Question question = null;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _questionService.ContainsCorrectAnswer(question)
            );

            Assert.AreEqual(typeof(ArgumentNullException), ex.GetType());
        }
    }
}
