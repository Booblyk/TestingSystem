namespace TestingSystem.DataBaseConfigurations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_database_new_answer_string : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Question", "Answer", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Question", "Answer", c => c.Boolean(nullable: false));
        }
    }
}
