namespace QuizApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changedmodelvalidation2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Answers", "Text", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Answers", "Text", c => c.String(maxLength: 256));
        }
    }
}
