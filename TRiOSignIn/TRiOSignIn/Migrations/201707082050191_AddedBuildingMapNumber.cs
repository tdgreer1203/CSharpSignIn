namespace TRiOSignIn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBuildingMapNumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Buildings", "MapNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Buildings", "MapNumber");
        }
    }
}
