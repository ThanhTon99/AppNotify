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

namespace AppNotify.Controllers.DoAn_Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserteamController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public UserteamController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("NotifyAppCon"));

            var dbList = dbClient.GetDatabase("Document").GetCollection<Userteam>("Userteam").AsQueryable();

            return new JsonResult(dbList);
        }
        [HttpPost]

        public JsonResult Post(UserteamRequest request)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("NotifyAppCon"));

            int LastUserteamId = dbClient.GetDatabase("Document").GetCollection<Userteam>("Userteam").AsQueryable().Count();
            request.UserteamId = LastUserteamId + 1;

            Userteam userteam = new Userteam(request);

            dbClient.GetDatabase("Document").GetCollection<Userteam>("Userteam").InsertOne(userteam);

            return new JsonResult("Added Successfully");
        }
        [HttpPut]

        public JsonResult Put(UserteamRequest userteam)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("NotifyAppCon"));

            var filter = Builders<Userteam>.Filter.Eq(x => x.Id, new BsonObjectId(new ObjectId(userteam.Id)));
            var update = Builders<Userteam>.Update.Set(x => x.UserteamName, userteam.UserteamName)
                                                  .Set(x => x.Permission, userteam.Permission);

            dbClient.GetDatabase("Document").GetCollection<Userteam>("Userteam").UpdateOne(filter, update);

            return new JsonResult("Updated Successfully");
        }

        [HttpDelete("{id}")]

        public JsonResult Delete(int id)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("NotifyAppCon"));

            var filter = Builders<Userteam>.Filter.Eq("UserteamId", id);

            dbClient.GetDatabase("Document").GetCollection<Userteam>("Userteam").DeleteOne(filter);

            return new JsonResult("Deleted Successfully");
        }

    }
}
