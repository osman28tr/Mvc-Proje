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
    public class YeteneklerimController : Controller
    {
        SkillsManager sm = new SkillsManager(new EfSkillsDal());
        public ActionResult Index()
        {
            var degerler = sm.Getlist();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult AddSkills()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSkills(Yetenek yetenek)
        {
            sm.SkillsAdd(yetenek);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditSkills(int id)
        {
            var valueSkills = sm.Getlist().Where(x => x.YetenekID == id).FirstOrDefault();
            return View(valueSkills);
        }
        [HttpPost]
        public ActionResult EditSkills(Yetenek yetenek)
        {
            sm.SkillsUpdate(yetenek);
            return RedirectToAction("Index");
        }
    }
}