namespace Eagles.LMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateSEOAR : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SEO", "HomePageTitle_AR", c => c.String());
            AddColumn("dbo.SEO", "HomPageMetaDescription_AR", c => c.String());
            AddColumn("dbo.SEO", "HomPageMetaKeywords_AR", c => c.String());
            AddColumn("dbo.SEO", "AboutUsPageTitle_AR", c => c.String());
            AddColumn("dbo.SEO", "AboutUsPageMetaDescription_AR", c => c.String());
            AddColumn("dbo.SEO", "AboutUsPageMetaKeywords_AR", c => c.String());
            AddColumn("dbo.SEO", "OutDoorLocationsPageTitle_AR", c => c.String());
            AddColumn("dbo.SEO", "OutDoorLocationsPageMetaDescription_AR", c => c.String());
            AddColumn("dbo.SEO", "OutDoorLocationsPageMetaKeywords_AR", c => c.String());
            AddColumn("dbo.SEO", "LocationsPageTitle_AR", c => c.String());
            AddColumn("dbo.SEO", "LocationsPageMetaDescription_AR", c => c.String());
            AddColumn("dbo.SEO", "LocationsPageMetaKeywords_AR", c => c.String());
            AddColumn("dbo.SEO", "ServicesPageTitle_AR", c => c.String());
            AddColumn("dbo.SEO", "ServicesPageMetaDescription_AR", c => c.String());
            AddColumn("dbo.SEO", "ServicesPageMetaKeywords_AR", c => c.String());
            AddColumn("dbo.SEO", "NewsPageTitle_AR", c => c.String());
            AddColumn("dbo.SEO", "NewsPageMetaDescription_AR", c => c.String());
            AddColumn("dbo.SEO", "NewsPageMetaKeywords_AR", c => c.String());
            AddColumn("dbo.SEO", "AgendaPageTitle_AR", c => c.String());
            AddColumn("dbo.SEO", "AgendaPageMetaDescription_AR", c => c.String());
            AddColumn("dbo.SEO", "AgendaPageMetaKeywords_AR", c => c.String());
            AddColumn("dbo.SEO", "AlbumsPageTitle_AR", c => c.String());
            AddColumn("dbo.SEO", "AlbumsPageMetaDescription_AR", c => c.String());
            AddColumn("dbo.SEO", "AlbumsPageMetaKeywords_AR", c => c.String());
            AddColumn("dbo.SEO", "VideoPageTitle_AR", c => c.String());
            AddColumn("dbo.SEO", "VideoPageMetaDescription_AR", c => c.String());
            AddColumn("dbo.SEO", "VideoPageMetaKeywords_AR", c => c.String());
            AddColumn("dbo.SEO", "PicturePageTitle_AR", c => c.String());
            AddColumn("dbo.SEO", "PicturePageMetaDescription_AR", c => c.String());
            AddColumn("dbo.SEO", "PicturePageMetaKeywords_AR", c => c.String());
            AddColumn("dbo.SEO", "CitizenPageTitle_AR", c => c.String());
            AddColumn("dbo.SEO", "CitizenPageMetaDescription_AR", c => c.String());
            AddColumn("dbo.SEO", "CitizenPageMetaKeywords_AR", c => c.String());
            AddColumn("dbo.SEO", "ContactUsPageTitle_AR", c => c.String());
            AddColumn("dbo.SEO", "ContactUsPageMetaDescription_AR", c => c.String());
            AddColumn("dbo.SEO", "ContactUsPageMetaKeywords_AR", c => c.String());
            AddColumn("dbo.SEO", "CareersPageTitle_AR", c => c.String());
            AddColumn("dbo.SEO", "CareersPageMetaDescription_AR", c => c.String());
            AddColumn("dbo.SEO", "CareersPageMetaKeywords_AR", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SEO", "CareersPageMetaKeywords_AR");
            DropColumn("dbo.SEO", "CareersPageMetaDescription_AR");
            DropColumn("dbo.SEO", "CareersPageTitle_AR");
            DropColumn("dbo.SEO", "ContactUsPageMetaKeywords_AR");
            DropColumn("dbo.SEO", "ContactUsPageMetaDescription_AR");
            DropColumn("dbo.SEO", "ContactUsPageTitle_AR");
            DropColumn("dbo.SEO", "CitizenPageMetaKeywords_AR");
            DropColumn("dbo.SEO", "CitizenPageMetaDescription_AR");
            DropColumn("dbo.SEO", "CitizenPageTitle_AR");
            DropColumn("dbo.SEO", "PicturePageMetaKeywords_AR");
            DropColumn("dbo.SEO", "PicturePageMetaDescription_AR");
            DropColumn("dbo.SEO", "PicturePageTitle_AR");
            DropColumn("dbo.SEO", "VideoPageMetaKeywords_AR");
            DropColumn("dbo.SEO", "VideoPageMetaDescription_AR");
            DropColumn("dbo.SEO", "VideoPageTitle_AR");
            DropColumn("dbo.SEO", "AlbumsPageMetaKeywords_AR");
            DropColumn("dbo.SEO", "AlbumsPageMetaDescription_AR");
            DropColumn("dbo.SEO", "AlbumsPageTitle_AR");
            DropColumn("dbo.SEO", "AgendaPageMetaKeywords_AR");
            DropColumn("dbo.SEO", "AgendaPageMetaDescription_AR");
            DropColumn("dbo.SEO", "AgendaPageTitle_AR");
            DropColumn("dbo.SEO", "NewsPageMetaKeywords_AR");
            DropColumn("dbo.SEO", "NewsPageMetaDescription_AR");
            DropColumn("dbo.SEO", "NewsPageTitle_AR");
            DropColumn("dbo.SEO", "ServicesPageMetaKeywords_AR");
            DropColumn("dbo.SEO", "ServicesPageMetaDescription_AR");
            DropColumn("dbo.SEO", "ServicesPageTitle_AR");
            DropColumn("dbo.SEO", "LocationsPageMetaKeywords_AR");
            DropColumn("dbo.SEO", "LocationsPageMetaDescription_AR");
            DropColumn("dbo.SEO", "LocationsPageTitle_AR");
            DropColumn("dbo.SEO", "OutDoorLocationsPageMetaKeywords_AR");
            DropColumn("dbo.SEO", "OutDoorLocationsPageMetaDescription_AR");
            DropColumn("dbo.SEO", "OutDoorLocationsPageTitle_AR");
            DropColumn("dbo.SEO", "AboutUsPageMetaKeywords_AR");
            DropColumn("dbo.SEO", "AboutUsPageMetaDescription_AR");
            DropColumn("dbo.SEO", "AboutUsPageTitle_AR");
            DropColumn("dbo.SEO", "HomPageMetaKeywords_AR");
            DropColumn("dbo.SEO", "HomPageMetaDescription_AR");
            DropColumn("dbo.SEO", "HomePageTitle_AR");
        }
    }
}
