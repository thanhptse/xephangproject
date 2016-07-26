namespace XepHang.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TheSecond : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepeartmentId = c.Int(nullable: false, identity: true),
                        DepeartmentName = c.String(nullable: false, maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        CreateBy = c.String(),
                        ModifiledDate = c.DateTime(),
                        ModifiledBy = c.String(),
                        Note = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DepeartmentId);
            
            CreateTable(
                "dbo.NumberReports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoomId = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        CurrentNumbebOrder = c.Int(nullable: false),
                        TotalNumberOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.RoomId);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        RoomId = c.Int(nullable: false, identity: true),
                        RoomName = c.String(nullable: false, maxLength: 50),
                        DepartmentId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreateBy = c.String(),
                        ModifiledDate = c.DateTime(),
                        ModifiledBy = c.String(),
                        Note = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RoomId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        RoomId = c.Int(nullable: false),
                        ChosenNumber = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        ModifiledDate = c.DateTime(),
                        ModifiledBy = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.RoomId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.NumberReports", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Rooms", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Orders", new[] { "RoomId" });
            DropIndex("dbo.Rooms", new[] { "DepartmentId" });
            DropIndex("dbo.NumberReports", new[] { "RoomId" });
            DropTable("dbo.Orders");
            DropTable("dbo.Rooms");
            DropTable("dbo.NumberReports");
            DropTable("dbo.Departments");
        }
    }
}
