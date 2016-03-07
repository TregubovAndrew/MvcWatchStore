namespace WatchStore.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User", "DateRegistered", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "DateRegistered", c => c.DateTime(nullable: false));
        }
    }
}
