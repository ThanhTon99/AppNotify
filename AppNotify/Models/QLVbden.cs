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
        public bool TrangthaiPhancong { get; set; }
        public bool TrangthaiPheduyet { get; set; }
        public bool BcNhanvien { get; set; }
        public bool BcTruongphong { get; set; }
        public bool BcBgh { get; set; }
        public string MessageXuly { get; set; }
        public string MessageCv { get; set; }
        public string MessageBaocaonv { get; set; }
        public string MessageBaocaotp { get; set; }
        public string MessageBaocaobgh { get; set; }
        public string Note { get; set; }
        public bool Save { get; set; }
        public QLVbden(QLVbdenRequest rq)
        {
            IdVbden = rq.IdVbden;
            TenVbden = rq.TenVbden;
            MotaVbden = rq.MotaVbden;
            Noiden = rq.Noiden;
            TenNhanvien = rq.TenNhanvien;
            TrangthaiXuly = rq.TrangthaiXuly;
            TrangthaiPhancong = rq.TrangthaiPhancong;
            TrangthaiPheduyet = rq.TrangthaiPheduyet;
            BcNhanvien = rq.BcNhanvien;
            BcTruongphong = rq.BcTruongphong;
            BcBgh = rq.BcBgh;
            MessageCv = rq.MessageCv;
            MessageXuly = rq.MessageXuly;
            MessageBaocaonv = rq.MessageBaocaonv;
            MessageBaocaotp = rq.MessageBaocaotp; 
            MessageBaocaobgh = rq.MessageBaocaobgh;
            Note = rq.Note;
            Save = rq.Save;
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
        public bool TrangthaiPhancong { get; set; }
        public bool TrangthaiPheduyet { get; set; }

        public bool BcNhanvien { get; set; }
        public bool BcTruongphong { get; set; }
        public bool BcBgh { get; set; }
        public string MessageXuly { get; set; }
        public string MessageCv { get; set; }
        public string MessageBaocaonv { get; set; }
        public string MessageBaocaotp { get; set; }
        public string MessageBaocaobgh { get; set; }
        public string Note { get; set; }
        public bool Save { get; set; }

    }
}
