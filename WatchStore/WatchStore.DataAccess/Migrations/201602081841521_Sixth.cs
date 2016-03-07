namespace WatchStore.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sixth : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Watch", new[] { "BrandId" });
            AlterColumn("dbo.Watch", "BrandId", c => c.Int());
            CreateIndex("dbo.Watch", "BrandId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Watch", new[] { "BrandId" });
            AlterColumn("dbo.Watch", "BrandId", c => c.Int(nullable: false));
            CreateIndex("dbo.Watch", "BrandId");
        }
    }
}
