namespace TRiOSignIn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIdentifierToKiosk : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Kiosks", "Identifier", c => c.String());
            DropColumn("dbo.Kiosks", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Kiosks", "Description", c => c.String());
            DropColumn("dbo.Kiosks", "Identifier");
        }
    }
}
