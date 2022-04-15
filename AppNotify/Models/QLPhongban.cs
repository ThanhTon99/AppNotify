using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace AppNotify.Models
{
    public class QLPhongban 
    {
        public ObjectId Id { get; set; }
        public int IdPhongban { get; set; }
        public string TenPhongban { get; set; }
        public string MotaPhongban { get; set; }
        public string IdChucvu { get; set; }
        public string TenChucvu { get; set; }
        public QLPhongban(QLPhongbanRequest rq)
        {
            IdPhongban = rq.IdPhongban;
            TenPhongban = rq.TenPhongban;
            MotaPhongban = rq.MotaPhongban;
            IdChucvu = rq.IdChucvu;
            TenChucvu = rq.TenChucvu;
        }
    }
    public class QLPhongbanRequest
    {
        public string Id { get; set; }
        public int IdPhongban { get; set; }
        public string TenPhongban { get; set; }
        public string MotaPhongban { get; set; }
        public string IdChucvu { get; set; }
        public string TenChucvu { get; set; }

    }

}
