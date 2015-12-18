namespace WatchStore.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Watches", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Watches", "Description", c => c.String());
            AddColumn("dbo.Watches", "CaseMaterial", c => c.String());
            AddColumn("dbo.Watches", "CaseDiameter", c => c.Single(nullable: false));
            AddColumn("dbo.Watches", "Lens", c => c.String());
            AddColumn("dbo.Watches", "Strap", c => c.String());
            AddColumn("dbo.Watches", "Mechanism", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Watches", "Mechanism");
            DropColumn("dbo.Watches", "Strap");
            DropColumn("dbo.Watches", "Lens");
            DropColumn("dbo.Watches", "CaseDiameter");
            DropColumn("dbo.Watches", "CaseMaterial");
            DropColumn("dbo.Watches", "Description");
            DropColumn("dbo.Watches", "Price");
        }
    }
}
