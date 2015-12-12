using FoodyDomain;
using FoodyDomain.Model;
using Foody;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FoodyResponsitory;

namespace FoodyRespository.Respository
{
    public class RestaurantResponsitory:IResponsitory<RestaurantEntity>
    {
        FoodyEntities1 _restaurantContext;

        public RestaurantResponsitory()
        {
            _restaurantContext = new FoodyEntities1();
 
        }
        public IEnumerable<RestaurantEntity> List
        {
            get
            {
                return AutoMapper.Mapper.Map<List<RestaurantEntity>>(_restaurantContext.Restaurants);
            }
            
        }

        public void Add(RestaurantEntity entity)
        {
            _restaurantContext.Restaurants.Add(AutoMapper.Mapper.Map<Restaurant>(entity));
            _restaurantContext.SaveChanges();
        }

        public void Delete(RestaurantEntity entity)
        {
            _restaurantContext.Restaurants.Remove(AutoMapper.Mapper.Map<Restaurant>(entity));
            _restaurantContext.SaveChanges();
        }

        public void Update(RestaurantEntity entity)
        {
            _restaurantContext.Entry(AutoMapper.Mapper.Map<Restaurant>(entity)).State = 
                System.Data.Entity.EntityState.Modified;
            _restaurantContext.SaveChanges();
            
        }

        public RestaurantEntity FindById(string Id)
        {
            var result = (from r in _restaurantContext.Restaurants where r.ID == Id select r).FirstOrDefault();
            return AutoMapper.Mapper.Map<RestaurantEntity>(result); 
        }
    }
}
