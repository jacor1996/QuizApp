using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using QuizApp.Entities;
using QuizApp.Repositories.Abstract;
using QuizApp.Repositories.Concrete;

namespace QuizAppTests
{
    [TestFixture]
    public class QuestionRepositoryTest
    {
        private IQuestionRepository _questionRepository;
        private Mock<IQuestionRepository> _mock;
        private List<Question> _questions;

        [SetUp]
        public void Initialize()
        {
            _mock = new Mock<IQuestionRepository>();
            _questions = new List<Question>
            {
                new Question
                {
                    Id = 1,
                    Text = "How many fingers do people have?",
                    CorrectAnswer = new Answer { Text = "20" },
                    Answers = new List<Answer>
                    {
                        new Answer { Text = "1" },
                        new Answer { Text = "20" },
                        new Answer { Text = "21" },
                        new Answer { Text = "19" },
                    }
                },

                new Question
                {
                    Id = 2,
                    Text = "The capitol of Poland is:",
                    CorrectAnswer = new Answer { Text = "Warsaw" },
                    Answers = new List<Answer>
                    {
                        new Answer { Text = "Wroclaw" },
                        new Answer { Text = "Krakow" },
                        new Answer { Text = "Katowice" },
                        new Answer { Text = "Warsaw" }
                    }
                },

                new Question
                {
                    Id = 3,
                    Text = "Who is the biggest drunk in Trailer Park Boys Tv series?",
                    CorrectAnswer = new Answer { Text = "Jim Lahey" },
                    Answers = new List<Answer>
                    {
                        new Answer { Text = "Jim Lahey" },
                        new Answer { Text = "Randy Bobandy" },
                        new Answer { Text = "Ricky" },
                        new Answer { Text = "Bubbles" }
                    }
                },

                new Question
                {
                    Id = 4,
                    Text = "Which data type can store the biggest number?",
                    CorrectAnswer = new Answer { Text = "int" },
                    Answers = new List<Answer>
                    {
                        new Answer { Text = "int" },
                        new Answer { Text = "string" },
                        new Answer { Text = "long" },
                        new Answer { Text = "float" }
                    }
                }
            };
        }

        [Test]
        public void ShouldReturnQuestionWhenIdExists()
        {
            Question question = new Question
            {
                Id = 1,
                Text = "2 + 2 = ?",
                CorrectAnswer = new Answer {Text = "4"},
                Answers = new List<Answer>
                {
                    new Answer {Text = "2"},
                    new Answer {Text = "4"},
                    new Answer {Text = "5"},
                    new Answer {Text = "6"}
                }
            };

            _mock.Setup(x => x.Get(1)).Returns(question);

            _questionRepository = _mock.Object;

            Question result = _questionRepository.Get(1);

            Assert.AreEqual(question, result);
        }

        [Test]
        public void ShouldReturnNullWhenIdDoesNotExist()
        {
            Question question = null;
            _mock.Setup(x => x.Get(999)).Returns(question);
            _questionRepository = _mock.Object;

            Question result = _questionRepository.Get(999);

            Assert.IsNull(result);
        }

        [Test]
        public void ShouldReturnAllQuestionsWhenRepositoryIsNotEmpty()
        {
            _mock.Setup(x => x.GetAll()).Returns(_questions);
            int expectedSize = _questions.Count;
            _questionRepository = _mock.Object;

            int size = _questionRepository.GetAll().Count();

            Assert.AreEqual(expectedSize, size);
        }

        [Test]
        public void ShouldReturnEmptyCollectionWhenRepositoryIsEmpty()
        {
            _questions = new List<Question>();
            _mock.Setup(x => x.GetAll()).Returns(_questions);
            _questionRepository = _mock.Object;
            int expectedSize = 0;

            int size = _questionRepository.GetAll().Count();

            Assert.AreEqual(expectedSize, size);
        }
    }
}
