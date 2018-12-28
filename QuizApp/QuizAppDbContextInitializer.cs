using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using QuizApp.Entities;

namespace QuizApp
{
    public class QuizAppDbContextInitializer : DropCreateDatabaseIfModelChanges<QuizAppDbContext>
    {
        protected override void Seed(QuizAppDbContext context)
        {
            var questions = new List<Question>
            {
                new Question
                {
                    Id = 1,
                    Text = "How many fingers do people have?",
                    CorrectAnswer = "20",
                    Answers = new List<string>
                    {
                        "1",
                        "20",
                        "21",
                        "19"
                    }
                },

                new Question
                {
                    Id = 2,
                    Text = "The capitol of Poland is:",
                    CorrectAnswer = "Warsaw",
                    Answers = new List<string>
                    {
                        "Wroclaw",
                        "Krakow",
                        "Katowice",
                        "Warsaw"
                    }
                },

                new Question
                {
                    Id = 3,
                    Text = "Who is the biggest drunk in Trailer Park Boys Tv series?",
                    CorrectAnswer = "Jim Lahey",
                    Answers = new List<string>
                    {
                        "Jim Lahey",
                        "Randy Bobandy",
                        "Ricky",
                        "Bubbles"
                    }
                },

                new Question
                {
                    Id = 4,
                    Text = "Which data type can store the biggest number?",
                    CorrectAnswer = "20",
                    Answers = new List<string>
                    {
                        "int",
                        "string",
                        "long",
                        "float"
                    }
                }
            };

            questions.ForEach(q => context.Questions.Add(q));
            context.SaveChanges();
        }
    }
}