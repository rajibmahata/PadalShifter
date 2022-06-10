using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace PedalShifter.Controllers
{
    public class CommonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetCloseTime(string startTime)
        {
            var clockQuery = from offset in Enumerable.Range(0, 48)
                             select TimeSpan.FromMinutes(30 * offset);


            if (!string.IsNullOrWhiteSpace(startTime))
            {
                TimeSpan startTimeStamp = DateTime.Parse(startTime).TimeOfDay;

                IEnumerable<SelectListItem> StartOrEndTimeList = clockQuery.Where(x => x.TotalHours > startTimeStamp.TotalHours && x.TotalMinutes > startTimeStamp.TotalMinutes)
           .Select(s =>
               new SelectListItem
               {
                   Text = DateTime.Parse(s.ToString()).ToString("hh:mm tt", CultureInfo.GetCultureInfo("en-US")),
                   Value = DateTime.Parse(s.ToString()).ToString("hh:mm tt", CultureInfo.GetCultureInfo("en-US"))
               });
                return Json(StartOrEndTimeList);
            }
            return null;
        }
        [HttpGet]
        public JsonResult GetOpenTime(string closeTime)
        {
            var clockQuery = from offset in Enumerable.Range(0, 48)
                             select TimeSpan.FromMinutes(30 * offset);


            if (!string.IsNullOrWhiteSpace(closeTime))
            {
                TimeSpan EndTimeStamp = DateTime.Parse(closeTime).TimeOfDay;

                IEnumerable<SelectListItem> StartOrEndTimeList = clockQuery.Where(x => x.TotalHours < EndTimeStamp.TotalHours && x.TotalMinutes < EndTimeStamp.TotalMinutes)
           .Select(s =>
               new SelectListItem
               {
                   Text = DateTime.Parse(s.ToString()).ToString("hh:mm tt", CultureInfo.GetCultureInfo("en-US")),
                   Value = DateTime.Parse(s.ToString()).ToString("hh:mm tt", CultureInfo.GetCultureInfo("en-US"))
               });
                return Json(StartOrEndTimeList);
            }
            return null;
        }
    }
}
