using PedalShifter.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PedalShifter.Domain.Interfaces
{
    public interface IHostOpenHourService
    {
        Task<bool> CreateAsync(HostOpenHour hostOpenHour);
        Task<HostOpenHour> GetById(int id);
        Task<IEnumerable<HostOpenHour>> GetByHostId(int id);
        Task<bool> UpdateHostOpenHourAsync(HostOpenHour hostOpenHour);
    }
}
