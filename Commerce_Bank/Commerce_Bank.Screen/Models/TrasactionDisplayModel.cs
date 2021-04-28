using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commerce_Bank.Screen.Models
{
    public class TrasactionDisplayModel
    {
        public string Fullname { get; set; }
        public string AccountNo { get; set; }
        public string TrasactionType { get; set; }
        public decimal TrasactionAmount { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
    }
}
