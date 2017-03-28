namespace FestMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeRoomtopointtoLocation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rooms", "LocationId", c => c.Long(nullable: false));
            CreateIndex("dbo.Rooms", "LocationId");
            AddForeignKey("dbo.Rooms", "LocationId", "dbo.Locations", "Id", cascadeDelete: true);
            DropColumn("dbo.Rooms", "Location");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rooms", "Location", c => c.String());
            DropForeignKey("dbo.Rooms", "LocationId", "dbo.Locations");
            DropIndex("dbo.Rooms", new[] { "LocationId" });
            DropColumn("dbo.Rooms", "LocationId");
        }
    }
}
