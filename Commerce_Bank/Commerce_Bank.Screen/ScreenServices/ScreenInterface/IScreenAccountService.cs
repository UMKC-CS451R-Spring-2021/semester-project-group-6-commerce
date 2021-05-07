using Commerce_Bank.Screen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commerce_Bank.Screen.ScreenServices.ScreenInterface
{
    public interface IScreenAccountService
    {
        Task<LoginUserResponse> LoginUser(LoginModel model);
        Task<IEnumerable<TrasactionDisplayModel>> GetUserBankTransactions(int PersonId);
        Task<decimal> GetUserAccountBalance(int PersonId);
        Task<bool> AddTransaction(TransactionModel transactionModel);
        Task<bool> ForgotPassword(ForgotPasswordModel forgotPasswordDTO);
    }
}
