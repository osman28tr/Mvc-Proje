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
    public class MessageManager:IMessageService
    {
        IMessageDal _messageDal;
        Context c = new Context();
        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }
        public void MessageAdd(Message message)
        {
            _messageDal.insert(message);
        }

        public void MessageDelete(Message message)
        {
            _messageDal.Delete(message);
        }

        public void MessageUpdate(Message message)
        {
            _messageDal.Update(message);
        }

        public Message GetByID(int id)
        {
            return _messageDal.Get(x => x.MessageID == id);
        }

        public List<Message> GetListInbox(string p)
        {
            return _messageDal.list(x => x.ReceiverMail == p);
        }

        public List<Message> GetListSendInbox(string p)
        {
            return _messageDal.list(x => x.SenderMail == p);
        }

        public int SendMessageCount()
        {
            return c.Messages.Where(x => x.SenderMail == "admin@gmail.com").Count();
        }

        public int ReceiverMessageCount()
        {
            return c.Messages.Where(x => x.ReceiverMail == "admin@gmail.com").Count();
        }

        //public void DraftstateUpdate(bool durum)
        //{

        //}
    }
}
