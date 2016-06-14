namespace TestingSystem.DataBaseConfigurations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial_one_booblyk_huj : DbMigration
    {
        public override void Up()
        {
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Question", t => t.QuestionId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.QuestionId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Question",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TestId = c.Int(nullable: false),
                        Value = c.String(),
                        question = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Test", t => t.TestId, cascadeDelete: true)
                .Index(t => t.TestId);
            
            CreateTable(
                "dbo.Test",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 350),
                        Duration = c.DateTime(nullable: false),
                        MaxWork = c.DateTime(nullable: false),
                        CourseId = c.Int(nullable: false),
                        AccessibleDate = c.DateTime(nullable: false),
                        UserCreatorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Course", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserCreatorId, cascadeDelete: false)
                .Index(t => t.CourseId)
                .Index(t => t.UserCreatorId);
            
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupId = c.Int(nullable: false),
                        TeacherSubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Group", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.TeacherSubject", t => t.TeacherSubjectId, cascadeDelete: true)
                .Index(t => t.GroupId)
                .Index(t => t.TeacherSubjectId);
            
            CreateTable(
                "dbo.Group",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 100),
                        PasswordHash = c.String(nullable: false, maxLength: 100),
                        PasswordSalt = c.String(nullable: false, maxLength: 100),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                        GroupId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Group", t => t.GroupId, cascadeDelete: false)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.Mark",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TestId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.StudentId, cascadeDelete: true)
                .ForeignKey("dbo.Test", t => t.TestId, cascadeDelete: true)
                .Index(t => t.TestId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.TeacherSubject",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SunbjectId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subject", t => t.SunbjectId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.TeacherId, cascadeDelete: false)
                .Index(t => t.SunbjectId)
                .Index(t => t.TeacherId);
            
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
                "dbo.UserInRole",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Answer", "UserId", "dbo.User");
            DropForeignKey("dbo.Answer", "QuestionId", "dbo.Question");
            DropForeignKey("dbo.Question", "TestId", "dbo.Test");
            DropForeignKey("dbo.Test", "UserCreatorId", "dbo.User");
            DropForeignKey("dbo.Test", "CourseId", "dbo.Course");
            DropForeignKey("dbo.Course", "TeacherSubjectId", "dbo.TeacherSubject");
            DropForeignKey("dbo.Course", "GroupId", "dbo.Group");
            DropForeignKey("dbo.UserInRole", "UserId", "dbo.User");
            DropForeignKey("dbo.UserInRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.TeacherSubject", "TeacherId", "dbo.User");
            DropForeignKey("dbo.TeacherSubject", "SunbjectId", "dbo.Subject");
            DropForeignKey("dbo.Mark", "TestId", "dbo.Test");
            DropForeignKey("dbo.Mark", "StudentId", "dbo.User");
            DropForeignKey("dbo.User", "GroupId", "dbo.Group");
            DropIndex("dbo.UserInRole", new[] { "RoleId" });
            DropIndex("dbo.UserInRole", new[] { "UserId" });
            DropIndex("dbo.TeacherSubject", new[] { "TeacherId" });
            DropIndex("dbo.TeacherSubject", new[] { "SunbjectId" });
            DropIndex("dbo.Mark", new[] { "StudentId" });
            DropIndex("dbo.Mark", new[] { "TestId" });
            DropIndex("dbo.User", new[] { "GroupId" });
            DropIndex("dbo.Course", new[] { "TeacherSubjectId" });
            DropIndex("dbo.Course", new[] { "GroupId" });
            DropIndex("dbo.Test", new[] { "UserCreatorId" });
            DropIndex("dbo.Test", new[] { "CourseId" });
            DropIndex("dbo.Question", new[] { "TestId" });
            DropIndex("dbo.Answer", new[] { "UserId" });
            DropIndex("dbo.Answer", new[] { "QuestionId" });
            DropTable("dbo.Role");
            DropTable("dbo.UserInRole");
            DropTable("dbo.Subject");
            DropTable("dbo.TeacherSubject");
            DropTable("dbo.Mark");
            DropTable("dbo.User");
            DropTable("dbo.Group");
            DropTable("dbo.Course");
            DropTable("dbo.Test");
            DropTable("dbo.Question");
            DropTable("dbo.Answer");
        }
    }
}
