using Microsoft.AspNetCore.Identity;
using PedalShifter.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedalShifter.Data.Data
{
    public class UserRepository : RepositoryBase<IdentityUser>, IUserRepository
    {
        public UserRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }

        public IdentityUser GetUserById(string id)
        {
            return GetAll().Where(x => x.Id == id).FirstOrDefault();
        }

        public IdentityUser GetUserByEmail(string email)
        {
            return GetAll().Where(x => x.Email == email).FirstOrDefault();
        }
    }

}
