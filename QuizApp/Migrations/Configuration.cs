using System.Collections.Generic;
using QuizApp.Entities;

namespace QuizApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<QuizAppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(QuizAppDbContext context)
        {
            DbInitializer initializer = new DbInitializer();
            initializer.SeedDb(context);
        }
    }
}
