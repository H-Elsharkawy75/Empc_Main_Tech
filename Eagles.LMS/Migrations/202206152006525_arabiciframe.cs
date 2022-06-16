namespace Eagles.LMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class arabiciframe : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sliders", "ArabicIframe", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sliders", "ArabicIframe");
        }
    }
}
