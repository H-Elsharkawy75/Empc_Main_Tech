using Eagles.LMS.Data;
using Eagles.LMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eagles.LMS.BLL
{
    public class BrochuresManager : Reposatory<Brochure>
    {
        public BrochuresManager(EmcNewsContext ctx) : base(ctx)
        {

        }
    }
}