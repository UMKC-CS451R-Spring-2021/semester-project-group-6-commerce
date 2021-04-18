using Commerce_Bank.DataAccess.Model;
using Commerce_Bank.DataAccess.Model.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Commerce_Bank.DataAccess.Services.Interface
{
    public interface IBankActivityService:IRepositoryService<Bank_Activity>
    {
        Task<bool> BankUserTransaction(TrasactionDTO trasactionDTO);
        Task<IEnumerable<TrasactionDisplayDTO>> GetAccountTransactionBy(int PersonId);
    }
}
