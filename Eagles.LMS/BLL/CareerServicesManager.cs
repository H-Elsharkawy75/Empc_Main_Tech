using Eagles.LMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eagles.LMS.BLL
{
    public class CareerServiceManager : Reposatory<CareerService>
    {
        public CareerServiceManager(LMS.Data.EmcNewsContext ctx) : base(ctx) { }

    }
}