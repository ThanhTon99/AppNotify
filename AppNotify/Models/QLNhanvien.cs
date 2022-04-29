using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace AppNotify.Models
{
    public class QLNhanvien 
    {   
        public ObjectId Id { get; set; }
        public int IdNhanvien { get; set; }
        public string TenNhanvien { get; set; }
        public string Sodienthoai { get; set; }
        public string Diachi { get; set; }
        public string TenChucvu { get; set; }
        public QLNhanvien(QLNhanvienRequest rq)
        {
            IdNhanvien = rq.IdNhanvien;
            TenNhanvien = rq.TenNhanvien;
            Sodienthoai = rq.Sodienthoai;
            Diachi = rq.Diachi;
            TenChucvu = rq.TenChucvu;
        }

    }
    public class QLNhanvienRequest
    {
        public string Id { get; set; }
        public int IdNhanvien { get; set; }
        public string TenNhanvien { get; set; }
        public string Sodienthoai { get; set; }
        public string Diachi { get; set; }
        public string TenChucvu { get; set; }

    }
}
