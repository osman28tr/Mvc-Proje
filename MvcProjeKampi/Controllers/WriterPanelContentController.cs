using ClassLibrary1.Concrete;
using DataAccessLayer;
using DataAccessLayer.EntityFramework;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());
        RecordsManager rm = new RecordsManager(new EfRecordsDal());
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        public ActionResult MyContent()
        {
            int contentwriterid = rm.RecordByID();
            var contentvalues = cm.GetList().Where(x => x.Writer.WriterID == contentwriterid).ToList();
            return View(contentvalues);
        }
        [HttpGet]
        public ActionResult AddContent()
        {
            List<SelectListItem> valueheading = (from x in hm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.HeadingName,
                                                      Value = x.HeadingID.ToString()
                                                  }).ToList();
            ViewBag.vlc = valueheading;
            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Content p)
        {
            p.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            int contentwriterid = rm.RecordByID();
            p.WriterID = contentwriterid;
            p.ContentStatus = true;
            cm.ContentAdd(p);
            return RedirectToAction("MyContent");
        }
        public ActionResult ToDoList()
        {
            return View();
        }
    }
}