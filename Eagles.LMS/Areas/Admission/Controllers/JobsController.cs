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
    public class JobsController : Controller
    {
        public ActionResult Index()
        {
            var data = (new UnitOfWork().JobsManager.GetAll().OrderByDescending(s => s.Id).ToList());
            return View(data);
        }
        public int GetUserId()
        {
            var userFromSesstion = HttpContext.Session["User_Key"];
            return Convert.ToInt32(userFromSesstion);
        }
        public ActionResult Edit(int id)
        {
            var jobs = new UnitOfWork().JobsManager.GetBy(id);
            if (jobs == null)
                return HttpNotFound();
            return View(jobs);
        }
        [HttpPost]
        public ActionResult Edit(Jobs jobs, HttpPostedFileBase uploadattachments)
        {

            ActionResult result = View(jobs);


            RequestStatus requestStatus;
            if (uploadattachments != null && !
                uploadattachments.ContentType.CheckImageExtention())
            {

                requestStatus = new ManageRequestStatus().GetStatus(Status.GeneralError, "Attachment not supported ,Plz Upload Image Only");
            }
            else
            {


                if (uploadattachments == null)
                {

                    //string _rendom = new Random().Next(1, 99999999).ToString();

                    //var fileName = Guid.NewGuid() + Path.GetFileName(uploadattachments.FileName);

                    //var path = Path.Combine(Server.MapPath("~/attachments"), fileName);
                    //uploadattachments.SaveAs(path);
                    //client.Image = $"/attachments/{fileName}";

                }

                int userId = GetUserId();
                jobs.UserEditId = userId;
                jobs.EditeTime = DateTime.Now;


                var ctx = new UnitOfWork();
                ctx.JobsManager.UpdateWithSave(jobs);

                ctx.logManager.Add(new log
                {
                    UserId = userId,
                    ActionTime = DateTime.Now,
                    EntityId = jobs.Id,
                    TableName = "Jobs",
                    Action = "Edit:Jobs"
                });

                requestStatus = new ManageRequestStatus().GetStatus(Status.Edited);




            }
            TempData["RequestStatus"] = requestStatus;




            return result;

        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Jobs jobs, HttpPostedFileBase uploadattachments)
        {

            ActionResult result = View(jobs);

            if (ModelState.IsValid)
            {

                RequestStatus requestStatus;
                //if (uploadattachments == null || uploadattachments.ContentLength == 0 || !
                //    uploadattachments.ContentType.CheckImageExtention())
                //{
                //    requestStatus = new ManageRequestStatus().GetStatus(Status.GeneralError, "Attachment not supported ,Plz Upload Image Only");
                //}
                //else
                //{




                //string _rendom = new Random().Next(1, 99999999).ToString();

                //var fileName = _rendom + Path.GetFileName(uploadattachments.FileName);
                //string extention = System.IO.Path.GetExtension(uploadattachments.FileName);
                //var fileName = _rendom + extention;
                //var path = Path.Combine(Server.MapPath("~/attachments"), fileName);
                //uploadattachments.SaveAs(path);
                //addsnews.Image = $"/attachments/{fileName}";
                int userId = GetUserId();
                jobs.UserCreateId = userId;
                jobs.CreateTime = DateTime.Now;
                jobs.UserEditId = userId;
                jobs.EditeTime = DateTime.Now;

                var ctx = new UnitOfWork();
                jobs = ctx.JobsManager.Add(jobs);

                var user = ctx.UserManager.GetById(GetUserId());

                ctx.logManager.Add(new log
                {
                    UserId = userId,
                    ActionTime = DateTime.Now,
                    EntityId = jobs.Id,
                    TableName = "Jobs",
                    Action = "Create:Jobs",
                    //LoginDate = user.LoginDate,
                    //LogoutDate = user.LogoutDate,
                    //ActionTitle = jobs.NameEnglish


                });

                requestStatus = new ManageRequestStatus().GetStatus(Status.Created);
                result = RedirectToAction(nameof(Create));



                //}
                TempData["RequestStatus"] = requestStatus;



            }
            return result;

        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            UnitOfWork ctx = new UnitOfWork();
            var entity = ctx.JobsManager.GetBy(id);
            ctx.logManager.Add(new log
            {
                UserId = id,
                ActionTime = DateTime.Now,
                EntityId = id,
                TableName = "Jobs",
                Action = "Delete:Jobs"
            });
            ctx.JobsManager.Delete(entity);
            return Json(JsonRequestBehavior.AllowGet);
        }


    }
}