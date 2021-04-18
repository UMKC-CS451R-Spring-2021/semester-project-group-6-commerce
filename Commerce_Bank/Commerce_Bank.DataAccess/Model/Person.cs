using System;
using System.Collections.Generic;
using System.Text;

namespace Commerce_Bank.DataAccess.Model
{
    public class Person
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string PhoneNo { get; set; }
        public string AccountNo { get; set; }
        public bool IsActive { get; set; }
        public int Account_TypeId { get; set; }
        public virtual Account_Type Account_Type { get; set; }

    }
}
