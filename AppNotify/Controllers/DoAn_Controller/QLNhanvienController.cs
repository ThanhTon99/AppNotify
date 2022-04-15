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
    public class QLNhanvienController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public QLNhanvienController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]

        public JsonResult Get()
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("NotifyAppCon"));

            var dbList = dbClient.GetDatabase("Document").GetCollection<QLNhanvien>("QLNhanvien").AsQueryable();

            return new JsonResult(dbList);
        }
        [HttpPost]

        public JsonResult Post(QLNhanvienRequest request)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("NotifyAppCon"));

            int LastIdNhanvien = dbClient.GetDatabase("Document").GetCollection<QLNhanvien>("QLNhanvien").AsQueryable().Count();
            request.IdNhanvien = LastIdNhanvien + 1;

            QLNhanvien qLNhanvien = new QLNhanvien(request);

            dbClient.GetDatabase("Document").GetCollection<QLNhanvien>("QLNhanvien").InsertOne(qLNhanvien);

            return new JsonResult("Added Successfully");
        }
        [HttpPut]

        public JsonResult Put(QLNhanvienRequest qLNhanvien)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("NotifyAppCon"));

            var filter = Builders<QLNhanvien>.Filter.Eq(x => x.Id, new BsonObjectId(new ObjectId(qLNhanvien.Id)));
            var update = Builders<QLNhanvien>.Update.Set(x => x.TenNhanvien, qLNhanvien.TenNhanvien)
                                                    .Set(x => x.Diachi, qLNhanvien.Diachi)
                                                    .Set(x => x.TenChucvu, qLNhanvien.TenChucvu)
                                                    .Set(x => x.Sodienthoai, qLNhanvien.Sodienthoai);

            dbClient.GetDatabase("Document").GetCollection<QLNhanvien>("QLNhanvien").UpdateOne(filter, update);

            return new JsonResult("Updated Successfully");
        }

        [HttpDelete("{id}")]

        public JsonResult Delete(int id)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("NotifyAppCon"));

            var filter = Builders<QLNhanvien>.Filter.Eq("IdNhanvien", id);

            dbClient.GetDatabase("Document").GetCollection<QLNhanvien>("QLNhanvien").DeleteOne(filter);

            return new JsonResult("Deleted Successfully");
        }

    }
}
