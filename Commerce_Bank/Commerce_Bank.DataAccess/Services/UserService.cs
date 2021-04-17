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
    //this is the concrete implementation of the related interface (IUserService).
    //In a lay man term The concrete class is the workshop of the interface
    public class UserService:RepositoryService<User>,IUserService
    {
        public UserService(CommerceBankAppContext context)
           : base(context)
        {
           
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.USER.ToListAsync();
        }

        public async Task<User> GetUsersByAccountNo(string AccountNo)
        {
            return await _context.USER
                .Include(f=>f.Person)
                .Where(f => f.Person.AccountNo == AccountNo).FirstOrDefaultAsync();
        }

        public Task<IEnumerable<User>> GetUsersByBalance(decimal accountBalance)
        {
            throw new NotImplementedException();
        }
    }
}
