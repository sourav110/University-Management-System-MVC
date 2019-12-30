namespace UniversityManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class courseassigntoteacher : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AssignCourses", "CourseName", c => c.String());
            AddColumn("dbo.AssignCourses", "CourseCredit", c => c.Double(nullable: false));
            AddColumn("dbo.Courses", "CourseCredit", c => c.Double(nullable: false));
            DropColumn("dbo.Courses", "Credit");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "Credit", c => c.Double(nullable: false));
            DropColumn("dbo.Courses", "CourseCredit");
            DropColumn("dbo.AssignCourses", "CourseCredit");
            DropColumn("dbo.AssignCourses", "CourseName");
        }
    }
}
