using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppNotify.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AppNotify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QLNoidenController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public QLNoidenController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]

        public JsonResult Get()
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("NotifyAppCon"));

            var dbList = dbClient.GetDatabase("Document").GetCollection<QLNoiden>("QLNoiden").AsQueryable();

            return new JsonResult(dbList);
        }
        [HttpPost]

        public JsonResult Post(QLNoiden qLNoiden)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("NotifyAppCon"));

            int LastIdNoiden = dbClient.GetDatabase("Document").GetCollection<QLNoiden>("QLNoiden").AsQueryable().Count();
            qLNoiden.IdNoiden = LastIdNoiden + 1;

            dbClient.GetDatabase("Document").GetCollection<QLNoiden>("QLNoiden").InsertOne(qLNoiden);

            return new JsonResult("Added Successfully");
        }
        [HttpPut]

        public JsonResult Put(QLNoidenRequest qLNoiden)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("NotifyAppCon"));

            var filter = Builders<QLNoiden>.Filter.Eq(x => x.Id, new BsonObjectId(new ObjectId(qLNoiden.Id)));
            var update = Builders<QLNoiden>.Update.Set(x => x.TenNoiden, qLNoiden.TenNoiden)
                                                    .Set(x => x.MotaNoiden, qLNoiden.MotaNoiden);

            dbClient.GetDatabase("Document").GetCollection<QLNoiden>("QLNoiden").UpdateOne(filter, update);

            return new JsonResult("Updated Successfully");
        }

        [HttpDelete("{id}")]

        public JsonResult Delete(int id)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("NotifyAppCon"));

            var filter = Builders<QLNoiden>.Filter.Eq("IdNoiden", id);

            dbClient.GetDatabase("Document").GetCollection<QLNoiden>("QLNoiden").DeleteOne(filter);

            return new JsonResult("Deleted Successfully");
        }
    }
}
