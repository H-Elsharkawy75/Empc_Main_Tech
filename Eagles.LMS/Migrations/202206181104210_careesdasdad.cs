namespace Eagles.LMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class careesdasdad : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Careers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DateOfBirth = c.String(),
                        Address = c.String(),
                        Certification = c.String(),
                        GraduationYears = c.String(),
                        JobName = c.String(),
                        ExperianceLevel = c.String(),
                        CVLink = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Careers");
        }
    }
}
