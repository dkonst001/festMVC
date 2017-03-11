namespace FestMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EventImages : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EventImages",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Mame = c.String(),
                        EventId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EventImages");
        }
    }
}
