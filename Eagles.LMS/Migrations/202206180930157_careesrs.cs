namespace Eagles.LMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class careesrs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "Name", c => c.String());
            AddColumn("dbo.Bookings", "DateOfBirth", c => c.String());
            AddColumn("dbo.Bookings", "Address", c => c.String());
            AddColumn("dbo.Bookings", "Certification", c => c.String());
            AddColumn("dbo.Bookings", "GraduationYears", c => c.String());
            AddColumn("dbo.Bookings", "JobName", c => c.String());
            AddColumn("dbo.Bookings", "ExperianceLevel", c => c.String());
            AddColumn("dbo.Bookings", "CVLink", c => c.String());
            DropColumn("dbo.Bookings", "CompanyName");
            DropColumn("dbo.Bookings", "CompanyEmail");
            DropColumn("dbo.Bookings", "DataServicees");
            DropColumn("dbo.Bookings", "SartTime");
            DropColumn("dbo.Bookings", "EndTime");
            DropColumn("dbo.Bookings", "Origin");
            DropColumn("dbo.Bookings", "Message");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bookings", "Message", c => c.String());
            AddColumn("dbo.Bookings", "Origin", c => c.String());
            AddColumn("dbo.Bookings", "EndTime", c => c.String());
            AddColumn("dbo.Bookings", "SartTime", c => c.String());
            AddColumn("dbo.Bookings", "DataServicees", c => c.String());
            AddColumn("dbo.Bookings", "CompanyEmail", c => c.String());
            AddColumn("dbo.Bookings", "CompanyName", c => c.String());
            DropColumn("dbo.Bookings", "CVLink");
            DropColumn("dbo.Bookings", "ExperianceLevel");
            DropColumn("dbo.Bookings", "JobName");
            DropColumn("dbo.Bookings", "GraduationYears");
            DropColumn("dbo.Bookings", "Certification");
            DropColumn("dbo.Bookings", "Address");
            DropColumn("dbo.Bookings", "DateOfBirth");
            DropColumn("dbo.Bookings", "Name");
        }
    }
}
