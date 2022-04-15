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
    public class PhancongCvController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public PhancongCvController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]

        public JsonResult Get()
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("NotifyAppCon"));

            var dbList = dbClient.GetDatabase("Document").GetCollection<PhancongCv>("PhancongCv").AsQueryable();

            return new JsonResult(dbList);
        }
        [HttpPut]

        public JsonResult Put(PhancongCvRequest phancongCv)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("NotifyAppCon"));

            var filter = Builders<PhancongCv>.Filter.Eq(x => x.Id, new BsonObjectId(new ObjectId(phancongCv.Id)));
            var update = Builders<PhancongCv>.Update.Set(x => x.Note, phancongCv.Note)
                                                    .Set(x => x.TenNhanvien, phancongCv.TenNhanvien);
                                                   // .Set(x => x.NgayBd, phancongCv.NgayBd)
                                                 //.Set(x => x.NgayKt, phancongCv.NgayKt);

            dbClient.GetDatabase("Document").GetCollection<PhancongCv>("PhancongCv").UpdateOne(filter, update);

            return new JsonResult("Updated Successfully");
        }

        [HttpDelete("{id}")]

        public JsonResult Delete(int id)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("NotifyAppCon"));
            var filter = Builders<PhancongCv>.Filter.Eq("IdCongviec", id);

            dbClient.GetDatabase("Document").GetCollection<PhancongCv>("PhancongCv").DeleteOne(filter);

            return new JsonResult("Deleted Successfully");
        }
    }
}
