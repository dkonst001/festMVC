namespace FestMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoryIDdeletedfromEvent : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Events", "CategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "CategoryId", c => c.Long(nullable: false));
        }
    }
}
