namespace Eagles.LMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tetstsstst : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Locations", "IconImage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Locations", "IconImage", c => c.String());
        }
    }
}
