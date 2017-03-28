namespace FestMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClearFestivalViewModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Festivals", "StartTime");
            DropColumn("dbo.Festivals", "EndTime");
            DropColumn("dbo.Festivals", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Festivals", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Festivals", "EndTime", c => c.DateTime());
            AddColumn("dbo.Festivals", "StartTime", c => c.DateTime());
        }
    }
}
