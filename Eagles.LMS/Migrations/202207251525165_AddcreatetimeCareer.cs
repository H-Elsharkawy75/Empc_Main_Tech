namespace Eagles.LMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddcreatetimeCareer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Career", "CreatedTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Career", "CreatedTime");
        }
    }
}
