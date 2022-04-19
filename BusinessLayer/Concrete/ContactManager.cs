using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void AddMessage(Contact contact)
        {
            _contactDal.Insert(contact);
        }

        public void DeleteMessage(Contact contact)
        {
            _contactDal.Delete(contact);
        }

        public Contact GetByMessageId(int id)
        {
            return _contactDal.Find(x=>x.ContactId == id);
        }

        public List<Contact> ListMessages()
        {
            return _contactDal.List();
        }


        public void UpdateMessage(Contact contact)
        {
           _contactDal.Update(contact);
        }
    }
}
