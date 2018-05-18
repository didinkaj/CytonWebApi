using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CytonInterview.Controllers.Services
{
   public interface IRepository<T> where T: class
    {
        Task<bool> Add(T t);
        Task<bool> Delete(Guid id);
        Task<ICollection<T>> GetAll();
        Task<bool> Update(Guid Id,T t);
        Task<T> GetById(Guid Id);
    }
}
