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
    public class AdminCategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        // GET: AdminCategory
        
        public ActionResult Index()
        {
            var categories = categoryManager.GetCategories();
            return View(categories);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(Category category)
        {
            CategoryValidator rules = new CategoryValidator();
            ValidationResult result = rules.Validate(category);
            if (result.IsValid)
            {
                categoryManager.AddCategory(category);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                ModelState.AddModelError(error.PropertyName,error.ErrorMessage);
                }

            }
            return View();
        }

        public ActionResult KategoriSil(int id)
        {
            var category = categoryManager.GetById(id);
            categoryManager.DeleteCategory(category);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult KategoriGuncelle(int id)
        {
            var category = categoryManager.GetById(id);
            return View(category);
        }

        [HttpPost]
        public ActionResult KategoriGuncelle(Category category)
        {
            categoryManager.UpdateCategory(category);
            return RedirectToAction("Index");
        }
    }
}