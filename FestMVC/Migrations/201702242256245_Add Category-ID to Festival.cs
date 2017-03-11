namespace FestMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoryIDtoFestival : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Festivals", "CategoryId", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Festivals", "CategoryId");
        }
    }
}
