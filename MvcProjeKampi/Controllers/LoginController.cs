using ClassLibrary1.Concrete;
using DataAccessLayer;
using DataAccessLayer.EntityFramework;
using EntityLayer;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class LoginController : Controller
    {
        AdminManager adm = new AdminManager(new EfAdminDal());
        Context c = new Context();
        WriterManager wm = new WriterManager(new EfWriterDal());
        ContentManager cm = new ContentManager(new EfContentDal());
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        RecordsManager rm = new RecordsManager(new EfRecordsDal());
        WriterLoginManager wlm = new WriterLoginManager(new EfWriterDal());
        Records records = new Records();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            string mesaj = adm.AdminUserAndPasswordVal(p);
            if (mesaj == "basarılı")
            {
                return RedirectToAction("Index","AdminCategory");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(Writer p)
        {
            string mesaj = wm.WriterMailAndPasswordVal(p);
            //int a = 0;
            //int b = 0;
            if (mesaj == "basarılı")
            {
                var values = wm.GetList().Where(x => x.WriterMail == p.WriterMail).FirstOrDefault();
                var id = values.WriterID;
                //var contentupdatelist = cm.GetList().Where(x => x.Writer.WriterID == id).ToList();
                //var headingupdatelist = hm.GetList().Where(x => x.WriterID == id).ToList();
                //foreach (var item in contentupdatelist)
                //{
                //    item.WriterContentState = true;
                //    cm.ContentUpdate(contentupdatelist[a]);
                //    a++;
                //}
                //foreach (var item in headingupdatelist)
                //{
                //    item.WriterHeadingState = true;
                //    hm.HeadingUpdate(headingupdatelist[b]);
                //    b++;
                //}
                records.ContentByWriterID = id;
                records.HeadingByWriterID = id;
                rm.RecordAdd(records);

                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                return RedirectToAction("WriterLogin");
            }
        }
        public ActionResult LogOut()
        {
            return RedirectToAction("Index");
        }
    }
}