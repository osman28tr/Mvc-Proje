using ClassLibrary1.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer;
using MvcProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class CalendarController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetCalendarEvents()
        {
            List<CalendarEvent> eventItems = new List<CalendarEvent>();
            AddItem(eventItems);
            return Json(eventItems, JsonRequestBehavior.AllowGet);
        }

        Random rnd = new Random();
        public void AddItem(List<CalendarEvent> eventItems)
        {
            CalendarEvent item = new CalendarEvent();
            var headingcount = hm.GetList().Count;
            var value = hm.GetList();
            List<SelectListItem> valuedateheadings = (from x in hm.GetList()
                                                      select new SelectListItem
                                                      {
                                                          Text = x.HeadingDate.ToString("yyyy - d - MMMM"),
                                                          Value = x.HeadingID.ToString()
                                                      }).ToList();
            for (int i = 0; i < headingcount; i++)
            {
                DateTime startDate = Convert.ToDateTime(valuedateheadings[i].Text);
                item.ID = i + 1;
                item.Start = startDate;
                item.End = startDate.AddDays(rnd.Next(1, 5)).ToString("s");
                item.allDay = true;
                item.Color = "blue";
                item.Title = value[i].HeadingName + item.ID;
                eventItems.Add(item);
            }
        }
    }
}