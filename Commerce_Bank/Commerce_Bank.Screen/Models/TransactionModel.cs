using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commerce_Bank.Screen.Models
{
    public class TransactionModel
    {
        public bool TransactionType { get; set; }
        public decimal TransactionAmount { get; set; }
        public string Description { get; set; }
        public int PersonId { get; set; }
    }
}
