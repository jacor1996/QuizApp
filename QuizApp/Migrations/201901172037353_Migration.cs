namespace QuizApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Questions", "CorrectAnswer_Id", "dbo.Answers");
            DropIndex("dbo.Questions", new[] { "CorrectAnswer_Id" });
            AlterColumn("dbo.Questions", "CorrectAnswer_Id", c => c.Int());
            CreateIndex("dbo.Questions", "CorrectAnswer_Id");
            AddForeignKey("dbo.Questions", "CorrectAnswer_Id", "dbo.Answers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "CorrectAnswer_Id", "dbo.Answers");
            DropIndex("dbo.Questions", new[] { "CorrectAnswer_Id" });
            AlterColumn("dbo.Questions", "CorrectAnswer_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Questions", "CorrectAnswer_Id");
            AddForeignKey("dbo.Questions", "CorrectAnswer_Id", "dbo.Answers", "Id", cascadeDelete: true);
        }
    }
}
