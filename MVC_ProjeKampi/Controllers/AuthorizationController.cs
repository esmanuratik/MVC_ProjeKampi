using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ProjeKampi.Controllers
{
    public class AuthorizationController : Controller
    {
		//Burada admin işlemleri gerçekleşecek 
		AdminManager admin = new AdminManager(new EF_AdminDAL());
		public ActionResult Index()
        {
            var adminvalues=admin.GetList();
            return View(adminvalues);
        }
        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(Admin p)
        {
            admin.AdminAdd(p);
            return RedirectToAction("Index");
        }
		[HttpGet]
		public ActionResult EditAdmin(int id)//güncellenecek olan bilgiyi int id ile gönderdim sayfa yüklendiğinde burası çalışacak
		{
			var adminvalue = admin.GetByID(id);//id değişkeninden gelen parametre değerine göre ilgili satırın kaydı atandı
			return View(adminvalue);//değişkenin içeriğide gelsin diye onunla birlikte döndürüyorum.
		}
		[HttpPost]
		public ActionResult EditAdmin(Admin p)
		{
			admin.AdminUpdate(p);
			return RedirectToAction("Index");
		}
		public ActionResult DeleteAdmin(int id) //bunun view olmayacak ındex de çağırılacak.id ye göre silme işlemi
		{
			var adminvalue = admin.GetByID(id);
			admin.AdminDelete(adminvalue);
			return RedirectToAction("Index");
		}
	}
}