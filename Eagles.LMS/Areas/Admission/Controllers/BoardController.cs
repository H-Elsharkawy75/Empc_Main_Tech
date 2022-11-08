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
    public class BoardController : Controller
    {
        // GET: Admission/Board
        public ActionResult Index()
        {
            return View(new UnitOfWork().BoardManager.GetAll().OrderByDescending(s => s.Id).ToList());
        }
        public int GetUserId()
        {
            var userFromSesstion = HttpContext.Session["User_Key"];
            return Convert.ToInt32(userFromSesstion);
        }
        public ActionResult Edit(int id)
        {
            var _board = new UnitOfWork().BoardManager.GetBy(id);
            if (_board == null)
                return HttpNotFound();
            return View(_board);
        }
        [HttpPost]
        public ActionResult Edit(Board board, HttpPostedFileBase uploadattachments)
        {

            ActionResult result = View(board);


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

                    //var fileName = _rendom + Path.GetFileName(uploadattachments.FileName);
                    string extention = System.IO.Path.GetExtension(uploadattachments.FileName);
                    var fileName = Guid.NewGuid() + extention;

                    var path = Path.Combine(Server.MapPath("~/attachments"), fileName);
                    uploadattachments.SaveAs(path);
                    board.Image = $"/attachments/{fileName}";

                }

                int userId = GetUserId();
                board.UserEditId = userId;
                board.EditeTime = DateTime.Now;
                var ctx = new UnitOfWork();
                ctx.BoardManager.UpdateWithSave(board);

                ctx.logManager.Add(new log
                {
                    UserId = userId,
                    ActionTime = DateTime.Now,
                    EntityId = board.Id,
                    TableName = "Board",
                    Action = "Edit:Board"
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
        public ActionResult Create(Board board, HttpPostedFileBase uploadattachments)
        {

            ActionResult result = View(board);

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

                    //var fileName = _rendom + Path.GetFileName(uploadattachments.FileName);
                    string extention = System.IO.Path.GetExtension(uploadattachments.FileName);
                    var fileName = Guid.NewGuid() + extention;
                    var path = Path.Combine(Server.MapPath("~/attachments"), fileName);
                    uploadattachments.SaveAs(path);
                    board.Image = $"/attachments/{fileName}";
                    int userId = GetUserId();
                    board.UserCreateId = userId;
                    board.CreateTime = DateTime.Now;
                    board.UserEditId = userId;
                    board.EditeTime = DateTime.Now;

                    var ctx = new UnitOfWork();
                    board = ctx.BoardManager.Add(board);
                    ctx.logManager.Add(new log
                    {
                        UserId = userId,
                        ActionTime = DateTime.Now,
                        EntityId = board.Id,
                        TableName = "Board",
                        Action = "Create:Board"
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
            var entity = ctx.BoardManager.GetBy(id);
            ctx.logManager.Add(new log
            {
                UserId = id,
                ActionTime = DateTime.Now,
                EntityId = id,
                TableName = "Board",
                Action = "Delete:Board"
            });
            ctx.BoardManager.Delete(entity);
            return Json(JsonRequestBehavior.AllowGet);
        }

    }
}