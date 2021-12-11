using ClassLibrary1.Concrete;
using DataAccessLayer;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetAllContent()
        {
            var values = cm.GetList();
            return View(values);
        }
        [HttpPost]
        public ActionResult GetAllContent(string p)
        {
            if (p == " ")
            {
                var values1 = cm.GetList();
                return View(values1);
            }
            else
            {
                var values2 = cm.GetListByFindKey(p);
                return View(values2);
            }
        }
        public ActionResult ContentByHeading(int id)
        {
            var contentvalues = cm.GetListByHeadingID(id);
            return View(contentvalues);
        }
    }
}