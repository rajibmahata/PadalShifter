using PedalShifter.Data.Entities;
using System.Threading.Tasks;

namespace PedalShifter.Data.Interfaces
{
    public interface IRenterRepository : IRepositoryBase<Renter>
    {
        Task CreateAsync(Renter renter);
        Renter GetUserById(string id);
        Task UpdateProfile(Renter renter);
    }
}
