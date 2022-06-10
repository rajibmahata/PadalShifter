using PedalShifter.Data.Entities;
using PedalShifter.Data.Interfaces;
using PedalShifter.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PedalShifter.Domain.Models
{
    public class HostOpenHourService : IHostOpenHourService
    {
        private readonly IHostOpenHourRepository HostOpenHourRepository;
        private readonly IUserRepository UserRepository;
        public HostOpenHourService(IHostOpenHourRepository hostOpenHourRepository, IUserRepository userRepository)
        {
            this.HostOpenHourRepository = hostOpenHourRepository;
            this.UserRepository = userRepository;
        }

        
        public async Task<bool> CreateAsync(HostOpenHour hostOpenHour)
        {
            try
            {
                await HostOpenHourRepository.CreateAsync(hostOpenHour);
                return true;
            }
            catch (Exception e)
            {

            }
            return false;
        }

        public async Task<HostOpenHour> GetById(int id)
        {
            HostOpenHour hostOpenHour = await  HostOpenHourRepository.GetById(id);
            
            return hostOpenHour;
        }
        public async Task<IEnumerable<HostOpenHour>> GetByHostId(int id)
        {
            IEnumerable<HostOpenHour> hostOpenHours =await HostOpenHourRepository.GetByHostId(id);

            return hostOpenHours;
        }

        public async Task<bool> UpdateHostOpenHourAsync(HostOpenHour hostOpenHour)
        {
            try
            {
                await HostOpenHourRepository.UpdateHostOpenHourAsync(hostOpenHour);
                return true;
            }
            catch (Exception e)
            {

            }
            return false;
        }

        
    }
}
