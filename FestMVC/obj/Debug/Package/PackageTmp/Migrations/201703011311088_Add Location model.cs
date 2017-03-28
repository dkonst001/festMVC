namespace FestMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLocationmodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Adress = c.String(),
                        Capacity = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        Size = c.Int(nullable: false),
                        NumberOfHalls = c.Int(nullable: false),
                        ArenaMapImage = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Locations");
        }
    }
}
