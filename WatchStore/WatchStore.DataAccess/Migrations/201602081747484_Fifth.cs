namespace WatchStore.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fifth : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brand",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Watch", "BrandOld", c => c.String());
            AddColumn("dbo.Watch", "BrandId", c => c.Int(nullable: true));
            CreateIndex("dbo.Watch", "BrandId");
            AddForeignKey("dbo.Watch", "BrandId", "dbo.Brand", "Id");
            DropColumn("dbo.Watch", "Brand");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Watch", "Brand", c => c.String());
            DropForeignKey("dbo.Watch", "BrandId", "dbo.Brand");
            DropIndex("dbo.Watch", new[] { "BrandId" });
            DropColumn("dbo.Watch", "BrandId");
            DropColumn("dbo.Watch", "BrandOld");
            DropTable("dbo.Brand");
        }
    }
}
