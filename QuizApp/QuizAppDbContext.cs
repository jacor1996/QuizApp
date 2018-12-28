using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using QuizApp.Entities;

namespace QuizApp
{
    public class QuizAppDbContext : DbContext
    {
        public QuizAppDbContext() : base("name=QuizAppConnectionString")
        {
            
        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        
    }
}