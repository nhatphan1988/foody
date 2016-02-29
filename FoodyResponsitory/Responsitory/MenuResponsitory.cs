using FoodyDomain;
using FoodyDomain.Model;
using Foody;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FoodyResponsitory;
using System.Threading.Tasks;
using System.Data.Entity;

namespace FoodyRespository.Respository
{
    public static class ExtensionMethod
    {
        public static IEnumerable<T> SelectEntityById<T>(this IEnumerable<T> list) where T : IEntity
        {
            var result = list
                    .Where(f => f.Id == "1")
                    .ToList();
            
            return result;


        }
        
    }
    public class MenuResponsitory:IResponsitory<MenuEntity>
    {
        FoodyEntities context;

        public MenuResponsitory()
        {
            context = new FoodyEntities();
 
        }
        public IEnumerable<MenuEntity> List
        {
            get
            {

                return AutoMapper.Mapper.Map<List<MenuEntity>>(context.Menus);
            }
        }

        public async Task<IEnumerable<MenuEntity>> ToListAsync()
        {
            List<Menu> menus = await context.Menus.ToListAsync();

            return AutoMapper.Mapper.Map<List<MenuEntity>>(menus);

        }

        public IEnumerable<MenuEntity> ListById
        {
            get
            {
                return AutoMapper.Mapper.Map<List<MenuEntity>>(context.Menus).SelectEntityById();
            }
        }

        public async Task<int> AddAsync(MenuEntity entity)
        {
            context.Menus.Add(AutoMapper.Mapper.Map<Menu>(entity));
            return await context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(string id)
        {
            Menu menu = await context.Menus.FindAsync(id);
            context.Menus.Remove(menu);
            return await context.SaveChangesAsync();

        }

        public async Task<int> UpdateAsync(MenuEntity entity)
        {

            return 0;
        }

        public async Task<MenuEntity> FindAsync(string id)
        {
            return AutoMapper.Mapper.Map<MenuEntity>(await context.Menus.FindAsync(id));
        }
        
    }
}
