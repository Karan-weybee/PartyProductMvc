namespace PartyProduct.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class ebitdata : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4a5710d3-7b35-42d2-9dda-87b512106fe4', N'karan@weybee.in', 0, N'AHPuT7ucD4/GfRvgmGPr+AgGZNjcbOWkp+lCTs22HEEROxoMPqj1WfthNcCvebuJqQ==', N'b2558059-1bb7-4a99-9815-67946b9f33de', NULL, 0, 0, NULL, 1, 0, N'karan@weybee.in')

INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1', N'Admin')


INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4a5710d3-7b35-42d2-9dda-87b512106fe4', N'1')

");
        }

        public override void Down()
        {
        }
    }
}
