using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace AppNotify.Models
{
    public class QLLoaivb
    {
        public ObjectId Id { get; set; }
        public int IdLoaivb { get; set; }
        public string TenLoaivb { get; set; }
        public string MotaLoaivb { get; set; }
    }
    public class QLLoaivbRequest
    {
        public string Id { get; set; }
        public int IdLoaivb { get; set; }
        public string TenLoaivb { get; set; }
        public string MotaLoaivb { get; set; }
    }
}
