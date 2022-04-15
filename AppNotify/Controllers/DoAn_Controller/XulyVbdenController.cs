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
    public class XulyVbdenController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public XulyVbdenController(IConfiguration configuration)
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
    }
}
