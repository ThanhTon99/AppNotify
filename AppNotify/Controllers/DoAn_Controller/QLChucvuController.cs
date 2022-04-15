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
    public class QLChucvuController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public QLChucvuController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]

        public JsonResult Get()
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("NotifyAppCon"));

            var dbList = dbClient.GetDatabase("Document").GetCollection<QLChucvu>("QLChucvu").AsQueryable();

            return new JsonResult(dbList);
        }
        [HttpPost]

        public JsonResult Post(QLChucvu qLChucvu)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("NotifyAppCon"));

            int LastIdChucvu = dbClient.GetDatabase("Document").GetCollection<QLChucvu>("QLChucvu").AsQueryable().Count();
            qLChucvu.IdChucvu = LastIdChucvu + 1;

            dbClient.GetDatabase("Document").GetCollection<QLChucvu>("QLChucvu").InsertOne(qLChucvu);

            return new JsonResult("Added Successfully");
        }
        [HttpPut]

        public JsonResult Put(QLChucvuRequest qLChucvu)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("NotifyAppCon"));

            var filter = Builders<QLChucvu>.Filter.Eq(x => x.Id, new BsonObjectId(new ObjectId(qLChucvu.Id)));
            var update = Builders<QLChucvu>.Update.Set(x => x.TenChucvu, qLChucvu.TenChucvu)
                                                    .Set(x => x.MotaChucvu, qLChucvu.MotaChucvu);

            dbClient.GetDatabase("Document").GetCollection<QLChucvu>("QLChucvu").UpdateOne(filter, update);

            return new JsonResult("Updated Successfully");
        }

        [HttpDelete("{id}")]

        public JsonResult Delete(int id)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("NotifyAppCon"));

            var filter = Builders<QLChucvu>.Filter.Eq("IdChucvu", id);

            dbClient.GetDatabase("Document").GetCollection<QLChucvu>("QLChucvu").DeleteOne(filter);

            return new JsonResult("Deleted Successfully");
        }

    }
}
