namespace UniversityManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class grade : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EnrollCourses", "IsGraded", c => c.Boolean(nullable: false));
            DropColumn("dbo.EnrollCourses", "IsEnroll");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EnrollCourses", "IsEnroll", c => c.Boolean(nullable: false));
            DropColumn("dbo.EnrollCourses", "IsGraded");
        }
    }
}
