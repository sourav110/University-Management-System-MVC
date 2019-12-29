namespace UniversityManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Teacher2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        DesignationId = c.Int(nullable: false, identity: true),
                        DesignationName = c.String(),
                    })
                .PrimaryKey(t => t.DesignationId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherId = c.Int(nullable: false, identity: true),
                        TeacherName = c.String(nullable: false, maxLength: 50),
                        Address = c.String(),
                        Email = c.String(nullable: false, maxLength: 8000, unicode: false),
                        ContactNo = c.String(nullable: false),
                        DesignationId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        CreditToBeTaken = c.Double(nullable: false),
                        RemainingCredit = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.TeacherId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .ForeignKey("dbo.Designations", t => t.DesignationId)
                .Index(t => t.DesignationId)
                .Index(t => t.DepartmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teachers", "DesignationId", "dbo.Designations");
            DropForeignKey("dbo.Teachers", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Teachers", new[] { "DepartmentId" });
            DropIndex("dbo.Teachers", new[] { "DesignationId" });
            DropTable("dbo.Teachers");
            DropTable("dbo.Designations");
        }
    }
}
