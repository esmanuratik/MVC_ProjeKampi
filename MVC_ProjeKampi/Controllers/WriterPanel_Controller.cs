using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ProjeKampi.Controllers
{
    public class WriterPanel_Controller : Controller
    {
        HeadingManager hm = new HeadingManager(new EF_HeadingDAL());
        CategoryManager cm = new CategoryManager(new EF_CategoryDAL());//ekleme işlemi gerçekleştirilen başlığa ait kategoriyi çekebilmek
        Context c = new Context();
        


        public ActionResult WriterProfile()
        {
            return View();
        }
        public ActionResult MyHeading(string p)
        {
            
            p = (string)Session["WriterMail"];
            var writeridinfo = c.Writerss.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var values=hm.GetListByWriter(writeridinfo);
           
            return View(values);
        }
        [HttpGet]
        public ActionResult NewHeading() 
        {

            //cm yi burada kullanmamın sebebi yazarın açtığı başlıpın bir kategorisinin olması
            List<SelectListItem> valuecategory = (from x in cm.GetList()//dropdownList i burada doldurdum bunu addheadiing view e eklyiorum.
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()

                                                  }).ToList();    //amaç=başlıklara ekleme işlemi gerçekleştirirken o başlığa ait kategorinin listesini                                 getirmek.

            ViewBag.vlc = valuecategory;
            return View();
        }
        [HttpPost]
        public ActionResult NewHeading(Heading p)
        {
            string writermailinfo = (string)Session["WriterMail"];
            var writeridinfo = c.Writerss.Where(x => x.WriterMail == writermailinfo).Select(y => y.WriterID).FirstOrDefault();
        
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());//bugünün kısa tarihini eklemiş oldum 
            p.WriterID = writeridinfo; //bu başlığı oluşturan yazarı session dan çekmiş olduk.
            p.HeadingStatus = true;
            hm.HeadingAdd(p); //ID ile yeni başlık eklenir bu şekilde.  
            return RedirectToAction("MyHeading");
            
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
            var HeadingValue = hm.GetByID(id);
            return View(HeadingValue);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {
            hm.HeadingUpdate(p);
            return RedirectToAction("MyHeading");
        }
        public ActionResult DeleteHeading(int id)
        {
            var HeadingValue = hm.GetByID(id);
            HeadingValue.HeadingStatus = false;//silme işleminin burada yapılması manager da yapılmasından daha sağlıklıdır.
            hm.HeadingDelete(HeadingValue);
            return RedirectToAction("MyHeading");
        }
        public ActionResult AllHeading()
        {
            var headings = hm.GetList();
            return View(headings);
        }
    }
}