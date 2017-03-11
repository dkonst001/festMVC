namespace FestMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedIncrementstable : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Increments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Increments",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Incremented = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
