namespace FestMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEventstoFestival : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Events", "FestivalId");
            AddForeignKey("dbo.Events", "FestivalId", "dbo.Festivals", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "FestivalId", "dbo.Festivals");
            DropIndex("dbo.Events", new[] { "FestivalId" });
        }
    }
}
