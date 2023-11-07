using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IDapperBaseRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> query(string query);
        Task<int> command(string command);
    }
}
