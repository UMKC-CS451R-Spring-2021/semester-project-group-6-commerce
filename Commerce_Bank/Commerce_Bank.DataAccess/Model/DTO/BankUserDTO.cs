using System;
using System.Collections.Generic;
using System.Text;

namespace Commerce_Bank.DataAccess.Model.DTO
{
    public class BankUserDTO
    { 
        public string UserName { get; set; }
        public string Password { get; set; }
        public string AccountNo { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Account_Type_Id { get; set; }
        public decimal InitialDeposit { get; set; }
    }
}
