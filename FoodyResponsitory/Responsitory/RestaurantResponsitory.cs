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
    public class RestaurantResponsitory
        //:IResponsitory<RestaurantEntity>
    {
        FoodyEntities context;

        public RestaurantResponsitory()
        {
            context = new FoodyEntities();
 
        }
        public IEnumerable<RestaurantEntity> List
        {
            get
            {
                return AutoMapper.Mapper.Map<List<RestaurantEntity>>(context.Restaurants);
            }
            
        }

        public IEnumerable<RestaurantEntity> ListById
        {
            get
            {
                return AutoMapper.Mapper.Map<List<RestaurantEntity>>(context.Restaurants).SelectEntityById();
            }
        }

        public void Add(RestaurantEntity entity)
        {
            context.Restaurants.Add(AutoMapper.Mapper.Map<Restaurant>(entity));
            context.SaveChanges();
        }

        public void Delete(RestaurantEntity entity)
        {
            context.Restaurants.Remove(AutoMapper.Mapper.Map<Restaurant>(entity));
            context.SaveChanges();
        }

        public void Update(RestaurantEntity entity)
        {
            context.Entry(AutoMapper.Mapper.Map<Restaurant>(entity)).State = 
                System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            
        }

        public RestaurantEntity FindById(string Id)
        {
            var result = (from r in context.Restaurants where r.Id == Id select r).FirstOrDefault();
            return AutoMapper.Mapper.Map<RestaurantEntity>(result); 
        }
    }
}
