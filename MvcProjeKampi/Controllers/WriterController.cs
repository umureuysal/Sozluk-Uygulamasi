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
    public class WriterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        WriterValidator validationRules = new WriterValidator();
        // GET: Writer
        public ActionResult Index()
        {
            var writers = writerManager.GetWriters();
            return View(writers);
        }
        [HttpGet]
        public ActionResult YazarEkle()
        {
            return View();  
        }
        [HttpPost]
        public ActionResult YazarEkle(Writer writer)
        {
            
            ValidationResult result=validationRules.Validate(writer);
            if (result.IsValid)
            {
                writerManager.AddWriter(writer);
                return RedirectToAction("Index");
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
        [HttpGet]
        public ActionResult ProfiliDuzenle(int id)
        {
            var writerID = writerManager.GetByID(id);
            return View(writerID);
        }
        [HttpPost]
        public ActionResult ProfiliDuzenle(Writer writer)
        {
            ValidationResult result = validationRules.Validate(writer);
            if (result.IsValid)
            {
                writerManager.UpdateWriter(writer);
                return RedirectToAction("Index");
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