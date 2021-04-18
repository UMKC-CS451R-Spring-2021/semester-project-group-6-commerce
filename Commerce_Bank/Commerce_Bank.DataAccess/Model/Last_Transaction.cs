using System;
using System.Collections.Generic;
using System.Text;

namespace Commerce_Bank.DataAccess.Model
{
    public class Last_Transaction
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public decimal Balance { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual Person Person { get; set; }
    }
}
