using Microsoft.AspNetCore.Identity;

namespace PedalShifter.Domain.Interfaces
{
    public interface IUserService
    {
        IdentityUser GetUserByEmail(string email);
    }
}