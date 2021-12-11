using ClassLibrary1.Concrete;
using ClassLibrary1.ValidationRules;
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
    public class WriterPanelMessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator messagevalidator = new MessageValidator();
        RecordsManager rm = new RecordsManager(new EfRecordsDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        public ActionResult Inbox()
        {
            int recordbywriterid = rm.RecordByID();
            var writerınboxmail = wm.GetList().Where(x => x.WriterID == recordbywriterid);
            var a = writerınboxmail.FirstOrDefault().WriterMail;
            var messagelist = mm.GetListInbox(a);
            return View(messagelist);
        }
        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }
        public ActionResult SendInbox()
        {
            int recordbywriterid = rm.RecordByID();
            var writerınboxmail = wm.GetList().Where(x => x.WriterID == recordbywriterid);
            var a = writerınboxmail.FirstOrDefault().WriterMail;
            var messagelist = mm.GetListSendInbox(a);
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

                int recordbywriterid = rm.RecordByID();
                var writerınboxmail = wm.GetList().Where(x => x.WriterID == recordbywriterid);
                var a = writerınboxmail.FirstOrDefault().WriterMail;
                p.SenderMail = a;
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