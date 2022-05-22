namespace Eagles.LMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tststs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Applications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TitleArabic = c.String(nullable: false),
                        TitleEnglish = c.String(nullable: false),
                        Link = c.String(nullable: false),
                        EditeTime = c.DateTime(nullable: false),
                        UserEditId = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        UserCreateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Applications");
        }
    }
}
