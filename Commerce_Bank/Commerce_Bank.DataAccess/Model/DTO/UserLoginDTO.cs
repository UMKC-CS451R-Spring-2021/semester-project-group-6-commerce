using System;
using System.Collections.Generic;
using System.Text;

namespace Commerce_Bank.DataAccess.Model.DTO
{
    public class UserLoginDTO
    {
       
        public string Username { get; set; }
        public string AccountNumber { get; set; }
        public string Fullname { get; set; }
        public int PersonId { get; set; }
        public int UserId { get; set; }
    }
}
