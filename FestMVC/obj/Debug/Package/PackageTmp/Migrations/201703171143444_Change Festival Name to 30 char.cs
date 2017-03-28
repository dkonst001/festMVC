namespace FestMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeFestivalNameto30char : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Festivals", "Name", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Festivals", "Name", c => c.String(nullable: false, maxLength: 15));
        }
    }
}
