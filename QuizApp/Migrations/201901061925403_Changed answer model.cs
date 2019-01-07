namespace QuizApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changedanswermodel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Answers", "Text", c => c.String(maxLength: 256));
            AlterColumn("dbo.Questions", "Text", c => c.String(maxLength: 256));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Questions", "Text", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.Answers", "Text", c => c.String(nullable: false, maxLength: 256));
        }
    }
}
