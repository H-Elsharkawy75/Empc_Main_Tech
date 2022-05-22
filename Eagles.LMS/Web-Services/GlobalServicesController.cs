using Eagles.LMS.BLL;
using Eagles.LMS.Helper;
using Eagles.LMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Eagles.LMS.Web_Services
{
    public class GlobalServicesController : ApiController
    {
        [HttpPost]
        [Route("api/GlobalServices/RemoveServicesImg")]
        public async Task<IHttpActionResult> EditUser(int id)
        {
            UnitOfWork ctx = new UnitOfWork();
            var serviceImg = ctx.ServiceImagesManager.GetBy(id);
            if (serviceImg != null)
            {
                ctx.ServiceImagesManager.Delete(serviceImg);
                return Ok();
            }
            return NotFound();
        }

        [HttpPost]
        [Route("api/GlobalServices/RemoveNewsImg")]
        public async Task<IHttpActionResult> RemoveNewsImg(int id)
        {
            UnitOfWork ctx = new UnitOfWork();
            var newsImg = ctx.NewImagesMnager.GetBy(id);
            if (newsImg != null)
            {
                ctx.NewImagesMnager.Delete(newsImg);
                return Ok();
            }
            return NotFound();
        }

        [HttpPost]
        [Route("api/GlobalServices/RemoveNewsMainImg")]
        public async Task<IHttpActionResult> RemoveNewsMainImg(int id)
        {
            UnitOfWork ctx = new UnitOfWork();
            var _new = ctx.NewManager.GetBy(id);
            if (_new != null)
            {
                _new.MainImage = "";
                ctx.NewManager.UpdateWithSave(_new);

                return Ok();
            }
            return NotFound();
        }




        [HttpPost]
        [Route("api/GlobalServices/RemoveAgendaMainImg")]
        public async Task<IHttpActionResult> RemoveAgendaMainImg(int id)
        {
            UnitOfWork ctx = new UnitOfWork();
            var _new = ctx.AgendaManager.GetBy(id);
            if (_new != null)
            {
                _new.MainImage = "";
                ctx.AgendaManager.UpdateWithSave(_new);

                return Ok();
            }
            return NotFound();
        }






        [HttpPost]
        [Route("api/GlobalServices/RemoveLocationsMainImg")]
        public async Task<IHttpActionResult> RemoveLocationsMainImg(int id)
        {
            UnitOfWork ctx = new UnitOfWork();
            var _new = ctx.LocationManager.GetBy(id);
            if (_new != null)
            {
                _new.MainImage = "";
                ctx.LocationManager.UpdateWithSave(_new);

                return Ok();
            }
            return NotFound();
        }





        [HttpPost]
        [Route("api/GlobalServices/RemoveServicesMainImg")]
        public async Task<IHttpActionResult> RemoveServicesMainImg(int id)
        {
            UnitOfWork ctx = new UnitOfWork();
            var _new = ctx.ServiceManager.GetBy(id);
            if (_new != null)
            {
                _new.MainImage = "";
                ctx.ServiceManager.UpdateWithSave(_new);
                return Ok();
            }
            return NotFound();
        }



        [HttpPost]
        [Route("api/GlobalServices/RemoveLocationsIconImg")]
        public async Task<IHttpActionResult> RemoveLocationsIconImg(int id)
        {
            UnitOfWork ctx = new UnitOfWork();
            var _new = ctx.LocationManager.GetBy(id);
            if (_new != null)
            {
                _new.IconImage = "";
                ctx.LocationManager.UpdateWithSave(_new);

                return Ok();
            }
            return NotFound();
        }








        [HttpPost]
        [Route("api/GlobalServices/RemoveLocationsImg")]
        public async Task<IHttpActionResult> RemoveLocationsImg(int id)
        {
            UnitOfWork ctx = new UnitOfWork();
            var locationImage = ctx.LocationImagesManager.GetBy(id);
            if (locationImage != null)
            {
                ctx.LocationImagesManager.Delete(locationImage);
                return Ok();
            }
            return NotFound();
        }
        [HttpPost]
        [Route("api/GlobalServices/RemoveAgendaImg")]
        public async Task<IHttpActionResult> RemoveAgendaImg(int id)
        {
            UnitOfWork ctx = new UnitOfWork();
            var agendaImg = ctx.AgendaImagesManager.GetBy(id);
            if (agendaImg != null)
            {
                ctx.AgendaImagesManager.Delete(agendaImg);
                return Ok();
            }
            return NotFound();
        }


        [HttpGet]
        [Route("api/GlobalServices/GetAgendaByDate")]
        public async Task<IHttpActionResult> GetAgendaByDate(DateTime _Date)
        {
            return Ok(new UnitOfWork().AgendaManager.GetAll().Where(s => s.AgendaDate.Date == _Date.Date).ToList());
        }



        [HttpPost]
        [Route("api/GlobalServices/AddBooking")]

        public async Task<IHttpActionResult> AddBooking([FromBody] Booking booking)
        {
            var ctx = new UnitOfWork();
            var book = ctx.BookingManager.Add(booking);
            if (book.Services != null && book.Services.Any())
            {
                foreach (var item in book.Services)
                {
                    ctx.BookingInServicesManager.Add(new BookingInServices
                    {
                        BookingServiceId = item,
                        BookingId = book.Id

                    });
                }
            }
            // try send email
            //try
            //{
            //    new SendEmail().SendMail(new EmailDTO { To = book.CompanyEmail, Message = book.Message, From = "web@empcnews.com", Subject = "New Booking" });
            //    new SendEmail().SendMail(new EmailDTO { To = book.CompanyEmail, Message = book.Message, From = "web@empcnews.com", Subject = "New Booking" });
            //}
            //catch
            //{

            //}
            return Ok();
        }






    }
}