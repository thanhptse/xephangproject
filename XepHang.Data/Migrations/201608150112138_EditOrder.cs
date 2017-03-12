namespace XepHang.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Username", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Username");
        }
    }
}
