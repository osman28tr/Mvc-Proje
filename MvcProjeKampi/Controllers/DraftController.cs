using ClassLibrary1.Concrete;
using DataAccessLayer;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class DraftController : Controller
    {
        DraftManager dm = new DraftManager(new EfDraftDal());
        Context c = new Context();
        public ActionResult Index()
        {
            var draftvalues = dm.GetList();
            return View(draftvalues);
        }
        public ActionResult AddDraft()
        {
            return View();
        }
        public ActionResult Drafts(string s)
        {
            ViewBag.ss = s;
            return View();
        }
    }
}