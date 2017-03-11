namespace FestMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeFestivaltopointtoLocation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Festivals", "LocationId", c => c.Long(nullable: false));
            CreateIndex("dbo.Festivals", "LocationId");
            AddForeignKey("dbo.Festivals", "LocationId", "dbo.Locations", "Id", cascadeDelete: false);
            DropColumn("dbo.Festivals", "Location");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Festivals", "Location", c => c.String());
            DropForeignKey("dbo.Festivals", "LocationId", "dbo.Locations");
            DropIndex("dbo.Festivals", new[] { "LocationId" });
            DropColumn("dbo.Festivals", "LocationId");
        }
    }
}
