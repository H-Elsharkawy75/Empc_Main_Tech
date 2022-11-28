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
    public class BoardTapsController : Controller
    {
        // GET: Admission/BoardTaps
        public ActionResult Index(int id,int? tab_id = 0)
        {
            if (tab_id != null && tab_id != 0)
            {
                ViewBag.Id = id;
                ViewBag.Tab_Id = tab_id;
                return View(new UnitOfWork().BoardTapsManager.GetAll().Where(s => s.Board_Id == id && s.Parent_Id == tab_id).OrderBy(s => s.Order).ToList());
            }
            else
            {
                ViewBag.Id = id;
                return View(new UnitOfWork().BoardTapsManager.GetAll().Where(s => s.Board_Id == id && s.Parent_Id == 0).OrderBy(s => s.Order).ToList());
            }
            
        }
        public int GetUserId()
        {
            var userFromSesstion = HttpContext.Session["User_Key"];
            return Convert.ToInt32(userFromSesstion);
        }





        public ActionResult Edit(int id)
        {
            var taps = new UnitOfWork().BoardTapsManager.GetBy(id);
            if (taps == null)
                return HttpNotFound();
            return View(taps);
        }
        [HttpPost]
        public ActionResult Edit(BoardTaps _taps, HttpPostedFileBase uploadattachments)
        {

            ActionResult result = View(_taps);
            var ctx = new UnitOfWork();
            RequestStatus requestStatus;
            if (uploadattachments != null && !
                uploadattachments.ContentType.CheckImageExtention())
            {

                requestStatus = new ManageRequestStatus().GetStatus(Status.GeneralError, "Attachment not supported ,Plz Upload Image Only");
            }
            else
            {


              

                int userId = GetUserId();
                _taps.UserEditId = userId;
                _taps.EditeTime = DateTime.Now;

                ctx.BoardTapsManager.UpdateWithSave(_taps);

                var user = ctx.UserManager.GetById(GetUserId());

                ctx.logManager.Add(new log
                {
                    UserId = userId,
                    ActionTime = DateTime.Now,
                    EntityId = _taps.Id,
                    TableName = "BoardTaps",
                    Action = "Edit:BoardTaps",


                });



                requestStatus = new ManageRequestStatus().GetStatus(Status.Edited);




            }
            TempData["RequestStatus"] = requestStatus;




            return result;

        }


        public ActionResult Create(int id)
        {
            ViewBag.Id = id;
            Session["board_Id"] = id;
            //return View(new BoardTaps { Board_Id = id });
            return View();
        }
        [HttpPost]
        public ActionResult Create(BoardTaps _taps, HttpPostedFileBase uploadattachments)
        {


            ActionResult result = View(_taps);
            _taps.Board_Id = (int)Session["board_Id"];

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
                _taps.UserCreateId = userId;
                _taps.CreateTime = DateTime.Now;
                _taps.UserEditId = userId;
                _taps.EditeTime = DateTime.Now;

                var ctx = new UnitOfWork();
                _taps = ctx.BoardTapsManager.Add(_taps);

                var user = ctx.UserManager.GetById(GetUserId());

                ctx.logManager.Add(new log
                {
                    UserId = userId,
                    ActionTime = DateTime.Now,
                    EntityId = _taps.Id,
                    TableName = "BoardTaps",
                    Action = "Create:BoardTaps",


                });

                requestStatus = new ManageRequestStatus().GetStatus(Status.Created);
                result = RedirectToAction("Index", new { id = _taps.Board_Id, tab_id = _taps.Parent_Id });



                //}
                TempData["RequestStatus"] = requestStatus;



            }
            return result;

        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            UnitOfWork ctx = new UnitOfWork();
            var entity = ctx.BoardTapsManager.GetBy(id);

            var user = ctx.UserManager.GetById(GetUserId());



            ctx.BoardTapsManager.Delete(entity);
            ctx.logManager.Add(new log
            {
                UserId = GetUserId(),
                ActionTime = DateTime.Now,
                EntityId = id,
                TableName = "BoardTaps",
                Action = "Delete:BoardTaps",


            });
            return Json(JsonRequestBehavior.AllowGet);
        }






    }
}