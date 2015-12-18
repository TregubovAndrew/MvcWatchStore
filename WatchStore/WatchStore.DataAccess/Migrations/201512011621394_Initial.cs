namespace WatchStore.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PostalCode = c.Int(nullable: false),
                        Country = c.String(),
                        City = c.String(),
                        Address = c.String(),
                        Phone = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageSize = c.Int(nullable: false),
                        FileName = c.String(),
                        ImageData = c.Binary(),
                        WatchId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Watches", t => t.WatchId)
                .Index(t => t.WatchId);
            
            CreateTable(
                "dbo.Watches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Brand = c.String(),
                        Colour = c.String(),
                        WaterResistance = c.String(),
                        Warranty = c.Int(nullable: false),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderWatches",
                c => new
                    {
                        OrderId = c.Int(nullable: false),
                        WatchId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderId, t.WatchId })
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Watches", t => t.WatchId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.WatchId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Sum = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Email = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PostalCode = c.Int(nullable: false),
                        Country = c.String(),
                        City = c.String(),
                        Address = c.String(),
                        Phone = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderWatches", "WatchId", "dbo.Watches");
            DropForeignKey("dbo.OrderWatches", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Images", "WatchId", "dbo.Watches");
            DropIndex("dbo.OrderWatches", new[] { "WatchId" });
            DropIndex("dbo.OrderWatches", new[] { "OrderId" });
            DropIndex("dbo.Images", new[] { "WatchId" });
            DropTable("dbo.Orders");
            DropTable("dbo.OrderWatches");
            DropTable("dbo.Watches");
            DropTable("dbo.Images");
            DropTable("dbo.Accounts");
        }
    }
}
