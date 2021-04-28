using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commerce_Bank.Screen.Models
{
    public class LoginUserResponse
    {
        public string Username { get; set; }//username
        public string AccountNumber { get; set; }
        public string Fullname { get; set; }
        public int PersonId { get; set; }
        public int UserId { get; set; }
    }
}
