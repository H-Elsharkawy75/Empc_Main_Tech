namespace Eagles.LMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShowBoard : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Settings", "ShowBoard", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Settings", "ShowBoard");
        }
    }
}
