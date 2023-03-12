using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SeasonAPP.Models;
using System.Web.Http.Cors;

namespace SeasonAPP.Controllers
{
    public class SeasonAPIController : ApiController
    {

        /// <summary>
        /// Receive an input of the temperature and provides a message indicating the season
        /// </summary>
        /// <param name="temperature">The temperature in degree C</param>
        /// <example>Get api/example/seasion/21  -> {"Summer", "Tobermory", "#"}</example>
        /// <example>Get api/example/seasion/17  -> {"Fall", "Algonquin", "#"}</example>
        /// <example>Get api/example/seasion/-15  -> {"Winter", "Toronto", "#"}</example>
        /// <returns>If temperatur is greater than 20, return "Summer!". If the temperature is greater than 15, return "Fall!".
        /// Else if the temperature is greater than 10, return "Spring!". Else return "Winter!"
        /// The associated season with the temperature,
        /// The taken place of the photo,
        /// Link
        /// </returns>

        [Route("api/SeasonAPI/GetSeason/{temperature}")]
        [EnableCors(origins:"*", methods:"*", headers:"*")]
        public Season GetSeason(int? temperature)
        {
            string season = "";
            string place = "";
            string url = "";
            if (temperature == null)
            {
                season= "Unknown";
                place= "Unknown";
                url = "Unknown";
            }
   
            if (temperature > 20)
            {
                season = "Summer";
                place = "Tobermory";
                url = "#";
            }
            else if (temperature > 15)
            {
                season = "Fall";
                place = "Algonquin";
                url = "#";
            }
            else if (temperature > 10)
            {
                season = "Spring";
                place = "Jinan";
                url = "#";
            }
            else
            {
                season = "Winter";
                place = "Toronto";
                url= "#";
            }
            Season SeasonInfo = new Season();
            SeasonInfo.SeasonName = season;
            SeasonInfo.place = place;
            SeasonInfo.url = url;
            SeasonInfo.temp = temperature.ToString();
            //IEnumerable<string> SeasonInfo = new string[] {season, place, url };
            return SeasonInfo;
        }


    }
}
