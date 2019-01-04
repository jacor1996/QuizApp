using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using QuizApp.Entities;

namespace QuizApp
{
    public class DbInitializer
    {
        public void SeedDb(QuizAppDbContext context)
        {
            var questions = new List<Question>
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

            questions.ForEach(q => context.Questions.AddOrUpdate(q));
            context.SaveChanges();
        }
    }
}