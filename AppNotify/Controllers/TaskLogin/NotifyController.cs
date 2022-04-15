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

namespace AppNotify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotifyController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public NotifyController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        [HttpGet]

        public JsonResult Get()
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("NotifyAppCon"));

            var dbList = dbClient.GetDatabase("Notify").GetCollection<Notify>("NotifyDb").AsQueryable();

            return new JsonResult(dbList);
        }
        [HttpGet]
        [Route("gettruoc")]
        public JsonResult GetData()
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("NotifyAppCon"));

            var dbList = dbClient.GetDatabase("Notify").GetCollection<Notify>("NotifyDb").AsQueryable();

            var List = from list in dbList
                       where list.Activate == true && (list.Display == "tintuc" || list.Display == "thongbao") && list.Login =="truoc"
                       select list;  
            return new JsonResult(List);
        }
        [HttpGet]
        [Route("getsau")]
        public JsonResult GetData1()
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("NotifyAppCon"));

            var dbList = dbClient.GetDatabase("Notify").GetCollection<Notify>("NotifyDb").AsQueryable();

            var List = from list in dbList
                       where list.Activate == true && (list.Display == "tintuc" || list.Display == "thongbao") && list.Login == "sau"
                       select list;
            return new JsonResult(List);
        }
        [HttpGet]
        [Route("getmessage")]
        public JsonResult GetMessage()
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("NotifyAppCon"));

            var dbList = dbClient.GetDatabase("Notify").GetCollection<Notify>("NotifyDb").AsQueryable();

            var List = from list in dbList
                       where list.Activate == true && (list.Display == "thongbao") 
                       select list;
            return new JsonResult(List);
        }
        [HttpGet]
        [Route("getslide")]
        public JsonResult GetImage()
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("NotifyAppCon"));

            var dbList = dbClient.GetDatabase("Notify").GetCollection<Notify>("NotifyDb").AsQueryable();

            var List1 = from list1 in dbList
                        where list1.Activate == true && list1.Display == "slide"
                        select list1;

            return new JsonResult(List1);
        }


        [HttpPost]

        public JsonResult Post(Notify not)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("NotifyAppCon"));

            int LastNotifyId = dbClient.GetDatabase("Notify").GetCollection<Notify>("NotifyDb").AsQueryable().Count();
            not.NotifyId = LastNotifyId + 1;

            dbClient.GetDatabase("Notify").GetCollection<Notify>("NotifyDb").InsertOne(not);

            return new JsonResult("Added Successfully");
        }

        [HttpPut]

        public JsonResult Put(NotifyRequest not)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("NotifyAppCon"));

            var filter = Builders<Notify>.Filter.Eq(x => x.Id, new BsonObjectId(new ObjectId(not.Id)));
            var update = Builders<Notify>.Update.Set(x => x.Title, not.Title)
                                                .Set(x => x.Department, not.Department)
                                                .Set(x => x.Description, not.Description)
                                                .Set(x => x.Content, not.Content)
                                                //.Set(x => x.Link, not.Link)
                                                //.Set(x => x.PhotoFileName, not.PhotoFileName)
                                                //.Set(x => x.files, not.files)
                                                .Set(x => x.Activate, not.Activate)
                                                .Set(x => x.Login, not.Login)
                                                .Set(x => x.Display, not.Display);
            dbClient.GetDatabase("Notify").GetCollection<Notify>("NotifyDb").UpdateOne(filter, update);

            return new JsonResult("Updated Successfully !!!");
        }

        [HttpDelete("{id}")]

        public JsonResult Delete(int id)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("NotifyAppCon"));

            var filter = Builders<Notify>.Filter.Eq("NotifyId", id);

            dbClient.GetDatabase("Notify").GetCollection<Notify>("NotifyDb").DeleteOne(filter);

            return new JsonResult("Deleted Successfully");
        }

        //[Route("SaveFile")]
        //[HttpPost]
        //public  JsonResult SaveFile()
        //{
        //    try
        //    {             
        //        var httpRequest = Request.Form;
        //        var postedFile = httpRequest.Files[0];
        //        string filename = postedFile.FileName;
        //        var physicalPath = _env.ContentRootPath + "/Photos/" + filename;

        //        using(var stream = new FileStream(physicalPath, FileMode.Create))
        //        {
        //            return new JsonResult(filename);
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return new JsonResult("Something Wrong");
        //    }
        //}

        //[HttpPost]
        //[Route("upload")]

        //public string PostImage([FromForm] Notify objectFile)
        //{
        //    try
        //    {
        //        if (objectFile.files.Length > 0)
        //        {
        //            string path = _env.ContentRootPath + "/Photos/";

        //            if (!Directory.Exists(path))
        //            {
        //                Directory.CreateDirectory(path);
        //            }
        //            using (FileStream fileStream = System.IO.File.Create(path + objectFile.files.FileName))
        //            {
        //                objectFile.files.CopyTo(fileStream);
        //                fileStream.Flush();
        //                return "Uploaded";
        //            }
        //        }
        //        else
        //        {
        //            return "Not Uploaded";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message;
        //    }
        //}
    }
}

