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
    public class QLLoaivbController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public QLLoaivbController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]

        public JsonResult Get()
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("NotifyAppCon"));

            var dbList = dbClient.GetDatabase("Document").GetCollection<QLLoaivb>("QLLoaivb").AsQueryable();

            return new JsonResult(dbList);
        }
        [HttpPost]

        public JsonResult Post(QLLoaivb qLLoaivb)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("NotifyAppCon"));

            int LastIdLoaivb = dbClient.GetDatabase("Document").GetCollection<QLLoaivb>("QLLoaivb").AsQueryable().Count();
            qLLoaivb.IdLoaivb = LastIdLoaivb + 1;

            dbClient.GetDatabase("Document").GetCollection<QLLoaivb>("QLLoaivb").InsertOne(qLLoaivb);

            return new JsonResult("Added Successfully");
        }
        [HttpPut]

        public JsonResult Put(QLLoaivbRequest qLLoaivb)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("NotifyAppCon"));

            var filter = Builders<QLLoaivb>.Filter.Eq(x => x.Id, new BsonObjectId(new ObjectId(qLLoaivb.Id)));
            var update = Builders<QLLoaivb>.Update.Set(x => x.TenLoaivb, qLLoaivb.TenLoaivb)
                                                    .Set(x => x.MotaLoaivb, qLLoaivb.MotaLoaivb);

            dbClient.GetDatabase("Document").GetCollection<QLLoaivb>("QLLoaivb").UpdateOne(filter, update);

            return new JsonResult("Updated Successfully");
        }

        [HttpDelete("{id}")]

        public JsonResult Delete(int id)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("NotifyAppCon"));

            var filter = Builders<QLLoaivb>.Filter.Eq("IdLoaivb", id);

            dbClient.GetDatabase("Document").GetCollection<QLLoaivb>("QLLoaivb").DeleteOne(filter);

            return new JsonResult("Deleted Successfully");
        }
    }
}
