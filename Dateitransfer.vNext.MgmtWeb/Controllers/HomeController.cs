using System.Web.Mvc;
using Dateitransfer.vNext.Api.Dto;
using Dateitransfer.vNext.MgmtWeb.Services;

namespace Dateitransfer.vNext.MgmtWeb.Controllers
{
    public class HomeController : Controller
    {
        private JobService jobService = new JobService();

        // TODO: IoC
        //public HomeController(JobService jobService)
        //{
        //    this.jobService = jobService;
        //}

        public ActionResult Index()
        {
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

        [HttpPost]
        public ActionResult EnableJob(int jobId, bool enable)
        {
            Job job = jobService.GetJob(jobId);

            job.IsEnabled = enable;

            jobService.Update(job);

            return PartialView("_JobInfo", job);
        }
    }
}