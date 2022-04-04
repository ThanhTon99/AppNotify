using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppNotify.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace AppNotify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public DepartmentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]

        public JsonResult Get()
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("NotifyAppCon"));

            var dbList = dbClient.GetDatabase("Notify").GetCollection<Department>("Department").AsQueryable();

            return new JsonResult(dbList);
        }
        [HttpPost]

        public JsonResult Post(Department dep)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("NotifyAppCon"));

            int LastDepartmentId = dbClient.GetDatabase("Notify").GetCollection<Department>("Department").AsQueryable().Count();
            dep.UserId = LastDepartmentId + 1;
            dbClient.GetDatabase("Notify").GetCollection<Department>("Department").InsertOne(dep);

            return new JsonResult("Updated Successfully");
        }

        [HttpPut]

        public JsonResult Put(Department dep)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("NotifyAppCon"));

            var filter = Builders<Department>.Filter.Eq(x => x.Id , dep.Id);
            var update = Builders<Department>.Update.Set(x => x.Username, dep.Username)
                                                    .Set(x => x.Password, dep.Password);

            dbClient.GetDatabase("Notify").GetCollection<Department>("Department").UpdateOne(filter, update);

            return new JsonResult("Updated Successfully");
        }

        [HttpDelete("{id}")]

        public JsonResult Delete(int id)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("NotifyAppCon"));

            var filter = Builders<Department>.Filter.Eq("UserId", id);

            dbClient.GetDatabase("Notify").GetCollection<Department>("Department").DeleteOne(filter);

            return new JsonResult("Deleted Successfully");
        }

    }
}

