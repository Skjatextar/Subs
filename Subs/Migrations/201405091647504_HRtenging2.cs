namespace Subs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HRtenging2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Comment", newName: "Client");
            DropForeignKey("dbo.Comment", "Client_sUsername", "dbo.Client");
            DropForeignKey("dbo.Request", "sUsername", "dbo.Client");
            DropForeignKey("dbo.SubFile", "sUsername", "dbo.Client");
            DropIndex("dbo.Comment", new[] { "Client_sUsername" });
            DropIndex("dbo.Request", new[] { "sUsername" });
            DropIndex("dbo.SubFile", new[] { "sUsername" });
            AddColumn("dbo.Client", "vComments_iCommentId", c => c.Int());
            AddColumn("dbo.Client", "vRequests_iRequestId", c => c.Int());
            AddColumn("dbo.Client", "vSubFiles_iSubFileId", c => c.Int());
            AlterColumn("dbo.Request", "sUsername", c => c.String());
            AlterColumn("dbo.SubFile", "sUsername", c => c.String());
            CreateIndex("dbo.Client", "vComments_iCommentId");
            CreateIndex("dbo.Client", "vRequests_iRequestId");
            CreateIndex("dbo.Client", "vSubFiles_iSubFileId");
            AddForeignKey("dbo.Client", "vComments_iCommentId", "dbo.Comment", "iCommentId");
            AddForeignKey("dbo.Client", "vRequests_iRequestId", "dbo.Request", "iRequestId");
            AddForeignKey("dbo.Client", "vSubFiles_iSubFileId", "dbo.SubFile", "iSubFileId");
            DropColumn("dbo.Comment", "Client_sUsername");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comment", "Client_sUsername", c => c.String(maxLength: 128));
            DropForeignKey("dbo.Client", "vSubFiles_iSubFileId", "dbo.SubFile");
            DropForeignKey("dbo.Client", "vRequests_iRequestId", "dbo.Request");
            DropForeignKey("dbo.Client", "vComments_iCommentId", "dbo.Comment");
            DropIndex("dbo.Client", new[] { "vSubFiles_iSubFileId" });
            DropIndex("dbo.Client", new[] { "vRequests_iRequestId" });
            DropIndex("dbo.Client", new[] { "vComments_iCommentId" });
            AlterColumn("dbo.SubFile", "sUsername", c => c.String(maxLength: 128));
            AlterColumn("dbo.Request", "sUsername", c => c.String(maxLength: 128));
            DropColumn("dbo.Client", "vSubFiles_iSubFileId");
            DropColumn("dbo.Client", "vRequests_iRequestId");
            DropColumn("dbo.Client", "vComments_iCommentId");
            CreateIndex("dbo.SubFile", "sUsername");
            CreateIndex("dbo.Request", "sUsername");
            CreateIndex("dbo.Comment", "Client_sUsername");
            AddForeignKey("dbo.SubFile", "sUsername", "dbo.Client", "sUsername");
            AddForeignKey("dbo.Request", "sUsername", "dbo.Client", "sUsername");
            AddForeignKey("dbo.Comment", "Client_sUsername", "dbo.Client", "sUsername");
            RenameTable(name: "dbo.Client", newName: "Comment");
        }
    }
}
