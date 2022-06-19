namespace Eagles.LMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sdfsdf : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Careers", newName: "Career");
            DropForeignKey("dbo.BookingInServices", "Careers_Id", "dbo.Careers");
            DropIndex("dbo.BookingInServices", new[] { "Careers_Id" });
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
            
            DropColumn("dbo.BookingInServices", "Careers_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BookingInServices", "Careers_Id", c => c.Int());
            DropForeignKey("dbo.CareerInServices", "CareerServiceId", "dbo.CareerServices");
            DropForeignKey("dbo.CareerInServices", "CareerId", "dbo.Career");
            DropIndex("dbo.CareerInServices", new[] { "CareerId" });
            DropIndex("dbo.CareerInServices", new[] { "CareerServiceId" });
            DropTable("dbo.CareerServices");
            DropTable("dbo.CareerInServices");
            CreateIndex("dbo.BookingInServices", "Careers_Id");
            AddForeignKey("dbo.BookingInServices", "Careers_Id", "dbo.Careers", "Id");
            RenameTable(name: "dbo.Career", newName: "Careers");
        }
    }
}
