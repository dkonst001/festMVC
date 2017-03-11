namespace FestMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAbouttoInstructor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Instructors", "About", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Instructors", "About");
        }
    }
}
