using System;
using System.Collections.Generic;
using System.Text;

namespace Commerce_Bank.DataAccess.Model
{
    public class Bank_Activity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsOpeningBalance { get; set; }
        public bool? IsDeposit { get; set; }
        public decimal TrasactionAmount { get; set; }
        public decimal Balance { get; set; }
        public DateTime TransactionDate { get; set; }
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }

    }
}
