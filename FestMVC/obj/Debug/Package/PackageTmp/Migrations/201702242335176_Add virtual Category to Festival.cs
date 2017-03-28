namespace FestMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddvirtualCategorytoFestival : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Festivals", "CategoryId");
            AddForeignKey("dbo.Festivals", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Festivals", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Festivals", new[] { "CategoryId" });
        }
    }
}
