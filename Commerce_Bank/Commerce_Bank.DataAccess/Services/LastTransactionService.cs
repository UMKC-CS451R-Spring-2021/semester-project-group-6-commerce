using Commerce_Bank.DataAccess.Model;
using Commerce_Bank.DataAccess.Model.DTO;
using Commerce_Bank.DataAccess.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce_Bank.DataAccess.Services
{

    public class LastTransactionService : RepositoryService<Last_Transaction>, ILastTransactionService
    {
        public LastTransactionService(CommerceBankAppContext context)
           : base(context)
        {


        }

        public async Task<IEnumerable<DisplayAccountHolderDetailDTO>> GetAllAccountHolderDetail()
        {
            return await _context.LAST_TRANSACTION
                .Include(f=>f.Person)
                .ThenInclude(f=>f.Account_Type)
                .Select(f => new DisplayAccountHolderDetailDTO
                {
                    FullName = $"{f.Person.Firstname} {f.Person.Lastname}",
                    AccountNo = f.Person.AccountNo,
                    AccountType = f.Person.Account_Type.Name,
                    Balance = f.Balance,
                    PersonId = f.PersonId
                }).ToListAsync();
        }

        public async Task<decimal> GetUserCurentAccountBalance(int PersonId)
        {
            return await _context.LAST_TRANSACTION.Where(f => f.PersonId == PersonId).Select(f=>f.Balance).FirstOrDefaultAsync();
        }
    }
}
