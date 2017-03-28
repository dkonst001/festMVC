namespace FestMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddvirtualFestivalManagertoFestival : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Festivals", "FestivalManagerId");
            AddForeignKey("dbo.Festivals", "FestivalManagerId", "dbo.FestivalManagers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Festivals", "FestivalManagerId", "dbo.FestivalManagers");
            DropIndex("dbo.Festivals", new[] { "FestivalManagerId" });
        }
    }
}
