using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppNotify.Models
{
    public class Department
    {
        public  ObjectId Id {get; set;}
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
       
    }
    
    public class DepartmentRequest
    {
        public string Id { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
