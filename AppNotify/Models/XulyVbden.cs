using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace AppNotify.Models
{
    public class XulyVbden
    {
        public ObjectId Id { get; set; }
        public int IdVbden { get; set; }
        public string TenVbden { get; set; }
        public string MotaVbden { get; set; }
        public string Noiden { get; set; }
        public XulyVbden(XulyVbdenRequest rq)
        {
            IdVbden = rq.IdVbden;
            TenVbden = rq.TenVbden;
            MotaVbden = rq.MotaVbden;
            Noiden = rq.Noiden;
        }
    }
    public class XulyVbdenRequest
    {
        public string Id { get; set; }
        public int IdVbden { get; set; }
        public string TenVbden { get; set; }
        public string MotaVbden { get; set; }
        public string Noiden { get; set; }
    }
}
