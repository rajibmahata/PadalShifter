using Microsoft.AspNetCore.Http;
using PedalShifter.Data.Entities;
using PedalShifter.Data.Interfaces;
using PedalShifter.Data.ViewModels;
using PedalShifter.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedalShifter.Domain.Models
{
    public class BikeService : IBikeService
    {
        private readonly IBikeRepository bikeRepository;
        private readonly IHostRepository hostRepository;
        private readonly IHostOpenHourRepository hostOpenHourRepository;
        public BikeService(IBikeRepository bikeRepository, IHostRepository hostRepository, IHostOpenHourRepository hostOpenHourRepository)
        {
            this.bikeRepository = bikeRepository;
            this.hostRepository = hostRepository;
            this.hostOpenHourRepository = hostOpenHourRepository;
        }

        public async Task<List<BikeViewModel>> GetAll()
        {
            List<Bike> bikes = bikeRepository.GetAllBikes();
            List<BikeViewModel> listings = new List<BikeViewModel>();

            foreach (var bike in bikes)
            {
                var listing = await BikeEntityToViewModel(bike);

                listings.Add(listing);
            }

            return listings;
        }

        public async Task<List<BikeViewModel>> GetAllByUserId(string userId)
        {
            List<Bike> bikes = bikeRepository.GetAllByUserId(userId);
            List<BikeViewModel> listings = new List<BikeViewModel>();

            foreach(var bike in bikes)
            {
                var listing = await BikeEntityToViewModel(bike);
                listings.Add(listing);
            }

            return listings;
        }

        public async Task<BikeViewModel> GetById(int id)
        {
            Bike bike = bikeRepository.GetById(id);
            if(bike != null)
            {
                return await BikeEntityToViewModel(bike);
            }
            return null;
        }

        private async Task<BikeViewModel> BikeEntityToViewModel(Bike bike)
        {
            Host host = hostRepository.GetUserById(bike.UserId);
            IEnumerable<HostOpenHour> hostOpenHours = await hostOpenHourRepository.GetByHostId(host.Id);
            var model = new BikeViewModel
            {
                Id = bike.id,
                Name = bike.Name,
                DailyRate = bike.DailyRate,
                Description = bike.Description,
                FileName = bike.MainImage,
                Status = "Approved",
                Host = host,
                HostOpenHours=hostOpenHours

            };

            model.Category = bike.Category switch
            {
                1 => "Mountain Bike",
                _ => "",
            };

            return model;
        }
    }
}
