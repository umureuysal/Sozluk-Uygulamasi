using BusinessLayer.Concrete;
using BusinessLayer.Validation_Rules;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using FluentValidation.Results;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager= new CategoryManager(new EfCategoryDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        Context context = new Context();
        // GET: WriterPanel
        [HttpGet]
        public ActionResult WriterProfile(int id=0)
        {
            string parameter = (string)Session["WriterMail"];
            id = context.Writers.Where(x => x.Mail == parameter).Select(y => y.WriterID).FirstOrDefault();
            var writer = writerManager.GetByID(id);
            return View(writer);
        }

        [HttpPost]
        public ActionResult WriterProfile(Writer writer)
        {
            WriterValidator writerValidator = new WriterValidator();
            ValidationResult result = writerValidator.Validate(writer);
            if (result.IsValid)
            {
                writerManager.UpdateWriter(writer);
                return RedirectToAction("AllHeadings");
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

        [AllowAnonymous]
        public ActionResult MyHeading(string parameter)
        {
            parameter = (string)Session["WriterMail"];
            var writeridinfo = context.Writers.Where(x=>x.Mail==parameter).Select(y=>y.WriterID).FirstOrDefault();
            var value = headingManager.GetHeadingsbyWriter(writeridinfo);
            return View(value);
        }
        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> categoryvalue = (from category in categoryManager.GetCategories()
                                                select new SelectListItem
                                                {
                                                    Text = category.CategoryName,
                                                    Value = category.CategoryID.ToString()
                                                }).ToList();
            ViewBag.vlc = categoryvalue;
            return View();
        } 
        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {
            string mailinfo = (string)Session["WriterMail"];
            var writeridinfo = context.Writers.Where(x => x.Mail == mailinfo).Select(y => y.WriterID).FirstOrDefault();
            ViewBag.d = writeridinfo;
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterID = writeridinfo;
            heading.HeadingStatus = true;
            headingManager.AddHeading(heading);
            return RedirectToAction("MyHeading");
        }

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
            return RedirectToAction("MyHeading");
        }
        public ActionResult BasligiSil(int id)
        {
            var headingvalue = headingManager.GetById(id);
            headingvalue.HeadingStatus = false;
            headingManager.DeleteHeading(headingvalue);
            return RedirectToAction("MyHeading");
        }
        public ActionResult AllHeadings(int page = 1)
        {
            var allheadings = headingManager.GetHeadings().ToPagedList(page,4);
            return View(allheadings);
        }
    }
}