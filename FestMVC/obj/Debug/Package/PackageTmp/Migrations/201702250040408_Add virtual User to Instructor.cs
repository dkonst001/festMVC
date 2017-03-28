namespace FestMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddvirtualUsertoInstructor : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Instructors", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Instructors", "UserId");
            AddForeignKey("dbo.Instructors", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Instructors", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Instructors", new[] { "UserId" });
            AlterColumn("dbo.Instructors", "UserId", c => c.String());
        }
    }
}
