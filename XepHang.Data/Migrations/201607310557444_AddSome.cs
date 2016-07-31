namespace XepHang.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSome : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Departments", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.Rooms", "CreatedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rooms", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Departments", "CreatedDate", c => c.DateTime(nullable: false));
        }
    }
}
