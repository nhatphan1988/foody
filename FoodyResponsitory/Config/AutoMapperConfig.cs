using FoodyDomain.Model;
using FoodyResponsitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Foody.Config
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            AutoMapper.Mapper.CreateMap<RestaurantEntity, Restaurant>();
            AutoMapper.Mapper.CreateMap<Restaurant, RestaurantEntity>();
            AutoMapper.Mapper.CreateMap<MenuEntity, Menu>();
            AutoMapper.Mapper.CreateMap<Menu, MenuEntity>();
        }
    }
}
