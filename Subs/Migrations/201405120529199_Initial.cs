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
                        Request_RequestId = c.Int(),
                        SubFile_SubFileId = c.Int(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Requests", t => t.Request_RequestId)
                .ForeignKey("dbo.SubFiles", t => t.SubFile_SubFileId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.Request_RequestId)
                .Index(t => t.SubFile_SubFileId)
                .Index(t => t.ApplicationUser_Id);
            
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
                        UserName_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.RequestId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserName_Id)
                .Index(t => t.UserName_Id);
            
            CreateTable(
                "dbo.SubFiles",
                c => new
                    {
                        SubFileId = c.Int(nullable: false, identity: true),
                        sTitle = c.String(nullable: false),
                        sSubLanguage = c.String(),
                        sSubType = c.String(),
                        sGenre = c.String(),
                        dSubDate = c.DateTime(),
                        sPicture = c.String(),
                        sSubDescription = c.String(),
                        sFilePath = c.String(),
                        iUpVote = c.Int(),
                        Request_RequestId = c.Int(),
                        UserName_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.SubFileId)
                .ForeignKey("dbo.Requests", t => t.Request_RequestId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserName_Id)
                .Index(t => t.Request_RequestId)
                .Index(t => t.UserName_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        sEmail = c.String(),
                        iRanking = c.Int(),
                        iTheme = c.Int(),
                        dSignupDate = c.DateTime(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.LoginProvider, t.ProviderKey })
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
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubFiles", "UserName_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Requests", "UserName_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.SubFiles", "Request_RequestId", "dbo.Requests");
            DropForeignKey("dbo.Comments", "SubFile_SubFileId", "dbo.SubFiles");
            DropForeignKey("dbo.Comments", "Request_RequestId", "dbo.Requests");
            DropIndex("dbo.SubFiles", new[] { "UserName_Id" });
            DropIndex("dbo.Requests", new[] { "UserName_Id" });
            DropIndex("dbo.Comments", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "User_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.SubFiles", new[] { "Request_RequestId" });
            DropIndex("dbo.Comments", new[] { "SubFile_SubFileId" });
            DropIndex("dbo.Comments", new[] { "Request_RequestId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.SubFiles");
            DropTable("dbo.Requests");
            DropTable("dbo.Comments");
        }
    }
}
