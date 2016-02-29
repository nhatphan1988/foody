using FoodyDomain.Model;
using FoodyRespository.Respository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Foody.Controllers
{
    [EnableCors(origins: "http://localhost:8000,http://localhost:3000", headers: "*", methods: "*")]
    public class UsersController : ApiController
    {
        //UserResponsitory _userResponsitory;
        //public UsersController(DbContext context)
        //{
        //    _userResponsitory = new UserResponsitory(context);
        //}
        // GET: api/Users
        public IEnumerable<UserEntity> Get()
        {
            //return _userResponsitory.List;
            return new List<UserEntity>() { new UserEntity() { Id = "1", Name = "NhatPhan" }, new UserEntity() { Id="2",Name="NhaBui"} };
        }

        // GET: api/Users/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Users
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Users/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Users/5
        public void Delete(int id)
        {
        }
    }
}
