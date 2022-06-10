using PedalShifter.Data.Entities;
using System.Collections.Generic;

namespace PedalShifter.Data.Interfaces
{
    public interface IBikeRepository : IRepositoryBase<Bike>
    {
        List<Bike> GetAllBikes();
        List<Bike> GetAllByUserId(string userId);
        Bike GetById(int id);
    }
}
