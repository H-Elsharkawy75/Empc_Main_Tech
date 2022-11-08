namespace Eagles.LMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Jobs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameArabic = c.String(),
                        NameEnglish = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        UserCreateId = c.Int(nullable: false),
                        EditeTime = c.DateTime(nullable: false),
                        UserEditId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Jobs");
        }
    }
}
