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
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void AdddMessage(Message message)
        {
            _messageDal.Insert(message);
        }

       

        public void DeleteMessage(Message message)
        {
            throw new NotImplementedException();
        }

       

        public Message GetById(int id)
        {
            return _messageDal.Find(x => x.MessageID == id);
        }

        public List<Message> GetMessagesInbox(string receiver)
        {
            return _messageDal.List(x => x.ReceiverMail == receiver);
        }

        public List<Message> GetMessagesSendbox(string sender)
        {
            return _messageDal.List(x => x.SenderMail == sender);
        }

        public void SendMessage(Message message)
        {
            throw new NotImplementedException();
        }

        public void UpdateMessage(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
