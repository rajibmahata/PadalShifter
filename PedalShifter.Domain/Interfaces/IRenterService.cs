using PedalShifter.Data.Entities;
using System.Threading.Tasks;

namespace PedalShifter.Domain.Interfaces
{
    public interface IRenterService
    {
        Task<bool> CreateAsync(Renter renter);
        Task<Renter> GetUserById(string id);
        void UpdateProfile(Renter renter);
    }
}
