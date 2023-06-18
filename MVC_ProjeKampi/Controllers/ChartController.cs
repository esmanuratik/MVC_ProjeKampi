using MVC_ProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ProjeKampi.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CategoryChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }
        List<CategoryClassD> BlogList()
        {
            List<CategoryClassD> ct= new List<CategoryClassD>();

            ct.Add(new CategoryClassD()
            {
                CategoryName = "Yazılım",
                CategoryCount = 8
            });
			ct.Add(new CategoryClassD()
			{
				CategoryName = "Seyehat",
				CategoryCount = 4
			});
			ct.Add(new CategoryClassD()
			{
				CategoryName = "Teknoloji",
				CategoryCount = 7
			});
			ct.Add(new CategoryClassD()
			{
				CategoryName = "Spor",
				CategoryCount = 1
			});


			return ct;
        }

    }
}