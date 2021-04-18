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

    public class BankActivityService : RepositoryService<Bank_Activity>, IBankActivityService
    {
        private readonly ILastTransactionService _lastTransactionService;
        public BankActivityService(CommerceBankAppContext context,ILastTransactionService lastTransactionService)
           : base(context)
        {
            _lastTransactionService = lastTransactionService;
        }

        public async Task<bool> BankUserTransaction(TrasactionDTO trasactionDTO)
        {
            if(trasactionDTO!=null && trasactionDTO.PersonId>0 && trasactionDTO.TransactionAmount > 0)
            {
                //var recentBankTransaction=await GetAccountStatus(trasactionDTO.PersonId);
                var lastTransaction=await _lastTransactionService.GetBy(f => f.PersonId == trasactionDTO.PersonId);
                if (lastTransaction != null)
                {
                    if(lastTransaction.Balance<trasactionDTO.TransactionAmount && trasactionDTO.TransactionType == false)
                    {
                        throw new Exception("Insufficient account balance");
                    }

                    Bank_Activity bank_Activity = new Bank_Activity();
                    //if the trasaction type is true(credit transaction) then we substract the transaction amount from the previous balance, else we sum the trasaction amount with the previous balance
                    bank_Activity.Balance = trasactionDTO.TransactionType ? (bank_Activity.Balance + trasactionDTO.TransactionAmount) : (bank_Activity.Balance - trasactionDTO.TransactionAmount);
                    bank_Activity.Description = trasactionDTO.Description;
                    bank_Activity.IsDeposit = trasactionDTO.TransactionType ? true : false;
                    bank_Activity.IsOpeningBalance = false;
                    bank_Activity.PersonId = trasactionDTO.PersonId;
                    bank_Activity.TrasactionAmount = trasactionDTO.TransactionAmount;
                    bank_Activity.TransactionDate = DateTime.Now;
                    var iscreated=await Save(bank_Activity);
                    if (iscreated > 0)
                    {
                        lastTransaction.Balance = bank_Activity.Balance;
                        lastTransaction.DateCreated = DateTime.Now;
                        await _lastTransactionService.Update(lastTransaction);
                        return true;
                    }

                        
                    
                }
                
            }
            return false;
        }
        public async Task<Bank_Activity> GetAccountStatus(int personId)
        {
            return await _context.BANK_ACTIVITY.Where(f => f.PersonId == personId).LastOrDefaultAsync();
        }

        public async Task<IEnumerable<TrasactionDisplayDTO>> GetAccountTransactionBy(int PersonId)
        {
            return await _context.BANK_ACTIVITY.Where(f => f.PersonId == PersonId)
                .Select(f=> new TrasactionDisplayDTO
                {
                    Fullname=$"{f.Person.Firstname} {f.Person.Lastname}",
                    AccountNo=f.Person.AccountNo,
                    TrasactionAmount=f.TrasactionAmount,
                    TrasactionType=(f.IsDeposit==true || f.IsDeposit==null )?"CR":"DR",
                    Date=f.TransactionDate.Date.ToString("d"),
                    Description=f.Description
                })
                .ToListAsync();
        }

     
    }
}
