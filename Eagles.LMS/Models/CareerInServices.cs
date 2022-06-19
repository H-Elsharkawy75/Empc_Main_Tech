using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Eagles.LMS.Models
{
    [Table("CareerInServices")]
    public class CareerInServices
    {
        public int Id { get; set; }
        public CareerService CareerService { get; set; }

        public Career Career { get; set; }

        public int CareerServiceId { get; set; }

        public int CareerId { get; set; }


    }
}