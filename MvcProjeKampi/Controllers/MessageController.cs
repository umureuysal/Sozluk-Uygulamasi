using BusinessLayer.Concrete;
using BusinessLayer.Validation_Rules;
using DataAccessLayer.Concrete.EntityFramework;
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
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator validationRules = new MessageValidator();
        // GET: Message
        [Authorize]
        public ActionResult Inbox(string w)
        {
            var messagelist = messageManager.GetMessagesInbox(w);
            return View(messagelist);
        }
        public ActionResult Sendbox(string sender)
        {
            var messagelist = messageManager.GetMessagesSendbox(sender);
            return View(messagelist);
        }
        public ActionResult InboxDetails(int id)
        {
            var values = messageManager.GetById(id);
            return View(values);
        }
        public ActionResult SendboxDetails(int id)
        {
            var values = messageManager.GetById(id);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            ValidationResult result = validationRules.Validate(message);
            if (result.IsValid)
            {
                message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                messageManager.AdddMessage(message);
                return RedirectToAction("Sendbox");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }
            return View();
        }
     
    }
}