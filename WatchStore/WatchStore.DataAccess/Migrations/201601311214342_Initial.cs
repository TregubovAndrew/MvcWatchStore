namespace WatchStore.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 128),
                        DateRegistered = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Image",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageSize = c.Int(nullable: false),
                        FileName = c.String(),
                        ImageData = c.Binary(),
                        WatchId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Watch", t => t.WatchId)
                .Index(t => t.WatchId);
            
            CreateTable(
                "dbo.Watch",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Brand = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        CaseMaterial = c.String(),
                        CaseDiameter = c.Single(nullable: false),
                        Lens = c.String(),
                        Strap = c.String(),
                        Mechanism = c.String(),
                        WaterResistance = c.String(),
                        Warranty = c.Int(nullable: false),
                        Colour = c.String(),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderWatch",
                c => new
                    {
                        OrderId = c.Int(nullable: false),
                        WatchId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderId, t.WatchId })
                .ForeignKey("dbo.Order", t => t.OrderId)
                .ForeignKey("dbo.Watch", t => t.WatchId)
                .Index(t => t.OrderId)
                .Index(t => t.WatchId);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Sum = c.Decimal(nullable: false, precision: 18, scale: 2),
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
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PostalCode = c.Int(nullable: false),
                        Country = c.String(),
                        City = c.String(),
                        Address = c.String(),
                        Phone = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customer", "Id", "dbo.User");
            DropForeignKey("dbo.OrderWatch", "WatchId", "dbo.Watch");
            DropForeignKey("dbo.OrderWatch", "OrderId", "dbo.Order");
            DropForeignKey("dbo.Image", "WatchId", "dbo.Watch");
            DropIndex("dbo.Customer", new[] { "Id" });
            DropIndex("dbo.OrderWatch", new[] { "WatchId" });
            DropIndex("dbo.OrderWatch", new[] { "OrderId" });
            DropIndex("dbo.Image", new[] { "WatchId" });
            DropTable("dbo.Customer");
            DropTable("dbo.Order");
            DropTable("dbo.OrderWatch");
            DropTable("dbo.Watch");
            DropTable("dbo.Image");
            DropTable("dbo.User");
        }
    }
}
