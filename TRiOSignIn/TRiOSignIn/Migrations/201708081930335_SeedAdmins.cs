namespace TRiOSignIn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedAdmins : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'346ff953-7500-4849-a40d-5a1b5e0e7041', N'admin@localhost.edu', 0, N'AN5p4ceOpiA65s3vrvf7bSURXXYlQYvmLQCDfce/dsHzHgdGnuyVFVQ8YasAk3+MYw==', N'13b44974-ea41-4426-a8a7-5af589b20fdd', NULL, 0, 0, NULL, 1, 0, N'admin@localhost.edu')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3f38bbb0-d38d-4ccd-baf2-5c091f24b6de', N'theodore.greer@famu.edu', 0, N'AJGsXj5D7Cng10GhPMnrXHLnhNfWuAH7CRXDNnpPckroX3+QiU/nu+4pDxOMuB7lmA==', N'335626d0-acb3-485c-90b6-8733bb9343e2', NULL, 0, 0, NULL, 1, 0, N'theodore.greer@famu.edu')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f0717eee-f584-4da3-a65c-24811a09ea10', N'triosss@famu.edu', 0, N'AHJCtBGmhyn2a2XqL/OvEOi69Gr4GOPSs/qrY2IRL+r/f45Zhko/3YJSv29aWo82uw==', N'909b8475-322e-4246-8edb-c316a25bd1d2', NULL, 0, 0, NULL, 1, 0, N'triosss@famu.edu')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'6fabb5ab-e145-4607-8579-43b6e0fed036', N'Admin')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f0717eee-f584-4da3-a65c-24811a09ea10', N'6fabb5ab-e145-4607-8579-43b6e0fed036')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3f38bbb0-d38d-4ccd-baf2-5c091f24b6de', N'6fabb5ab-e145-4607-8579-43b6e0fed036')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'346ff953-7500-4849-a40d-5a1b5e0e7041', N'6fabb5ab-e145-4607-8579-43b6e0fed036')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
