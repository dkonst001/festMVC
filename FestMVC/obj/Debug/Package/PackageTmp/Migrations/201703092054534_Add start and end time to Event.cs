namespace FestMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddstartandendtimetoEvent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Festivals", "StartTime", c => c.DateTime());
            AddColumn("dbo.Festivals", "EndTime", c => c.DateTime());
            AddColumn("dbo.Festivals", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Events", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Events", "EndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Events", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Events", "StartTime", c => c.DateTime());
            AlterColumn("dbo.Events", "EndTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "EndTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Events", "StartTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Events", "Discriminator");
            DropColumn("dbo.Events", "EndDate");
            DropColumn("dbo.Events", "StartDate");
            DropColumn("dbo.Festivals", "Discriminator");
            DropColumn("dbo.Festivals", "EndTime");
            DropColumn("dbo.Festivals", "StartTime");
        }
    }
}
