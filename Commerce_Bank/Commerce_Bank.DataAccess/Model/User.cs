using System;
using System.Collections.Generic;
using System.Text;

namespace Commerce_Bank.DataAccess.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
}
