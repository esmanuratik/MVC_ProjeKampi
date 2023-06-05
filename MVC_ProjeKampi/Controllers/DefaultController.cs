using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ProjeKampi.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        HeadingManager hm = new HeadingManager(new EF_HeadingDAL());
        ContentManager cm = new ContentManager(new EF_ContentDAL());

        public ActionResult Headings()//sol menüyü oluştaracak başlıklar layout u olacak
        {
            var headinglist = hm.GetList();
            return View(headinglist);
        }
        public PartialViewResult Index(int id=0)//amaç burada başlık id ye content getşrmek
        {
            var contentlist=cm.GetListByHeadingID(id);
            return PartialView(contentlist);
        }
    }
}