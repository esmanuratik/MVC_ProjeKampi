using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace MVC_ProjeKampi.Controllers
{
    public class HeadingController : Controller
    {
        // GET: Heading
        HeadingManager hm=new HeadingManager(new EF_HeadingDAL());//listeleme işlemi yapabilmek için 
        CategoryManager cm=new CategoryManager(new EF_CategoryDAL());//ekleme işlemi gerçekleştirilen başlığa ait kategoriyi çekebilmek için.
        WriterManager wm=new WriterManager(new EF_WriterDAL());//admin writer eklemek için örneklendi
        public ActionResult Index()
        {
           var headingvalues= hm.GetList();
            return View(headingvalues);
        }
        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()//dropdownList i burada doldurdum bunu addheadiing view e eklyiorum.
                                                  select new SelectListItem
                                                  {
                                                      Text=x.CategoryName, 
                                                      Value=x.CategoryID.ToString()

                                                  }).ToList();    //amaç=başlıklara ekleme işlemi gerçekleştirirken o başlığa ait kategorinin listesini                                 getirmek.
            List<SelectListItem> valuewriter = (from x in wm.GetList() 
                                                select new SelectListItem
                                                {
                                                    Text = x.WriterName+""+x.WriterSurname,
                                                    Value = x.WriterID.ToString()
                                                }).ToList();
            
            ViewBag.vlc=valuecategory;
            ViewBag.vlw = valuewriter;
            return View();
        }
        [HttpPost]
        public ActionResult AddHeading(Heading p)
        {
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());//bugünün kısa tarihini eklemiş oldum 
            hm.HeadingAdd(p); //ID ile yeni başlık eklenir bu şekilde.  
            return RedirectToAction("Index");
        }
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()//dropdownList i burada doldurdum bunu addheadiing view e eklyiorum.
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()

                                                  }).ToList();    //amaç=başlıklara ekleme işlemi gerçekleştirirken o başlığa ait kategorinin listesini                                 getirmek.

            ViewBag.vlc = valuecategory;//her başlığımın bir kategorisi olacağı için taşıma işlemi gerçekleştirdim.
            var HeadingValue=hm.GetByID(id);
            return View(HeadingValue);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {
            hm.HeadingUpdate(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteHeading(int id)
        {
            var HeadingValue= hm.GetByID(id);
            HeadingValue.HeadingStatus = false;//silme işleminin burada yapılması manager da yapılmasından daha sağlıklıdır.
            hm.HeadingDelete(HeadingValue);
            return RedirectToAction("Index");
        }

    }
}