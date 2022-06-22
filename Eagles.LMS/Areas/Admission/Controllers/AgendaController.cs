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
    public class AgendaController : Controller
    {
        // GET: Admission/Agendas
        public ActionResult Index()
        {

            return View(new UnitOfWork().AgendaManager.GetAll().Where(s => s.Status == EntityStatus.Approval).OrderByDescending(s => s.Id).ToList());
        }

        public ActionResult Pending()
        {

            return View(new UnitOfWork().AgendaManager.GetAll().Where(s => s.Status == EntityStatus.Pending).ToList());
        }

        [HttpPost]
        public ActionResult Edit(Agenda agenda, HttpPostedFileBase uploadattachments, List<HttpPostedFileBase> uploadattachments_multi = null)
        {

            var _ctx = new UnitOfWork();



            RequestStatus requestStatus;
            if (uploadattachments != null && !
                uploadattachments.ContentType.CheckImageExtention())
            {

                requestStatus = new ManageRequestStatus().GetStatus(Status.GeneralError, "Attachment not supported ,Plz Upload Image Only");
            }
            else
            {
                if (uploadattachments_multi != null && uploadattachments_multi[0] != null && uploadattachments_multi.Any() &&
            uploadattachments_multi.Any(s => !s.ContentType.CheckImageExtention()))
                {
                    requestStatus = new ManageRequestStatus().GetStatus(Status.GeneralError, "Attachment not supported ,Plz Upload Image Only");

                }
                else
                {
                    string _rendom, fileName, path;
                    if (uploadattachments != null)
                    {

                        //_rendom = new Random().Next(1, 99999999).ToString();

                        //fileName = _rendom + Path.GetFileName(uploadattachments.FileName);

                        string extention = System.IO.Path.GetExtension(uploadattachments.FileName);
                        fileName = Guid.NewGuid() + extention;


                        path = Path.Combine(Server.MapPath("~/attachments"), fileName);
                        uploadattachments.SaveAs(path);
                        agenda.MainImage = $"/attachments/{fileName}";

                    }

                    int userId = GetUserId();
                    agenda.UserEditId = userId;
                    agenda.EditeTime = DateTime.Now;

                    _ctx.AgendaManager.UpdateWithSave(agenda);

                    _ctx.logManager.Add(new log
                    {
                        UserId = userId,
                        ActionTime = DateTime.Now,
                        EntityId = agenda.Id,
                        TableName = "Agenda",
                        Action = "Update:Agenda"
                    });

                    if (uploadattachments_multi != null && uploadattachments_multi[0] != null)
                    {
                        foreach (var item in uploadattachments_multi)
                        {
                            //_rendom = new Random().Next(1, 99999999).ToString();

                            fileName = Guid.NewGuid() + Path.GetFileName(item.FileName);

                            path = Path.Combine(Server.MapPath("~/attachments"), fileName);
                            item.SaveAs(path);
                            _ctx.AgendaImagesManager.Add(new AgendaImages
                            {

                                AgendaId = agenda.Id,
                                Path = $"/attachments/{fileName}",

                            });

                        }
                    }


                    requestStatus = new ManageRequestStatus().GetStatus(Status.Edited);




                }
            }

            TempData["RequestStatus"] = requestStatus;
            agenda.AgendaImages = _ctx.AgendaImagesManager.GetAll().Where(s => s.AgendaId == agenda.Id).ToList();
            return View(agenda);

        }

        public ActionResult Edit(int id)
        {
            var ctx = new UnitOfWork();
            var _agenda = ctx.AgendaManager.GetBy(id);
            if (_agenda == null)
                return HttpNotFound();
            _agenda.AgendaImages = ctx.AgendaImagesManager.GetAll().Where(s => s.AgendaId == id).ToList();
            return View(_agenda);
        }
        public int GetUserId()
        {
            var userFromSesstion = HttpContext.Session["User_Key"];
            return Convert.ToInt32(userFromSesstion);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Agenda _Agenda, HttpPostedFileBase uploadattachments, List<HttpPostedFileBase> uploadattachments_multi = null)
        {
            _Agenda.Status = EntityStatus.Pending;
            ActionResult result = View(_Agenda);

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


                    if (uploadattachments_multi != null && uploadattachments_multi[0] != null && uploadattachments_multi.Any() &&
              uploadattachments_multi.Any(s => !s.ContentType.CheckImageExtention()))
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
                        _Agenda.MainImage = $"/attachments/{fileName}";

                        var _ctx = new UnitOfWork();
                        _Agenda.CreateTime = DateTime.Now;
                        int userId = GetUserId();
                        _Agenda.UserCreateId = userId;
                        _Agenda.CreateTime = DateTime.Now;
                        _Agenda.UserEditId = userId;
                        _Agenda.EditeTime = DateTime.Now;
                        _Agenda = _ctx.AgendaManager.Add(_Agenda);
                        _ctx.logManager.Add(new log
                        {
                            UserId = userId,
                            ActionTime = DateTime.Now,
                            EntityId = _Agenda.Id,
                            TableName = "Agenda",
                            Action = "Create:Agenda"
                        });
                        requestStatus = new ManageRequestStatus().GetStatus(Status.Created);
                        result = RedirectToAction(nameof(Create));
                        if (uploadattachments_multi != null && uploadattachments_multi[0] != null)
                        {
                            foreach (var item in uploadattachments_multi)
                            {
                                //_rendom = new Random().Next(1, 99999999).ToString();

                                fileName = Guid.NewGuid() + Path.GetFileName(item.FileName);

                                path = Path.Combine(Server.MapPath("~/attachments"), fileName);
                                item.SaveAs(path);
                                _ctx.AgendaImagesManager.Add(new AgendaImages
                                {

                                    AgendaId = _Agenda.Id,
                                    Path = $"/attachments/{fileName}",

                                });

                            }
                        }

                    }
                }
                TempData["RequestStatus"] = requestStatus;



            }
            return result;

        }

        [HttpPost]
        public ActionResult Pending(int id, EntityStatus status)
        {
            UnitOfWork ctx = new UnitOfWork();
            var entity = ctx.AgendaManager.GetBy(id);

            entity.Status = status;
            ctx.AgendaManager.UpdateWithoutSave(entity);
            ctx.logManager.Add(new log
            {
                UserId = GetUserId(),
                ActionTime = DateTime.Now,
                EntityId = id,
                TableName = "Agenda",
                Action = "" + status.ToString() + ":Agenda"
            });
            return Json(JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            UnitOfWork ctx = new UnitOfWork();
            var entity = ctx.AgendaManager.GetBy(id);

            ctx.AgendaManager.Delete(entity);

            ctx.logManager.Add(new log
            {
                UserId = GetUserId(),
                ActionTime = DateTime.Now,
                EntityId = id,
                TableName = "Agenda",
                Action = "Delete:Agenda"
            });

            return Json(JsonRequestBehavior.AllowGet);
        }
    }
}