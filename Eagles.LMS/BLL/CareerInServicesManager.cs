using Eagles.LMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace Eagles.LMS.BLL
{
    public class CareerInServicesManager : Reposatory<CareerInServices>
    {
        public CareerInServicesManager(LMS.Data.EmcNewsContext ctx) : base(ctx) { }
        public List<CareerInServices> GetAllIncluded(int careerid)
        {
            return ctx.CareerInServices.Include(s => s.CareerService).Where(s => s.CareerId == careerid).ToList();
        }

    }
}