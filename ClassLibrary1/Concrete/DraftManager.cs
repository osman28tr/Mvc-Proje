using ClassLibrary1.Abstract;
using DataAccessLayer;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Concrete
{
    public class DraftManager : IDraftService
    {
        IDraftDal _draftDal;
        Draft draft1;
        Context c = new Context();
        public DraftManager(IDraftDal draftDal)
        {
            _draftDal = draftDal;
        }
        public void DraftAdd(int id)
        {
            var draftvalues = c.Messages.Where(x => x.MessageID == id).ToList();
            draft1.DraftSenderMail = draftvalues.Select(x => x.SenderMail).ToString();
            draft1.DraftReceiverMail = draftvalues.Select(x => x.ReceiverMail).ToString();
            draft1.Subject = draftvalues.Select(x => x.Subject).ToString();
            draft1.DraftContent = draftvalues.Select(x => x.MessageContent).ToString();
            draft1.DraftDate = Convert.ToDateTime(draftvalues.Select(x => x.MessageDate));
            c.Drafts.Add(draft1);
        }
        public void DraftDelete(Draft draft)
        {
            _draftDal.Delete(draft);
        }

        public void DraftUpdate(Draft draft)
        {
            _draftDal.Update(draft);
        }

        public Draft GetByID(int id)
        {
            return _draftDal.Get(x => x.DraftID == id);
        }

        public List<Draft> GetList()
        {
            return _draftDal.list();
        }
    }
}
