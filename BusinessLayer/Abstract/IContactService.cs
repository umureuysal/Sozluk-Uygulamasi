using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContactService
    {
        List<Contact> ListMessages();
        void AddMessage(Contact contact);
        Contact GetByMessageId(int id);
        void DeleteMessage(Contact contact);
        void UpdateMessage(Contact contact);
    }
}
