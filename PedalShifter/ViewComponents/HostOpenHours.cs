using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PedalShifter.Data;
using PedalShifter.Data.Entities;
using PedalShifter.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedalShifter.ViewComponents
{
    public class HostOpenHours : ViewComponent
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IUserService userService;
        private readonly IBikeService bikeService;
        private readonly IHostService hostService;
        private readonly IHostOpenHourService hostOpenHourService;
        public HostOpenHours(ApplicationDbContext context, IWebHostEnvironment hostEnvironment, IUserService userService, IBikeService bikeService, IHostService hostService, IHostOpenHourService hostOpenHourService)
        {
            dbContext = context;
            webHostEnvironment = hostEnvironment;
            this.userService = userService;
            this.bikeService = bikeService;
            this.hostService = hostService;
            this.hostOpenHourService = hostOpenHourService;
        }
        public async Task<IViewComponentResult> InvokeAsync(int hostid)
        {
            IdentityUser user = userService.GetUserByEmail(User.Identity.Name);
            IEnumerable<HostOpenHour> hostOpenHours = await hostOpenHourService.GetByHostId(hostid);

           // return PartialView("_HostOpenHours.cshtml", hostOpenHours);
            return View("HostOpenHours.cshtml",hostOpenHours);
        }
    }
}
