namespace QuizApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modelchanges2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Questions", "CorrectAnswerId", "dbo.Answers");
            DropIndex("dbo.Questions", new[] { "CorrectAnswerId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Questions", "CorrectAnswerId");
            AddForeignKey("dbo.Questions", "CorrectAnswerId", "dbo.Answers", "Id", cascadeDelete: true);
        }
    }
}
