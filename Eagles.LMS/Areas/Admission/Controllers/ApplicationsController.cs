using Eagles.LMS.BLL;
using Eagles.LMS.Models;
using Eagles.LMS.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eagles.LMS.Areas.Admission.Controllers
{

    [RouteArea("Admission")]
    [AuthorizeFilterAttribute]
    public class ApplicationsController : Controller
    {
        public ActionResult Index()
        {
            return View(new UnitOfWork().ApplicationManager.GetAll().OrderByDescending(s => s.Id).ToList());
        }
        public int GetUserId()
        {
            var userFromSesstion = HttpContext.Session["User_Key"];
            return Convert.ToInt32(userFromSesstion);
        }
        public ActionResult Edit(int id)
        {
            var _application = new UnitOfWork().ApplicationManager.GetBy(id);
            if (_application == null)
                return HttpNotFound();
            return View(_application);
        }
        [HttpPost]
        public ActionResult Edit(Application application, HttpPostedFileBase uploadattachments)
        {

            ActionResult result = View(application);


            RequestStatus requestStatus;





            int userId = GetUserId();
            application.UserEditId = userId;
            application.EditeTime = DateTime.Now;
            var ctx = new UnitOfWork();
            ctx.ApplicationManager.UpdateWithSave(application);

            ctx.logManager.Add(new log
            {
                UserId = userId,
                ActionTime = DateTime.Now,
                EntityId = application.Id,
                TableName = "application",
                Action = "Edit:application"
            });

            requestStatus = new ManageRequestStatus().GetStatus(Status.Edited);





            TempData["RequestStatus"] = requestStatus;




            return result;

        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Application application, HttpPostedFileBase uploadattachments)
        {

            ActionResult result = View(application);

            if (ModelState.IsValid)
            {

                RequestStatus requestStatus;




                int userId = GetUserId();
                application.UserCreateId = userId;
                application.CreateTime = DateTime.Now;
                application.UserEditId = userId;
                application.EditeTime = DateTime.Now;

                var ctx = new UnitOfWork();
                application = ctx.ApplicationManager.Add(application);
                ctx.logManager.Add(new log
                {
                    UserId = userId,
                    ActionTime = DateTime.Now,
                    EntityId = application.Id,
                    TableName = "application",
                    Action = "Create:application"
                });
                requestStatus = new ManageRequestStatus().GetStatus(Status.Created);
                result = RedirectToAction(nameof(Create));




                TempData["RequestStatus"] = requestStatus;



            }
            return result;

        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            UnitOfWork ctx = new UnitOfWork();
            var entity = ctx.ApplicationManager.GetBy(id);
            ctx.logManager.Add(new log
            {
                UserId = id,
                ActionTime = DateTime.Now,
                EntityId = id,
                TableName = "application",
                Action = "Delete:application"
            });
            ctx.ApplicationManager.Delete(entity);
            return Json(JsonRequestBehavior.AllowGet);
        }


    }
}