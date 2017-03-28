namespace FestMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestArena : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Arenas",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FestivalId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Festivals", t => t.FestivalId, cascadeDelete: true)
                .Index(t => t.FestivalId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Arenas", "FestivalId", "dbo.Festivals");
            DropIndex("dbo.Arenas", new[] { "FestivalId" });
            DropTable("dbo.Arenas");
        }
    }
}
