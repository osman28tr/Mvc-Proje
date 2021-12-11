using ClassLibrary1.Abstract;
using DataAccessLayer;
using DataAccessLayer.Abstract;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Concrete
{
    public class ContactManager : IContactService
    {
        IContactDal _contactdal;
        Context c = new Context();

        public ContactManager(IContactDal contactdal)
        {
            _contactdal = contactdal;
        }
        public void ContactAdd(Contact contact)
        {
            _contactdal.insert(contact);
        }

        public int ContactCount()
        {
            return c.Contacts.Count();
        }

        public void ContactDelete(Contact contact)
        {
            _contactdal.Delete(contact);
        }

        public void ContactUpdate(Contact contact)
        {
            _contactdal.Update(contact);
        }

        public Contact GetByID(int id)
        {
            return _contactdal.Get(x => x.ContactID == id);
        }

        public List<Contact> GetList()
        {
            return _contactdal.list();
        }
    }
}
