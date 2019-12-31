namespace UniversityManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class isassigned1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "IsAssigned", c => c.Boolean(nullable: false));
            DropColumn("dbo.Courses", "IsEnrolled");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "IsEnrolled", c => c.Boolean(nullable: false));
            DropColumn("dbo.Courses", "IsAssigned");
        }
    }
}
