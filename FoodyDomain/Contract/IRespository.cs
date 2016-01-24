using FoodyDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodyDomain
{
    public interface IResponsitory<T> where T:IEntity
    {
        IEnumerable<T> List { get; }
        Task<int> AddAsync(T entity);
        Task<int> DeleteAsync(string id);
        Task<int> UpdateAsync(T entity);
        Task<IEnumerable<MenuEntity>> ToListAsync();
        Task<T> FindAsync(string id);  
    }
}
