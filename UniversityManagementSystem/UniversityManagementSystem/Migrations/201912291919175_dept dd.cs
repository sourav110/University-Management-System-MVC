namespace UniversityManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deptdd : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AssignCourses", "CourseName");
            DropColumn("dbo.AssignCourses", "CourseCredit");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AssignCourses", "CourseCredit", c => c.Double(nullable: false));
            AddColumn("dbo.AssignCourses", "CourseName", c => c.String());
        }
    }
}
