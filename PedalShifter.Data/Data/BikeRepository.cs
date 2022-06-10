using PedalShifter.Data.Entities;
using PedalShifter.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedalShifter.Data.Data
{
    public class BikeRepository : RepositoryBase<Bike>, IBikeRepository
    {
        public BikeRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }

        public List<Bike> GetAllBikes()
        {
            return GetAll().ToList();
        }

        public List<Bike> GetAllByUserId(string userId)
        {
            return GetAll().Where(x => x.UserId == userId).ToList();
        }

        public Bike GetById(int id)
        {
            return GetAll().Where(x => x.id == id).FirstOrDefault();
        }
    }
}
