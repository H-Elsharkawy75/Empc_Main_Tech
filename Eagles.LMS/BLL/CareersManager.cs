using Eagles.LMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace Eagles.LMS.BLL
{
    public class CareerManager : Reposatory<Career>
    {
        public CareerManager(LMS.Data.EmcNewsContext ctx) : base(ctx) { }

        public List<Career> GetAllIncluded()
        {
            return ctx.Career.Include(s => s.CareerInServices).ToList();
        }
    }
}