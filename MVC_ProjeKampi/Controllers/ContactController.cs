using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ProjeKampi.Controllers
{
    public class ContactController : Controller
    {
       ContactManager com=new ContactManager(new EF_ContactDAL());
        ContactValidator cv=new ContactValidator();
        public ActionResult Index()
        {
            var contactvalues=com.GetList();
            return View(contactvalues);
        }
        public ActionResult GetContactDetails(int id)//id ye göre işlem yapılacağı için dışarıdan id göndr. ve GetByID kull. 
        {
            var contactvalues=com.GetByID(id);
            return View(contactvalues);
        }
        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }
    }
}