namespace UniversityManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renameallocation : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AllocatedClassroms", newName: "AllocatedClassrooms");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.AllocatedClassrooms", newName: "AllocatedClassroms");
        }
    }
}
