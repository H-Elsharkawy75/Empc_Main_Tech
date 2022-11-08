namespace Eagles.LMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSEO : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SEO",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GoogleTageManager = c.String(),
                        GoogleTageAnalitics = c.String(),
                        GoogleTageSearch = c.String(),
                        HomePageTitle = c.String(),
                        HomPageMetaDescription = c.String(),
                        HomPageMetaKeywords = c.String(),
                        HomPageCanonicalUrl = c.String(),
                        WhoWeArePageTitle = c.String(),
                        WhoWeArePageMetaDescription = c.String(),
                        WhoWeArePageMetaKeywords = c.String(),
                        WhoWeArePageCanonicalUrl = c.String(),
                        AboutUsPageTitle = c.String(),
                        AboutUsPageMetaDescription = c.String(),
                        AboutUsPageMetaKeywords = c.String(),
                        AboutUsPageCanonicalUrl = c.String(),
                        FacilitiesPageTitle = c.String(),
                        FacilitiesPageMetaDescription = c.String(),
                        FacilitiesPageMetaKeywords = c.String(),
                        FacilitiesPageCanonicalUrl = c.String(),
                        ServicesPageTitle = c.String(),
                        ServicesPageMetaDescription = c.String(),
                        ServicesPageMetaKeywords = c.String(),
                        ServicesPageCanonicalUrl = c.String(),
                        ProceduresPageTitle = c.String(),
                        ProceduresPageMetaDescription = c.String(),
                        ProceduresPageMetaKeywords = c.String(),
                        ProceduresPageCanonicalUrl = c.String(),
                        DocumentsPageTitle = c.String(),
                        DocumentsPageMetaDescription = c.String(),
                        DocumentsPageMetaKeywords = c.String(),
                        DocumentsPageCanonicalUrl = c.String(),
                        EgyptLocationsPageTitle = c.String(),
                        EgyptLocationsPageMetaDescription = c.String(),
                        EgyptLocationsPageMetaKeywords = c.String(),
                        EgyptLocationsPageCanonicalUrl = c.String(),
                        OutDoorLocationsPageTitle = c.String(),
                        OutDoorLocationsPageMetaDescription = c.String(),
                        OutDoorLocationsPageMetaKeywords = c.String(),
                        OutDoorLocationsPageCanonicalUrl = c.String(),
                        FilmedInEgyptPageTitle = c.String(),
                        FilmedInEgyptPageMetaDescription = c.String(),
                        FilmedInEgyptPageMetaKeywords = c.String(),
                        FilmedInEgyptPageCanonicalUrl = c.String(),
                        ContactUsPageTitle = c.String(),
                        ContactUsPageMetaDescription = c.String(),
                        ContactUsPageMetaKeywords = c.String(),
                        ContactUsPageCanonicalUrl = c.String(),
                        UserEditId = c.Int(nullable: false),
                        EditeTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SEO");
        }
    }
}
