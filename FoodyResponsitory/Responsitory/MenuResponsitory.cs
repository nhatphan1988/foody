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
    public class MenuResponsitory:IResponsitory<MenuEntity>
    {
        FoodyEntities1 _menuContext;

        public MenuResponsitory()
        {
            _menuContext = new FoodyEntities1();
 
        }
        public IEnumerable<MenuEntity> List
        {
            get
            {
                return AutoMapper.Mapper.Map<List<MenuEntity>>(_menuContext.Menus);
            }
            
        }

        public void Add(MenuEntity entity)
        {

        }

        public void Delete(MenuEntity entity)
        {

        }

        public void Update(MenuEntity entity)
        {

        }

        public MenuEntity FindById(string Id)
        {
            return new MenuEntity();
        }

    }
}
