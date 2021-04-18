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
        Task<UserLoginDTO> Login(string username, string password);
        Task<bool> BankUserTransaction(TrasactionDTO trasactionDTO);
        Task<IEnumerable<TrasactionDisplayDTO>> GetAccountTransactionBy(int PersonId);
        Task<decimal> GetUserCurentAccountBalance(int PersonId);
        Task<IEnumerable<DisplayAccountHolderDetailDTO>> GetAllAccountHolderDetail();
    }
}
