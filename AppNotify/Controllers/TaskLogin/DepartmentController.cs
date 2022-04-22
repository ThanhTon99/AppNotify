using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using AppNotify.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using MongoDB.Bson;
using Microsoft.AspNetCore.Authorization;

namespace AppNotify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DepartmentController(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("NotifyAppCon");
        }
        
        [HttpGet]

        public JsonResult Get()
        {
            MongoClient dbClient = new MongoClient(_connectionString);

            var dbList = dbClient.GetDatabase("Notify").GetCollection<Department>("Department").AsQueryable();

            return new JsonResult(dbList);
        }

        [HttpPost]

        public JsonResult Post(DepartmentRequest request)
        {
            MongoClient dbClient = new MongoClient(_connectionString);

            int LastUserId = dbClient.GetDatabase("Notify").GetCollection<Department>("Department").AsQueryable().Count();
            request.UserId = LastUserId + 1;

            Department department = new Department(request);

            dbClient.GetDatabase("Notify").GetCollection<Department>("Department").InsertOne(department);

            return new JsonResult("Added Successfully");
        }

        [HttpPut]

        public JsonResult Put(DepartmentRequest dep)
        {
            MongoClient dbClient = new MongoClient(_connectionString);

            var filter = Builders<Department>.Filter.Eq(x => x.Id, new BsonObjectId(new ObjectId(dep.Id)));
            var update = Builders<Department>.Update.Set(x => x.Username, dep.Username)
                                                    .Set(x => x.Password, dep.Password)
                                                    .Set(x => x.Roles, dep.Roles)
                                                    .Set(x => x.TenNguoidung, dep.TenNguoidung)
                                                    .Set(x => x.Chucvu, dep.Chucvu)
                                                    .Set(x => x.Phongban, dep.Phongban);

            dbClient.GetDatabase("Notify").GetCollection<Department>("Department").UpdateOne(filter, update);

            return new JsonResult("Updated Successfully");
        }

        [HttpDelete("{id}")]

        public JsonResult Delete(int id)
        {
            MongoClient dbClient = new MongoClient(_connectionString);

            var filter = Builders<Department>.Filter.Eq("UserId", id);

            dbClient.GetDatabase("Notify").GetCollection<Department>("Department").DeleteOne(filter);

            return new JsonResult("Deleted Successfully");
        }

        // Phân Quyền User
        [HttpGet]
        [Route("rolesAdmin")]
        public JsonResult GetUser()
        {
            MongoClient dbClient = new MongoClient(_connectionString);

            var dbList = dbClient.GetDatabase("Notify").GetCollection<Department>("Department").AsQueryable();

            var List = from list in dbList
                        where list.Roles == "Admin"
                        select list;

            return new JsonResult(List);
        }
        [HttpGet]
        [Route("rolesMember")]
        public JsonResult GetUser1()
        {
            MongoClient dbClient = new MongoClient(_connectionString);

            var dbList = dbClient.GetDatabase("Notify").GetCollection<Department>("Department").AsQueryable();

            var List = from list in dbList
                       where list.Roles == "Member"
                       select list;
            
            return new JsonResult(List);
        }

    }
}

