using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace PedalShifter.Data.Interfaces
{
    public interface IUserRepository : IRepositoryBase<IdentityUser>
    {
        public IdentityUser GetUserById(string id);
        public IdentityUser GetUserByEmail(string email);
    }
}