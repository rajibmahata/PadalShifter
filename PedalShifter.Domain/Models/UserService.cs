using Microsoft.AspNetCore.Identity;
using PedalShifter.Data.Interfaces;
using PedalShifter.Domain.Interfaces;

namespace PedalShifter.Domain.Models
{
    public class UserService : IUserService
    {
        private readonly IUserRepository UserRepository;
        public UserService(IUserRepository userRepository)
        {
            this.UserRepository = userRepository;
        }

        public IdentityUser GetUserByEmail(string email)
        {
            return UserRepository.GetUserByEmail(email);
        }
    }
}
