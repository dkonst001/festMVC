namespace FestMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class takenameoutfromInstructor : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Instructors", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Instructors", "Name", c => c.String(nullable: false));
        }
    }
}
