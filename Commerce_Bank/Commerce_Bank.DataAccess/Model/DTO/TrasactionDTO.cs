using System;
using System.Collections.Generic;
using System.Text;

namespace Commerce_Bank.DataAccess.Model.DTO
{
    public class TrasactionDTO
    {
        public bool TransactionType { get; set; }
        public decimal TransactionAmount { get; set; }
        public string Description { get; set; }
        public int PersonId { get; set; }
        

    }
}
