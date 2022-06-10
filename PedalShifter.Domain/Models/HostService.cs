using PedalShifter.Data.Entities;
using PedalShifter.Data.Interfaces;
using PedalShifter.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace PedalShifter.Domain.Models
{
    public class HostService : IHostService
    {
        private readonly IHostRepository HostRepository;
        private readonly IUserRepository UserRepository;
        public HostService(IHostRepository hostRepository, IUserRepository userRepository)
        {
            this.HostRepository = hostRepository;
            this.UserRepository = userRepository;
        }

        //public Host GetUserByEmail(string email)
        //{
        //    Host host = HostRepository.GetUserByEmail(email);
        //    if(UserRepository.GetUserByEmail(email) != null)
        //    {
        //        host.Identity = UserRepository.GetUserByEmail(email);
        //    }
        //    return host;
        //}

        public async Task<bool> CreateAsync(Host host)
        {
            try
            {
                await HostRepository.CreateAsync(host);
                return true;
            }
            catch (Exception e)
            {

            }
            return false;
        }

        public async Task<Host> GetUserById(string id)
        {
            Host host = HostRepository.GetUserById(id);
            
            return host;
        }

        public void UpdateProfile(Host host)
        {
            HostRepository.UpdateProfile(host);
        }
    }
}
