using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eagles.LMS.Models
{
    public class Brochure
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Description Arabic Is Required")]
        [AllowHtml]

        public string DescriptionArabic { get; set; }

        [Required(ErrorMessage = "Description English Is Required")]
        [AllowHtml]

        public string DescriptionEnglish { get; set; }

        public string PdfLink { get; set; }
        public string Image { get; set; }

        public DateTime EditeTime { get; set; }
        public int UserEditId { get; set; }
        public DateTime CreateTime { get; set; }
        public int UserCreateId { get; set; }




    }
}