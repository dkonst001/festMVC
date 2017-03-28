namespace FestMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddrelatedUserfprEnrollment : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Enrollments", "UserID", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Enrollments", "UserID");
            AddForeignKey("dbo.Enrollments", "UserID", "dbo.AspNetUsers", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enrollments", "UserID", "dbo.AspNetUsers");
            DropIndex("dbo.Enrollments", new[] { "UserID" });
            AlterColumn("dbo.Enrollments", "UserID", c => c.String(nullable: false));
        }
    }
}
