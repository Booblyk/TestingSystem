namespace TestingSystem.DataBaseConfigurations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_base_new_migration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.User", "GroupId", "dbo.Group");
            DropForeignKey("dbo.TeacherSubject", "SunbjectId", "dbo.Subject");
            DropForeignKey("dbo.TeacherSubject", "TeacherId", "dbo.User");
            DropForeignKey("dbo.UserInRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.UserInRole", "UserId", "dbo.User");
            DropForeignKey("dbo.Course", "GroupId", "dbo.Group");
            DropForeignKey("dbo.Course", "TeacherSubjectId", "dbo.TeacherSubject");
            DropForeignKey("dbo.Test", "CourseId", "dbo.Course");
            DropForeignKey("dbo.Test", "UserCreatorId", "dbo.User");
            DropForeignKey("dbo.Answer", "QuestionId", "dbo.Question");
            DropForeignKey("dbo.Answer", "UserId", "dbo.User");
            DropIndex("dbo.Answer", new[] { "QuestionId" });
            DropIndex("dbo.Answer", new[] { "UserId" });
            DropIndex("dbo.Test", new[] { "CourseId" });
            DropIndex("dbo.Test", new[] { "UserCreatorId" });
            DropIndex("dbo.Course", new[] { "GroupId" });
            DropIndex("dbo.Course", new[] { "TeacherSubjectId" });
            DropIndex("dbo.User", new[] { "GroupId" });
            DropIndex("dbo.TeacherSubject", new[] { "SunbjectId" });
            DropIndex("dbo.TeacherSubject", new[] { "TeacherId" });
            DropIndex("dbo.UserInRole", new[] { "UserId" });
            DropIndex("dbo.UserInRole", new[] { "RoleId" });
            AddColumn("dbo.Question", "Answer", c => c.Boolean(nullable: false));
            AddColumn("dbo.Question", "Questionn", c => c.String());
            AddColumn("dbo.Test", "Description", c => c.String(maxLength: 350));
            AddColumn("dbo.User", "Password", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.User", "Role", c => c.String());
            DropColumn("dbo.Question", "Value");
            DropColumn("dbo.Question", "question");
            DropColumn("dbo.Test", "Name");
            DropColumn("dbo.Test", "MaxWork");
            DropColumn("dbo.Test", "CourseId");
            DropColumn("dbo.Test", "AccessibleDate");
            DropColumn("dbo.Test", "UserCreatorId");
            DropColumn("dbo.User", "PasswordHash");
            DropColumn("dbo.User", "PasswordSalt");
            DropColumn("dbo.User", "GroupId");
            DropColumn("dbo.User", "IsActive");
            DropColumn("dbo.Mark", "Date");
            DropTable("dbo.Answer");
            DropTable("dbo.Course");
            DropTable("dbo.Group");
            DropTable("dbo.TeacherSubject");
            DropTable("dbo.Subject");
            DropTable("dbo.UserInRole");
            DropTable("dbo.Role");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserInRole",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subject",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TeacherSubject",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SunbjectId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Group",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupId = c.Int(nullable: false),
                        TeacherSubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Answer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuestionId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Value = c.String(),
                        IsCorrect = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Mark", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.User", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.User", "GroupId", c => c.Int(nullable: false));
            AddColumn("dbo.User", "PasswordSalt", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.User", "PasswordHash", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Test", "UserCreatorId", c => c.Int(nullable: false));
            AddColumn("dbo.Test", "AccessibleDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Test", "CourseId", c => c.Int(nullable: false));
            AddColumn("dbo.Test", "MaxWork", c => c.DateTime(nullable: false));
            AddColumn("dbo.Test", "Name", c => c.String(nullable: false, maxLength: 350));
            AddColumn("dbo.Question", "question", c => c.String(nullable: false));
            AddColumn("dbo.Question", "Value", c => c.String());
            DropColumn("dbo.User", "Role");
            DropColumn("dbo.User", "Password");
            DropColumn("dbo.Test", "Description");
            DropColumn("dbo.Question", "Questionn");
            DropColumn("dbo.Question", "Answer");
            CreateIndex("dbo.UserInRole", "RoleId");
            CreateIndex("dbo.UserInRole", "UserId");
            CreateIndex("dbo.TeacherSubject", "TeacherId");
            CreateIndex("dbo.TeacherSubject", "SunbjectId");
            CreateIndex("dbo.User", "GroupId");
            CreateIndex("dbo.Course", "TeacherSubjectId");
            CreateIndex("dbo.Course", "GroupId");
            CreateIndex("dbo.Test", "UserCreatorId");
            CreateIndex("dbo.Test", "CourseId");
            CreateIndex("dbo.Answer", "UserId");
            CreateIndex("dbo.Answer", "QuestionId");
            AddForeignKey("dbo.Answer", "UserId", "dbo.User", "Id");
            AddForeignKey("dbo.Answer", "QuestionId", "dbo.Question", "Id");
            AddForeignKey("dbo.Test", "UserCreatorId", "dbo.User", "Id");
            AddForeignKey("dbo.Test", "CourseId", "dbo.Course", "Id");
            AddForeignKey("dbo.Course", "TeacherSubjectId", "dbo.TeacherSubject", "Id");
            AddForeignKey("dbo.Course", "GroupId", "dbo.Group", "Id");
            AddForeignKey("dbo.UserInRole", "UserId", "dbo.User", "Id");
            AddForeignKey("dbo.UserInRole", "RoleId", "dbo.Role", "Id");
            AddForeignKey("dbo.TeacherSubject", "TeacherId", "dbo.User", "Id");
            AddForeignKey("dbo.TeacherSubject", "SunbjectId", "dbo.Subject", "Id");
            AddForeignKey("dbo.User", "GroupId", "dbo.Group", "Id");
        }
    }
}
