namespace FestMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBaseEnrollmentwithNumOfTickets : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Enrollments", "NumOfTickets", c => c.Int(nullable: false));
            AddColumn("dbo.FestivalEnrollments", "NumOfTickets", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FestivalEnrollments", "NumOfTickets");
            DropColumn("dbo.Enrollments", "NumOfTickets");
        }
    }
}
