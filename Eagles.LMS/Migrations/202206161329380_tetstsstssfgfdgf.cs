namespace Eagles.LMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tetstsstssfgfdgf : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Locations", "IconImage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Locations", "IconImage");
        }
    }
}
