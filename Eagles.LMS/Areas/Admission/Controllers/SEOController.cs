using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Eagles.LMS.BLL;
using Eagles.LMS.Data;
using Eagles.LMS.Models;
using Eagles.LMS.Security;

namespace Eagles.LMS.Areas.Admission.Controllers
{
    [RouteArea("Admission")]
    [AuthorizeFilterAttribute]
    public class SEOController : Controller
    {
        // GET: Admission/SEO
        public ActionResult Index()
        {
            return View(new UnitOfWork().SEOManager.GetAll().FirstOrDefault());
        }
        public int GetUserId()
        {
            var userFromSesstion = HttpContext.Session["User_Key"];
            return Convert.ToInt32(userFromSesstion);
        }
        [HttpPost]
        public ActionResult Index(SEO seting)
        {
            ActionResult result = View(seting);
            RequestStatus requestStatus;
            seting.EditeTime = DateTime.Now;
            seting.UserEditId = Convert.ToInt32(HttpContext.Session["User_Key"]);
            var ctx = new UnitOfWork();
            if (seting.Id == 0)
                ctx.SEOManager.Add(seting);
            else
                ctx.SEOManager.UpdateWithSave(seting);
            var user = ctx.UserManager.GetById(GetUserId());
            ctx.logManager.Add(new log
            {
                UserId = GetUserId(),
                ActionTime = DateTime.Now,
                EntityId = seting.Id,
                TableName = "SEO",
                Action = "Update:SEO",
                //LoginDate = user.LoginDate,
                //LogoutDate = user.LogoutDate,
                //ActionTitle = "Update:SEO"
            });
            requestStatus = new ManageRequestStatus().GetStatus(Status.Edited);
            result = RedirectToAction(nameof(Index));
            return result;
        }
    }
}