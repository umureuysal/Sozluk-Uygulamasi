using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContentController : Controller
    {
        ContentManager contentManager = new ContentManager(new EfContentDal());
        // GET: Content
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult GetContent(string p)
        {
            if (string.IsNullOrEmpty(p))
            {
                var values = contentManager.GetContents();
                return View(values.ToList());
            }
            var filteredvalues = contentManager.GetContents(p);
            return View(filteredvalues);
        }

        public ActionResult ContentbyHeading(int id)
        {
            var content=contentManager.ContentsByHeadingID(id);
            return View(content);
        }
    }
}