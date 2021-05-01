using HotelBooking.Models;
using HotelBooking.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelBooking.Controllers
{
    public class RoomController : Controller
    {
        private HotelDBEntities objHotelDbEntities;
        public RoomController()
        {
            objHotelDbEntities = new HotelDBEntities();
        }
        public ActionResult Index()
        {
            RoomViewModel objRoomViewModel = new RoomViewModel();
            objRoomViewModel.ListOfBookingStatus = (from obj in objHotelDbEntities.BookingStatus
                select new SelectListItem()
                {
                    Text = obj.BookingStatus,
                    Value=obj.BookingStatusId.ToString()
                }).ToList();
            objRoomViewModel.ListOfRoomType= (from obj in objHotelDbEntities.RoomTypes
                select new SelectListItem()
                {
                     Text = obj.RoomTypeName,
                     Value = obj.RoomTypeId.ToString()
                }).ToList();

            return View(objRoomViewModel);
        }
        [HttpPost]
        public ActionResult Index(RoomViewModel objroomViewModel)
        {
            return Json("", JsonRequestBehavior.AllowGet);
        }
    }
}