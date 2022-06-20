namespace Eagles.LMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class carrer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CareerInServices", "CareerId", "dbo.Career");
            DropForeignKey("dbo.CareerInServices", "CareerServiceId", "dbo.CareerServices");
            DropIndex("dbo.CareerInServices", new[] { "CareerServiceId" });
            DropIndex("dbo.CareerInServices", new[] { "CareerId" });
            AlterColumn("dbo.Services", "Order", c => c.Int());
            DropTable("dbo.Career");
            DropTable("dbo.CareerInServices");
            DropTable("dbo.CareerServices");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CareerServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
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
                .PrimaryKey(t => t.Id);
            
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
            
            AlterColumn("dbo.Services", "Order", c => c.Int(nullable: false));
            CreateIndex("dbo.CareerInServices", "CareerId");
            CreateIndex("dbo.CareerInServices", "CareerServiceId");
            AddForeignKey("dbo.CareerInServices", "CareerServiceId", "dbo.CareerServices", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CareerInServices", "CareerId", "dbo.Career", "Id", cascadeDelete: true);
        }
    }
}
