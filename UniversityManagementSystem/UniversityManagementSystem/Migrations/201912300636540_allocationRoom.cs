namespace UniversityManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class allocationRoom : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AllocatedClassroms",
                c => new
                    {
                        AllocatedClassroomId = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        RoomId = c.Int(nullable: false),
                        DayId = c.Int(nullable: false),
                        FromTime = c.String(),
                        ToTime = c.String(),
                        AllocationStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AllocatedClassroomId)
                .ForeignKey("dbo.Courses", t => t.CourseId)
                .ForeignKey("dbo.Days", t => t.DayId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .ForeignKey("dbo.Rooms", t => t.RoomId)
                .Index(t => t.DepartmentId)
                .Index(t => t.CourseId)
                .Index(t => t.RoomId)
                .Index(t => t.DayId);
            
            CreateTable(
                "dbo.Days",
                c => new
                    {
                        DayId = c.Int(nullable: false, identity: true),
                        DayName = c.String(),
                    })
                .PrimaryKey(t => t.DayId);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        RoomId = c.Int(nullable: false, identity: true),
                        RoomNo = c.String(),
                    })
                .PrimaryKey(t => t.RoomId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AllocatedClassroms", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.AllocatedClassroms", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.AllocatedClassroms", "DayId", "dbo.Days");
            DropForeignKey("dbo.AllocatedClassroms", "CourseId", "dbo.Courses");
            DropIndex("dbo.AllocatedClassroms", new[] { "DayId" });
            DropIndex("dbo.AllocatedClassroms", new[] { "RoomId" });
            DropIndex("dbo.AllocatedClassroms", new[] { "CourseId" });
            DropIndex("dbo.AllocatedClassroms", new[] { "DepartmentId" });
            DropTable("dbo.Rooms");
            DropTable("dbo.Days");
            DropTable("dbo.AllocatedClassroms");
        }
    }
}
