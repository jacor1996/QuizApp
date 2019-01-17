namespace QuizApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modelchanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Questions", "CorrectAnswer_Id", "dbo.Answers");
            DropIndex("dbo.Questions", new[] { "CorrectAnswer_Id" });
            RenameColumn(table: "dbo.Questions", name: "CorrectAnswer_Id", newName: "CorrectAnswerId");
            AlterColumn("dbo.Questions", "CorrectAnswerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Questions", "CorrectAnswerId");
            AddForeignKey("dbo.Questions", "CorrectAnswerId", "dbo.Answers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "CorrectAnswerId", "dbo.Answers");
            DropIndex("dbo.Questions", new[] { "CorrectAnswerId" });
            AlterColumn("dbo.Questions", "CorrectAnswerId", c => c.Int());
            RenameColumn(table: "dbo.Questions", name: "CorrectAnswerId", newName: "CorrectAnswer_Id");
            CreateIndex("dbo.Questions", "CorrectAnswer_Id");
            AddForeignKey("dbo.Questions", "CorrectAnswer_Id", "dbo.Answers", "Id");
        }
    }
}
