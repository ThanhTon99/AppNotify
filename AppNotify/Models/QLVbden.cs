using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace AppNotify.Models
{
    public class QLVbden
    {
        public ObjectId Id { get; set; }
        public int IdVbden { get; set; }
        public string TenVbden { get; set; }
        public string MotaVbden { get; set; }
        public string Noiden { get; set; }
        public string TenNhanvien { get; set; }
        public bool TrangthaiXuly { get; set; }
        public QLVbden(QLVbdenRequest rq)
        {
            IdVbden = rq.IdVbden;
            TenVbden = rq.TenVbden;
            MotaVbden = rq.MotaVbden;
            Noiden = rq.Noiden;
            TenNhanvien = rq.TenNhanvien;
            TrangthaiXuly = rq.TrangthaiXuly;
        }
    }
    public class QLVbdenRequest
    {
        public string Id { get; set; }
        public int IdVbden { get; set; }
        public string TenVbden { get; set; }
        public string MotaVbden { get; set; }
        public string Noiden { get; set; }
        public string TenNhanvien { get; set; }
        public bool TrangthaiXuly { get; set; }

    }
}
