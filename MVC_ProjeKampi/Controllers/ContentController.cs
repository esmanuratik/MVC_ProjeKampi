using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ProjeKampi.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        ContentManager cm = new ContentManager(new EF_ContentDAL());
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ContentByHeading(int id)
        {
            var contentvalues=cm.GetListByHeadingID(id);
            return View(contentvalues);
        }
    }
}