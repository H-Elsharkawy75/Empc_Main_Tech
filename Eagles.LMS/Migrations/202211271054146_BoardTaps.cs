namespace Eagles.LMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BoardTaps : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BoardTaps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Board_Id = c.Int(nullable: false),
                        Title_EN = c.String(),
                        Title_AR = c.String(),
                        Description_EN = c.String(),
                        Description_AR = c.String(),
                        Parent_Id = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        UserCreateId = c.Int(nullable: false),
                        EditeTime = c.DateTime(nullable: false),
                        UserEditId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BoardTaps");
        }
    }
}
