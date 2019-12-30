namespace UniversityManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class coursestatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Status", c => c.Boolean(nullable: false));
            DropColumn("dbo.Courses", "IsEnroll");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "IsEnroll", c => c.Boolean(nullable: false));
            DropColumn("dbo.Courses", "Status");
        }
    }
}
