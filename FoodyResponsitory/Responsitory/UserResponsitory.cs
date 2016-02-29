using FoodyDomain.Model;
using FoodyResponsitory;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Dish = FoodyDomain.Model.DishEntity;

namespace FoodyRespository.Respository
{
    public class UserResponsitory
    {
        FoodyEntities _context;

        public UserResponsitory(DbContext context)
        {
            _context = context as FoodyEntities;
        }

        public IEnumerable<UserEntity> List
        {
            get
            {
                return AutoMapper.Mapper.Map<List<UserEntity>>(_context.Users);
            }

        }
    }
}
