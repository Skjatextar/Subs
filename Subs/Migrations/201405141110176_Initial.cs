namespace Subs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        sCommenterUsername = c.String(nullable: false),
                        sCommentText = c.String(nullable: false),
                        dCommentDate = c.DateTime(),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        Request_RequestId = c.Int(nullable: false),
                        SubFile_SubFileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Requests", t => t.Request_RequestId, cascadeDelete: true)
                .ForeignKey("dbo.SubFiles", t => t.SubFile_SubFileId, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Request_RequestId)
                .Index(t => t.SubFile_SubFileId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        sEmail = c.String(),
                        iRanking = c.Int(nullable: false),
                        iTheme = c.Int(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        RequestId = c.Int(nullable: false, identity: true),
                        sRequesterUsername = c.String(nullable: false),
                        sTitle = c.String(nullable: false),
                        sLanguageTo = c.String(),
                        sLanguageFrom = c.String(),
                        sSubType = c.String(),
                        iUpVote = c.Int(),
                        dRequestDate = c.DateTime(),
                        sPicture = c.String(),
                        sRequestDescription = c.String(),
                    })
                .PrimaryKey(t => t.RequestId);
            
            CreateTable(
                "dbo.SubFiles",
                c => new
                    {
                        SubFileId = c.Int(nullable: false, identity: true),
                        sTitle = c.String(nullable: false),
                        sFileUserName = c.String(),
                        sSubLanguage = c.String(),
                        sSubType = c.String(),
                        sGenre = c.String(),
                        dSubDate = c.DateTime(),
                        sPicture = c.String(),
                        sSubDescription = c.String(),
                        sFilePath = c.Binary(),
                        iUpVote = c.Int(),
                    })
                .PrimaryKey(t => t.SubFileId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Comments", "SubFile_SubFileId", "dbo.SubFiles");
            DropForeignKey("dbo.Comments", "Request_RequestId", "dbo.Requests");
            DropForeignKey("dbo.Comments", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Comments", new[] { "SubFile_SubFileId" });
            DropIndex("dbo.Comments", new[] { "Request_RequestId" });
            DropIndex("dbo.Comments", new[] { "ApplicationUser_Id" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.SubFiles");
            DropTable("dbo.Requests");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Comments");
        }
    }
}
