using BusinessLayer.Concrete;
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
    public class HeadingController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        // GET: Heading
        public ActionResult Index()
        {
            var headings = headingManager.GetHeadings();
            return View(headings);
        }
        [HttpGet]
        public ActionResult BaslikEkle()
        {
            List<SelectListItem> categoryvalue = (from category in categoryManager.GetCategories()
                                                  select new SelectListItem
                                                  {
                                                      Text = category.CategoryName,
                                                      Value = category.CategoryID.ToString()
                                                  }).ToList();
            List<SelectListItem> writervalue = (from writer in writerManager.GetWriters()
                                                select new SelectListItem
                                                {
                                                    Text = writer.FirstName + " " + writer.LastName,
                                                    Value = writer.WriterID.ToString()
                                                }).ToList();
            ViewBag.categoryvalue = categoryvalue;
            ViewBag.writervalue = writervalue;
            return View();
        }
        [HttpPost]
        public ActionResult BaslikEkle(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            headingManager.AddHeading(heading);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult BasligiDuzenle(int id)
        {
            List<SelectListItem> categoryvalue = (from category in categoryManager.GetCategories()
                                                  select new SelectListItem
                                                  {
                                                      Text = category.CategoryName,
                                                      Value = category.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.categoryvalue = categoryvalue;
            var headingvalue = headingManager.GetById(id);
            return View(headingvalue);

        }

        [HttpPost]
        public ActionResult BasligiDuzenle(Heading heading)
        {
            headingManager.UpdateHeading(heading);
            return RedirectToAction("Index");
        }
        public ActionResult BasligiSil(int id)
        {
            var headingvalue = headingManager.GetById(id);
            headingvalue.HeadingStatus = false;
            headingManager.DeleteHeading(headingvalue);
            return RedirectToAction("Index");
        }
    }
}