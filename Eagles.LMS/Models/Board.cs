using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eagles.LMS.Models
{
    [Table("Board")]
    public class Board
    {
        public int Id { get; set; }

        public string Image { get; set; }

        public string CV_Link { get; set; }
        public string NameArabic { get; set; }
        public string NameEnglish { get; set; }
        public string JobTitleArabic { get; set; }
        public string JobTitleEnglish { get; set; }
        [AllowHtml]
        public string JobDescriptionArabic { get; set; }
        [AllowHtml]
        public string JobDescriptionEnglish { get; set; }


        public string Phone { get; set; }
        public string Email { get; set; }
        public string FaceLink { get; set; }
        public string twiterLink { get; set; }
        public string LinkedInLink { get; set; }
        public string GoogleLink { get; set; }

        public DateTime CreateTime { get; set; }
        public int UserCreateId { get; set; }

        public DateTime EditeTime { get; set; }
        public int UserEditId { get; set; }


    }
}