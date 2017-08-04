namespace TRiOSignIn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedReasonsFromVisit : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Visits", "ReasonId", "dbo.Reasons");
            DropIndex("dbo.Visits", new[] { "ReasonId" });
            DropColumn("dbo.Visits", "ReasonId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Visits", "ReasonId", c => c.Int(nullable: false));
            CreateIndex("dbo.Visits", "ReasonId");
            AddForeignKey("dbo.Visits", "ReasonId", "dbo.Reasons", "Id", cascadeDelete: true);
        }
    }
}
