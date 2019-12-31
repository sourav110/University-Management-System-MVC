namespace UniversityManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _bool : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "AssignedTo", c => c.String());
            AddColumn("dbo.Courses", "IsEnrolled", c => c.Boolean(nullable: false));
            DropColumn("dbo.Courses", "AssignTo");
            DropColumn("dbo.Courses", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Courses", "AssignTo", c => c.String());
            DropColumn("dbo.Courses", "IsEnrolled");
            DropColumn("dbo.Courses", "AssignedTo");
        }
    }
}
