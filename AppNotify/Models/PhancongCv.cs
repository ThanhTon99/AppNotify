using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace AppNotify.Models
{
    public class PhancongCv
    {
        public ObjectId Id { get; set; }
        public int IdVbden { get; set; }
        public string TenVbden { get; set; }
        public string MotaVbden { get; set; }
        public string Noiden { get; set; }
        public string TenNhanvien { get; set; }
        //   public string NgayBd { get; set; }
        //   public string NgayKt { get; set;}
        public string Note { get; set; }
        public PhancongCv(PhancongCvRequest rq)
        {
            IdVbden = rq.IdVbden;
            TenVbden = rq.TenVbden;
            MotaVbden = rq.MotaVbden;
            Noiden = rq.Noiden;
            TenNhanvien = rq.TenNhanvien;
            //  NgayBd = rq.NgayBd;
            // NgayKt = rq.NgayKt;
            Note = rq.Note;
        }

    }
    public class PhancongCvRequest
    {
        public string Id { get; set; }
        public int IdVbden { get; set; }
        public string TenVbden { get; set; }
        public string MotaVbden { get; set; }
        public string Noiden { get; set; }
        public string TenNhanvien { get; set; }

        //public string NgayBd { get; set; }
        //public string NgayKt { get; set; }
        public string Note { get; set; }

    }
}
