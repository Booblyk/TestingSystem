namespace TestingSystem.DataBaseConfigurations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _some_new_error : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Question", "Answer", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Question", "Answer", c => c.Boolean(nullable: false));
        }
    }
}
