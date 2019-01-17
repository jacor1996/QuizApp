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
                    CorrectAnswerId = 1,
                    Answers = new List<Answer>
                    {
                        new Answer { Id = 1, Text = "1" },
                        new Answer { Id = 2,Text = "20" },
                        new Answer { Id = 3,Text = "21" },
                        new Answer { Id = 4,Text = "19" },
                    }
                },

                new Question
                {
                    Id = 2,
                    Text = "The capitol of Poland is:",
                    CorrectAnswerId = 5,
                    Answers = new List<Answer>
                    {
                        new Answer {Id = 5, Text = "Wroclaw" },
                        new Answer {Id = 6, Text = "Krakow" },
                        new Answer {Id = 7, Text = "Katowice" },
                        new Answer {Id = 8, Text = "Warsaw" }
                    }
                },

                new Question
                {
                    Id = 3,
                    Text = "Who is the biggest drunk in Trailer Park Boys Tv series?",
                    CorrectAnswerId = 9,
                    Answers = new List<Answer>
                    {
                        new Answer {Id = 9, Text = "Jim Lahey" },
                        new Answer {Id = 10, Text = "Randy Bobandy" },
                        new Answer {Id = 11, Text = "Ricky" },
                        new Answer {Id = 12, Text = "Bubbles" }
                    }
                },

                new Question
                {
                    Id = 4,
                    Text = "Which data type can store the biggest number?",
                    CorrectAnswerId = 13,
                    Answers = new List<Answer>
                    {
                        new Answer {Id = 13, Text = "int" },
                        new Answer {Id = 14, Text = "string" },
                        new Answer {Id = 15, Text = "long" },
                        new Answer {Id = 16, Text = "float" }
                    }
                }
            };

            questions.ForEach(q => context.Questions.AddOrUpdate(q));
            context.SaveChanges();
        }
    }
}