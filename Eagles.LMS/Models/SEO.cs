using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eagles.LMS.Models
{
    [Table("SEO")]
    public class SEO
    {
        public int Id { get; set; }

        [AllowHtml]
        public string GoogleTageManager { get; set; }
        [AllowHtml]
        public string GoogleTageAnalitics { get; set; }
        [AllowHtml]
        public string GoogleTageSearch { get; set; }


        public string HomePageTitle { get; set; }
        public string HomPageMetaDescription { get; set; }
        public string HomPageMetaKeywords { get; set; }
        public string HomPageCanonicalUrl { get; set; }




        public string AboutUsPageTitle { get; set; }
        public string AboutUsPageMetaDescription { get; set; }
        public string AboutUsPageMetaKeywords { get; set; }
        public string AboutUsPageCanonicalUrl { get; set; }




        public string OutDoorLocationsPageTitle { get; set; }
        public string OutDoorLocationsPageMetaDescription { get; set; }
        public string OutDoorLocationsPageMetaKeywords { get; set; }
        public string OutDoorLocationsPageCanonicalUrl { get; set; }



        public string LocationsPageTitle { get; set; }
        public string LocationsPageMetaDescription { get; set; }
        public string LocationsPageMetaKeywords { get; set; }
        public string LocationsPageCanonicalUrl { get; set; }

        

        public string ServicesPageTitle { get; set; }
        public string ServicesPageMetaDescription { get; set; }
        public string ServicesPageMetaKeywords { get; set; }
        public string ServicesPageCanonicalUrl { get; set; }

        

        public string NewsPageTitle { get; set; }
        public string NewsPageMetaDescription { get; set; }
        public string NewsPageMetaKeywords { get; set; }
        public string NewsPageCanonicalUrl { get; set; }
        


        public string AgendaPageTitle { get; set; }
        public string AgendaPageMetaDescription { get; set; }
        public string AgendaPageMetaKeywords { get; set; }
        public string AgendaPageCanonicalUrl { get; set; }


        
        public string AlbumsPageTitle { get; set; }
        public string AlbumsPageMetaDescription { get; set; }
        public string AlbumsPageMetaKeywords { get; set; }
        public string AlbumsPageCanonicalUrl { get; set; }

        
        public string VideoPageTitle { get; set; }
        public string VideoPageMetaDescription { get; set; }
        public string VideoPageMetaKeywords { get; set; }
        public string VideoPageCanonicalUrl { get; set; }

        

        public string PicturePageTitle { get; set; }
        public string PicturePageMetaDescription { get; set; }
        public string PicturePageMetaKeywords { get; set; }
        public string PicturePageCanonicalUrl { get; set; }

        

        public string CitizenPageTitle { get; set; }
        public string CitizenPageMetaDescription { get; set; }
        public string CitizenPageMetaKeywords { get; set; }
        public string CitizenPageCanonicalUrl { get; set; }



        public string ContactUsPageTitle { get; set; }
        public string ContactUsPageMetaDescription { get; set; }
        public string ContactUsPageMetaKeywords { get; set; }
        public string ContactUsPageCanonicalUrl { get; set; }





        public string CareersPageTitle { get; set; }
        public string CareersPageMetaDescription { get; set; }
        public string CareersPageMetaKeywords { get; set; }
        public string CareersPageCanonicalUrl { get; set; }






        public int UserEditId { get; set; }
        public DateTime EditeTime { get; set; }
    }
}