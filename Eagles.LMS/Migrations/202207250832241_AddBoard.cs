namespace Eagles.LMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBoard : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Board",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.String(),
                        NameArabic = c.String(),
                        NameEnglish = c.String(),
                        JobTitleArabic = c.String(),
                        JobTitleEnglish = c.String(),
                        JobDescriptionArabic = c.String(),
                        JobDescriptionEnglish = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        UserCreateId = c.Int(nullable: false),
                        EditeTime = c.DateTime(nullable: false),
                        UserEditId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Board");
        }
    }
}
