namespace FestMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AboutinInstructortoMultilineandUserIdrequired : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Instructors", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Instructors", new[] { "UserId" });
            AlterColumn("dbo.Instructors", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Instructors", "UserId");
            AddForeignKey("dbo.Instructors", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Instructors", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Instructors", new[] { "UserId" });
            AlterColumn("dbo.Instructors", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Instructors", "UserId");
            AddForeignKey("dbo.Instructors", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
