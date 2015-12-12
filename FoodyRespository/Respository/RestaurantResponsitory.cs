using FoodyRespository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodyRespository.Respository
{
    public class RestaurantResponsitory:IResponsitory<Restaurant>
    {
        Model1 _authorContext;

        public RestaurantResponsitory()
        {
            _authorContext = new Model1();
 
        }
        public IEnumerable<Restaurant> List
        {
            get
            {
                return _authorContext.Authors;
            }
            
        }

        public void Add(Restaurant entity)
        {
            _authorContext.Authors.Add(entity);
            _authorContext.SaveChanges();
        }

        public void Delete(Restaurant entity)
        {
            _authorContext.Authors.Remove(entity);
            _authorContext.SaveChanges();
        }

        public void Update(Restaurant entity)
        {
            _authorContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _authorContext.SaveChanges();
            
        }

        public Restaurant FindById(int Id)
        {
            var result = (from r in _authorContext.Authors where r.Id == Id select r).FirstOrDefault();
            return result; 
        }
    }
}
