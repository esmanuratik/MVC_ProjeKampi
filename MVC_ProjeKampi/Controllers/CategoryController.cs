using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ProjeKampi.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager cm = new CategoryManager(new EF_CategoryDAL()); 
        public ActionResult Index()
        {
            //fjvkhsdjkfhdsjkfhsd
            return View();
        }
        public ActionResult GetCategoryList()
        {
            //yoruma alma sebebim category manager da ekleme işlemlerini sildim bunları ctor ile yapacağım.
            //var categoryvalues = cm.GetAll_BL();// GetAll_BL(); category manager daki okuma (listeleme) yapt. metot adı
            //return View(categoryvalues);
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
            //cm.CategoryAdd_BL(p);
            Category_Validatior categoryValidator= new Category_Validatior();   
            ValidationResult results=categoryValidator.Validate(p);

            if (results.IsValid)
            {
                cm.CategoryAdd(p);
                return RedirectToAction("GetCategoryList");               
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

    }
}