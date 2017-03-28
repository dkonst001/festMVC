namespace FestMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addvalidations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Enrollments", "UserID", c => c.String(nullable: false));
            AlterColumn("dbo.Enrollments", "EventId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Enrollments", "EventId", c => c.String());
            AlterColumn("dbo.Enrollments", "UserID", c => c.String());
            AlterColumn("dbo.Categories", "Name", c => c.String());
        }
    }
}
