namespace Eagles.LMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateSEO1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SEO", "LocationsPageTitle", c => c.String());
            AddColumn("dbo.SEO", "LocationsPageMetaDescription", c => c.String());
            AddColumn("dbo.SEO", "LocationsPageMetaKeywords", c => c.String());
            AddColumn("dbo.SEO", "LocationsPageCanonicalUrl", c => c.String());
            AddColumn("dbo.SEO", "NewsPageTitle", c => c.String());
            AddColumn("dbo.SEO", "NewsPageMetaDescription", c => c.String());
            AddColumn("dbo.SEO", "NewsPageMetaKeywords", c => c.String());
            AddColumn("dbo.SEO", "NewsPageCanonicalUrl", c => c.String());
            AddColumn("dbo.SEO", "AgendaPageTitle", c => c.String());
            AddColumn("dbo.SEO", "AgendaPageMetaDescription", c => c.String());
            AddColumn("dbo.SEO", "AgendaPageMetaKeywords", c => c.String());
            AddColumn("dbo.SEO", "AgendaPageCanonicalUrl", c => c.String());
            AddColumn("dbo.SEO", "AlbumsPageTitle", c => c.String());
            AddColumn("dbo.SEO", "AlbumsPageMetaDescription", c => c.String());
            AddColumn("dbo.SEO", "AlbumsPageMetaKeywords", c => c.String());
            AddColumn("dbo.SEO", "AlbumsPageCanonicalUrl", c => c.String());
            AddColumn("dbo.SEO", "VideoPageTitle", c => c.String());
            AddColumn("dbo.SEO", "VideoPageMetaDescription", c => c.String());
            AddColumn("dbo.SEO", "VideoPageMetaKeywords", c => c.String());
            AddColumn("dbo.SEO", "VideoPageCanonicalUrl", c => c.String());
            AddColumn("dbo.SEO", "PicturePageTitle", c => c.String());
            AddColumn("dbo.SEO", "PicturePageMetaDescription", c => c.String());
            AddColumn("dbo.SEO", "PicturePageMetaKeywords", c => c.String());
            AddColumn("dbo.SEO", "PicturePageCanonicalUrl", c => c.String());
            AddColumn("dbo.SEO", "CitizenPageTitle", c => c.String());
            AddColumn("dbo.SEO", "CitizenPageMetaDescription", c => c.String());
            AddColumn("dbo.SEO", "CitizenPageMetaKeywords", c => c.String());
            AddColumn("dbo.SEO", "CitizenPageCanonicalUrl", c => c.String());
            AddColumn("dbo.SEO", "CareersPageTitle", c => c.String());
            AddColumn("dbo.SEO", "CareersPageMetaDescription", c => c.String());
            AddColumn("dbo.SEO", "CareersPageMetaKeywords", c => c.String());
            AddColumn("dbo.SEO", "CareersPageCanonicalUrl", c => c.String());
            DropColumn("dbo.SEO", "WhoWeArePageTitle");
            DropColumn("dbo.SEO", "WhoWeArePageMetaDescription");
            DropColumn("dbo.SEO", "WhoWeArePageMetaKeywords");
            DropColumn("dbo.SEO", "WhoWeArePageCanonicalUrl");
            DropColumn("dbo.SEO", "FacilitiesPageTitle");
            DropColumn("dbo.SEO", "FacilitiesPageMetaDescription");
            DropColumn("dbo.SEO", "FacilitiesPageMetaKeywords");
            DropColumn("dbo.SEO", "FacilitiesPageCanonicalUrl");
            DropColumn("dbo.SEO", "ProceduresPageTitle");
            DropColumn("dbo.SEO", "ProceduresPageMetaDescription");
            DropColumn("dbo.SEO", "ProceduresPageMetaKeywords");
            DropColumn("dbo.SEO", "ProceduresPageCanonicalUrl");
            DropColumn("dbo.SEO", "DocumentsPageTitle");
            DropColumn("dbo.SEO", "DocumentsPageMetaDescription");
            DropColumn("dbo.SEO", "DocumentsPageMetaKeywords");
            DropColumn("dbo.SEO", "DocumentsPageCanonicalUrl");
            DropColumn("dbo.SEO", "EgyptLocationsPageTitle");
            DropColumn("dbo.SEO", "EgyptLocationsPageMetaDescription");
            DropColumn("dbo.SEO", "EgyptLocationsPageMetaKeywords");
            DropColumn("dbo.SEO", "EgyptLocationsPageCanonicalUrl");
            DropColumn("dbo.SEO", "FilmedInEgyptPageTitle");
            DropColumn("dbo.SEO", "FilmedInEgyptPageMetaDescription");
            DropColumn("dbo.SEO", "FilmedInEgyptPageMetaKeywords");
            DropColumn("dbo.SEO", "FilmedInEgyptPageCanonicalUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SEO", "FilmedInEgyptPageCanonicalUrl", c => c.String());
            AddColumn("dbo.SEO", "FilmedInEgyptPageMetaKeywords", c => c.String());
            AddColumn("dbo.SEO", "FilmedInEgyptPageMetaDescription", c => c.String());
            AddColumn("dbo.SEO", "FilmedInEgyptPageTitle", c => c.String());
            AddColumn("dbo.SEO", "EgyptLocationsPageCanonicalUrl", c => c.String());
            AddColumn("dbo.SEO", "EgyptLocationsPageMetaKeywords", c => c.String());
            AddColumn("dbo.SEO", "EgyptLocationsPageMetaDescription", c => c.String());
            AddColumn("dbo.SEO", "EgyptLocationsPageTitle", c => c.String());
            AddColumn("dbo.SEO", "DocumentsPageCanonicalUrl", c => c.String());
            AddColumn("dbo.SEO", "DocumentsPageMetaKeywords", c => c.String());
            AddColumn("dbo.SEO", "DocumentsPageMetaDescription", c => c.String());
            AddColumn("dbo.SEO", "DocumentsPageTitle", c => c.String());
            AddColumn("dbo.SEO", "ProceduresPageCanonicalUrl", c => c.String());
            AddColumn("dbo.SEO", "ProceduresPageMetaKeywords", c => c.String());
            AddColumn("dbo.SEO", "ProceduresPageMetaDescription", c => c.String());
            AddColumn("dbo.SEO", "ProceduresPageTitle", c => c.String());
            AddColumn("dbo.SEO", "FacilitiesPageCanonicalUrl", c => c.String());
            AddColumn("dbo.SEO", "FacilitiesPageMetaKeywords", c => c.String());
            AddColumn("dbo.SEO", "FacilitiesPageMetaDescription", c => c.String());
            AddColumn("dbo.SEO", "FacilitiesPageTitle", c => c.String());
            AddColumn("dbo.SEO", "WhoWeArePageCanonicalUrl", c => c.String());
            AddColumn("dbo.SEO", "WhoWeArePageMetaKeywords", c => c.String());
            AddColumn("dbo.SEO", "WhoWeArePageMetaDescription", c => c.String());
            AddColumn("dbo.SEO", "WhoWeArePageTitle", c => c.String());
            DropColumn("dbo.SEO", "CareersPageCanonicalUrl");
            DropColumn("dbo.SEO", "CareersPageMetaKeywords");
            DropColumn("dbo.SEO", "CareersPageMetaDescription");
            DropColumn("dbo.SEO", "CareersPageTitle");
            DropColumn("dbo.SEO", "CitizenPageCanonicalUrl");
            DropColumn("dbo.SEO", "CitizenPageMetaKeywords");
            DropColumn("dbo.SEO", "CitizenPageMetaDescription");
            DropColumn("dbo.SEO", "CitizenPageTitle");
            DropColumn("dbo.SEO", "PicturePageCanonicalUrl");
            DropColumn("dbo.SEO", "PicturePageMetaKeywords");
            DropColumn("dbo.SEO", "PicturePageMetaDescription");
            DropColumn("dbo.SEO", "PicturePageTitle");
            DropColumn("dbo.SEO", "VideoPageCanonicalUrl");
            DropColumn("dbo.SEO", "VideoPageMetaKeywords");
            DropColumn("dbo.SEO", "VideoPageMetaDescription");
            DropColumn("dbo.SEO", "VideoPageTitle");
            DropColumn("dbo.SEO", "AlbumsPageCanonicalUrl");
            DropColumn("dbo.SEO", "AlbumsPageMetaKeywords");
            DropColumn("dbo.SEO", "AlbumsPageMetaDescription");
            DropColumn("dbo.SEO", "AlbumsPageTitle");
            DropColumn("dbo.SEO", "AgendaPageCanonicalUrl");
            DropColumn("dbo.SEO", "AgendaPageMetaKeywords");
            DropColumn("dbo.SEO", "AgendaPageMetaDescription");
            DropColumn("dbo.SEO", "AgendaPageTitle");
            DropColumn("dbo.SEO", "NewsPageCanonicalUrl");
            DropColumn("dbo.SEO", "NewsPageMetaKeywords");
            DropColumn("dbo.SEO", "NewsPageMetaDescription");
            DropColumn("dbo.SEO", "NewsPageTitle");
            DropColumn("dbo.SEO", "LocationsPageCanonicalUrl");
            DropColumn("dbo.SEO", "LocationsPageMetaKeywords");
            DropColumn("dbo.SEO", "LocationsPageMetaDescription");
            DropColumn("dbo.SEO", "LocationsPageTitle");
        }
    }
}
