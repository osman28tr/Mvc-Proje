﻿using ClassLibrary1.Concrete;
using ClassLibrary1.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer;
using DataAccessLayer;
using FluentValidation.Results;
using DataAccessLayer.Concrete.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AdminCategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        Context c = new Context();
        Statistics st = new Statistics();
        
        public ActionResult Index()
        {
            var categoryvalues = cm.GetList();
            return View(categoryvalues);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(p);
            if (results.IsValid)
            {
                cm.CategoryAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult DeleteCategory(int id)
        {
            var categoryvalue = cm.GetByID(id);
            cm.CategoryDelete(categoryvalue);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var categoryvalue = cm.GetByID(id);
            return View(categoryvalue);
        }
        [HttpPost]
        public ActionResult EditCategory(Category category)
        {
            cm.CategoryUpdate(category);
            return RedirectToAction("Index");
        }
        public ActionResult Statistics()
        {
            ViewBag.kategorisayisi = st.Toplamkategorisayisi();
            ViewData["EnCokBaslik"] = st.Enfazlabasligasahipkategoriadı(ViewBag.kategorisayisi);
            ViewData["kategoridurumtruefalseolanlar"] = st.KategoriTrueFalseArasiFark();
            ViewData["yazaradindaAharfiGecenler"] = st.YazaradindaAharfigecenyazarsayisi();
            ViewData["yazilimbasliksayisi"] = st.Basliktablosundayazilimkategorisineaitbasliksayisi();
            return View();
        }
    }
}