namespace TestingSystem.DataBaseConfigurations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new_data_base : DbMigration
    {
        public override void Up()
        {
            //DropColumn("dbo.Question", "Answer");
            AddColumn("dbo.Question", "Answer", c => c.String());
        }
        
        public override void Down()
        {
            
        }
    }
}
