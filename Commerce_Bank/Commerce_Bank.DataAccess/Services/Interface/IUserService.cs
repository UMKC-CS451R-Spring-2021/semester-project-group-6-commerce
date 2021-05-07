using Commerce_Bank.DataAccess.Model;
using Commerce_Bank.DataAccess.Model.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Commerce_Bank.DataAccess.Services.Interface
{
    //the IUserService is inheriting the interfaces found on the IRepositoryService. Meaning that every service found on IrepositoryServicce
    //can as well be accessed from the IUserService
    public interface IUserService:IRepositoryService<User>
    {
        Task<IEnumerable<User>> GetAll();
        Task<IEnumerable<User>> GetUsersByBalance(decimal accountBalance);
        Task<User> GetUsersByAccountNo(string AccountNo);
        Task<User> GetUserBy(string username, string pasword);
        Task<bool> ForgotPassword(ForgotPasswordDTO forgotPasswordDTO);
    }
}
