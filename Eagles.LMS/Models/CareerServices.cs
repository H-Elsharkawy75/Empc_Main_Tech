using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Eagles.LMS.Models
{

    [Table("CareerServices")]
    public class CareerService
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<CareerInServices> CareerInServices { get; set; }


    }
}