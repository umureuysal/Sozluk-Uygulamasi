using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EfAboutDal());
        // GET: About
        public ActionResult Index()
        {
            var about = aboutManager.GetAbouts();
            return View(about);
        }
        [HttpGet]
        public ActionResult HakkımdaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult HakkımdaEkle(About about)
        {
            aboutManager.AddAbout(about);
            return RedirectToAction("Index");
        }
        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }
    }
}