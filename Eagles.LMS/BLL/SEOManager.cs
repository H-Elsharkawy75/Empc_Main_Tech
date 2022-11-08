using Eagles.LMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eagles.LMS.BLL
{
    public class SEOManager : Reposatory<SEO>
    {

        public SEOManager(LMS.Data.EmcNewsContext ctx) : base(ctx) { }
    }

}