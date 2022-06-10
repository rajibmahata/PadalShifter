using Microsoft.EntityFrameworkCore;
using PedalShifter.Data.Entities;
using PedalShifter.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedalShifter.Data.Data
{
    public class HostRepository : RepositoryBase<Host>, IHostRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public HostRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task CreateAsync(Host host)
        {
            await AddAsync(host);
            
        }

        public Host GetUserById(string id)
        {
            var result = GetAll().FirstOrDefault(x => x.IdentityId.Equals(id));
                 return result;
        }

        public async Task UpdateProfile(Host host)
        {
            await UpdateAsync(host);
        }
    }
}
