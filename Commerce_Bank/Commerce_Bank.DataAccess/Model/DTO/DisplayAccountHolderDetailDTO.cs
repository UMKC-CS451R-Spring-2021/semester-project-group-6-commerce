using System;
using System.Collections.Generic;
using System.Text;

namespace Commerce_Bank.DataAccess.Model.DTO
{
    public class DisplayAccountHolderDetailDTO
    {
        public string FullName { get; set; }
        public string AccountNo { get; set; }
        public decimal Balance { get; set; }
        public string AccountType { get; set; }
        public int PersonId { get; set; } 
    }
}
