namespace FestMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnrollmentEventIdtolong : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Enrollments", "EventId", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Enrollments", "EventId", c => c.String(nullable: false));
        }
    }
}
