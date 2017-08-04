namespace TRiOSignIn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NulledEndTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Visits", "EndTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Visits", "EndTime", c => c.DateTime());
        }
    }
}
