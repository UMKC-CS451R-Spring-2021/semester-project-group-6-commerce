using Commerce_Bank.DataAccess.Model;
using Commerce_Bank.DataAccess.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce_Bank.DataAccess.Services
{
  
    public class AccountTypeService : RepositoryService<Account_Type>, IAccountTypeService
    {
        public AccountTypeService(CommerceBankAppContext context)
           : base(context)
        {

        }

        public async Task<bool> AddAccountType(string name)
        {
            Account_Type account_Type = new Account_Type()
            {
                IsActive = true,
                Name = name
            };
            _context.Add(account_Type);
            var created=await _context.SaveChangesAsync();
            if (created > 0)
                return true;
            return false;

        }

        public async Task<IEnumerable<Account_Type>> GetAll()
        {
            return await _context.ACCOUNT_TYPE.ToListAsync();
        }

        public async Task<Account_Type> GetById(int id)
        {
           return  await _context.ACCOUNT_TYPE.Where(f => f.Id == id).FirstOrDefaultAsync();
        }
    }
}
