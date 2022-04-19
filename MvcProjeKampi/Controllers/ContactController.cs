using BusinessLayer.Concrete;
using BusinessLayer.Validation_Rules;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());
        ContactValidator validationRules = new ContactValidator();
        Context context = new Context();
        // GET: Contact
        public ActionResult Index()
        {
            var contactvalue = contactManager.ListMessages();
            return View(contactvalue);
        }
        public ActionResult MessageDetails(int id)
        {
            var contactvalues = contactManager.GetByMessageId(id);
            return View(contactvalues);
        }
        public PartialViewResult Content()
        {
           string a = context.Messages.Count().ToString();
            return PartialView();
        }
    }
}