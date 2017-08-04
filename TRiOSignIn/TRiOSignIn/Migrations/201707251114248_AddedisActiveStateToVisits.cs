namespace TRiOSignIn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedisActiveStateToVisits : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Visits", "isActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Visits", "isActive");
        }
    }
}
