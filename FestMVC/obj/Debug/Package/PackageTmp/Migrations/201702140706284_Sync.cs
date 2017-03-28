namespace FestMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sync : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Festivals", "Name", c => c.String(nullable: false, maxLength: 15));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Festivals", "Name", c => c.String());
        }
    }
}
