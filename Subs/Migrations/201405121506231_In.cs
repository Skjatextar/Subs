namespace Subs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class In : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "dSignupDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "dSignupDate", c => c.DateTime());
        }
    }
}
