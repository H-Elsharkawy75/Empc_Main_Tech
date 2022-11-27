namespace Eagles.LMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderBoardTaps : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BoardTaps", "Order", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BoardTaps", "Order");
        }
    }
}
