using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using FluentValidation.Results;

namespace MVC_ProjeKampi.Controllers
{
    public class WriterPanel_Controller : Controller
    {
        HeadingManager hm = new HeadingManager(new EF_HeadingDAL());
        CategoryManager cm = new CategoryManager(new EF_CategoryDAL());//ekleme işlemi gerçekleştirilen başlığa ait kategoriyi çekebilmek
        WriterManager wm = new WriterManager(new EF_WriterDAL());
        Context c = new Context();

        Writer_Validatior writervalidator = new Writer_Validatior();

        [HttpGet]
        public ActionResult WriterProfile(int id = 0)
        {
            string p = (string)Session["WriterMail"];
            id = c.Writerss.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var writervalue = wm.GetByID(id);
            return View(writervalue);
        }
        [HttpPost]
        public ActionResult WriterProfile(Writer p)
        {
            ValidationResult results = writervalidator.Validate(p);

            if (results.IsValid)//Eğer Validate geçerliyse update et.ValidationMessageların view de çalışması için bunu eklemeliyim.
            {
                wm.WriterUpdate(p);
                return RedirectToAction("AllHeading","WriterPanel_");
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


        public ActionResult MyHeading(string p)
        {

            p = (string)Session["WriterMail"];
            var writeridinfo = c.Writerss.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var values = hm.GetListByWriter(writeridinfo);

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
        public ActionResult AllHeading(int p = 1)
        {
            var headings = hm.GetList().ToPagedList(p, 4);
            return View(headings);
        }
    }
}