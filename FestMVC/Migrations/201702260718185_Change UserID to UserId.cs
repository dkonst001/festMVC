namespace FestMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeUserIDtoUserId : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Enrollments", new[] { "UserID" });
            DropIndex("dbo.FestivalEnrollments", new[] { "UserID" });
            CreateIndex("dbo.Enrollments", "UserId");
            CreateIndex("dbo.FestivalEnrollments", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.FestivalEnrollments", new[] { "UserId" });
            DropIndex("dbo.Enrollments", new[] { "UserId" });
            CreateIndex("dbo.FestivalEnrollments", "UserID");
            CreateIndex("dbo.Enrollments", "UserID");
        }
    }
}
