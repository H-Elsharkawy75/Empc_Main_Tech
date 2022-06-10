using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Eagles.LMS.Models
{
    [Table("Applications")]
    public class Application
    {
        public int Id { get; set; }

        //[Required(ErrorMessage = "Title Arabic Is Required")]

        public string TitleArabic { get; set; }
        //[Required(ErrorMessage = "Title English Is Required")]

        public string TitleEnglish { get; set; }
        [Required(ErrorMessage = "Link Is Required")]

        public string Link { get; set; }
        public DateTime EditeTime { get; set; }
        public int UserEditId { get; set; }
        public DateTime CreateTime { get; set; }
        public int UserCreateId { get; set; }
    }
}