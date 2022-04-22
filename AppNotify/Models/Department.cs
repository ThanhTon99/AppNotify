using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppNotify.Models
{
    public class Department
    {
        public  ObjectId Id {get; set;}
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Roles { get; set; }
        public string TenNguoidung { get; set; }
        public string Chucvu { get; set; }
        public string Phongban { get; set; }

        public Department(DepartmentRequest rq)
        {
            UserId = rq.UserId;
            Username = rq.Username;
            Password = rq.Password;
            Roles = rq.Roles;
            TenNguoidung = rq.TenNguoidung;
            Chucvu = rq.Chucvu;
            Phongban = rq.Phongban;
        }
    }
    
    public class DepartmentRequest
    {
        public string Id { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Roles { get; set; }
        public string TenNguoidung { get; set; }
        public string Chucvu { get; set; }
        public string Phongban { get; set; }


    }
}
