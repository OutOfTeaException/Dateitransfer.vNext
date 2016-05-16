using Dateitransfer.vNext.MgmtWeb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dateitransfer.vNext.MgmtWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var jobService = new JobService();
            var jobs = jobService.GetJobs();

            return View(jobs);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}