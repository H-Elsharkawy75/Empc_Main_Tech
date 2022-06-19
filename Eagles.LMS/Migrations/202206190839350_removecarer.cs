namespace Eagles.LMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removecarer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookingInServices", "Careers_Id", c => c.Int());
            CreateIndex("dbo.BookingInServices", "Careers_Id");
            AddForeignKey("dbo.BookingInServices", "Careers_Id", "dbo.Careers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookingInServices", "Careers_Id", "dbo.Careers");
            DropIndex("dbo.BookingInServices", new[] { "Careers_Id" });
            DropColumn("dbo.BookingInServices", "Careers_Id");
        }
    }
}
