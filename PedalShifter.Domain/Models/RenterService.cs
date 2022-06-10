using PedalShifter.Data.Entities;
using PedalShifter.Data.Interfaces;
using PedalShifter.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace PedalShifter.Domain.Models
{
    public class RenterService : IRenterService
    {
        private readonly IRenterRepository RenterRepository;
        private readonly IUserRepository UserRepository;
        public RenterService(IRenterRepository renterRepository, IUserRepository userRepository)
        {
            this.RenterRepository = renterRepository;
            this.UserRepository = userRepository;
        }

        public async Task<bool> CreateAsync(Renter renter)
        {
            try
            {
                await RenterRepository.CreateAsync(renter);
                return true;
            }
            catch (Exception e)
            {

            }
            return false;
        }

        public async Task<Renter> GetUserById(string id)
        {
            Renter renter = RenterRepository.GetUserById(id);
            
            return renter;
        }

        public void UpdateProfile(Renter renter)
        {
            RenterRepository.UpdateProfile(renter);
        }
    }
}
