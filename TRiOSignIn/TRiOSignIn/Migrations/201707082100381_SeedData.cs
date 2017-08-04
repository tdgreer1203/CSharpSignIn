using Microsoft.AspNet.Identity;

namespace TRiOSignIn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedData : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Buildings (Name, MapNumber) VALUES ('TRiO/CEDAR', 104)");
            Sql("INSERT INTO Departments (Name) VALUES ('TRiO SSS')");
            Sql("INSERT INTO Reasons (Name) VALUES ('Tutoring')");
            Sql("INSERT INTO Reasons (Name) VALUES ('Computer Useage')");
            Sql("INSERT INTO Reasons (Name) VALUES ('Counseling')");
            Sql("INSERT INTO Labs (Name, Room, BuildingId, DepartmentId) VALUES ('TRiO Lab', '100', 1, 1)");
        }
        
        public override void Down()
        {
        }
    }
}
