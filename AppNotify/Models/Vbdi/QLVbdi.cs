using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace AppNotify.Models.Vbdi
{
    public class QLVbdi
    {
        public ObjectId Id { get; set; }
        public int IdVbdi { get; set; }
        public string TenVbdi { get; set; }
        public string MotaVbdi { get; set; }
        public string Noidi { get; set; }

        public QLVbdi(QlVbdiRequest rq)
        {
            IdVbdi = rq.IdVbdi;
            TenVbdi = rq.TenVbdi;
            MotaVbdi = rq.MotaVbdi;
            Noidi = rq.Noidi;
        }
    }
    public class QlVbdiRequest
    {
        public string Id { get; set; }
        public int IdVbdi { get; set; }
        public string TenVbdi { get; set; }
        public string MotaVbdi { get; set; }
        public string Noidi { get; set; }
    }
}
