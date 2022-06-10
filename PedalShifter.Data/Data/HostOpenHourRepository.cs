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
    public class HostOpenHourRepository : RepositoryBase<HostOpenHour>, IHostOpenHourRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public HostOpenHourRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task CreateAsync(HostOpenHour hostOpenHour)
        {
            await AddAsync(hostOpenHour);
            
        }

        public async Task<HostOpenHour> GetById(int id)
        {
            var result = GetAll().FirstOrDefault(x => x.Id.Equals(id));
                 return result;
        }

        public async Task<IEnumerable<HostOpenHour>> GetByHostId(int id)
        {
            var result = GetAll().Where(x => x.HostId.Equals(id));
            return result;
        }

        public async Task UpdateHostOpenHourAsync(HostOpenHour hostOpenHour)
        {
            await UpdateAsync(hostOpenHour);
        }
    }
}
