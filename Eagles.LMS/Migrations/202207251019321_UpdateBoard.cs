namespace Eagles.LMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBoard : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Board", "Phone", c => c.String());
            AddColumn("dbo.Board", "Email", c => c.String());
            AddColumn("dbo.Board", "FaceLink", c => c.String());
            AddColumn("dbo.Board", "twiterLink", c => c.String());
            AddColumn("dbo.Board", "LinkedInLink", c => c.String());
            AddColumn("dbo.Board", "GoogleLink", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Board", "GoogleLink");
            DropColumn("dbo.Board", "LinkedInLink");
            DropColumn("dbo.Board", "twiterLink");
            DropColumn("dbo.Board", "FaceLink");
            DropColumn("dbo.Board", "Email");
            DropColumn("dbo.Board", "Phone");
        }
    }
}
