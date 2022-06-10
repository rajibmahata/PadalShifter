using Microsoft.AspNetCore.Mvc;
using PedalShifter.Data.ViewModels;
using PedalShifter.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedalShifter.Controllers
{
    public class ListingsController : Controller
    {
        private readonly IBikeService bikeService;
        private readonly IHostService hostService;
        public ListingsController(IBikeService bikeService, IHostService hostService)
        {
            this.bikeService = bikeService;
            this.hostService = hostService;
        }
        public async Task<IActionResult> Index()
        {
            List<BikeViewModel> listings = await bikeService.GetAll();
            return View(listings);
        }

        [HttpGet]
        [Route("Listings/{id}")]
        public async Task<IActionResult> Index(int id)
        {
            BikeViewModel listing =await bikeService.GetById(id);
            if (listing != null)
                return View("SingleListing", listing);
            else
                return NotFound();
        }
    }
}
