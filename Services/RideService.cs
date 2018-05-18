using CytonInterview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CytonInterview.Controllers.Services
{
    public class RideService : IRepository<Ride>
    {
        private readonly CytonDbContext _cytonDbContext;
        public RideService(CytonDbContext cytonDbContext)
        {
            _cytonDbContext = cytonDbContext;
        }
        public async Task<bool> Add(Ride t)
        {
            _cytonDbContext.Rides.Add(t);
          await  _cytonDbContext.SaveChangesAsync();
          return true;
        }

        public async Task<bool> Delete(Guid id)
        {
          var ride= await _cytonDbContext.Rides.FindAsync(id);
           _cytonDbContext.Rides.Remove(ride);
            return true;
        }

        public async Task<ICollection<Ride>> GetAll()
        {
            return null;
        }

        public async Task<Ride> GetById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(Guid Id,Ride ride)
        {
            throw new NotImplementedException();
        }
    }
}
