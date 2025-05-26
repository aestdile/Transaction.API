using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transaction.API.DataAccess
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Create(T model);
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Update(int id, T model);
        Task<bool> Delete(int id);
    }
}
