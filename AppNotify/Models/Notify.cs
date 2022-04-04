using Microsoft.AspNetCore.Http;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppNotify.Models
{
    public class Notify
    {
        public ObjectId Id { get; set; }
        public int NotifyId { get; set; }
        public string Department { get; set; }
        public string Title { get; set; }
        public string Description { get; set;}
        public string Content { get; set; }
        public string Link { get; set; }
        public string PhotoFileName { get; set; }
        public IFormFile files { get; set; }
        public bool Activate { get; set; }
        public string Login { get;set; }
        public string Display { get; set; }
    }
    public class NotifyRequest
    {
        public string Id { get; set; }
        public int NotifyId { get; set; }   
        public string Department { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string Link { get; set; }
        public string PhotoFileName { get; set; }
        public IFormFile files { get; set; }
        public bool Activate { get; set; }
        public string Login { get; set; }
        public string Display { get; set; }
    }
}
