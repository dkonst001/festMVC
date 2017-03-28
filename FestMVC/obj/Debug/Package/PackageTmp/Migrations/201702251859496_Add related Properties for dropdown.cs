namespace FestMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddrelatedPropertiesfordropdown : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EventImages", "Name", c => c.String());
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.FestivalManagers", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Events", "InstructorId");
            CreateIndex("dbo.Events", "RoomId");
            CreateIndex("dbo.EventImages", "EventId");
            CreateIndex("dbo.FestivalManagers", "UserId");
            CreateIndex("dbo.Enrollments", "EventId");
            AddForeignKey("dbo.EventImages", "EventId", "dbo.Events", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Events", "InstructorId", "dbo.Instructors", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Events", "RoomId", "dbo.Rooms", "Id", cascadeDelete: true);
            AddForeignKey("dbo.FestivalManagers", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Enrollments", "EventId", "dbo.Events", "Id", cascadeDelete: true);
            DropColumn("dbo.EventImages", "Mame");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EventImages", "Mame", c => c.String());
            DropForeignKey("dbo.Enrollments", "EventId", "dbo.Events");
            DropForeignKey("dbo.FestivalManagers", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Events", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Events", "InstructorId", "dbo.Instructors");
            DropForeignKey("dbo.EventImages", "EventId", "dbo.Events");
            DropIndex("dbo.Enrollments", new[] { "EventId" });
            DropIndex("dbo.FestivalManagers", new[] { "UserId" });
            DropIndex("dbo.EventImages", new[] { "EventId" });
            DropIndex("dbo.Events", new[] { "RoomId" });
            DropIndex("dbo.Events", new[] { "InstructorId" });
            AlterColumn("dbo.FestivalManagers", "UserId", c => c.String());
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false, maxLength: 10));
            DropColumn("dbo.EventImages", "Name");
        }
    }
}
