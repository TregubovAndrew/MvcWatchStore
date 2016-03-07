namespace WatchStore.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Third : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User", "DateRegistered", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "DateRegistered", c => c.DateTime());
        }
    }
}
