using Commerce_Bank.DataAccess.Model;
using Commerce_Bank.DataAccess.Model.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Commerce_Bank.DataAccess.Services.Interface
{
    public interface ILastTransactionService:IRepositoryService<Last_Transaction>
    {
        Task<decimal> GetUserCurentAccountBalance(int PersonId);
        Task<IEnumerable<DisplayAccountHolderDetailDTO>> GetAllAccountHolderDetail();
    }
}
