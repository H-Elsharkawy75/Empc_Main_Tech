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
    public class SlidersController : Controller
    {
        // GET: Admission/Slider
        public ActionResult Index()
        {

            return View(new UnitOfWork().SliderManager.GetAll().OrderByDescending(s => s.Order).ToList());
        }
        public int GetUserId()
        {
            var userFromSesstion = HttpContext.Session["User_Key"];
            return Convert.ToInt32(userFromSesstion);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var slider = new UnitOfWork().SliderManager.GetBy(id);
            if (slider == null)
                return HttpNotFound();
            return View(slider);
        }
        [HttpPost]
        public ActionResult Edit(Slider slider, HttpPostedFileBase uploadattachments, HttpPostedFileBase Video_EN_uploadattachments, HttpPostedFileBase Video_AR_uploadattachments)
        {

            ActionResult result = View(slider);


            RequestStatus requestStatus;
            if (((string.IsNullOrEmpty(slider.Iframe)) &&(string.IsNullOrEmpty(slider.ArabicIframe))) && 
                (uploadattachments != null && (! uploadattachments.ContentType.CheckImageExtention() && ! uploadattachments.ContentType.CheckVideoExtention())) &&
                (Video_EN_uploadattachments != null && (!Video_EN_uploadattachments.ContentType.CheckImageExtention() && !Video_EN_uploadattachments.ContentType.CheckVideoExtention())) &&
                (Video_AR_uploadattachments != null && (!Video_AR_uploadattachments.ContentType.CheckImageExtention() && !Video_AR_uploadattachments.ContentType.CheckVideoExtention()))

                    )
            {

                requestStatus = new ManageRequestStatus().GetStatus(Status.GeneralError, "Attachment not supported ,Plz Upload Image Only");
            }
            else
            {
                if (string.IsNullOrEmpty(slider.Iframe) && string.IsNullOrEmpty(slider.ArabicIframe))
                {



                    if (uploadattachments != null)
                    {
                        string extention = System.IO.Path.GetExtension(uploadattachments.FileName);
                        var fileName = Guid.NewGuid() + extention;

                        var path = Path.Combine(Server.MapPath("~/attachments"), fileName);
                        uploadattachments.SaveAs(path);
                        slider.Image = $"/attachments/{fileName}";
                        slider.IsImage = uploadattachments.ContentType.CheckImageExtention();

                    }

                }
                else
                {

                    if (Video_EN_uploadattachments != null)
                    {
                        string extention = System.IO.Path.GetExtension(Video_EN_uploadattachments.FileName);
                        var fileName = Guid.NewGuid() + extention;

                        var path = Path.Combine(Server.MapPath("~/attachments/Videos"), fileName);
                        Video_EN_uploadattachments.SaveAs(path);
                        slider.Iframe = $"/attachments/Videos/{fileName}";

                    }

                    if (Video_AR_uploadattachments != null)
                    {
                        string extention = System.IO.Path.GetExtension(Video_AR_uploadattachments.FileName);
                        var fileName = Guid.NewGuid() + extention;

                        var path = Path.Combine(Server.MapPath("~/attachments/Videos"), fileName);
                        Video_AR_uploadattachments.SaveAs(path);
                        slider.ArabicIframe = $"/attachments/Videos/{fileName}";

                    }



                    //slider.Image = "";
                    //slider.IsImage = false;
                    //if (!string.IsNullOrEmpty(slider.Iframe))
                    //{
                    //    try
                    //    {
                    //        slider.Iframe = slider.Iframe.Split('/').Last().ToString();
                    //    }
                    //    catch
                    //    {
                    //        requestStatus = new ManageRequestStatus().GetStatus(Status.GeneralError,
                    //              "Uncompatible IFrame Formtaing");
                    //        return result;
                    //    }
                    //    slider.Iframe = slider.Iframe.Split('/').Last().ToString();
                    //}
                    //if (!string.IsNullOrEmpty(slider.ArabicIframe))
                    //{
                    //    try
                    //    {
                    //        slider.ArabicIframe = slider.ArabicIframe.Split('/').Last().ToString();
                    //    }
                    //    catch
                    //    {
                    //        requestStatus = new ManageRequestStatus().GetStatus(Status.GeneralError,
                    //              "Uncompatible IFrame Formtaing");
                    //        return result;
                    //    }
                    //    slider.ArabicIframe = slider.ArabicIframe.Split('/').Last().ToString();
                    //}
                }


                int userId = GetUserId();
                slider.UserEditId = userId;
                slider.EditeTime = DateTime.Now;

                var ctx = new UnitOfWork();
                ctx.SliderManager.UpdateWithSave(slider);
                ctx.logManager.Add(new log
                {
                    UserId = userId,
                    ActionTime = DateTime.Now,
                    EntityId = slider.Id,
                    TableName = "Slider",
                    Action = "Update:Slider"
                });

                requestStatus = new ManageRequestStatus().GetStatus(Status.Edited);
                result = RedirectToAction(nameof(Edit));


            }
            TempData["RequestStatus"] = requestStatus;




            return result;

        }
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(Slider slider, HttpPostedFileBase uploadattachments, HttpPostedFileBase Video_EN_uploadattachments, HttpPostedFileBase Video_AR_uploadattachments)
        {

            ActionResult result = View(slider);

            if (ModelState.IsValid)
            {
                RequestStatus requestStatus;
                if (
                    (string.IsNullOrEmpty(slider.Iframe) && (string.IsNullOrEmpty(slider.ArabicIframe))) &&
                    (uploadattachments == null || uploadattachments.ContentLength == 0 ||
                    (!uploadattachments.ContentType.CheckImageExtention() && !uploadattachments.ContentType.CheckVideoExtention())) &&

                    (Video_EN_uploadattachments == null || Video_EN_uploadattachments.ContentLength == 0 ||
                    (!Video_EN_uploadattachments.ContentType.CheckImageExtention() && !Video_EN_uploadattachments.ContentType.CheckVideoExtention())) &&

                    (Video_AR_uploadattachments == null || Video_AR_uploadattachments.ContentLength == 0 ||
                    (!Video_AR_uploadattachments.ContentType.CheckImageExtention() && !Video_AR_uploadattachments.ContentType.CheckVideoExtention()))

                    )
                {
                    requestStatus = new ManageRequestStatus().GetStatus(Status.GeneralError, "Attachment not supported ,Plz Upload Image Or Video Only");
                }
                
                else
                {

                    if (uploadattachments != null)
                    {

                        string extention = System.IO.Path.GetExtension(uploadattachments.FileName);
                        var fileName = Guid.NewGuid() + extention;

                        var path = Path.Combine(Server.MapPath("~/attachments"), fileName);
                        uploadattachments.SaveAs(path);
                        slider.Image = $"/attachments/{fileName}";
                        slider.IsImage = uploadattachments.ContentType.CheckImageExtention();
                    }
                    else
                    {

                        if (Video_EN_uploadattachments != null)
                        {
                            string extention = System.IO.Path.GetExtension(Video_EN_uploadattachments.FileName);
                            var fileName = Guid.NewGuid() + extention;

                            var path = Path.Combine(Server.MapPath("~/attachments/Videos"), fileName);
                            Video_EN_uploadattachments.SaveAs(path);
                            slider.Iframe = $"/attachments/Videos/{fileName}";

                        }

                        if (Video_AR_uploadattachments != null)
                        {
                            string extention = System.IO.Path.GetExtension(Video_AR_uploadattachments.FileName);
                            var fileName = Guid.NewGuid() + extention;

                            var path = Path.Combine(Server.MapPath("~/attachments/Videos"), fileName);
                            Video_AR_uploadattachments.SaveAs(path);
                            slider.ArabicIframe = $"/attachments/Videos/{fileName}";

                        }





                        //slider.Image = "";
                        //slider.IsImage = false;
                        //if (!string.IsNullOrEmpty(slider.Iframe))
                        //{

                        //    try
                        //    {
                        //        slider.Iframe = slider.Iframe.Split('/').Last().ToString();
                        //    }
                        //    catch
                        //    {
                        //        requestStatus = new ManageRequestStatus().GetStatus(Status.GeneralError,
                        //            "Uncompatible IFrame Formtaing");
                        //        return result;

                        //    }
                        //}

                        //if (!string.IsNullOrEmpty(slider.ArabicIframe))
                        //{
                        //    try
                        //    {
                        //        slider.ArabicIframe = slider.ArabicIframe.Split('/').Last().ToString();
                        //    }
                        //    catch
                        //    {
                        //        requestStatus = new ManageRequestStatus().GetStatus(Status.GeneralError,
                        //            "Uncompatible IFrame Formtaing");
                        //        return result;

                        //    }
                        //}
                    }

                    int userId = GetUserId();
                    slider.UserCreateId = userId;
                    slider.CreateTime = DateTime.Now;
                    slider.UserEditId = userId;
                    slider.EditeTime = DateTime.Now;
                    var ctx = new UnitOfWork();
                    slider = ctx.SliderManager.Add(slider);
                    ctx.logManager.Add(new log
                    {
                        UserId = userId,
                        ActionTime = DateTime.Now,
                        EntityId = slider.Id,
                        TableName = "Slider",
                        Action = "Create:Slider"
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
            var entity = ctx.SliderManager.GetBy(id);

            ctx.SliderManager.Delete(entity);
            ctx.logManager.Add(new log
            {
                UserId = GetUserId(),
                ActionTime = DateTime.Now,
                EntityId = id,
                TableName = "Slider",
                Action = "Delete:Slider"
            });
            return Json(JsonRequestBehavior.AllowGet);
        }
    }
}