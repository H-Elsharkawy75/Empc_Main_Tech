namespace Eagles.LMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderserviceandarabiciframe : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Galaries", "ArabicVideoIframe", c => c.String());
            AddColumn("dbo.Services", "Order", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Services", "Order");
            DropColumn("dbo.Galaries", "ArabicVideoIframe");
        }
    }
}
