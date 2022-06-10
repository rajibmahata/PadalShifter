using PedalShifter.Data.Entities;
using PedalShifter.Data.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace PedalShifter.Data.Data
{
    public class RenterRepository : RepositoryBase<Renter>, IRenterRepository
    {
        public RenterRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public async Task CreateAsync(Renter renter)
        {
            await AddAsync(renter);
            
        }

        public Renter GetUserById(string id)
        {
            var result = GetAll().FirstOrDefault(x => x.IdentityId.Equals(id));
                 return result;
        }

        public async Task UpdateProfile(Renter renter)
        {
            await UpdateAsync(renter);
        }
    }
}
