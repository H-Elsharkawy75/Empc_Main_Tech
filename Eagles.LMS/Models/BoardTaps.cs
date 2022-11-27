using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eagles.LMS.Models
{
    [Table("BoardTaps")]
    public class BoardTaps
    {
        public int Id { get; set; }
        public int Board_Id { get; set; }
        public int Order { get; set; }
        public string Title_EN { get; set; }
        public string Title_AR { get; set; }
        [AllowHtml]
        public string Description_EN { get; set; }
        [AllowHtml]
        public string Description_AR { get; set; }
        public int Parent_Id { get; set; }


        public DateTime CreateTime { get; set; }
        public int UserCreateId { get; set; }
        public DateTime EditeTime { get; set; }
        public int UserEditId { get; set; }


    }
}