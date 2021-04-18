namespace HospitalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "BeginWorkingHours", c => c.DateTime(nullable: false));
            AddColumn("dbo.Employees", "EndWorkingHours", c => c.DateTime(nullable: false));
            DropColumn("dbo.Employees", "WorkingHours");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "WorkingHours", c => c.Int(nullable: false));
            DropColumn("dbo.Employees", "EndWorkingHours");
            DropColumn("dbo.Employees", "BeginWorkingHours");
        }
    }
}
