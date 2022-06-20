namespace Eagles.LMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class servicenull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Services", "Order", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Services", "Order", c => c.Int(nullable: false));
        }
    }
}
