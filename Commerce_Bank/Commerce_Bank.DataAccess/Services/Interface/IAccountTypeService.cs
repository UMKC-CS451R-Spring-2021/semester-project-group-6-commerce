using Commerce_Bank.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Commerce_Bank.DataAccess.Services.Interface
{
    public interface IAccountTypeService:IRepositoryService<Account_Type>
    {
        Task<IEnumerable<Account_Type>> GetAll();
        Task<Account_Type> GetById(int id);
        Task<bool> AddAccountType(string name);
    }
}
