using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppNotify.Models
{
    public class Userteam
    {
        public ObjectId Id { get; set; }
        public int UserteamId { get; set; }
        public string UserteamName { get; set; }
        public string Permission { get; set; }
        public Userteam(UserteamRequest rq)
        {
            UserteamId = rq.UserteamId;
            UserteamName = rq.UserteamName;
            Permission = rq.Permission;
         
        }
    }
    public class UserteamRequest
    {
        public string Id { get; set; }
        public int UserteamId { get; set; }
        public string UserteamName { get; set; }
        public string Permission { get; set; }

    }
}
