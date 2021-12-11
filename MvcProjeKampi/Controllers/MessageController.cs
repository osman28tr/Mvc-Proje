using ClassLibrary1.Concrete;
using ClassLibrary1.ValidationRules;
using DataAccessLayer;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        RecordsManager rm = new RecordsManager(new EfRecordsDal());
        AdminManager adm = new AdminManager(new EfAdminDal());
        Context c = new Context();
        MessageValidator messagevalidator = new MessageValidator();
        public ActionResult Inbox()
        {
            int recordbyadminid = rm.RecordByID();
            var a = adm.GetByID(recordbyadminid);
            var messagelist = mm.GetListInbox(a.AdminUserName);
            return View(messagelist);
        }
        public ActionResult SendInbox()
        {
            int recordbyadminid = rm.RecordByID();
            var a = adm.GetByID(recordbyadminid);
            var messagelist = mm.GetListSendInbox(a.AdminUserName);
            return View(messagelist);
        }
        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            return View(values);
        }
        public ActionResult GetSendboxMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            ValidationResult results = messagevalidator.Validate(p);
            if (results.IsValid)
            {
                int recordbyadminid = rm.RecordByID();
                var a = adm.GetByID(recordbyadminid);
                p.SenderMail = a.AdminUserName;
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                mm.MessageAdd(p);
                return RedirectToAction("SendInbox");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}