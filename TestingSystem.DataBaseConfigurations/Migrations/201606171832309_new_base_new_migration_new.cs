namespace TestingSystem.DataBaseConfigurations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_base_new_migration_new : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Test", "Duration", c => c.Time(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Test", "Duration", c => c.DateTime(nullable: false));
        }
    }
}
