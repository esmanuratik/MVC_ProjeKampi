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
    public class AdminCatgeoryController : Controller
    {

        CategoryManager cm= new CategoryManager(new EF_CategoryDAL());

        [Authorize(Roles="B")]//Role B olanlar kategorilere girsin başka kimse giremsins
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
            Category_Validatior categoryvalidator = new Category_Validatior();//geçerlilik sorgulama işlemi yapıyoruz burada.
            ValidationResult results=categoryvalidator.Validate(p);

            if (results.IsValid)
            {
                cm.CategoryAdd(p);
                RedirectToAction("Index");
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
        public ActionResult DeleteCategory(int id) //bunun view olmayacak ındex de çağırılacak.id ye göre silme işlemi
        {
            var categoryvalue = cm.GetByID(id);
            cm.CategoryDelete(categoryvalue);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditCategory(int id)//güncellenecek olan bilgiyi int id ile gönderdim sayfa yüklendiğinde burası çalışacak
        {
            var categoryvalue=cm.GetByID(id);//id değişkeninden gelen parametre değerine göre ilgili satırın kaydı atandı
            return View(categoryvalue);//değişkenin içeriğide gelsin diye onunla birlikte döndürüyorum.
        }
        [HttpPost]
        public ActionResult EditCategory(Category p)
        {
            cm.CategoryUpdate(p);
            return RedirectToAction("Index");
        }


    }
}