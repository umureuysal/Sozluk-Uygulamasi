using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class DefaultController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        ContentManager contentManager = new ContentManager(new EfContentDal());
        // GET: Default
        public ActionResult Headings()
        {
            var headings = headingManager.GetHeadings();
            return View(headings);
        }
        public PartialViewResult Index(int id=0)
        {
            var content = contentManager.ContentsByHeadingID(id); 
            return PartialView(content);
        }
    }
}