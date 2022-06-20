namespace Eagles.LMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class career : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Career",
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
            
            CreateTable(
                "dbo.CareerInServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CareerServiceId = c.Int(nullable: false),
                        CareerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Career", t => t.CareerId, cascadeDelete: true)
                .ForeignKey("dbo.CareerServices", t => t.CareerServiceId, cascadeDelete: true)
                .Index(t => t.CareerServiceId)
                .Index(t => t.CareerId);
            
            CreateTable(
                "dbo.CareerServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CareerInServices", "CareerServiceId", "dbo.CareerServices");
            DropForeignKey("dbo.CareerInServices", "CareerId", "dbo.Career");
            DropIndex("dbo.CareerInServices", new[] { "CareerId" });
            DropIndex("dbo.CareerInServices", new[] { "CareerServiceId" });
            DropTable("dbo.CareerServices");
            DropTable("dbo.CareerInServices");
            DropTable("dbo.Career");
        }
    }
}
