using Commerce_Bank.DataAccess.Model.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Commerce_Bank.DataAccess.Services.Interface
{
    public interface IAccountService
    {
        Task<bool> CreateBankUsers(BankUserDTO bankUserDTO);
    }
}
