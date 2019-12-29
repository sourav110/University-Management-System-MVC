namespace UniversityManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deartment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentCode = c.String(nullable: false, maxLength: 7, unicode: false),
                        DepartmentName = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Departments");
        }
    }
}
