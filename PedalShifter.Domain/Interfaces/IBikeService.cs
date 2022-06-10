using PedalShifter.Data.Entities;
using PedalShifter.Data.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PedalShifter.Domain.Interfaces
{
    public interface IBikeService
    {
        Task<List<BikeViewModel>> GetAll();
        Task<List<BikeViewModel>> GetAllByUserId(string userId);
        Task<BikeViewModel> GetById(int id);
    }
}