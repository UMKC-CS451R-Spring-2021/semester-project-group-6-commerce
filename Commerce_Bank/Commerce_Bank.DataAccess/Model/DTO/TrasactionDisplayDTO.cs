using System;
using System.Collections.Generic;
using System.Text;

namespace Commerce_Bank.DataAccess.Model.DTO
{
    public class TrasactionDisplayDTO
    {
        public string Fullname { get; set; }
        public string AccountNo { get; set; }
        public string TrasactionType { get; set; }
        public decimal TrasactionAmount { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }

    }
}
