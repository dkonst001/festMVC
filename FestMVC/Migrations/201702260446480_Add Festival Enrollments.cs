namespace FestMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFestivalEnrollments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FestivalEnrollments",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UserID = c.String(nullable: false, maxLength: 128),
                        FestivalId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Festivals", t => t.FestivalId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.FestivalId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FestivalEnrollments", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.FestivalEnrollments", "FestivalId", "dbo.Festivals");
            DropIndex("dbo.FestivalEnrollments", new[] { "FestivalId" });
            DropIndex("dbo.FestivalEnrollments", new[] { "UserID" });
            DropTable("dbo.FestivalEnrollments");
        }
    }
}
