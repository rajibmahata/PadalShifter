using PedalShifter.Data.Entities;
using System.Threading.Tasks;

namespace PedalShifter.Data.Interfaces
{
    public interface IHostRepository : IRepositoryBase<Host>
    {
        Task CreateAsync(Host host);
        Host GetUserById(string id);
        //public Host GetUserByEmail(string email);
        Task UpdateProfile(Host host);
    }
}
