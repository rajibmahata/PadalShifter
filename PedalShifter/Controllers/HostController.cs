using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PedalShifter.Data;
using PedalShifter.Data.Entities;
using PedalShifter.Data.ViewModels;
using PedalShifter.Domain.Interfaces;
using PedalShifter.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace PedalShifter.Controllers
{
    [Authorize(Policy = "Host")]
    public class HostController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IUserService userService;
        private readonly IBikeService bikeService;
        private readonly IHostService hostService;
        private readonly IHostOpenHourService hostOpenHourService;
        public HostController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment, IUserService userService, IBikeService bikeService, IHostService hostService, IHostOpenHourService hostOpenHourService)
        {
            dbContext = context;
            webHostEnvironment = hostEnvironment;
            this.userService = userService;
            this.bikeService = bikeService;
            this.hostService = hostService;
            this.hostOpenHourService = hostOpenHourService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            return View();
        }


        public async Task<IActionResult> Listings()
        {
            IdentityUser user = userService.GetUserByEmail(User.Identity.Name);
            List<BikeViewModel> listings =await bikeService.GetAllByUserId(user.Id);
            return View(listings);
        }

        [Route("/Host/New-Listing")]
        public IActionResult NewListing()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/Host/New-Listing")]
        public async Task<IActionResult> NewListing(BikeViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);
                IdentityUser user = userService.GetUserByEmail(User.Identity.Name);

                Bike bike = new Bike
                {
                    Name = model.Name,
                    Category = Int32.Parse(model.Category),
                    Description = model.Description,
                    DailyRate = model.DailyRate,
                    MainImage = uniqueFileName,
                    SerialNumber = model.SerialNumber,
                    UserId = user.Id
                };

                dbContext.Add(bike);
                await dbContext.SaveChangesAsync();
                return RedirectToAction("Dashboard");
            }
            return View(model);
        }

        private string UploadedFile(BikeViewModel model)
        {
            string uniqueFileName = null;

            if (model.MainImage != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images/userimages");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.MainImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.MainImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        [Authorize]
        public async Task<IActionResult> Profile()
        {
            IdentityUser user = userService.GetUserByEmail(User.Identity.Name);
            Host host = await hostService.GetUserById(user.Id);

            return View(host);
        }


        [HttpPost]
        public IActionResult Profile(Host model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = userService.GetUserByEmail(User.Identity.Name);
                model.IdentityId = user.Id;
                hostService.UpdateProfile(model);
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateLocation(Host model)
        {
            IdentityUser user = userService.GetUserByEmail(User.Identity.Name);
            Host host = await hostService.GetUserById(user.Id);
            if (host != null)
            {
                host.PreferredLocationLattitude = model.PreferredLocationLattitude;
                host.PreferredLocationLongitude = model.PreferredLocationLongitude;
                hostService.UpdateProfile(host);
                return Json(new { status = "success", reponseText = "Location updated successfuly." });
            }
            else
            {
                return Json(new { status = "failure", reponseText = "User does not exist." });
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateHostOpenHours(HostOpenHourViewModel model)
        {
            try
            {
                IdentityUser user = userService.GetUserByEmail(User.Identity.Name);
                HostOpenHour hostOpenHour = await hostOpenHourService.GetById(model.Id);
                if (hostOpenHour != null)
                {
                    //hostOpenHour.StartTime = model.StartTime;
                    //hostOpenHour.EndTime = model.EndTime;
                    hostOpenHour.StartTime = DateTime.Parse(model.StartTime).TimeOfDay;
                    hostOpenHour.EndTime = DateTime.Parse(model.EndTime).TimeOfDay;
                    hostOpenHour.IsActive = true;
                    await hostOpenHourService.UpdateHostOpenHourAsync(hostOpenHour);
                }
                else
                {
                    HostOpenHour hostOpenHourEntity = new HostOpenHour();
                    hostOpenHourEntity.Day = model.Day;
                    hostOpenHourEntity.DateJoined = DateTime.Now;
                    //hostOpenHourEntity.EndTime = model.EndTime;
                    //hostOpenHourEntity.StartTime = model.StartTime;
                    hostOpenHourEntity.StartTime = DateTime.Parse(model.StartTime).TimeOfDay;
                    hostOpenHourEntity.EndTime = DateTime.Parse(model.EndTime).TimeOfDay;
                    hostOpenHourEntity.HostId = model.HostId;
                    hostOpenHourEntity.IsActive = true;
                    await hostOpenHourService.CreateAsync(hostOpenHourEntity);
                }
                return Json(new { status = "success", reponseText = "Location updated successfuly." });
            }
            catch (Exception ex)
            {

                return Json(new { status = "failure", reponseText = "User does not exist." });
            }
        }
       
    }
}
