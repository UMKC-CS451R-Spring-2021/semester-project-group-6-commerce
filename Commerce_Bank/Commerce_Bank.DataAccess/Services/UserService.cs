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
    //this is the concrete implementation of the related interface (IUserService).
    //In a lay man term The concrete class is the workshop of the interface
    public class UserService:RepositoryService<User>,IUserService
    {
        //context exposes the database object to the application
        public UserService(CommerceBankAppContext context)
           : base(context)
        {
           
        }

        public async Task<bool> ForgotPassword(ForgotPasswordDTO forgotPasswordDTO)
        {
            if(forgotPasswordDTO?.Username!=null && forgotPasswordDTO?.NewPassword != null)
            {
                var user = await GetBy(f => f.Username == forgotPasswordDTO.Username);
                if (user?.Id > 0)
                {
                    user.Password = forgotPasswordDTO.NewPassword;
                    var isUpdated = await Update(user);
                    if (isUpdated > 0)
                        return true;
                }
            }
            
            return false;

        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.USER.ToListAsync();//go to the USER table get me all the user records there
        }

        public async Task<User> GetUserBy(string username, string pasword)
        {
            return await _context.USER
                .Include(f=>f.Person)
                .Where(f => f.Username == username && f.Password == pasword).FirstOrDefaultAsync();
            //go to the user table get me the first user with username=supplied username and password=supplied password
        }

        public async Task<User> GetUsersByAccountNo(string AccountNo)
        {
            return await _context.USER
                .Include(f=>f.Person)
                .Where(f => f.Person.AccountNo == AccountNo).FirstOrDefaultAsync();
            //go to user table get me the user with accountno=supplied account no
        }

        public Task<IEnumerable<User>> GetUsersByBalance(decimal accountBalance)
        {
            throw new NotImplementedException();
        }
    }
}
