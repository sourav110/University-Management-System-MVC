namespace UniversityManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AllocatedClassrooms", "FromTime", c => c.String(nullable: false));
            AlterColumn("dbo.AllocatedClassrooms", "ToTime", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AllocatedClassrooms", "ToTime", c => c.String());
            AlterColumn("dbo.AllocatedClassrooms", "FromTime", c => c.String());
        }
    }
}
