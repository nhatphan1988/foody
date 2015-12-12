using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodyDomain
{
    public interface IResponsitory<T> where T:IEntity
    {
        IEnumerable<T> List { get; }
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T FindById(string Id);  
    }
}
