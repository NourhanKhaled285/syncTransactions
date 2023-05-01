using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncProject.BLL
{
    public interface IGenericRepository<T>
    {
        Task<T> Get(int? id);
        Task<IEnumerable<T>> GetAll();
        Task<int> Add(T employee);
        Task<int> Update(T employee);
        Task<int> Delete(T employee);
    }
}
