using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SeasonAPP.Models;

namespace SeasonAPP.Controllers
{
    public class SeasonController : Controller
    {
        // POST: /Season/Index
        public ActionResult Index()
        {
            return View();
        }

        // POST: /Season/Show
        // Acquire information about the season and send it to show.cshtml
        [HttpPost]
        public ActionResult Show(int? temperature)
        {
            if(temperature == null)
            {
                ViewBag.Temp = "Unknown";
            }
            else
            {
                ViewBag.Temp = temperature;
            }

                SeasonAPIController controller = new SeasonAPIController();
                Season SeasonInfo = controller.GetSeason(temperature);
                
                

                //string[] SeasonInfo = controller.GetSeason(temperature).ToArray();

                //ViewBag.Season = SeasonInfo[0];
                //ViewBag.place = SeasonInfo[1];
                //ViewBag.url = SeasonInfo[2];

            return View(SeasonInfo);
        }
    }
}