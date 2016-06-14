namespace TestingSystem.DataBaseConfigurations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_migration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Answer", "QuestionId", "dbo.Question");
            DropForeignKey("dbo.Answer", "UserId", "dbo.User");
            DropForeignKey("dbo.Question", "TestId", "dbo.Test");
            DropForeignKey("dbo.Test", "CourseId", "dbo.Course");
            DropForeignKey("dbo.Mark", "TestId", "dbo.Test");
            DropForeignKey("dbo.Test", "UserCreatorId", "dbo.User");
            DropForeignKey("dbo.Course", "GroupId", "dbo.Group");
            DropForeignKey("dbo.Course", "TeacherSubjectId", "dbo.TeacherSubject");
            DropForeignKey("dbo.User", "GroupId", "dbo.Group");
            DropForeignKey("dbo.Mark", "StudentId", "dbo.User");
            DropForeignKey("dbo.TeacherSubject", "TeacherId", "dbo.User");
            DropForeignKey("dbo.UserInRole", "UserId", "dbo.User");
            DropForeignKey("dbo.TeacherSubject", "SunbjectId", "dbo.Subject");
            DropForeignKey("dbo.UserInRole", "RoleId", "dbo.Role");
            AddForeignKey("dbo.Answer", "QuestionId", "dbo.Question", "Id");
            AddForeignKey("dbo.Answer", "UserId", "dbo.User", "Id");
            AddForeignKey("dbo.Question", "TestId", "dbo.Test", "Id");
            AddForeignKey("dbo.Test", "CourseId", "dbo.Course", "Id");
            AddForeignKey("dbo.Mark", "TestId", "dbo.Test", "Id");
            AddForeignKey("dbo.Test", "UserCreatorId", "dbo.User", "Id");
            AddForeignKey("dbo.Course", "GroupId", "dbo.Group", "Id");
            AddForeignKey("dbo.Course", "TeacherSubjectId", "dbo.TeacherSubject", "Id");
            AddForeignKey("dbo.User", "GroupId", "dbo.Group", "Id");
            AddForeignKey("dbo.Mark", "StudentId", "dbo.User", "Id");
            AddForeignKey("dbo.TeacherSubject", "TeacherId", "dbo.User", "Id");
            AddForeignKey("dbo.UserInRole", "UserId", "dbo.User", "Id");
            AddForeignKey("dbo.TeacherSubject", "SunbjectId", "dbo.Subject", "Id");
            AddForeignKey("dbo.UserInRole", "RoleId", "dbo.Role", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserInRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.TeacherSubject", "SunbjectId", "dbo.Subject");
            DropForeignKey("dbo.UserInRole", "UserId", "dbo.User");
            DropForeignKey("dbo.TeacherSubject", "TeacherId", "dbo.User");
            DropForeignKey("dbo.Mark", "StudentId", "dbo.User");
            DropForeignKey("dbo.User", "GroupId", "dbo.Group");
            DropForeignKey("dbo.Course", "TeacherSubjectId", "dbo.TeacherSubject");
            DropForeignKey("dbo.Course", "GroupId", "dbo.Group");
            DropForeignKey("dbo.Test", "UserCreatorId", "dbo.User");
            DropForeignKey("dbo.Mark", "TestId", "dbo.Test");
            DropForeignKey("dbo.Test", "CourseId", "dbo.Course");
            DropForeignKey("dbo.Question", "TestId", "dbo.Test");
            DropForeignKey("dbo.Answer", "UserId", "dbo.User");
            DropForeignKey("dbo.Answer", "QuestionId", "dbo.Question");
            AddForeignKey("dbo.UserInRole", "RoleId", "dbo.Role", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TeacherSubject", "SunbjectId", "dbo.Subject", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserInRole", "UserId", "dbo.User", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TeacherSubject", "TeacherId", "dbo.User", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Mark", "StudentId", "dbo.User", "Id", cascadeDelete: true);
            AddForeignKey("dbo.User", "GroupId", "dbo.Group", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Course", "TeacherSubjectId", "dbo.TeacherSubject", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Course", "GroupId", "dbo.Group", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Test", "UserCreatorId", "dbo.User", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Mark", "TestId", "dbo.Test", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Test", "CourseId", "dbo.Course", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Question", "TestId", "dbo.Test", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Answer", "UserId", "dbo.User", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Answer", "QuestionId", "dbo.Question", "Id", cascadeDelete: true);
        }
    }
}
