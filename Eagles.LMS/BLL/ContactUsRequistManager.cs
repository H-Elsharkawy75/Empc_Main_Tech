using Eagles.LMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace Eagles.LMS.BLL
{
    public class ContactUsRquistManager : Reposatory<ContactUsRequist>
    {
        public ContactUsRquistManager(LMS.Data.EmcNewsContext ctx) : base(ctx) { }
    }
}