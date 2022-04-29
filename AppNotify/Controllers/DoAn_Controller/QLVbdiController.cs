using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppNotify.Models;
using AppNotify.Models.Vbdi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AppNotify.Controllers.DoAn_Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class QLVbdiController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public QLVbdiController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public JsonResult Get()
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("NotifyAppCon"));

            var dbList = dbClient.GetDatabase("Document").GetCollection<QLVbdi>("QLVbdi").AsQueryable();
            //var List = from list in dbList
            //           where list.Save == false
            //           select list;
            return new JsonResult(dbList);
        }
    }
}
