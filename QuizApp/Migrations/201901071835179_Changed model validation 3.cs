namespace QuizApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changedmodelvalidation3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Questions", "Text", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Questions", "Text", c => c.String(maxLength: 256));
        }
    }
}
