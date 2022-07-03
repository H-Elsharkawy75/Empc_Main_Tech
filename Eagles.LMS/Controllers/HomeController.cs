using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Eagles.LMS.BLL;
using Eagles.LMS.DTO;
using Eagles.LMS.Models;


using System.IO;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eagles.LMS.Controllers
{
    public class HomeController : Controller
    {
        private UnitOfWork ctx = new UnitOfWork();
        // GET: Home
        public ActionResult Index()
        {

            //return Redirect("/Admission");
            return View();
        }

        public ActionResult AboutUs()
        {
            //return Redirect("/Admission");
            return View();
        }


        public ActionResult LocationOutdoor()
        {

            //return Redirect("/Admission");
            return View();
        }
        public ActionResult AriasLocation()
        {
            //return Redirect("/Admission");
            return View();
        }
        public ActionResult Locations(int? id, string type)
        {
            if (id != null)
                ViewBag.Id = id;
            if (!string.IsNullOrEmpty(type))
            {
                //return Redirect("/Admission");
                ViewBag.Type = type;
            }
            return View();
        }

        public ActionResult LocationDetails(int id)
        {
            var loction = new UnitOfWork().LocationManager.GetBy(id);
            if (loction == null)
            {
                return HttpNotFound();
            }
            bool en = true;

            if (Request.Cookies["Language"] != null)
            {
                en = (Request.Cookies["Language"].Value.ToString() == "en") ? true : false;

            }
            if (en == true)
            {
                loction = new UnitOfWork().LocationManager.GetAll().Where(s => s.TitleEnglish != null).FirstOrDefault(s => s.Id == id);
            }
            else
            {
                loction = new UnitOfWork().LocationManager.GetAll().Where(s => s.TitleArabic != null).FirstOrDefault(s => s.Id == id);
            }
            if (loction == null)
                return View("NotFound");
            loction.LocationImages = new UnitOfWork().LocationImagesManager.GetAllBind().Where(s => s.LocationId == id).ToList();
            //return Redirect("/Admission");
            return View(loction);
        }
        public ActionResult Services()
        {
            //return Redirect("/Admission");
            return View();
        }
        public ActionResult ServicesDetails(int id)
        {
            //var service = new UnitOfWork().ServiceManager.GetAll().FirstOrDefault(s => s.Id == id);
            //if (service == null)
            //    return HttpNotFound();


            // return Redirect("/Admission");
            var service = new Service();
            //if (service == null)
            //    return HttpNotFound();
            // return Redirect("/Admission");
            bool en = true;

            if (Request.Cookies["Language"] != null)
            {
                en = (Request.Cookies["Language"].Value.ToString() == "en") ? true : false;

            }
            if (en == true)
            {
                service = new UnitOfWork().ServiceManager.GetAll().Where(s => s.TitleEnglish != null).FirstOrDefault(s => s.Id == id);
            }
            else
            {
                service = new UnitOfWork().ServiceManager.GetAll().Where(s => s.TitleArabic != null).FirstOrDefault(s => s.Id == id);
            }
            if (service == null)
                return View("NotFound");

            service.ServiceImages = new UnitOfWork().ServiceImagesManager.GetAllBind().Where(s => s.ServiceId == id).ToList();

            return View(service);
        }

        public ActionResult TrainingCenter()
        {
            return View();
        }
        public ActionResult StudiosServices()
        {
            return View();
        }
        public ActionResult News()
        {
            //return Redirect("/Admission");
            return View();
        }
        public ActionResult NewsDetails(int id)
        {
            //var _new = new UnitOfWork().NewManager.GetAll().FirstOrDefault(s => s.Id == id);
            //if (_new == null)
            //    return HttpNotFound();


            //return Redirect("/Admission");

            var _new = new New();
            bool en = true;

            if (Request.Cookies["Language"] != null)
            {
                en = (Request.Cookies["Language"].Value.ToString() == "en") ? true : false;

            }
            if (en == true)
            {
                _new = new UnitOfWork().NewManager.GetAll().Where(s => s.TitleEnglish != null).FirstOrDefault(s => s.Id == id);

            }
            else
            {
                _new = new UnitOfWork().NewManager.GetAll().Where(s => s.TitleArabic != null).FirstOrDefault(s => s.Id == id);

            }
            if (_new == null)
                return View("NotFound");
            _new.NewImages = new UnitOfWork().NewImagesMnager.GetAllBind().Where(s => s.NewId == id).ToList();
            return View(_new);
        }
        public ActionResult Agenda(DateTime? _date)
        {
            if (_date != null)
            {
                ViewBag.Date = _date;
            }
            //return Redirect("/Admission");
            return View();
        }
        public ActionResult Albums()
        {
            return View();
        }


        public ActionResult AgendaDetails(int id)
        {
            var _agenda = new Agenda();
            //if (_agenda == null)
            //    return HttpNotFound();
            //return Redirect("/Admission");
            bool en = true;

            if (Request.Cookies["Language"] != null)
            {
                en = (Request.Cookies["Language"].Value.ToString() == "en") ? true : false;

            }
            if (en == true)
            {
                _agenda = new UnitOfWork().AgendaManager.GetAll().Where(s => s.TitleEnglish != null).FirstOrDefault(s => s.Id == id);
            }
            else
            {
                _agenda = new UnitOfWork().AgendaManager.GetAll().Where(s => s.TitleArabic != null).FirstOrDefault(s => s.Id == id);
            }
            if (_agenda == null)
                return View("NotFound");
            //return Redirect("/Admission");
            _agenda.AgendaImages = new UnitOfWork().AgendaImagesManager.GetAllBind().Where(s => s.AgendaId == id).ToList();
            return View(_agenda);
        }

        public ActionResult Video()
        {
            //return Redirect("/Admission");
            return View();
        }

        public ActionResult VideoAlbums()
        {
            //return Redirect("/Admission");
            return View();
        }
        public ActionResult VideoDetails(int? id, int? albumId)
        {

            if (id != null)
                ViewBag.Id = id;
            //return Redirect("/Admission");
            if (albumId != null)
                ViewBag.AlbumId = albumId;
            if (id == null && albumId == null)
            {
                return View("NotFound");
            }
            return View();
        }
        public ActionResult Picture(int? id, int? albumId)
        {

            if (id != null)
                ViewBag.Id = id;
            //return Redirect("/Admission");
            if (albumId != null)
                ViewBag.AlbumId = albumId;
            return View();
        }
        public ActionResult PictureDetails()
        {
            //var picture = new UnitOfWork().GalaryManager.GetBy(id);
            //if (picture == null)
            //{
            //    return HttpNotFound();mg
            //}
            //picture.Image = new UnitOfWork().GalaryManager.GetAllBind().Where(s => s.LocationId == id).ToList();
            //return Redirect("/Admission");
            return View();
        }
        public ActionResult Citizen()
        {
            //return Redirect("/Admission");
            return View();
        }
        public ActionResult ContactUs()
        {
            //return Redirect("/Admission");
            return View();
        }
        public ActionResult ContactUsHome()
        {
            //return Redirect("/Admission");
            return View();
        }

        public ActionResult Brouchour()
        {
            //return Redirect("/Admission");
            return View();
        }
        public ActionResult Booking()
        {
            //return Redirect("/Admission");
            return View();
        }

        public int GetUserId()
        {
            var userFromSesstion = HttpContext.Session["User_Key"];
            return Convert.ToInt32(userFromSesstion);
        }
        public ActionResult Careers()
        {
            //return Redirect("/Admission");
            return View();
        }

        public ActionResult Lastcareer()
        {
            return View();

        }
        [HttpPost]

        public ActionResult Lastcareer(Career career, HttpPostedFileBase uploadattachments)
        {

            ActionResult result = View(career);


            if (ModelState.IsValid)
            {

                RequestStatus requestStatus;
                if (uploadattachments == null || uploadattachments.ContentLength == 0)
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
                    career.CVLink = $"/attachments/{fileName}";
                    int userId = GetUserId();

                    var ctx = new UnitOfWork();
                    //career = ctx.CareerManager.Add(Career);
                    ctx.logManager.Add(new log
                    {
                        UserId = userId,
                        ActionTime = DateTime.Now,
                        EntityId = career.Id,
                        TableName = "Career",
                    });
                    requestStatus = new ManageRequestStatus().GetStatus(Status.Created);
                    result = RedirectToAction(nameof(career));




                }
                TempData["RequestStatus"] = requestStatus;




            }
            return result;
        }
        //[HttpPost]
        //public ActionResult Careers(Career _career, HttpPostedFileBase uploadattachments)
        //{
        //    var _maxOrder = new UnitOfWork().CareerManager.GetAllBind();
        //    ViewBag.MaxOrder = _maxOrder;


        //    //_career.Status = EntityStatus.Approval;
        //    ActionResult result = View(_career);

        //    if (ModelState.IsValid)
        //    {

        //        RequestStatus requestStatus;
        //        if (uploadattachments == null || uploadattachments.ContentLength == 0)
        //        {
        //            requestStatus = new ManageRequestStatus().GetStatus(Status.GeneralError, "Attachment not supported ,Plz Upload Image Only");
        //        }
        //        else
        //        {
        //            string _rendom = System.Guid.NewGuid().ToString();
        //            //var fileName = _rendom + Path.GetFileName(uploadattachments.FileName);
        //            string extention = System.IO.Path.GetExtension(uploadattachments.FileName);
        //            var fileName = _rendom + extention;
        //            var path = Path.Combine(Server.MapPath("~/attachments/Careers"), fileName);
        //            uploadattachments.SaveAs(path);
        //            _career.CVLink = $"/attachments/Careers/{fileName}";

        //            var _ctx = new UnitOfWork();
        //            requestStatus = new ManageRequestStatus().GetStatus(Status.Created);


        //        }
        //        TempData["RequestStatus"] = requestStatus;



        //    }
        //    return result;

        //}
        public class Newcareer
        {
            public int Id { get; set; }

            public string Name { get; set; }
            public string DateOfBirth { get; set; }

            public string Address { get; set; }

            public string Certification { get; set; }

            public string GraduationYears { get; set; }

            public string JobName { get; set; }

            public string ExperianceLevel { get; set; }

            public string CVLink { get; set; }

            public List<CareerInServices> CareerInServices { get; set; }

            [NotMapped]
            public int[] Services { get; set; }
            public HttpFileCollectionBase NewfileData { get; set; }

        }

        //[HttpPost]
        //public ActionResult Careerss(/*[System.Web.Http.FromBody] Newcareer career*/)
        //{
        //    Career career = new Career();


        //        ActionResult result = View(career);
        //    if (Request.Files.Count > 0)
        //    {

        //            //  Get all files from Request object  
        //            HttpFileCollectionBase files = Request.Files;
        //        for (int i = 0; i < files.Count; i++)
        //        {
        //            //string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";  
        //            //string filename = Path.GetFileName(Request.Files[i].FileName);  

        //            HttpPostedFileBase uploadattachments = files[i];
        //            //var files = Request.Files;
        //            //for (int i = 0; i < files.Count; i++)
        //            //{
        //            //string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";  
        //            //string filename = Path.GetFileName(Request.Files[i].FileName);  

        //            //HttpPostedFileBase uploadattachments = files[i];
        //            if (ModelState.IsValid)
        //            {

        //                RequestStatus requestStatus;
        //                if (uploadattachments == null || uploadattachments.ContentLength == 0)
        //                {
        //                    requestStatus = new ManageRequestStatus().GetStatus(Status.GeneralError, "Attachment not supported ,Plz Upload Image Only");
        //                }
        //                else
        //                {
        //                    //string _rendom = new Random().Next(1, 99999999).ToString();

        //                    //var fileName = _rendom + Path.GetFileName(uploadattachments.FileName);
        //                    string extention = System.IO.Path.GetExtension(uploadattachments.FileName);
        //                    var fileName = Guid.NewGuid() + extention;
        //                    var path = Path.Combine(Server.MapPath("~/attachments"), fileName);
        //                    uploadattachments.SaveAs(path);
        //                    career.CVLink = $"/attachments/{fileName}";
        //                    int userId = GetUserId();

        //                    var ctx = new UnitOfWork();
        //                    //career = ctx.CareerManager.Add(Career);
        //                    ctx.logManager.Add(new log
        //                    {
        //                        UserId = userId,
        //                        ActionTime = DateTime.Now,
        //                        EntityId = career.Id,
        //                        TableName = "Career",
        //                    });
        //                    requestStatus = new ManageRequestStatus().GetStatus(Status.Created);
        //                    result = RedirectToAction(nameof(career));




        //                }
        //                TempData["RequestStatus"] = requestStatus;
        //            }
        //        }



        //    }
        //        return result;

        //     }  
        [HttpPost]
        public ActionResult Careers(Career career, HttpPostedFileBase uploadattachments)
        {

            ActionResult result = View(career);


            if (ModelState.IsValid)
            {

                RequestStatus requestStatus;
                if (uploadattachments == null || uploadattachments.ContentLength == 0)
                {
                    requestStatus = new ManageRequestStatus().GetStatus(Status.GeneralError, "Plz Upload The Attachment");
                }
                else
                {

                    string folderName = "careers";

                    // To create a string that specifies the path to a subfolder under your
                    // top-level folder, add a name for the subfolder to folderName.
                    string pathString = System.IO.Path.Combine(Server.MapPath("~/attachments"), folderName);
                    System.IO.Directory.CreateDirectory(pathString);

                    //string _rendom = new Random().Next(1, 99999999).ToString();

                    //var fileName = _rendom + Path.GetFileName(uploadattachments.FileName);
                    string extention = System.IO.Path.GetExtension(uploadattachments.FileName);
                    var fileName = Guid.NewGuid() + extention;
                    var path = Path.Combine(Server.MapPath("~/attachments/careers"), fileName);
                    uploadattachments.SaveAs(path);
                    career.CVLink = $"/attachments/careers/{fileName}";

                    var ctx = new UnitOfWork();
                    ctx.CareerManager.Add(career);

                    requestStatus = new ManageRequestStatus().GetStatus(Status.Created);



                }
                TempData["RequestStatus"] = requestStatus;




            }
            return result;
        }

        public ActionResult CareethankPage()
        {
            return View();
        }
        public ActionResult ContactThankPage()
        {
            return View();
        }








        public ActionResult ChangeLanguage(string SelectedLanguage, string redirect)
        {

            var controller = RouteData.Values["controller"].ToString();
            var action = RouteData.Values["action"].ToString(); ;
            if (SelectedLanguage != null)
            {
                Thread.CurrentThread.CurrentCulture =
                    CultureInfo.CreateSpecificCulture(SelectedLanguage);
                Thread.CurrentThread.CurrentUICulture =
                    new CultureInfo(SelectedLanguage);
                var cookie = new HttpCookie("Language");
                cookie.Value = SelectedLanguage;
                Response.Cookies.Add(cookie);
            }
            if (redirect == null)
                redirect = "/";
            return Redirect(redirect);
        }

        public ActionResult Changethems(string redirect)
        {

            var controller = RouteData.Values["controller"].ToString();
            var action = RouteData.Values["action"].ToString(); ;


            var cookie = Request.Cookies["thems"];
            if (cookie == null)
            {
                cookie = new HttpCookie("thems");
                cookie.Value = "default";
            }
            else
            {
                cookie.Value = (cookie.Value == "dark") ? "default" : "dark";
            }
            Response.Cookies.Add(cookie);
            if (redirect == null)
                redirect = "/";
            return Redirect(redirect);
        }





        public ActionResult indextwo()
        {
            return View();
        }

        public ActionResult indexhreee()
        {
            return View();
        }
        //public ActionResult  LiveSession()
        //{

        //    int userid = int.Parse(Request.Cookies["UserId"].Value);
        //    var student = ctx.StudentManager.GetAll().FirstOrDefault(c => c.UserId == userid);
        //    if (student == null) return RedirectToAction("Index");
        //    int GradeId = ctx.AppointmentGroupManager.GetBy(ctx.StudentManager.GetAllBind().FirstOrDefault(c => c.UserId == student.UserId) != null ? ctx.StudentManager.GetAllBind().FirstOrDefault(c => c.UserId == student.UserId).AppointmentGroupId : 0) != null ? ctx.AppointmentGroupManager.GetBy(ctx.StudentManager.GetAllBind().FirstOrDefault(c => c.UserId == student.UserId) != null ? ctx.StudentManager.GetAllBind().FirstOrDefault(c => c.UserId == student.UserId).AppointmentGroupId : 0).GradeId : 0;
        //    var result = ctx.LiveVideoManger.GetAllBind().Where(c => c.IsActive == true && (c.GroupId == student.AppointmentGroupId || c.GradeId == GradeId)).ToList();
        //    return View(result);
        //}

    }
}