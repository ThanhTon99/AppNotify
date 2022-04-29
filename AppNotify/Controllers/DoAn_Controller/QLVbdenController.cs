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
            var List = from list in dbList
                       where list.Save == false
                       select list;
            return new JsonResult(List);
        }

        [HttpGet]
        [Route("getsave")]
        public JsonResult GetSave()
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("NotifyAppCon") );

            var dbList = dbClient.GetDatabase("Document").GetCollection<QLVbden>("QLVbden").AsQueryable();
            var List = from list in dbList
                       where list.Save == true
                       select list;
            return new JsonResult(List);
        }
        
        //------------------Báo Cáo -----------------

        [HttpGet]
        [Route("getBcnv")]
        public JsonResult GetBcnv()
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("NotifyAppCon"));

            var dbList = dbClient.GetDatabase("Document").GetCollection<QLVbden>("QLVbden").AsQueryable();
            var List = from list in dbList
                       where list.BcNhanvien == true
                       select list;
            return new JsonResult(List);
        }
        [HttpGet]
        [Route("getBctp")]
        public JsonResult GetBctp()
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("NotifyAppCon"));

            var dbList = dbClient.GetDatabase("Document").GetCollection<QLVbden>("QLVbden").AsQueryable();
            var List = from list in dbList
                       where list.BcTruongphong == true
                       select list;
            return new JsonResult(List);
        }
        [HttpGet]
        [Route("getBcbgh")]
        public JsonResult GetBcbgh()
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("NotifyAppCon"));

            var dbList = dbClient.GetDatabase("Document").GetCollection<QLVbden>("QLVbden").AsQueryable();
            var List = from list in dbList
                       where list.BcBgh == true
                       select list;
            return new JsonResult(List);
        }
        
        //-------------------Trạng Thái--------------------------

        [HttpGet]
        [Route("getstatus")]
        public JsonResult GetTTXuly()
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("NotifyAppCon"));

            var dbList = dbClient.GetDatabase("Document").GetCollection<QLVbden>("QLVbden").AsQueryable();

            var List = from list in dbList
                       where list.TrangthaiXuly == true
                       select list;
            return new JsonResult(List);
        }
        [HttpGet]
        [Route("getTTPC")]
        public JsonResult GetTTPhancong()
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("NotifyAppCon"));

            var dbList = dbClient.GetDatabase("Document").GetCollection<QLVbden>("QLVbden").AsQueryable();
            var List = from list in dbList
                       where list.TrangthaiPhancong == true
                       select list;
            return new JsonResult(List);
        }
        [HttpGet]
        [Route("getTTPD")]
        public JsonResult GetTTPheduyet()
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("NotifyAppCon"));

            var dbList = dbClient.GetDatabase("Document").GetCollection<QLVbden>("QLVbden").AsQueryable();
            var List = from list in dbList
                       where list.TrangthaiPheduyet == true
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
                                                    .Set(x => x.TrangthaiXuly, qLVbden.TrangthaiXuly)
                                                    .Set(x => x.TrangthaiPhancong, qLVbden.TrangthaiPhancong)
                                                    .Set(x => x.TrangthaiPheduyet, qLVbden.TrangthaiPheduyet)
                                                    .Set(x => x.BcNhanvien, qLVbden.BcNhanvien)
                                                    .Set(x => x.BcTruongphong, qLVbden.BcTruongphong)
                                                    .Set(x => x.BcBgh, qLVbden.BcBgh)
                                                    .Set(x => x.MessageXuly, qLVbden.MessageXuly)
                                                    .Set(x => x.MessageCv, qLVbden.MessageCv)
                                                    .Set(x => x.MessageBaocaonv, qLVbden.MessageBaocaonv)
                                                    .Set(x => x.MessageBaocaotp, qLVbden.MessageBaocaotp)
                                                    .Set(x => x.MessageBaocaobgh, qLVbden.MessageBaocaobgh)
                                                    .Set(x => x.Note, qLVbden.Note)
                                                    .Set(x => x.Save, qLVbden.Save);

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
