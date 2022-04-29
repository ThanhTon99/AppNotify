using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace AppNotify.Models
{
    public class QLNoiden
    {

        public ObjectId Id { get; set; }
        public int IdNoiden { get; set; }
        public string TenNoiden { get; set; }
        public string MotaNoiden { get; set; }
    }
    public class QLNoidenRequest
    {
        public string Id { get; set; }
        public int IdNoiden { get; set; }
        public string TenNoiden { get; set; }
        public string MotaNoiden { get; set; }
    }
}

