using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace AppNotify.Models
{
    public class QLChucvu
    {
        public ObjectId Id { get; set; }
        public int IdChucvu { get; set; }
        public string TenChucvu { get; set; }
        public string MotaChucvu { get; set; }
    }
    public class QLChucvuRequest
    {
        public string Id { get; set; }
        public int IdChucvu { get; set; }
        public string TenChucvu { get; set; }
        public string MotaChucvu { get; set; }
    }
}
