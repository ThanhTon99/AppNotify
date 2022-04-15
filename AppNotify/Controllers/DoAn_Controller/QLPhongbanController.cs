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
    public class QLPhongbanController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public QLPhongbanController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]

        public JsonResult Get()
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("NotifyAppCon"));

            var dbList = dbClient.GetDatabase("Document").GetCollection<QLPhongban>("QLPhongban").AsQueryable();

            return new JsonResult(dbList);
        }
        [HttpPost]

        public JsonResult Post(QLPhongbanRequest request)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("NotifyAppCon"));

            int LastIdPhongban = dbClient.GetDatabase("Document").GetCollection<QLPhongban>("QLPhongban").AsQueryable().Count();
            request.IdPhongban = LastIdPhongban + 1;

            QLPhongban qLPhongban = new QLPhongban(request);

            dbClient.GetDatabase("Document").GetCollection<QLPhongban>("QLPhongban").InsertOne(qLPhongban);

            return new JsonResult("Added Successfully");
        }
        [HttpPut]

        public JsonResult Put(QLPhongbanRequest qLPhongban)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("NotifyAppCon"));

            

            var filter = Builders<QLPhongban>.Filter.Eq(x => x.Id, new BsonObjectId(new ObjectId(qLPhongban.Id)));
            var update = Builders<QLPhongban>.Update.Set(x => x.TenPhongban, qLPhongban.TenPhongban)
                                                    .Set(x => x.MotaPhongban, qLPhongban.MotaPhongban)
                                                    .Set(x => x.TenChucvu, qLPhongban.TenChucvu)
                                                    .Set(x => x.IdChucvu, qLPhongban.IdChucvu);

            dbClient.GetDatabase("Document").GetCollection<QLPhongban>("QLPhongban").UpdateOne(filter, update);

            return new JsonResult("Updated Successfully");
        }

        [HttpDelete("{id}")]

        public JsonResult Delete(int id)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("NotifyAppCon"));

            var filter = Builders<QLPhongban>.Filter.Eq("IdPhongban", id);

            dbClient.GetDatabase("Document").GetCollection<QLPhongban>("QLPhongban").DeleteOne(filter);

            return new JsonResult("Deleted Successfully");
        }

    }

}
