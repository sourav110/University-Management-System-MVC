namespace UniversityManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class virtualdept : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AllocatedClassrooms", "IsAllocated", c => c.Boolean(nullable: false));
            DropColumn("dbo.AllocatedClassrooms", "AllocationStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AllocatedClassrooms", "AllocationStatus", c => c.Boolean(nullable: false));
            DropColumn("dbo.AllocatedClassrooms", "IsAllocated");
        }
    }
}
