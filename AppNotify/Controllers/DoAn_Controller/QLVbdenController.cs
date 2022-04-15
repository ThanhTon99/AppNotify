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
    public class QLVbdenController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public QLVbdenController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]

        public JsonResult Get()
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("NotifyAppCon"));

            var dbList = dbClient.GetDatabase("Document").GetCollection<QLVbden>("QLVbden").AsQueryable();

            return new JsonResult(dbList);
        }
        [HttpGet]
        [Route("getstatus")]
        public JsonResult GetStatus()
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("NotifyAppCon"));

            var dbList = dbClient.GetDatabase("Document").GetCollection<QLVbden>("QLVbden").AsQueryable();

            var List = from list in dbList
                       where list.TrangthaiXuly == true 
                       select list;
            return new JsonResult(List);

        }

        [HttpPost]

        public JsonResult Post(QLVbdenRequest request)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("NotifyAppCon"));

            int LastIdVbden = dbClient.GetDatabase("Document").GetCollection<QLVbden>("QLVbden").AsQueryable().Count();
            request.IdVbden = LastIdVbden + 1;

            QLVbden qLVbden = new QLVbden(request);

            dbClient.GetDatabase("Document").GetCollection<QLVbden>("QLVbden").InsertOne(qLVbden);

            return new JsonResult("Added Successfully");
        }
        [HttpPut]

        public JsonResult Put(QLVbdenRequest qLVbden)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("NotifyAppCon"));

            var filter = Builders<QLVbden>.Filter.Eq(x => x.Id, new BsonObjectId(new ObjectId(qLVbden.Id)));
            var update = Builders<QLVbden>.Update.Set(x => x.TenVbden, qLVbden.TenVbden)
                                                    .Set(x => x.MotaVbden, qLVbden.MotaVbden)
                                                    .Set(x => x.Noiden, qLVbden.Noiden)
                                                    .Set(x => x.TenNhanvien, qLVbden.TenNhanvien)
                                                    .Set(x => x.TrangthaiXuly, qLVbden.TrangthaiXuly);

            dbClient.GetDatabase("Document").GetCollection<QLVbden>("QLVbden").UpdateOne(filter, update);

            return new JsonResult("Updated Successfully");
        }

        [HttpDelete("{id}")]

        public JsonResult Delete(int id)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("NotifyAppCon"));

            var filter = Builders<QLVbden>.Filter.Eq("IdVbden", id);

            dbClient.GetDatabase("Document").GetCollection<QLVbden>("QLVbden").DeleteOne(filter);

            return new JsonResult("Deleted Successfully");
        }
    }
}
