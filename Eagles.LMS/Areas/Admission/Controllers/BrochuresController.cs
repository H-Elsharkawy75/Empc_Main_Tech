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
    public class BrochuresController : Controller
    {
        public ActionResult Index()
        {


            return View(new UnitOfWork().BrochuresManager.GetAll().FirstOrDefault());
            //var data = (new UnitOfWork().BrochuresManager.GetAll().OrderByDescending(s => s.Id).ToList());
            //return View(data);
        }
        public int GetUserId()
        {
            var userFromSesstion = HttpContext.Session["User_Key"];
            return Convert.ToInt32(userFromSesstion);
        }
        [HttpPost]
        public ActionResult Index(Brochure brochure, HttpPostedFileBase uploadattachments)
        {

            ActionResult result = View(brochure);


            RequestStatus requestStatus;
            if (brochure.Id == 0 && (uploadattachments == null || uploadattachments.ContentLength == 0 || !
                uploadattachments.ContentType.CheckImageExtention()) || (brochure.Id > 0 && uploadattachments != null && !
                uploadattachments.ContentType.CheckImageExtention()))
            {

                requestStatus = new ManageRequestStatus().GetStatus(Status.GeneralError, "Attachment not supported ,Plz Upload Image Only");
            }
            else
            {


                if (uploadattachments != null)
                {

                    //string _rendom = new Random().Next(1, 99999999).ToString();

                    var fileName = Guid.NewGuid() + Path.GetFileName(uploadattachments.FileName);

                    var path = Path.Combine(Server.MapPath("~/attachments"), fileName);
                    uploadattachments.SaveAs(path);
                    brochure.Image = $"/attachments/{fileName}";

                }

                int userId = GetUserId();
                brochure.UserEditId = userId;
                brochure.EditeTime = DateTime.Now;
                var ctx = new UnitOfWork();
                if (brochure.Id == 0)
                    brochure = ctx.BrochuresManager.Add(brochure);
                else
                    ctx.BrochuresManager.UpdateWithSave(brochure);

                requestStatus = new ManageRequestStatus().GetStatus(Status.Edited);
                result = RedirectToAction(nameof(Index));
                ctx.logManager.Add(new log
                {
                    UserId = userId,
                    ActionTime = DateTime.Now,
                    EntityId = brochure.Id,
                    TableName = "AboutUs",
                    Action = "Update:About Us"
                });


            }
            TempData["RequestStatus"] = requestStatus;




            return result;

        }

















        //public int GetUserId()
        //{
        //    var userFromSesstion = HttpContext.Session["User_Key"];
        //    return Convert.ToInt32(userFromSesstion);
        //}
        public ActionResult Edit(int id)
        {
            var Brochure = new UnitOfWork().BrochuresManager.GetBy(id);
            if (Brochure == null)
                return HttpNotFound();
            return View(Brochure);
        }
        [HttpPost]
        public ActionResult Edit(Brochure Brochure, HttpPostedFileBase uploadattachments )
        {

            ActionResult result = View(Brochure);


            RequestStatus requestStatus;
            if (uploadattachments != null && !
                uploadattachments.ContentType.CheckImageExtention())
            {

                requestStatus = new ManageRequestStatus().GetStatus(Status.GeneralError, "Attachment not supported ,Plz Upload Image Only");
            }
            else
            {


                if (uploadattachments != null)
                {

                    //string _rendom = new Random().Next(1, 99999999).ToString();

                    var fileName = Guid.NewGuid() + Path.GetFileName(uploadattachments.FileName);

                    var path = Path.Combine(Server.MapPath("~/attachments"), fileName);
                    uploadattachments.SaveAs(path);
                    Brochure.Image = $"/attachments/{fileName}";

                }

                int userId = GetUserId();
                Brochure.UserEditId = userId;
                Brochure.EditeTime = DateTime.Now;


                var ctx = new UnitOfWork();
                ctx.BrochuresManager.UpdateWithSave(Brochure);

                ctx.logManager.Add(new log
                {
                    UserId = userId,
                    ActionTime = DateTime.Now,
                    EntityId = Brochure.Id,
                    TableName = "Brochure",
                    Action = "Edit:Brochure"
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
        public ActionResult Create(Brochure Brochure, HttpPostedFileBase uploadattachments)
        {

            ActionResult result = View(Brochure);

            if (ModelState.IsValid)
            {

                RequestStatus requestStatus;
                if (uploadattachments == null || uploadattachments.ContentLength == 0 || !
                    uploadattachments.ContentType.CheckImageExtention())
                {
                    requestStatus = new ManageRequestStatus().GetStatus(Status.GeneralError, "Attachment not supported ,Plz Upload Image Only");
                }
                else
                {




                    //string _rendom = new Random().Next(1, 99999999).ToString();

                    var fileName = Guid.NewGuid() + Path.GetFileName(uploadattachments.FileName);

                    var path = Path.Combine(Server.MapPath("~/attachments"), fileName);
                    uploadattachments.SaveAs(path);
                    Brochure.Image = $"/attachments/{fileName}";
                    int userId = GetUserId();
                    Brochure.UserCreateId = userId;
                    Brochure.CreateTime = DateTime.Now;
                    Brochure.UserEditId = userId;
                    Brochure.EditeTime = DateTime.Now;

                    var ctx = new UnitOfWork();
                    Brochure = ctx.BrochuresManager.Add(Brochure);
                    ctx.logManager.Add(new log
                    {
                        UserId = userId,
                        ActionTime = DateTime.Now,
                        EntityId = Brochure.Id,
                        TableName = "Brochure",
                        Action = "Create:Brochure"
                    });
                    requestStatus = new ManageRequestStatus().GetStatus(Status.Created);
                    result = RedirectToAction(nameof(Create));



                }
                TempData["RequestStatus"] = requestStatus;



            }
            return result;

        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            UnitOfWork ctx = new UnitOfWork();
            var entity = ctx.BrochuresManager.GetBy(id);
            ctx.logManager.Add(new log
            {
                UserId = id,
                ActionTime = DateTime.Now,
                EntityId = id,
                TableName = "Brochure",
                Action = "Delete:Brochure"
            });
            ctx.BrochuresManager.Delete(entity);
            return Json(JsonRequestBehavior.AllowGet);
        }


    }
}