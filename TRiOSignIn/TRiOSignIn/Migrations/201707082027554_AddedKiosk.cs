namespace TRiOSignIn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedKiosk : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kiosks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LabId = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Labs", t => t.LabId, cascadeDelete: true)
                .Index(t => t.LabId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Kiosks", "LabId", "dbo.Labs");
            DropIndex("dbo.Kiosks", new[] { "LabId" });
            DropTable("dbo.Kiosks");
        }
    }
}
