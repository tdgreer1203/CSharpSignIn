namespace TRiOSignIn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NulledMapNumber : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Buildings", "MapNumber", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Buildings", "MapNumber", c => c.Int(nullable: false));
        }
    }
}
