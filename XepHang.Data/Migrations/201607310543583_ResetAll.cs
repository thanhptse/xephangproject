namespace XepHang.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ResetAll : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rooms", "DepartmentId", "dbo.Departments");
            DropPrimaryKey("dbo.Departments");
            DropColumn("dbo.Departments", "DepartmentId");
            DropColumn("dbo.Departments", "DepartmentName");
            AddColumn("dbo.Departments", "DepartmentId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Departments", "DepartmentName", c => c.String(nullable: false, maxLength: 50));
            AddPrimaryKey("dbo.Departments", "DepartmentId");
            AddForeignKey("dbo.Rooms", "DepartmentId", "dbo.Departments", "DepartmentId", cascadeDelete: true);
           
        }
        
        public override void Down()
        {
            AddColumn("dbo.Departments", "DepartmentName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Departments", "DepartmentId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Rooms", "DepartmentId", "dbo.Departments");
            DropPrimaryKey("dbo.Departments");
            DropColumn("dbo.Departments", "DepartmentName");
            DropColumn("dbo.Departments", "DepartmentId");
            AddPrimaryKey("dbo.Departments", "DepartmentId");
            AddForeignKey("dbo.Rooms", "DepartmentId", "dbo.Departments", "DepartmentId", cascadeDelete: true);
        }
    }
}
