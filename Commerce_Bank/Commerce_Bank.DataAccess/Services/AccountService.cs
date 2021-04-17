using Commerce_Bank.DataAccess.Model;
using Commerce_Bank.DataAccess.Model.DTO;
using Commerce_Bank.DataAccess.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Commerce_Bank.DataAccess.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserService _userService;
        private readonly IPersonService _personService;
        private readonly IBankActivityService _bankActivityService;
        //contructor injection(Dependency injection)
        public AccountService(IUserService userService, IPersonService personService,IBankActivityService bankActivityService)
        {
            _userService = userService;
            _personService = personService;
            _bankActivityService = bankActivityService;
        }
        public async Task<bool> CreateBankUsers(BankUserDTO bankUserDTO)
        {
            //User user
            Person person = new Person()
            {
                //mapping user entered field to the database table
                AccountNo = bankUserDTO.AccountNo,
                Account_TypId = bankUserDTO.Account_Type_Id,
                Firstname = bankUserDTO.FirstName,
                Lastname = bankUserDTO.LastName,
                IsActive = true,
                PhoneNo = bankUserDTO.PhoneNo
            };
            var personCreated=await _personService.Save(person);
            if (personCreated > 0)
            {
                User user = new User()
                {
                    Password = bankUserDTO.Password,
                    PersonId = person.Id,
                    Username = bankUserDTO.UserName
                };
                var userCreated = await _userService.Save(user);
                if (userCreated > 0)
                {
                    Bank_Activity bank_Activity = new Bank_Activity()
                    {
                        Balance = bankUserDTO.InitialDeposit,
                        Description = "Opening account deposit",
                        IsDeposit = true,
                        IsOpeningBalance = true,
                        PersonId = person.Id,
                        TrasactionAmount = bankUserDTO.InitialDeposit
                    };
                    var created = await _bankActivityService.Save(bank_Activity);
                    if(created>0)
                    return true;
                }
                
            }
            return false;
            
        }
    }
}
