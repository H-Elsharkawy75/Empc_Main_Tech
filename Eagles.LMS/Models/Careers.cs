using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Eagles.LMS.Models
{

    [Table("Career")]

    public class Career
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string DateOfBirth { get; set; }

        public string Address { get; set; }

        public string Certification { get; set; }

        public string GraduationYears { get; set; }

        public string JobName { get; set; }

        public string ExperianceLevel { get; set; }

        //public string ExperianceLevel { get; set; }
        public string CVLink { get; set; }

        public List<CareerInServices> CareerInServices { get; set; }

        [NotMapped]
        public int[] Services { get; set; }

        public DateTime CreatedTime { get; set; }

    }

}