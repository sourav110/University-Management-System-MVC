namespace UniversityManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teacher : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "Credit", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "Credit", c => c.Single(nullable: false));
        }
    }
}
