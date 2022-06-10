using PedalShifter.Data.Entities;
using System.Threading.Tasks;

namespace PedalShifter.Domain.Interfaces
{
    public interface IHostService
    {
        //Host GetUserByEmail(string email);
        Task<bool> CreateAsync(Host host);
        Task<Host> GetUserById(string id);
        void UpdateProfile(Host host);
    }
}
