using PedalShifter.Data.Entities;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace PedalShifter.Data.Interfaces
{
    public interface IHostOpenHourRepository : IRepositoryBase<HostOpenHour>
    {
        Task CreateAsync(HostOpenHour hostOpenHour);
        Task<HostOpenHour> GetById(int id);
        Task<IEnumerable<HostOpenHour>> GetByHostId(int id);
        Task UpdateHostOpenHourAsync(HostOpenHour hostOpenHour);
    }
}
