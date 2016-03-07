namespace WatchStore.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User", "DateRegistered", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "DateRegistered", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
    }
}
